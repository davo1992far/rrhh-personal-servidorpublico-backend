using System;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using minedu.rrhh.negocio.comunes.rabbitmq.lib;
using minedu.rrhh.negocio.comunes.rabbitmq.lib.ReplicaRegistro;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.rrhh.personal.servidorpublico.service.imp;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.messaging.rabbitmq.lib;
using RabbitMQ.Client.Exceptions;
using Serilog;

namespace minedu.rrhh.personal.servidorpublico.backend.Rabbit
{
    public class RabbitConsumerEspecialidadProfesionalHostedService : AyniConsumerHostedService
    {
        public RabbitConsumerEspecialidadProfesionalHostedService(IConfiguration configuration, IRabbitManagerConsumer rabbit) :
            base(configuration, rabbit, TipoConsumidor.ReplicaRegistro,
                Constante.RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_ESPECIALIDAD_PROFESIONAL, Constante.RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_ESPECIALIDAD_PROFESIONAL)
        {
        }

        protected override AcuseDeRecibo ConsumirMensaje(string contentJson)
        {
            if (string.IsNullOrEmpty(contentJson))
                return AcuseDeRecibo.NoRecibidoNoReencolar;
            try
            {
                int resultado = 0;
                AcuseDeRecibo acuse = AcuseDeRecibo.NoRecibidoNoReencolar;
                var request = JsonSerializer.Deserialize<MensajeReplicaRegistro<EspecialidadProfesionalReplica>>(contentJson);
                IEspecialidadProfesionalService service = new EspecialidadProfesionalService(config.GetConnectionString("DefaultConnection"));
                resultado = request.operacion switch
                {
                    TipoEventoReplicaRegistro.CREACION => service.Crear(request.entidad).Result,
                    TipoEventoReplicaRegistro.ACTUALIZACION => service.Actualizar(request.entidad).Result,
                    TipoEventoReplicaRegistro.ELIMINACION => service.Eliminar(request.entidad).Result,
                    _ => resultado
                };
                if (resultado > 0)
                    acuse = AcuseDeRecibo.Recibido;
                return acuse;
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