using System;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using minedu.rrhh.negocio.comunes.rabbitmq.lib;
using minedu.rrhh.negocio.comunes.rabbitmq.lib.Transaccion;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.service.imp;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.messaging.rabbitmq.lib;
using RabbitMQ.Client.Exceptions;
using Serilog;

namespace minedu.rrhh.personal.servidorpublico.backend.Rabbit
{
    public class RabbitConsumerCrearServidorPublicoRequestHostedService : AyniConsumerHostedService
    {
        private readonly IRabbitManagerPublisher rabbitTransaccion;

        public RabbitConsumerCrearServidorPublicoRequestHostedService(IConfiguration configuration, IRabbitManagerConsumer rabbitConsumer,
            IRabbitManagerPublisher rabbitTransaccion) :
            base(configuration, rabbitConsumer, TipoConsumidor.RequestEnTransacciones,
                Constante.RABBIT_EXCHANGE_REQUEST_CREARSERVIDORPUBLICO, Constante.RABBIT_QUEUE_REQUEST_CREARSERVIDORPUBLICO)
        {
            this.rabbitTransaccion = rabbitTransaccion;
        }

        protected override AcuseDeRecibo ConsumirMensaje(string contentJson)
        {
            if (string.IsNullOrEmpty(contentJson))
                return AcuseDeRecibo.NoRecibidoNoReencolar;
            TransaccionRequest<ServidorPublicoTransaccionRequest> request = null;
            try
            {
                request = JsonSerializer.Deserialize<TransaccionRequest<ServidorPublicoTransaccionRequest>>(contentJson);
                var servidorPublico = request.entidad;
                if (request.nombreSolicitante != Constante.NOMBRE_SISTEMA_RESOLUCION)
                {
                    rabbitTransaccion.PublicarMensajeTransaccionResponse(Constante.RABBIT_EXCHANGE_RESPONSE_CREARSERVIDORPUBLICO, false,
                        new
                        {
                            codigoResolucion = servidorPublico.codigoResolucion,
                            codigoServidorPublico = servidorPublico.codigoServidorPublico,
                            codigoTipoDocumentoIdentidad = servidorPublico.codigoTipoDocumentoIdentidad,
                            numeroDocumentoIdentidad = servidorPublico.numeroDocumentoIdentidad
                        },
                        request.nombreSolicitante,
                        "No se pudo registrar el servidor público",
                        "Nombre del sistema no coincide con el origen de la transacción");
                    return AcuseDeRecibo.NoRecibidoNoReencolar;
                }

                IServidorPublicoService service = new ServidorPublicoService(config.GetConnectionString("DefaultConnection"));
                servidorPublico = service.CrearServidorPublicoTransaccion(servidorPublico).Result;
                rabbitTransaccion.PublicarMensajeTransaccionResponse(Constante.RABBIT_EXCHANGE_RESPONSE_CREARSERVIDORPUBLICO, true,
                    new
                    {
                        codigoResolucion = servidorPublico.codigoResolucion,
                        codigoServidorPublico = servidorPublico.codigoServidorPublico,
                        codigoTipoDocumentoIdentidad = servidorPublico.codigoTipoDocumentoIdentidad,
                        numeroDocumentoIdentidad = servidorPublico.numeroDocumentoIdentidad
                    }, request.nombreSolicitante);
                return AcuseDeRecibo.Recibido;
            }
            catch (OperationInterruptedException ex)
            {
                ReconfigurarConexionConsumidor();
                var servidorPublico = request.entidad;
                rabbitTransaccion.PublicarMensajeTransaccionResponse(Constante.RABBIT_EXCHANGE_RESPONSE_CREARSERVIDORPUBLICO, false,
                    new
                    {
                        codigoResolucion = servidorPublico.codigoResolucion,
                        codigoServidorPublico = servidorPublico.codigoServidorPublico,
                        codigoTipoDocumentoIdentidad = servidorPublico.codigoTipoDocumentoIdentidad,
                        numeroDocumentoIdentidad = servidorPublico.numeroDocumentoIdentidad
                    },
                    request.nombreSolicitante,
                    "No se pudo registrar el servidor público",
                    ex.Message);
                Log.Error($"Error al procesar el mensaje recibido {this.GetType().Name}. Mensaje: {ex.Message}");
                return AcuseDeRecibo.NoRecibidoNoReencolar;
            }
            catch (Exception ex)
            {
                var servidorPublico = request.entidad;
                rabbitTransaccion.PublicarMensajeTransaccionResponse(Constante.RABBIT_EXCHANGE_RESPONSE_CREARSERVIDORPUBLICO, false,
                    new
                    {
                        codigoResolucion = servidorPublico.codigoResolucion,
                        codigoServidorPublico = servidorPublico.codigoServidorPublico,
                        codigoTipoDocumentoIdentidad = servidorPublico.codigoTipoDocumentoIdentidad,
                        numeroDocumentoIdentidad = servidorPublico.numeroDocumentoIdentidad
                    },
                    request.nombreSolicitante,
                    "No se pudo registrar el servidor público",
                    ex.Message);
                Log.Error($"Error al procesar el mensaje recibido {this.GetType().Name}. Mensaje: {ex.Message}");
                return AcuseDeRecibo.NoRecibidoNoReencolar;
            }
        }
    }
}