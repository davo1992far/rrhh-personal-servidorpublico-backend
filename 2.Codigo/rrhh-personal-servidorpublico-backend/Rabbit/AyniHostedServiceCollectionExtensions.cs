using Microsoft.Extensions.DependencyInjection;

namespace minedu.rrhh.personal.servidorpublico.backend.Rabbit
{
    public static class AyniHostedServiceCollectionExtensions
    {
        public static void AddAyniHostedService(this IServiceCollection services)
        {
            services.AddHostedService<RabbitConsumerAfpHostedService>();
            services.AddHostedService<RabbitConsumerCargoHostedService>();
            services.AddHostedService<RabbitConsumerCarreraProfesionalHostedService>();
            services.AddHostedService<RabbitConsumerCatalogoHostedService>();
            services.AddHostedService<RabbitConsumerCatalogoItemHostedService>();
            services.AddHostedService<RabbitConsumerCategoriaRemunerativaHostedService>();
            services.AddHostedService<RabbitConsumerCentroEstudioHostedService>();
            services.AddHostedService<RabbitConsumerCentroTrabajoHostedService>();
            services.AddHostedService<RabbitConsumerCrearServidorPublicoRequestHostedService>();
            services.AddHostedService<RabbitConsumerDepartamentoHostedService>();
            services.AddHostedService<RabbitConsumerDistritoHostedService>();
            services.AddHostedService<RabbitConsumerDreHostedService>();
            services.AddHostedService<RabbitConsumerEspecialidadProfesionalHostedService>();
            services.AddHostedService<RabbitConsumerFormacionAcademicaHostedService>();
            services.AddHostedService<RabbitConsumerGradoInstruccionHostedService>();
            services.AddHostedService<RabbitConsumerInstitucionEducativaHostedService>();
            services.AddHostedService<RabbitConsumerJornadaLaboralHostedService>();
            services.AddHostedService<RabbitConsumerModalidadEducativaHostedService>();
            services.AddHostedService<RabbitConsumerNivelEducativoHostedService>();
            services.AddHostedService<RabbitConsumerOtraInstanciaHostedService>();
            services.AddHostedService<RabbitConsumerPaisHostedService>();
            services.AddHostedService<RabbitConsumerPersonaHostedService>();
            services.AddHostedService<RabbitConsumerPropagarServidorPublicoHostedService>();
            services.AddHostedService<RabbitConsumerProvinciaHostedService>();
            services.AddHostedService<RabbitConsumerRegimenLaboralHostedService>();
            services.AddHostedService<RabbitConsumerRegimenPensionarioHostedService>();
            services.AddHostedService<RabbitConsumerServidorPublicoRequestHostedService>();
            services.AddHostedService<RabbitConsumerTipoCentroTrabajoHostedService>();
            services.AddHostedService<RabbitConsumerUgelHostedService>();
            services.AddHostedService<RabbitConsumerUnidadEjecutoraHostedService>();
        }
    }
}