namespace minedu.rrhh.personal.servidorpublico.common
{
    public static class Constante
    {
        public const string Desarrollo = "Development";
        public const string Produccion = "Production";
        public const string NOMBRE_SISTEMA = "rrhh-personal-servidorpublico-backend";
        public const string NOMBRE_SISTEMA_RESOLUCION = "rrhh-resoluciones-backend";
        
        public const string EX_GENERICA = "Internal Server Error - Se presento una condicion inesperada que impidio completar el Request.";
        public const string EX_PARAMETROS_INCORRECTOS = "No ingresó todos los parámetros obligatorios.";
        public const string EX_SERVIDOR_PUBLICO_CREATE = "No se pudo crear al servidor público";
        public const string DEPARTAMENTO_SUCCESS = "Lista los departamentos.";
        public const string DEPARTAMENTO_VALIDAR = "El código de departamento no es válido.";
        public const string PROVINCIA_VALIDAR = "El código de provincia no es válido.";
        

        #region RABBIT MQ EVENT BUSS [TRANSACTION]

        public const string RABBIT_EXCHANGE_REQUEST_CREARSERVIDORPUBLICO = "rrhh-personal-servidorpublico-crearservidorpublico-request-fanout-exchange";
        public const string RABBIT_QUEUE_REQUEST_CREARSERVIDORPUBLICO = "rrhh-personal-servidorpublico-crearservidorpublico-request-queue";
        public const string RABBIT_EXCHANGE_RESPONSE_CREARSERVIDORPUBLICO = "rrhh-personal-servidorpublico-crearservidorpublico-response-fanout-exchange";
        public const string RABBIT_EXCHANGE_PROPAGAR_CREARSERVIDORPUBLICO = "rrhh-personal-servidorpublico-crearservidorpublico-propagar-direct-exchange";
        public const string RABBIT_QUEUE_PROPAGAR_CREARSERVIDORPUBLICO = "rrhh-personal-servidorpublico-crearservidorpublico-propagar-queue";

        #endregion

        #region MENSAJES-REPLICA
        public const string EX_SERVIDOR_PUBLICO_NOT_FOUND = "No se pudo encontrar el registro del servidor público.";
        public const string EX_CATALOGO_NOT_FOUND = "No se pudo encontrar el registro de catalogo.";
        public const string EX_PERSONA_NOT_FOUND = "No se pudo encontrar el registro de la persona.";
        public const string EX_PROVINCIA_NOT_FOUND = "No se encuentra el registro de la provincia.";
        public const string EX_DISTRITO_NOT_FOUND = "No se encuentran registros de los distritos.";
        public const string EX_DEPARTAMENTO_NOT_FOUND = "No se encuentra el registro del departamento.";
        public const string EX_CARGO_NOTFOUND = "El código de cargo no es válida";
        public const string EX_AFP_NOTFOUND = "El código de afp no es válida";
        public const string EX_TIPO_PERSONA_NOTFOUND = "El código de tipo de persona no es válida";
        public const string EX_GENERO_NOTFOUND = "El código de genero no es válida";
        public const string EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND = "El código de tipo de documento de identidad no es válida";
        public const string EX_NUMERO_DOCUMENTO_IDENTIDAD_NOTFOUND = "El código de número de documento de identidad no es válida";
        public const string EX_ESTADO_CIVIL_NOTFOUND = "El código de estado civil no es válida";
        public const string EX_CATEGORIA_REMUNERATIVA_NOTFOUND = "El código de categoria remunerativa no es válida";
        public const string EX_SITUACION_LABORAL_NOTFOUND = "El código de situación laboral no es válida";
        public const string EX_CENTRO_TRABAJO_NOTFOUND = "El código de centro de trabajo no es válida";
        public const string EX_CONDICION_LABORAL_NOTFOUND = "El código de condición laboral no es válida";
        public const string EX_NIVEL_CARRERA_NOTFOUND = "El código de nivel de carrera no es válida";
        public const string EX_SITUACION_ACADEMICA_NOTFOUND = "El código de situación académica no es válida";
        public const string EX_COLEGIO_PROFESIONAL_NOTFOUND = "El código de colegio profesional no es válida";
        public const string EX_GRUPO_CARRERA_NOTFOUND = "El código de grupo de carrera no es válida";
        public const string EX_CARRERA_PROFESIONAL_NOTFOUND = "El código de carrera profesional no es válida";
        public const string EX_JORNADA_LABORAL_NOTFOUND = "El código de jornada laboral no es válida";
        public const string EX_TIPO_COMISION_NOTFOUND = "El código de tipo de comisión afp no es válida";
        public const string EX_TIPO_JORNADA_LABORAL_NOTFOUND = "El código de tipo de jornada laboral no es válida";
        public const string EX_NIVEL_CENTRO_ESTUDIO_NOTFOUND = "El código de nivel de centro de estudio no es válida";
        public const string EX_PAIS_NOTFOUND = "El código de país no es válida";
        public const string EX_CENTRO_ESTUDIO_NOTFOUND = "El código de centro de estudio no es válida";
        public const string EX_ESPECIALIDAD_PROFESIONAL_NOTFOUND = "El código de especialidad profesional no es válida";
        public const string EX_GRADO_INSTRUCCION_NOTFOUND = "El código de grado de instrucción no es válida";
        public const string EX_FORMACION_ACADEMICA_NOTFOUND = "El código de la unidad organizacional nivel 3 no es válida";
        public const string EX_REGIMEN_PENSIONARIO_NOTFOUND = "El código de régimen pensionario no encontrado";
        public const string EX_REGIMEN_LABORAL_NOTFOUND = "El código de régimen laboral no encontrado";
        public const string EX_OTRA_INSTANCIA_NOTFOUND = "Código de otra entidad no encontrado";
        public const string EX_TIPO_CENTRO_TRABAJO_NOTFOUND = "Código de tipo de centro de trabajo no encontrado";
        public const string EX_DRE_NOTFOUND = "Código de Dre no encontrado";
        public const string EX_UGEL_NOTFOUND = "Código de Ugel no encontrado";
        public const string EX_INSTITUCION_EDUCATIVA_NOTFOUND = "Código modular de institución educativa no encontrado";
        public const string EX_CODIGO_CENTRO_TRABAJO_OBLIGATORIO = "El código de centro de trabajo es obligatorio";
        public const string EX_ENTITY_REQUERID = "No ingresó los campos obligatorios";
        public const string EX_NIVEL_EDUCATIVO_NOTFOUND = "El código del nivel educativo no encontrado";
        public const string EX_TIPO_INSTITUCION_EDUCATIVA_NOTFOUND = "El código de tipo de institución educativa no encontrado";
        public const string EX_TIPO_RETENCION_TRIBUTARIA_NOTFOUND = "El código de tipo de de retencion tributaria no encontrado";
        public const string EX_DEPENDENCIA_INSTITUCION_EDUCATIVA_NOTFOUND = "El código de dependencia de institución educativa no encontrado";
        public const string EX_TIPO_GESTION_INSTITUCION_EDUCATIVA_NOTFOUND = "El código tipo de gestión de institución educativa no encontrado";
        public const string EX_MODALIDAD_EDUCATIVA_NOTFOUND = "El código de modalidad educativa no encuentrado";
        public const string EX_NIVEL_INSTANCIA_NOTFOUND = "El código de nivel de instancia no encontrado";
        public const string EX_UNIDAD_EJECUTORA_NOTFOUND = "Código de unidad ejecutora no encontrado";

        #endregion

        #region RABBIT MQ EVENT BUSS [CONSUMIR]
        
        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_CATALOGO_ITEM = "rrhh-negocio-comunes-maestros-catalogoitem-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_CATALOGO_ITEM = "rrhh-negocio-comunes-maestros-catalogoitem-servidorpublico-queue";
        
        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_CATALOGO = "rrhh-negocio-comunes-maestros-catalogo-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_CATALOGO= "rrhh-negocio-comunes-maestros-catalogo-servidorpublico-queue";
        
        public const string RABBIT_EXCHANGE_PAIS = "rrhh-negocio-comunes-maestros-pais-fanout-exchange";
        public const string RABBIT_QUEUE_PAIS = "rrhh-negocio-comunes-maestros-pais-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_DEPARTAMENTO = "rrhh-negocio-comunes-maestros-departamento-fanout-exchange";
        public const string RABBIT_QUEUE_DEPARTAMENTO = "rrhh-negocio-comunes-maestros-departamento-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_PROVINCIA = "rrhh-negocio-comunes-maestros-provincia-fanout-exchange";
        public const string RABBIT_QUEUE_PROVINCIA = "rrhh-negocio-comunes-maestros-provincia-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_DISTRITO = "rrhh-negocio-comunes-maestros-distrito-fanout-exchange";
        public const string RABBIT_QUEUE_DISTRITO = "rrhh-negocio-comunes-maestros-distrito-servidorpublico-queue";
        
        public const string RABBIT_EXCHANGE_SERVIDORPUBLICO = "rrhh-personal-servidorpublico-servidorpublico-fanout-exchange";
        public const string RABBIT_QUEUE_SERVIDORPUBLICO = "rrhh-personal-servidorpublico-servidorpublico-fanout-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_AFP = "rrhh-negocio-comunes-maestros-afp-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_AFP = "rrhh-negocio-comunes-maestros-afp-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_CARRERA_PROFESIONAL = "rrhh-negocio-comunes-maestros-carreraprofesional-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_CARRERA_PROFESIONAL = "rrhh-negocio-comunes-maestros-carreraprofesional-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_NIVEL_CENTRO_ESTUDIO = "rrhh-negocio-comunes-maestros-nivelcentroestudio-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_NIVEL_CENTRO_ESTUDIO = "rrhh-negocio-comunes-maestros-nivelcentroestudio-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_JORNADA_LABORAL = "rrhh-negocio-comunes-maestros-jornadalaboral-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_JORNADA_LABORAL = "rrhh-negocio-comunes-maestros-jornadalaboral-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_CENTRO_ESTUDIO = "rrhh-negocio-comunes-maestros-centroestudio-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_CENTRO_ESTUDIO = "rrhh-negocio-comunes-maestros-centroestudio-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_ESPECIALIDAD_PROFESIONAL = "rrhh-negocio-comunes-maestros-especialidadprofesional-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_ESPECIALIDAD_PROFESIONAL = "rrhh-negocio-comunes-maestros-especialidadprofesional-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_GRADO_INSTRUCCION = "rrhh-negocio-comunes-maestros-gradoinstruccion-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_GRADO_INSTRUCCION = "rrhh-negocio-comunes-maestros-gradoinstruccion-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_FORMACION_ACADEMICA = "rrhh-negocio-comunes-maestros-formacionacademica-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_FORMACION_ACADEMICA = "rrhh-negocio-comunes-maestros-formacionacademica-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_CARGO = "rrhh-negocio-comunes-maestros-cargo-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_CARGO = "rrhh-negocio-comunes-maestros-cargo-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_CENTRO_TRABAJO = "rrhh-negocio-comunes-maestros-centrotrabajo-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_CENTRO_TRABAJO = "rrhh-negocio-comunes-maestros-centrotrabajo-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_CATEGORIA_REMUNERATIVA = "rrhh-negocio-comunes-maestros-categoriaremunerativa-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_CATEGORIA_REMUNERATIVA = "rrhh-negocio-comunes-maestros-categoriaremunerativa-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_DRE = "rrhh-negocio-comunes-maestros-dre-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_DRE = "rrhh-negocio-comunes-maestros-dre-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_PERSONAS_PERSONA = "rrhh-personas-persona-fanout-exchange";
        public const string RABBIT_QUEUE_PERSONAS_PERSONA_SERVIDORPUBLICO = "rrhh-personas-persona-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_INSTITUCIONEDUCATIVA = "rrhh-negocio-comunes-maestros-institucioneducativa-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_INSTITUCIONEDUCATIVA = "rrhh-negocio-comunes-institucioneducativa-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_NIVEL_EDUCATIVO = "rrhh-negocio-comunes-maestros-niveleducativo-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_NIVEL_EDUCATIVO = "rrhh-negocio-comunes-maestros-niveleducativo-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_MODALIDAD_EDUCATIVA = "rrhh-negocio-comunes-maestros-modalidadeducativa-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_MODALIDAD_EDUCATIVA = "rrhh-negocio-comunes-maestros-modalidadeducativa-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_UNIDAD_EJECUTORA = "rrhh-negocio-comunes-maestros-unidadejecutora-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_UNIDAD_EJECUTORA = "rrhh-negocio-comunes-maestros-unidadejecutora-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_OTRA_INSTANCIA = "rrhh-negocio-comunes-maestros-otrainstancia-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_OTRA_INSTANCIA = "rrhh-negocio-comunes-maestros-otrainstancia-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_REGIMEN_LABORAL = "rrhh-negocio-comunes-maestros-regimenlaboral-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_REGIMEN_LABORAL = "rrhh-negocio-comunes-maestros-regimenlaboral-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_TIPO_CENTRO_TRABAJO = "rrhh-negocio-comunes-maestros-tipocentrotrabajo-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_TIPO_CENTRO_TRABAJO = "rrhh-negocio-comunes-maestros-tipocentrotrabajo-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_REGIMEN_PENSIONARIO = "rrhh-negocio-comunes-maestros-regimenpensionario-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_REGIMEN_PENSIONARIO = "rrhh-negocio-comunes-maestros-regimenpensionario-servidorpublico-queue";

        public const string RABBIT_EXCHANGE_NEGOCIO_COMUNES_MAESTROS_UGEL = "rrhh-negocio-comunes-maestros-ugel-fanout-exchange";
        public const string RABBIT_QUEUE_NEGOCIO_COMUNES_MAESTROS_UGEL = "rrhh-negocio-comunes-maestros-ugel-servidorpublico-queue";

        #endregion
    }
}