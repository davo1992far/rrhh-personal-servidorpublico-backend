using System;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using minedu.rrhh.negocio.comunes.rabbitmq.lib;
using minedu.rrhh.negocio.comunes.rabbitmq.lib.ReplicaRegistro;
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
    public class RabbitConsumerPropagarServidorPublicoHostedService : AyniConsumerHostedService
    {
        private readonly IRabbitManagerPublisher rabbitReplica;

        public RabbitConsumerPropagarServidorPublicoHostedService(IConfiguration configuration, IRabbitManagerConsumer rabbit,
            IRabbitManagerPublisher rabbitReplica) :
            base(configuration, rabbit, TipoConsumidor.PropagacionEnTransacciones,
                Constante.RABBIT_EXCHANGE_PROPAGAR_CREARSERVIDORPUBLICO, Constante.RABBIT_QUEUE_PROPAGAR_CREARSERVIDORPUBLICO)
        {
            this.rabbitReplica = rabbitReplica;
            this.config = configuration;
        }

        protected override AcuseDeRecibo ConsumirMensaje(string contentJson)
        {
            if (string.IsNullOrEmpty(contentJson))
                return AcuseDeRecibo.NoRecibidoNoReencolar;
            try
            {
                TransaccionPropagar<ServidorPublico> servidorPublico = JsonSerializer.Deserialize<TransaccionPropagar<ServidorPublico>>(contentJson);
                IServidorPublicoService service = new ServidorPublicoService(config.GetConnectionString("DefaultConnection"));

                if (servidorPublico == null) return AcuseDeRecibo.Recibido;
                ServidorPublicoReplica s = service.GetServidorPublicoReplicaPorCodigo(servidorPublico.entidad.codigoServidorPublico, true).Result;

                //se envía el mensaje de replica
                rabbitReplica.PublicarMensajeReplicaRegistro(s, Constante.RABBIT_EXCHANGE_SERVIDORPUBLICO, Constante.NOMBRE_SISTEMA, "ServidorPublico", servidorPublico.tipoEvento);

                return AcuseDeRecibo.Recibido;
            }
            catch (OperationInterruptedException ex)
            {
                ReconfigurarConexionConsumidor();
                Log.Error($"Error al procesar el mensaje recibido {this.GetType().Name}. Mensaje: {ex.Message}");
                return AcuseDeRecibo.NoRecibidoNoReencolar;
            }
            catch (Exception ex)
            {
                Log.Error($"Error al procesar el mensaje recibido {this.GetType().Name}. Mensaje: {ex.Message}");
                return AcuseDeRecibo.NoRecibidoNoReencolar;
            }
        }
    }
}
