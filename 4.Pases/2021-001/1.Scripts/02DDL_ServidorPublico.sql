USE [db_ayni_personal_servidorpublico]
GO

create sequence dbo.seq_afp
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_cargo
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_carrera_profesional
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_catalogo
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_catalogo_item
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_categoria_remunerativa
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_centro_estudio
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_centro_trabajo
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_codigo_servidor_publico
as bigint
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_departamento
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_distrito
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_dre
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_especialidad_profesional
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_formacion_academica
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_grado_instruccion
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_institucion_educativa
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_jornada_laboral
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_modalidad_educativa
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_nivel_educativo
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_otra_instancia
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_pais
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_persona
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_provincia
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_regimen_laboral
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_regimen_pensionario
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_servidor_publico
as bigint
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_servidor_publico_temporal
as bigint
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_tipo_centro_trabajo
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_ugel
as int
increment by 1
start with 1
 minvalue 1
go

create sequence dbo.seq_unidad_ejecutora
as int
increment by 1
start with 1
 minvalue 1
go

/*==============================================================*/
/* Table: AFP                                                   */
/*==============================================================*/
create table dbo.afp (
   ID_AFP               int                  not null,
   ID_REGIMEN_PENSIONARIO int                  not null,
   CODIGO_AFP           varchar(2)           not null,
   DESCRIPCION_AFP      varchar(50)          not null,
   ABREVIATURA_AFP_SUNAT varchar(10)          null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_AFP primary key (ID_AFP)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.afp') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'afp' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene información de las Administradoras de Fondos de Pensiones (AFP) que operan en el Perú utilizadas por el sistema. Ejm: Prima, Profuturo, Integra,Habitat', 
   'user', 'dbo', 'table', 'afp'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_AFP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'ID_AFP'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la administradora de fondos de pensiones.',
   'user', 'dbo', 'table', 'afp', 'column', 'ID_AFP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_REGIMEN_PENSIONARIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'ID_REGIMEN_PENSIONARIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado regimen pensionario',
   'user', 'dbo', 'table', 'afp', 'column', 'ID_REGIMEN_PENSIONARIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_AFP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'CODIGO_AFP'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de la AFP',
   'user', 'dbo', 'table', 'afp', 'column', 'CODIGO_AFP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_AFP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'DESCRIPCION_AFP'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre de la administradora de fondos de pensiones.',
   'user', 'dbo', 'table', 'afp', 'column', 'DESCRIPCION_AFP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA_AFP_SUNAT')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'ABREVIATURA_AFP_SUNAT'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre abreviado de la administradora de fondos de pensiones para la SUNAT',
   'user', 'dbo', 'table', 'afp', 'column', 'ABREVIATURA_AFP_SUNAT'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de estado del registro.',
   'user', 'dbo', 'table', 'afp', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'afp', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'afp', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'afp', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'afp', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'afp', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.afp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'afp', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP modificador del registro',
   'user', 'dbo', 'table', 'afp', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: CARGO                                                 */
/*==============================================================*/
create table dbo.cargo (
   ID_CARGO             int                  not null,
   ID_REGIMEN_LABORAL   int                  not null,
   CODIGO_CARGO         int                  not null,
   DESCRIPCION_CARGO    varchar(100)         not null,
   ABREVIATURA_CARGO    varchar(20)          null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_CARGO primary key (ID_CARGO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.cargo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'cargo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene información de los cargos que tenga el servidor público', 
   'user', 'dbo', 'table', 'cargo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CARGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'ID_CARGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado cargo.',
   'user', 'dbo', 'table', 'cargo', 'column', 'ID_CARGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_REGIMEN_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'ID_REGIMEN_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del régimen laboral',
   'user', 'dbo', 'table', 'cargo', 'column', 'ID_REGIMEN_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_CARGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'CODIGO_CARGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de Cargo',
   'user', 'dbo', 'table', 'cargo', 'column', 'CODIGO_CARGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_CARGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'DESCRIPCION_CARGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre del cargo que desempeña. Ejm: Docente.',
   'user', 'dbo', 'table', 'cargo', 'column', 'DESCRIPCION_CARGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA_CARGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'ABREVIATURA_CARGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Abreviatura del cargo',
   'user', 'dbo', 'table', 'cargo', 'column', 'ABREVIATURA_CARGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'cargo', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'cargo', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'cargo', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'cargo', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'cargo', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'cargo', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.cargo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'cargo', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'cargo', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: CARRERA_PROFESIONAL                                   */
/*==============================================================*/
create table dbo.carrera_profesional (
   ID_CARRERA_PROFESIONAL int                  not null,
   ID_GRUPO_CARRERA     int                  null,
   CODIGO_CARRERA_PROFESIONAL int                  not null,
   DESCRIPCION_CARRERA_PROFESIONAL varchar(300)         null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_CARRERA_PROFESIONAL primary key (ID_CARRERA_PROFESIONAL)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.carrera_profesional') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'carrera_profesional' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene datos de las carreras asociada al grupo de carrera', 
   'user', 'dbo', 'table', 'carrera_profesional'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CARRERA_PROFESIONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'ID_CARRERA_PROFESIONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la Carreara profesional',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'ID_CARRERA_PROFESIONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_GRUPO_CARRERA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'ID_GRUPO_CARRERA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'ID_GRUPO_CARRERA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_CARRERA_PROFESIONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'CODIGO_CARRERA_PROFESIONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de la Carrera profesional',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'CODIGO_CARRERA_PROFESIONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_CARRERA_PROFESIONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'DESCRIPCION_CARRERA_PROFESIONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción de carrera profesional',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'DESCRIPCION_CARRERA_PROFESIONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que crea el registro',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.carrera_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que modifica el registro',
   'user', 'dbo', 'table', 'carrera_profesional', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: CATALOGO                                              */
/*==============================================================*/
create table dbo.catalogo (
   ID_CATALOGO          int                  not null,
   CODIGO_CATALOGO      int                  not null,
   DESCRIPCION_CATALOGO varchar(100)         not null,
   ACTIVO               bit                  not null,
   ELIMINADO            bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_CATALOGO primary key (ID_CATALOGO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.catalogo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'catalogo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene las cabeceras de los catálogos', 
   'user', 'dbo', 'table', 'catalogo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CATALOGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'ID_CATALOGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del catálogo',
   'user', 'dbo', 'table', 'catalogo', 'column', 'ID_CATALOGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_CATALOGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'CODIGO_CATALOGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único del catálogo, transversal a los módulos',
   'user', 'dbo', 'table', 'catalogo', 'column', 'CODIGO_CATALOGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_CATALOGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'DESCRIPCION_CATALOGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción del catálogo',
   'user', 'dbo', 'table', 'catalogo', 'column', 'DESCRIPCION_CATALOGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'catalogo', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ELIMINADO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'ELIMINADO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador del borrado lógico del registro.',
   'user', 'dbo', 'table', 'catalogo', 'column', 'ELIMINADO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'catalogo', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'catalogo', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que crea el registro',
   'user', 'dbo', 'table', 'catalogo', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'catalogo', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'catalogo', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que modifica el registro',
   'user', 'dbo', 'table', 'catalogo', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: CATALOGO_ITEM                                         */
/*==============================================================*/
create table dbo.catalogo_item (
   ID_CATALOGO_ITEM     int                  not null,
   ID_CATALOGO          int                  not null,
   CODIGO_CATALOGO_ITEM int                  not null,
   DESCRIPCION_CATALOGO_ITEM varchar(250)         not null,
   ABREVIATURA_CATALOGO_ITEM varchar(50)          not null,
   ORDEN                int                  null,
   ACTIVO               bit                  not null,
   ELIMINADO            bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_CATALOGO_ITEM primary key (ID_CATALOGO_ITEM)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.catalogo_item') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'catalogo_item' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene los items de los catálogos', 
   'user', 'dbo', 'table', 'catalogo_item'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CATALOGO_ITEM')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ID_CATALOGO_ITEM'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ID_CATALOGO_ITEM'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CATALOGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ID_CATALOGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del catálogo',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ID_CATALOGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_CATALOGO_ITEM')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'CODIGO_CATALOGO_ITEM'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único del catálogo, transversal a los módulos',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'CODIGO_CATALOGO_ITEM'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_CATALOGO_ITEM')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'DESCRIPCION_CATALOGO_ITEM'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción del ítem del catálogo',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'DESCRIPCION_CATALOGO_ITEM'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA_CATALOGO_ITEM')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ABREVIATURA_CATALOGO_ITEM'

end


execute sp_addextendedproperty 'MS_Description', 
   'Abreviatura del ítem del catálogo',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ABREVIATURA_CATALOGO_ITEM'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ORDEN')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ORDEN'

end


execute sp_addextendedproperty 'MS_Description', 
   'Orden del catálogo',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ORDEN'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ELIMINADO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ELIMINADO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador del borrado lógico del registro. ',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'ELIMINADO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que crea el registro',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que crea el registro',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.catalogo_item')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que modifica el registro',
   'user', 'dbo', 'table', 'catalogo_item', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: CATEGORIA_REMUNERATIVA                                */
/*==============================================================*/
create table dbo.categoria_remunerativa (
   ID_CATEGORIA_REMUNERATIVA int                  not null,
   CODIGO_CATEGORIA_REMUNERATIVA int                  not null,
   CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA varchar(10)          null,
   DESCRIPCION_CATEGORIA_REMUNERATIVA varchar(50)          not null,
   ABREVIATURA_CATEGORIA_REMUNERATIVA varchar(10)          null,
   ORDEN_CATEGORIA_REMUNERATIVA int                  null,
   ES_ESCALA            bit                  not null,
   ACTIVO               bit                  not null,
   ELIMINADO            bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_CATEGORIA_REMUNERATIVA primary key nonclustered (ID_CATEGORIA_REMUNERATIVA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.categoria_remunerativa') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'categoria_remunerativa' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Listado de categoria remunerativa y escala magisterial.', 
   'user', 'dbo', 'table', 'categoria_remunerativa'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CATEGORIA_REMUNERATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ID_CATEGORIA_REMUNERATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la categoría remunerativa.',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ID_CATEGORIA_REMUNERATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_CATEGORIA_REMUNERATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'CODIGO_CATEGORIA_REMUNERATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de la categoria remunerativa',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'CODIGO_CATEGORIA_REMUNERATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código origen de la categoria remunerativa',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_CATEGORIA_REMUNERATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'DESCRIPCION_CATEGORIA_REMUNERATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción de la categoría remunerativa',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'DESCRIPCION_CATEGORIA_REMUNERATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA_CATEGORIA_REMUNERATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ABREVIATURA_CATEGORIA_REMUNERATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Abreviatura de la categoría remunerativa',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ABREVIATURA_CATEGORIA_REMUNERATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ORDEN_CATEGORIA_REMUNERATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ORDEN_CATEGORIA_REMUNERATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Orden de la categoría remunerativa',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ORDEN_CATEGORIA_REMUNERATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ES_ESCALA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ES_ESCALA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Valor que indica si es escala o Categoria remunerativa
   0= CATEGORIA REMUNERATIVA
   1 = ESCALA
   ',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ES_ESCALA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ELIMINADO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ELIMINADO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de eliminar el registro.',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'ELIMINADO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.categoria_remunerativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'categoria_remunerativa', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: CENTRO_ESTUDIO                                        */
/*==============================================================*/
create table dbo.centro_estudio (
   ID_CENTRO_ESTUDIO    int                  not null,
   ID_NIVEL_CENTRO_ESTUDIO int                  null,
   ID_PAIS              int                  not null,
   ID_DEPARTAMENTO      int                  null,
   ID_PROVINCIA         int                  null,
   ID_DISTRITO          int                  null,
   CODIGO_CENTRO_ESTUDIO int                  not null,
   DESCRIPCION_CENTRO_ESTUDIO varchar(100)         not null,
   CODIGO_ORIGEN_CENTRO_ESTUDIO varchar(20)          null,
   ACTIVO               bit                  not null,
   ELIMINADO            bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_CENTRO_ESTUDIO primary key (ID_CENTRO_ESTUDIO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.centro_estudio') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'centro_estudio' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene el listado de los centros de estudios.', 
   'user', 'dbo', 'table', 'centro_estudio'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CENTRO_ESTUDIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_CENTRO_ESTUDIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del centro de estudios',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_CENTRO_ESTUDIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_NIVEL_CENTRO_ESTUDIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_NIVEL_CENTRO_ESTUDIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_NIVEL_CENTRO_ESTUDIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PAIS')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_PAIS'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del país.',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_PAIS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DEPARTAMENTO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_DEPARTAMENTO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID del departamento',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_DEPARTAMENTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PROVINCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_PROVINCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID de la provincia',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_PROVINCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DISTRITO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_DISTRITO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID del distrito',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ID_DISTRITO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_CENTRO_ESTUDIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'CODIGO_CENTRO_ESTUDIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único del centro de estudios',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'CODIGO_CENTRO_ESTUDIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_CENTRO_ESTUDIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'DESCRIPCION_CENTRO_ESTUDIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción del centro de estudios',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'DESCRIPCION_CENTRO_ESTUDIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_ORIGEN_CENTRO_ESTUDIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'CODIGO_ORIGEN_CENTRO_ESTUDIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código origen de centro de estudio',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'CODIGO_ORIGEN_CENTRO_ESTUDIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ELIMINADO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ELIMINADO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador del borrado lógico del registro. ',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'ELIMINADO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que crea el registro',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_estudio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que modifica el registro',
   'user', 'dbo', 'table', 'centro_estudio', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: CENTRO_TRABAJO                                        */
/*==============================================================*/
create table dbo.centro_trabajo (
   ID_CENTRO_TRABAJO    int                  not null,
   ID_TIPO_CENTRO_TRABAJO int                  not null,
   ID_OTRA_INSTANCIA    int                  null,
   ID_DRE               int                  null,
   ID_UGEL              int                  null,
   ID_INSTITUCION_EDUCATIVA int                  null,
   CODIGO_CENTRO_TRABAJO varchar(10)          not null,
   ANEXO_CENTRO_TRABAJO varchar(5)           null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_CENTRO_TRABAJO primary key (ID_CENTRO_TRABAJO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.centro_trabajo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'centro_trabajo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene todos los centros de trabajo, es decir aquellos lugares donde se puede ubicar una plaza, tanto docente como administrativa.', 
   'user', 'dbo', 'table', 'centro_trabajo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CENTRO_TRABAJO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_CENTRO_TRABAJO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del centro de trabajo.',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_CENTRO_TRABAJO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_TIPO_CENTRO_TRABAJO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_TIPO_CENTRO_TRABAJO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del tipo de centro de trabajo.',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_TIPO_CENTRO_TRABAJO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_OTRA_INSTANCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_OTRA_INSTANCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la entidad de trabajo',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_OTRA_INSTANCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DRE')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_DRE'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la DRE',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_DRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_UGEL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_UGEL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la UGEL',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_UGEL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_INSTITUCION_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_INSTITUCION_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la Institución educativa',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_INSTITUCION_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_CENTRO_TRABAJO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'CODIGO_CENTRO_TRABAJO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código de centro de trabajo. Replicado de las entidades DRE, UGEL, IEs y otras entidades',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'CODIGO_CENTRO_TRABAJO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: DEPARTAMENTO                                          */
/*==============================================================*/
create table dbo.departamento (
   ID_DEPARTAMENTO      int                  not null,
   CODIGO_DEPARTAMENTO_INEI varchar(10)          not null,
   CODIGO_DEPARTAMENTO_RENIEC varchar(10)          null,
   DESCRIPCION          varchar(100)         not null,
   ABREVIATURA          varchar(7)           null,
   ACTIVO               bit                  not null,
   ELIMINADO            bit                  not null,
   CODIGO_USUARIO_CREACION varchar(20)          not null,
   FECHA_CREACION       datetime             not null,
   CODIGO_USUARIO_MODIFICACION varchar(20)          null,
   FECHA_MODIFICACION   datetime             null,
   constraint PK_DEPARTAMENTO primary key (ID_DEPARTAMENTO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.departamento') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'departamento' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene los departamentos del Perú', 
   'user', 'dbo', 'table', 'departamento'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DEPARTAMENTO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'ID_DEPARTAMENTO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID del departamento',
   'user', 'dbo', 'table', 'departamento', 'column', 'ID_DEPARTAMENTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_DEPARTAMENTO_INEI')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'CODIGO_DEPARTAMENTO_INEI'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código del departamento en INEI',
   'user', 'dbo', 'table', 'departamento', 'column', 'CODIGO_DEPARTAMENTO_INEI'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_DEPARTAMENTO_RENIEC')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'CODIGO_DEPARTAMENTO_RENIEC'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código del departamento en RENIEC',
   'user', 'dbo', 'table', 'departamento', 'column', 'CODIGO_DEPARTAMENTO_RENIEC'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'DESCRIPCION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción del departamento',
   'user', 'dbo', 'table', 'departamento', 'column', 'DESCRIPCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'ABREVIATURA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Abreviatura del departamento',
   'user', 'dbo', 'table', 'departamento', 'column', 'ABREVIATURA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'departamento', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ELIMINADO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'ELIMINADO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indica si el registro ha sido eliminado',
   'user', 'dbo', 'table', 'departamento', 'column', 'ELIMINADO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'CODIGO_USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código del usuario que crea el registro',
   'user', 'dbo', 'table', 'departamento', 'column', 'CODIGO_USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'departamento', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'CODIGO_USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código del usuario que modifica el registro',
   'user', 'dbo', 'table', 'departamento', 'column', 'CODIGO_USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.departamento')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'departamento', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'departamento', 'column', 'FECHA_MODIFICACION'
go

/*==============================================================*/
/* Table: DISTRITO                                              */
/*==============================================================*/
create table dbo.distrito (
   ID_DISTRITO          int                  not null,
   ID_DEPARTAMENTO      int                  not null,
   ID_PROVINCIA         int                  not null,
   CODIGO_DISTRITO_INEI varchar(10)          not null,
   CODIGO_DISTRITO_RENIEC varchar(10)          null,
   DESCRIPCION          varchar(100)         not null,
   ABREVIATURA          varchar(7)           null,
   ACTIVO               bit                  not null,
   ELIMINADO            bit                  not null,
   CODIGO_USUARIO_CREACION varchar(20)          not null,
   FECHA_CREACION       datetime             not null,
   CODIGO_USUARIO_MODIFICACION varchar(20)          null,
   FECHA_MODIFICACION   datetime             null,
   constraint PK_DISTRITO primary key (ID_DISTRITO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.distrito') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'distrito' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene los distritos del Perú', 
   'user', 'dbo', 'table', 'distrito'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DISTRITO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'ID_DISTRITO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID del distrito',
   'user', 'dbo', 'table', 'distrito', 'column', 'ID_DISTRITO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DEPARTAMENTO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'ID_DEPARTAMENTO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID del departamento',
   'user', 'dbo', 'table', 'distrito', 'column', 'ID_DEPARTAMENTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PROVINCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'ID_PROVINCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID de la provincia',
   'user', 'dbo', 'table', 'distrito', 'column', 'ID_PROVINCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_DISTRITO_INEI')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'CODIGO_DISTRITO_INEI'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código del distrito en INEI',
   'user', 'dbo', 'table', 'distrito', 'column', 'CODIGO_DISTRITO_INEI'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_DISTRITO_RENIEC')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'CODIGO_DISTRITO_RENIEC'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código del distrito en RENIEC',
   'user', 'dbo', 'table', 'distrito', 'column', 'CODIGO_DISTRITO_RENIEC'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'DESCRIPCION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción del distrito',
   'user', 'dbo', 'table', 'distrito', 'column', 'DESCRIPCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'ABREVIATURA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Abreviatura del distrito',
   'user', 'dbo', 'table', 'distrito', 'column', 'ABREVIATURA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'distrito', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ELIMINADO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'ELIMINADO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indica si el registro ha sido eliminado',
   'user', 'dbo', 'table', 'distrito', 'column', 'ELIMINADO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'CODIGO_USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código del usuario que crea el registro',
   'user', 'dbo', 'table', 'distrito', 'column', 'CODIGO_USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'distrito', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'CODIGO_USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código del usuario que modifica el registro',
   'user', 'dbo', 'table', 'distrito', 'column', 'CODIGO_USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.distrito')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'distrito', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'distrito', 'column', 'FECHA_MODIFICACION'
go

/*==============================================================*/
/* Table: DRE                                                   */
/*==============================================================*/
create table dbo.dre (
   ID_DRE               int                  not null,
   ID_UNIDAD_EJECUTORA  int                  not null,
   ID_SERVIDOR_PUBLICO_DIRECTOR bigint               null,
   ID_DISTRITO          int                  null,
   DESCRIPCION_DRE      varchar(500)         not null,
   CODIGO_DRE           varchar(10)          not null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_DRE primary key (ID_DRE)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.dre') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'dre' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene listado de las DREs', 
   'user', 'dbo', 'table', 'dre'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DRE')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'ID_DRE'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la DRE',
   'user', 'dbo', 'table', 'dre', 'column', 'ID_DRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_UNIDAD_EJECUTORA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'ID_UNIDAD_EJECUTORA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la unidad ejecutora.',
   'user', 'dbo', 'table', 'dre', 'column', 'ID_UNIDAD_EJECUTORA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_SERVIDOR_PUBLICO_DIRECTOR')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'ID_SERVIDOR_PUBLICO_DIRECTOR'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del servidor público',
   'user', 'dbo', 'table', 'dre', 'column', 'ID_SERVIDOR_PUBLICO_DIRECTOR'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DISTRITO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'ID_DISTRITO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID del distrito',
   'user', 'dbo', 'table', 'dre', 'column', 'ID_DISTRITO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_DRE')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'DESCRIPCION_DRE'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción de la DRE',
   'user', 'dbo', 'table', 'dre', 'column', 'DESCRIPCION_DRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_DRE')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'CODIGO_DRE'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de la DRE',
   'user', 'dbo', 'table', 'dre', 'column', 'CODIGO_DRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'dre', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'dre', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'dre', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de creador del registro',
   'user', 'dbo', 'table', 'dre', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'dre', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'dre', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dre')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dre', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificador del registro',
   'user', 'dbo', 'table', 'dre', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: ESPECIALIDAD_PROFESIONAL                              */
/*==============================================================*/
create table dbo.especialidad_profesional (
   ID_ESPECIALIDAD_PROFESIONAL int                  not null,
   ID_CARRERA_PROFESIONAL int                  null,
   ID_GRUPO_CARRERA     int                  null,
   CODIGO_ESPECIALIDAD_PROFESIONAL int                  not null,
   DESCRIPCION_ESPECIALIDAD_PROFESIONAL varchar(300)         null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_ESPECIALIDAD_PROFESIONAL primary key (ID_ESPECIALIDAD_PROFESIONAL)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.especialidad_profesional') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'especialidad_profesional' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene datos de las especialidades asociado a la carrera', 
   'user', 'dbo', 'table', 'especialidad_profesional'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_ESPECIALIDAD_PROFESIONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'ID_ESPECIALIDAD_PROFESIONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la Carreara profesional',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'ID_ESPECIALIDAD_PROFESIONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CARRERA_PROFESIONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'ID_CARRERA_PROFESIONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la Carreara profesional',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'ID_CARRERA_PROFESIONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_GRUPO_CARRERA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'ID_GRUPO_CARRERA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'ID_GRUPO_CARRERA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_ESPECIALIDAD_PROFESIONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'CODIGO_ESPECIALIDAD_PROFESIONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de la Carrera profesional',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'CODIGO_ESPECIALIDAD_PROFESIONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_ESPECIALIDAD_PROFESIONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'DESCRIPCION_ESPECIALIDAD_PROFESIONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción de carrera profesional',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'DESCRIPCION_ESPECIALIDAD_PROFESIONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que crea el registro',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.especialidad_profesional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que modifica el registro',
   'user', 'dbo', 'table', 'especialidad_profesional', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: FORMACION_ACADEMICA                                   */
/*==============================================================*/
create table dbo.formacion_academica (
   ID_FORMACION_ACADEMICA bigint               not null,
   ID_SERVIDOR_PUBLICO  bigint               not null,
   ID_PAIS              int                  null,
   ID_GRADO_INSTRUCCION int                  null,
   ID_CENTRO_ESTUDIO    int                  null,
   ID_GRUPO_CARRERA     int                  null,
   ID_NIVEL_CARRERA     int                  null,
   ID_SITUACION_ACADEMICA int                  null,
   ID_COLEGIO_PROFESIONAL int                  null,
   ID_DEPARTAMENTO      int                  null,
   ID_PROVINCIA         int                  null,
   ID_DISTRITO          int                  null,
   ID_ESPECIALIDAD_PROFESIONAL int                  null,
   ID_CARRERA_PROFESIONAL int                  null,
   CODIGO_FORMACION_ACADEMICA int                  not null,
   FECHA_REGISTRO       datetime             not null,
   ANIO_INICIO_ESTUDIOS varchar(4)           not null,
   ANIO_FIN_ESTUDIOS    varchar(4)           null,
   FECHA_EXPEDICION_GRADO_ACADEMICO datetime             null,
   NUMERO_COLEGIATURA   varchar(20)          null,
   FECHA_COLEGIATURA    datetime             null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_FORMACION_ACADEMICA primary key (ID_FORMACION_ACADEMICA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.formacion_academica') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'formacion_academica' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene datos de la fomación académica del Servidor Público', 
   'user', 'dbo', 'table', 'formacion_academica'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_FORMACION_ACADEMICA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_FORMACION_ACADEMICA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la formación académica del Servidor público',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_FORMACION_ACADEMICA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_SERVIDOR_PUBLICO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_SERVIDOR_PUBLICO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del servidor público',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_SERVIDOR_PUBLICO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PAIS')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_PAIS'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del país.',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_PAIS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_GRADO_INSTRUCCION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_GRADO_INSTRUCCION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del grado instrucción',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_GRADO_INSTRUCCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CENTRO_ESTUDIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_CENTRO_ESTUDIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del centro de estudios',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_CENTRO_ESTUDIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_GRUPO_CARRERA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_GRUPO_CARRERA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Grupo de carrera',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_GRUPO_CARRERA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_NIVEL_CARRERA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_NIVEL_CARRERA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Nivel de carrera',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_NIVEL_CARRERA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_SITUACION_ACADEMICA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_SITUACION_ACADEMICA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Situación Académica
   1= Incompleto
   2= Completo
   3= Egresado
   4= Con grado
   5= Titulado',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_SITUACION_ACADEMICA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_COLEGIO_PROFESIONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_COLEGIO_PROFESIONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Colegio Profesional',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_COLEGIO_PROFESIONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DEPARTAMENTO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_DEPARTAMENTO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID del departamento',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_DEPARTAMENTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PROVINCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_PROVINCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID de la provincia',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_PROVINCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DISTRITO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_DISTRITO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID del distrito',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_DISTRITO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_ESPECIALIDAD_PROFESIONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_ESPECIALIDAD_PROFESIONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la Carreara profesional',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_ESPECIALIDAD_PROFESIONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CARRERA_PROFESIONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_CARRERA_PROFESIONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la Carreara profesional',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ID_CARRERA_PROFESIONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_FORMACION_ACADEMICA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'CODIGO_FORMACION_ACADEMICA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de la formación académica del servidor público',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'CODIGO_FORMACION_ACADEMICA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_REGISTRO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'FECHA_REGISTRO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'FECHA_REGISTRO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ANIO_INICIO_ESTUDIOS')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ANIO_INICIO_ESTUDIOS'

end


execute sp_addextendedproperty 'MS_Description', 
   'Año de inicio de estudios',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ANIO_INICIO_ESTUDIOS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ANIO_FIN_ESTUDIOS')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ANIO_FIN_ESTUDIOS'

end


execute sp_addextendedproperty 'MS_Description', 
   'Año fin de estudios',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ANIO_FIN_ESTUDIOS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_EXPEDICION_GRADO_ACADEMICO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'FECHA_EXPEDICION_GRADO_ACADEMICO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de expedición de grado de estudios',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'FECHA_EXPEDICION_GRADO_ACADEMICO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que crea el registro',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.formacion_academica')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP que modifica el registro',
   'user', 'dbo', 'table', 'formacion_academica', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: GRADO_INSTRUCCION                                     */
/*==============================================================*/
create table dbo.grado_instruccion (
   ID_GRADO_INSTRUCCION int                  not null,
   CODIGO_GRADO_INSTRUCCION int                  not null,
   CODIGO_ORIGEN_GRADO_INSTRUCCION varchar(10)          null,
   DESCRIPCION_GRADO_INSTRUCCION varchar(100)         not null,
   ABREVIATURA_GRADO_INSTRUCCION varchar(100)         not null,
   ORDEN                int                  not null,
   ACTIVO               bit                  not null,
   ELIMINADO            bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_GRADO_INSTRUCCION primary key (ID_GRADO_INSTRUCCION)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.grado_instruccion') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'grado_instruccion' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene información del grado académico del Servidor Público. Ejm: Inicial, Primaria, Secundaria, Superior, etc', 
   'user', 'dbo', 'table', 'grado_instruccion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_GRADO_INSTRUCCION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'ID_GRADO_INSTRUCCION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del grado instrucción',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'ID_GRADO_INSTRUCCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_GRADO_INSTRUCCION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'CODIGO_GRADO_INSTRUCCION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único del grado de instrucción',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'CODIGO_GRADO_INSTRUCCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_ORIGEN_GRADO_INSTRUCCION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'CODIGO_ORIGEN_GRADO_INSTRUCCION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código origen del grado de instrucción',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'CODIGO_ORIGEN_GRADO_INSTRUCCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_GRADO_INSTRUCCION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'DESCRIPCION_GRADO_INSTRUCCION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre del grado de instrucción',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'DESCRIPCION_GRADO_INSTRUCCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA_GRADO_INSTRUCCION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'ABREVIATURA_GRADO_INSTRUCCION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Abreviatura del grado de instrucción',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'ABREVIATURA_GRADO_INSTRUCCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ORDEN')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'ORDEN'

end


execute sp_addextendedproperty 'MS_Description', 
   'Orden del grado de instrucción',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'ORDEN'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ELIMINADO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'ELIMINADO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de eliminar el registro.',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'ELIMINADO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.grado_instruccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP modificador del registro',
   'user', 'dbo', 'table', 'grado_instruccion', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: INSTITUCION_EDUCATIVA                                 */
/*==============================================================*/
create table dbo.institucion_educativa (
   ID_INSTITUCION_EDUCATIVA int                  not null,
   ID_DRE               int                  null,
   ID_UGEL              int                  null,
   ID_OTRA_INSTANCIA    int                  null,
   ID_NIVEL_EDUCATIVO   int                  null,
   ID_TIPO_INSTITUCION_EDUCATIVA int                  null,
   ID_DEPENDENCIA_INSTITUCION_EDUCATIVA int                  null,
   ID_TIPO_GESTION_INSTITUCION_EDUCATIVA int                  null,
   ID_UNIDAD_EJECUTORA  int                  null,
   ID_SERVIDOR_PUBLICO_DIRECTOR bigint               null,
   CODIGO_MODULAR       varchar(7)           not null,
   ANEXO_INSTITUCION_EDUCATIVA varchar(5)           null,
   INSTITUCION_EDUCATIVA varchar(200)         not null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_INSTITUCION_EDUCATIVA primary key (ID_INSTITUCION_EDUCATIVA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.institucion_educativa') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'institucion_educativa' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene el listado de las instituciones educativas', 
   'user', 'dbo', 'table', 'institucion_educativa'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_INSTITUCION_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_INSTITUCION_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la Institución educativa',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_INSTITUCION_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DRE')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_DRE'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la DRE',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_DRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_UGEL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_UGEL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la UGEL',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_UGEL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_OTRA_INSTANCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_OTRA_INSTANCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de otra instancia',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_OTRA_INSTANCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_NIVEL_EDUCATIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_NIVEL_EDUCATIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado nivel educativo.',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_NIVEL_EDUCATIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_TIPO_INSTITUCION_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_TIPO_INSTITUCION_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Tipo de institución educativa',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_TIPO_INSTITUCION_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DEPENDENCIA_INSTITUCION_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_DEPENDENCIA_INSTITUCION_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Dependencia de Institución educativa',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_DEPENDENCIA_INSTITUCION_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_TIPO_GESTION_INSTITUCION_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_TIPO_GESTION_INSTITUCION_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Tipo Gestión Institución Educativa
   Pública de gestión directa
   Pública de gestión privada
   Privada',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_TIPO_GESTION_INSTITUCION_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_UNIDAD_EJECUTORA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_UNIDAD_EJECUTORA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la Unidad ejecutora',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_UNIDAD_EJECUTORA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_SERVIDOR_PUBLICO_DIRECTOR')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_SERVIDOR_PUBLICO_DIRECTOR'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del servidor público',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_SERVIDOR_PUBLICO_DIRECTOR'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_MODULAR')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'CODIGO_MODULAR'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código modular de la institución educativa',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'CODIGO_MODULAR'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ANEXO_INSTITUCION_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ANEXO_INSTITUCION_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Anexo de la Institución educativa',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ANEXO_INSTITUCION_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'INSTITUCION_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'INSTITUCION_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre de la institución educativa',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'INSTITUCION_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: JORNADA_LABORAL                                       */
/*==============================================================*/
create table dbo.jornada_laboral (
   ID_JORNADA_LABORAL   int                  not null,
   ID_TIPO_JORNADA_LABORAL int                  null,
   CODIGO_JORNADA_LABORAL int                  not null,
   CODIGO_ORIGEN_JORNADA_LABORAL varchar(10)          null,
   DESCRIPCION_JORNADA_LABORAL varchar(50)          not null,
   ABREVIATURA_JORNADA_LABORAL varchar(10)          null,
   ORDEN_JORNADA_LABORAL int                  null,
   CANTIDAD_JORNADA_LABORAL int                  null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_JORNADA_LABORAL primary key (ID_JORNADA_LABORAL)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.jornada_laboral') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'jornada_laboral' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Listado de jornada laboral', 
   'user', 'dbo', 'table', 'jornada_laboral'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_JORNADA_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'ID_JORNADA_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la jornada laboral',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'ID_JORNADA_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_TIPO_JORNADA_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'ID_TIPO_JORNADA_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Tipo Jornada laboral
   1= PEDAGOGICA    
   2= CRONOLOGICA  
   3= GENERICO          ',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'ID_TIPO_JORNADA_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_JORNADA_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'CODIGO_JORNADA_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de la jornada laboral.',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'CODIGO_JORNADA_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_ORIGEN_JORNADA_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'CODIGO_ORIGEN_JORNADA_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código origen de la jornada laboral.',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'CODIGO_ORIGEN_JORNADA_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_JORNADA_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'DESCRIPCION_JORNADA_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción de la jornada laboral',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'DESCRIPCION_JORNADA_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA_JORNADA_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'ABREVIATURA_JORNADA_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'abreviatura de la jornada laboral.',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'ABREVIATURA_JORNADA_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ORDEN_JORNADA_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'ORDEN_JORNADA_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Orden de la jornada laboral.',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'ORDEN_JORNADA_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CANTIDAD_JORNADA_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'CANTIDAD_JORNADA_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Cantidad de la jornada laboral.',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'CANTIDAD_JORNADA_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.jornada_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'jornada_laboral', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: MODALIDAD_EDUCATIVA                                   */
/*==============================================================*/
create table dbo.modalidad_educativa (
   ID_MODALIDAD_EDUCATIVA int                  not null,
   CODIGO_MODALIDAD_EDUCATIVA int                  not null,
   DESCRIPCION_MODALIDAD_EDUCATIVA varchar(50)          not null,
   ABREVIATURA_MODALIDAD_EDUCATIVA varchar(10)          null,
   ORDEN                int                  null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_MODALIDAD_EDUCATIVA primary key (ID_MODALIDAD_EDUCATIVA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.modalidad_educativa') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'modalidad_educativa' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene información de las diversas modalidades educativas que presenta la unidad de servicio educativo. Ejm: Regular, especial y alternativa', 
   'user', 'dbo', 'table', 'modalidad_educativa'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_MODALIDAD_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'ID_MODALIDAD_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado modalidad educativa',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'ID_MODALIDAD_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_MODALIDAD_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'CODIGO_MODALIDAD_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de la modalidad educativa.',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'CODIGO_MODALIDAD_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_MODALIDAD_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'DESCRIPCION_MODALIDAD_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre de la modalidad educativa',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'DESCRIPCION_MODALIDAD_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA_MODALIDAD_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'ABREVIATURA_MODALIDAD_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre abreviado de la modalidad educativa',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'ABREVIATURA_MODALIDAD_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ORDEN')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'ORDEN'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indica el orden en que se presentaran los registros.',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'ORDEN'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.modalidad_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'modalidad_educativa', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: NIVEL_EDUCATIVO                                       */
/*==============================================================*/
create table dbo.nivel_educativo (
   ID_NIVEL_EDUCATIVO   int                  not null,
   ID_MODALIDAD_EDUCATIVA int                  null,
   CODIGO_NIVEL_EDUCATIVO varchar(4)           not null,
   DESCRIPCION_NIVEL_EDUCATIVO varchar(50)          not null,
   ABREVIATURA_NIVEL_EDUCATIVO varchar(10)          null,
   ORDEN                int                  null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_NIVEL_EDUCATIVO primary key (ID_NIVEL_EDUCATIVO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.nivel_educativo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'nivel_educativo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene información de los diversos niveles educativos que presenta la unidad de servicio educativo. Ejm: Inicial, primaria, secundaria, especial', 
   'user', 'dbo', 'table', 'nivel_educativo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_NIVEL_EDUCATIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'ID_NIVEL_EDUCATIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado nivel educativo.',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'ID_NIVEL_EDUCATIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_MODALIDAD_EDUCATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'ID_MODALIDAD_EDUCATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Llave foránea del identificador de la modalidad del nivel educativo',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'ID_MODALIDAD_EDUCATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_NIVEL_EDUCATIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'CODIGO_NIVEL_EDUCATIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único del nivel educativo.',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'CODIGO_NIVEL_EDUCATIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_NIVEL_EDUCATIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'DESCRIPCION_NIVEL_EDUCATIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre del nivel educativo',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'DESCRIPCION_NIVEL_EDUCATIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA_NIVEL_EDUCATIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'ABREVIATURA_NIVEL_EDUCATIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre abreviado del nivel educativo',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'ABREVIATURA_NIVEL_EDUCATIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ORDEN')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'ORDEN'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indica el orden en que se presentaran los registros.',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'ORDEN'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP desde donde se realiza la creación',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.nivel_educativo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP desde donde se realiza la modificación',
   'user', 'dbo', 'table', 'nivel_educativo', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: OTRA_INSTANCIA                                        */
/*==============================================================*/
create table dbo.otra_instancia (
   ID_OTRA_INSTANCIA    int                  not null,
   ID_UNIDAD_EJECUTORA  int                  null,
   CODIGO_OTRA_INSTANCIA varchar(10)          not null,
   DESCRIPCION_OTRA_INSTANCIA varchar(100)         not null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_OTRA_INSTANCIA primary key (ID_OTRA_INSTANCIA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.otra_instancia') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'otra_instancia' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene algunas instancia:
   MINEDU
   ', 
   'user', 'dbo', 'table', 'otra_instancia'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_OTRA_INSTANCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'ID_OTRA_INSTANCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la entidad de trabajo',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'ID_OTRA_INSTANCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_UNIDAD_EJECUTORA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'ID_UNIDAD_EJECUTORA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la unidad ejecutora.',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'ID_UNIDAD_EJECUTORA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_OTRA_INSTANCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'CODIGO_OTRA_INSTANCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de la instancia',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'CODIGO_OTRA_INSTANCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_OTRA_INSTANCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'DESCRIPCION_OTRA_INSTANCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción de la instancia',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'DESCRIPCION_OTRA_INSTANCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.otra_instancia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'otra_instancia', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: PAIS                                                  */
/*==============================================================*/
create table dbo.pais (
   ID_PAIS              int                  not null,
   CODIGO_PAIS          varchar(10)          not null,
   DESCRIPCION_PAIS     varchar(200)         not null,
   ACTIVO               bit                  not null,
   ABREVIATURA_PAIS     varchar(10)          null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_PAIS primary key (ID_PAIS)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.pais') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'pais' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene información de los diversos paises utilizados por el sistema.', 
   'user', 'dbo', 'table', 'pais'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PAIS')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'ID_PAIS'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del país.',
   'user', 'dbo', 'table', 'pais', 'column', 'ID_PAIS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_PAIS')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'CODIGO_PAIS'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único del identificador país.',
   'user', 'dbo', 'table', 'pais', 'column', 'CODIGO_PAIS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_PAIS')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'DESCRIPCION_PAIS'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre del país.',
   'user', 'dbo', 'table', 'pais', 'column', 'DESCRIPCION_PAIS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'pais', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA_PAIS')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'ABREVIATURA_PAIS'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre abreviado del país.',
   'user', 'dbo', 'table', 'pais', 'column', 'ABREVIATURA_PAIS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'pais', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'pais', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'pais', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'pais', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'pais', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.pais')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'pais', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP modificador del registro',
   'user', 'dbo', 'table', 'pais', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table dbo.persona (
   ID_PERSONA           int                  not null,
   ID_TIPO_PERSONA      int                  not null,
   ID_GENERO            int                  null,
   ID_TIPO_DOCUMENTO_IDENTIDAD int                  not null,
   ID_ESTADO_CIVIL      int                  null,
   NUMERO_DOCUMENTO_IDENTIDAD varchar(12)          not null,
   NOMBRES              varchar(100)         not null,
   PRIMER_APELLIDO      varchar(100)         not null,
   SEGUNDO_APELLIDO     varchar(100)         null,
   FECHA_NACIMIENTO     date                 not null,
   ULTIMA_ACTUALIZACION_RENIEC date                 null,
   FECHA_CONSULTA_RENIEC date                 null,
   EMAIL_LABORAL        varchar(60)          null,
   EMAIL_PERSONAL       varchar(60)          null,
   TELEFONO_FIJO        varchar(10)          null,
   TELEFONO_MOVIL       varchar(10)          null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_PERSONA primary key (ID_PERSONA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.persona') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'persona' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene registros de la persona ', 
   'user', 'dbo', 'table', 'persona'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PERSONA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'ID_PERSONA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado persona',
   'user', 'dbo', 'table', 'persona', 'column', 'ID_PERSONA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_GENERO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'ID_GENERO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Género
   F = Femenino
   M = Masculino',
   'user', 'dbo', 'table', 'persona', 'column', 'ID_GENERO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_TIPO_DOCUMENTO_IDENTIDAD')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'ID_TIPO_DOCUMENTO_IDENTIDAD'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Tipo Documento de Identidad',
   'user', 'dbo', 'table', 'persona', 'column', 'ID_TIPO_DOCUMENTO_IDENTIDAD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_ESTADO_CIVIL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'ID_ESTADO_CIVIL'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Estado Civil
   S=Soltero(a)
   C=Casado(a)
   V=Viudo(a)
   D=Divorciado(a)
   etc',
   'user', 'dbo', 'table', 'persona', 'column', 'ID_ESTADO_CIVIL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NUMERO_DOCUMENTO_IDENTIDAD')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'NUMERO_DOCUMENTO_IDENTIDAD'

end


execute sp_addextendedproperty 'MS_Description', 
   'Número de documento de identidad de la persona',
   'user', 'dbo', 'table', 'persona', 'column', 'NUMERO_DOCUMENTO_IDENTIDAD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NOMBRES')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'NOMBRES'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre de la persona',
   'user', 'dbo', 'table', 'persona', 'column', 'NOMBRES'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PRIMER_APELLIDO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'PRIMER_APELLIDO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Primer apellido de la persona',
   'user', 'dbo', 'table', 'persona', 'column', 'PRIMER_APELLIDO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SEGUNDO_APELLIDO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'SEGUNDO_APELLIDO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Segundo apellido de la persona',
   'user', 'dbo', 'table', 'persona', 'column', 'SEGUNDO_APELLIDO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_NACIMIENTO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'FECHA_NACIMIENTO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de nacimiento de la persona',
   'user', 'dbo', 'table', 'persona', 'column', 'FECHA_NACIMIENTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ULTIMA_ACTUALIZACION_RENIEC')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'ULTIMA_ACTUALIZACION_RENIEC'

end


execute sp_addextendedproperty 'MS_Description', 
   'Última fecha actualizada de la RENIEC',
   'user', 'dbo', 'table', 'persona', 'column', 'ULTIMA_ACTUALIZACION_RENIEC'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CONSULTA_RENIEC')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'FECHA_CONSULTA_RENIEC'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de consulta de reniec',
   'user', 'dbo', 'table', 'persona', 'column', 'FECHA_CONSULTA_RENIEC'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EMAIL_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'EMAIL_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Correo electrónico laboral de la persona.',
   'user', 'dbo', 'table', 'persona', 'column', 'EMAIL_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EMAIL_PERSONAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'EMAIL_PERSONAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Correo electrónico personal de la persona',
   'user', 'dbo', 'table', 'persona', 'column', 'EMAIL_PERSONAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TELEFONO_FIJO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'TELEFONO_FIJO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Número de telefono fijo de la persona.',
   'user', 'dbo', 'table', 'persona', 'column', 'TELEFONO_FIJO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TELEFONO_MOVIL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'TELEFONO_MOVIL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Número de celular de la persona.',
   'user', 'dbo', 'table', 'persona', 'column', 'TELEFONO_MOVIL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'persona', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro.',
   'user', 'dbo', 'table', 'persona', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'persona', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'persona', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'persona', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'persona', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.persona')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'persona', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'persona', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Index: IX_PERSONA_001                                        */
/*==============================================================*/




create unique nonclustered index ix_persona_001 on dbo.persona (ID_TIPO_DOCUMENTO_IDENTIDAD ASC,
  NUMERO_DOCUMENTO_IDENTIDAD ASC)
go

/*==============================================================*/
/* Table: PROVINCIA                                             */
/*==============================================================*/
create table dbo.provincia (
   ID_PROVINCIA         int                  not null,
   ID_DEPARTAMENTO      int                  not null,
   CODIGO_PROVINCIA_INEI varchar(10)          not null,
   CODIGO_PROVINCIA_RENIEC varchar(10)          null,
   DESCRIPCION          varchar(100)         not null,
   ABREVIATURA          varchar(7)           null,
   ACTIVO               bit                  not null,
   ELIMINADO            bit                  not null,
   CODIGO_USUARIO_CREACION varchar(20)          not null,
   FECHA_CREACION       datetime             not null,
   CODIGO_USUARIO_MODIFICACION varchar(20)          null,
   FECHA_MODIFICACION   datetime             null,
   constraint PK_PROVINCIA primary key (ID_PROVINCIA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.provincia') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'provincia' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene las provincias del Perú', 
   'user', 'dbo', 'table', 'provincia'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PROVINCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'ID_PROVINCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID de la provincia',
   'user', 'dbo', 'table', 'provincia', 'column', 'ID_PROVINCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DEPARTAMENTO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'ID_DEPARTAMENTO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID del departamento',
   'user', 'dbo', 'table', 'provincia', 'column', 'ID_DEPARTAMENTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_PROVINCIA_INEI')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'CODIGO_PROVINCIA_INEI'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código de la provincia en INEI',
   'user', 'dbo', 'table', 'provincia', 'column', 'CODIGO_PROVINCIA_INEI'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_PROVINCIA_RENIEC')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'CODIGO_PROVINCIA_RENIEC'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código de la provincia en RENIEC',
   'user', 'dbo', 'table', 'provincia', 'column', 'CODIGO_PROVINCIA_RENIEC'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'DESCRIPCION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción de la provincia',
   'user', 'dbo', 'table', 'provincia', 'column', 'DESCRIPCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'ABREVIATURA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Abreviatura de la provincia',
   'user', 'dbo', 'table', 'provincia', 'column', 'ABREVIATURA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'provincia', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ELIMINADO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'ELIMINADO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indica si el registro ha sido eliminado',
   'user', 'dbo', 'table', 'provincia', 'column', 'ELIMINADO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'CODIGO_USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código del usuario que crea el registro',
   'user', 'dbo', 'table', 'provincia', 'column', 'CODIGO_USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'provincia', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'CODIGO_USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código del usuario que modifica el registro',
   'user', 'dbo', 'table', 'provincia', 'column', 'CODIGO_USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.provincia')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'provincia', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'provincia', 'column', 'FECHA_MODIFICACION'
go

/*==============================================================*/
/* Index: IX_PROVINCIA_001                                      */
/*==============================================================*/




create nonclustered index ix_provincia_001 on dbo.provincia (ID_DEPARTAMENTO ASC)
go

/*==============================================================*/
/* Index: IX_PROVINCIA_002                                      */
/*==============================================================*/




create nonclustered index ix_provincia_002 on dbo.provincia (CODIGO_PROVINCIA_INEI ASC)
go

/*==============================================================*/
/* Index: IX_PROVINCIA_003                                      */
/*==============================================================*/




create nonclustered index ix_provincia_003 on dbo.provincia (CODIGO_PROVINCIA_RENIEC ASC)
go

/*==============================================================*/
/* Table: REGIMEN_LABORAL                                       */
/*==============================================================*/
create table dbo.regimen_laboral (
   ID_REGIMEN_LABORAL   int                  not null,
   ID_TIPO_RETENCION_TRIBUTARIA int                  null,
   CODIGO_REGIMEN_LABORAL int                  not null,
   DESCRIPCION_REGIMEN_LABORAL varchar(200)         not null,
   ABREVIATURA_REGIMEN_LABORAL varchar(30)          not null,
   ADMINISTRATIVO       bit                  not null,
   FECHA_INICIO_VIGENCIA datetime             not null,
   FECHA_FIN_VIGENCIA   datetime             null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_REGIMEN_LABORAL primary key (ID_REGIMEN_LABORAL)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.regimen_laboral') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'regimen_laboral' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene el listado de los regímenes laborales', 
   'user', 'dbo', 'table', 'regimen_laboral'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_REGIMEN_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'ID_REGIMEN_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del régimen laboral',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'ID_REGIMEN_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_TIPO_RETENCION_TRIBUTARIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'ID_TIPO_RETENCION_TRIBUTARIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Tipo retención tributaria
   1=ALIMENTO
   2= DEUDA
   3= OTROS
   ',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'ID_TIPO_RETENCION_TRIBUTARIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_REGIMEN_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'CODIGO_REGIMEN_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único del régimen laboral',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'CODIGO_REGIMEN_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_REGIMEN_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'DESCRIPCION_REGIMEN_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción del régimen laboral',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'DESCRIPCION_REGIMEN_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ABREVIATURA_REGIMEN_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'ABREVIATURA_REGIMEN_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Abreviatura del régimen laboral',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'ABREVIATURA_REGIMEN_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ADMINISTRATIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'ADMINISTRATIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Permite identificar si al régimen laboral es administrativo o docente
   Administrativo = 1
   Docente = 0',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'ADMINISTRATIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_INICIO_VIGENCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'FECHA_INICIO_VIGENCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de inicio de vigencia',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'FECHA_INICIO_VIGENCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_FIN_VIGENCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'FECHA_FIN_VIGENCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de fin de vigencia',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'FECHA_FIN_VIGENCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_laboral')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'regimen_laboral', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: REGIMEN_PENSIONARIO                                   */
/*==============================================================*/
create table dbo.regimen_pensionario (
   ID_REGIMEN_PENSIONARIO int                  not null,
   ID_TIPO_RETENCION_TRIBUTARIA int                  null,
   CODIGO_REGIMEN_PENSIONARIO int                  not null,
   DESCRIPCION_REGIMEN_PENSIONARIO varchar(100)         not null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_REGIMEN_PENSIONARIO_ESCALAFON primary key (ID_REGIMEN_PENSIONARIO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.regimen_pensionario') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'regimen_pensionario' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene los registros de los regímenes pensionarios', 
   'user', 'dbo', 'table', 'regimen_pensionario'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_REGIMEN_PENSIONARIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'ID_REGIMEN_PENSIONARIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado regimen pensionario',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'ID_REGIMEN_PENSIONARIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_TIPO_RETENCION_TRIBUTARIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'ID_TIPO_RETENCION_TRIBUTARIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Titpo retención tribuitaria
   1	- ALIMENTO
   2	- DEUDA
   3	- OTROS
   ',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'ID_TIPO_RETENCION_TRIBUTARIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_REGIMEN_PENSIONARIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'CODIGO_REGIMEN_PENSIONARIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único del régimen pensionario',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'CODIGO_REGIMEN_PENSIONARIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_REGIMEN_PENSIONARIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'DESCRIPCION_REGIMEN_PENSIONARIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Nombre del régimen pensionario escalafón. Ejm: Sistema Privado de pensiones',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'DESCRIPCION_REGIMEN_PENSIONARIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro.',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP del creador del registro',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.regimen_pensionario')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP modificador del registro',
   'user', 'dbo', 'table', 'regimen_pensionario', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: SERVIDOR_PUBLICO                                      */
/*==============================================================*/
create table dbo.servidor_publico (
   ID_SERVIDOR_PUBLICO  bigint               not null,
   ID_PERSONA           int                  not null,
   ID_REGIMEN_LABORAL   int                  not null,
   ID_SITUACION_LABORAL int                  not null,
   ID_CONDICION_LABORAL int                  not null,
   ID_AFP               int                  null,
   ID_REGIMEN_PENSIONARIO int                  null,
   ID_CARGO             int                  null,
   ID_JORNADA_LABORAL   int                  null,
   ID_CATEGORIA_REMUNERATIVA int                  null,
   ID_CENTRO_TRABAJO    int                  null,
   ID_TIPO_COMISION_AFP int                  null,
   CODIGO_SERVIDOR_PUBLICO bigint               not null,
   CODIGO_PLAZA         char(12)             null,
   CUSPP                varchar(20)          null,
   FECHA_INGRESO_SPP    date                 null,
   FECHA_INICIO_VINCULACION date                 null,
   FECHA_FIN_VINCULACION date                 null,
   FECHA_CESE           date                 null,
   ES_PERMANENTE        bit                  not null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_SERVIDOR_PUBLICO primary key (ID_SERVIDOR_PUBLICO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.servidor_publico') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'servidor_publico' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene la información del servidor público (situación actual)', 
   'user', 'dbo', 'table', 'servidor_publico'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_SERVIDOR_PUBLICO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_SERVIDOR_PUBLICO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del servidor público',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_SERVIDOR_PUBLICO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PERSONA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_PERSONA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado persona ',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_PERSONA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_REGIMEN_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_REGIMEN_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado régimen laboral',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_REGIMEN_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_SITUACION_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_SITUACION_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Situación del Servidor Público
   
   EN ACTIVIDAD
   DESTACADO
   REASIGNADO
   ENCARGADO
   DESIGNADO
   CESADO
   EN ABANDONO DE CARGO
   CON SANCIÓN
   CON LICENCIA CON GOCE
   CON LICENCIA SIN GOCE
   
   
   ',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_SITUACION_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CONDICION_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_CONDICION_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Condición Laboral
   1= NOMBRADO
   2= CONTRATADO',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_CONDICION_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_AFP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_AFP'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la administradora de fondos de pensiones.',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_AFP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_REGIMEN_PENSIONARIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_REGIMEN_PENSIONARIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado regimen pensionario',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_REGIMEN_PENSIONARIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CARGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_CARGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado cargo.',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_CARGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_JORNADA_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_JORNADA_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la jornada laboral',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_JORNADA_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CATEGORIA_REMUNERATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_CATEGORIA_REMUNERATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la categoría remunerativa.',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_CATEGORIA_REMUNERATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CENTRO_TRABAJO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_CENTRO_TRABAJO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del centro de trabajo.',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_CENTRO_TRABAJO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_TIPO_COMISION_AFP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_TIPO_COMISION_AFP'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo
   1= FLUJO
   2= MIXTA',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ID_TIPO_COMISION_AFP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_SERVIDOR_PUBLICO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'CODIGO_SERVIDOR_PUBLICO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único del servidor público (Correlativo)',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'CODIGO_SERVIDOR_PUBLICO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_PLAZA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'CODIGO_PLAZA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código de plaza
   ',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'CODIGO_PLAZA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CUSPP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'CUSPP'

end


execute sp_addextendedproperty 'MS_Description', 
   'Número CUSPP del Servidor Público',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'CUSPP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_INGRESO_SPP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_INGRESO_SPP'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de ingreso del SPP del Servidor Público',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_INGRESO_SPP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_INICIO_VINCULACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_INICIO_VINCULACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de inicio de vinculación del Servidor Público',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_INICIO_VINCULACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_FIN_VINCULACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_FIN_VINCULACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de fin de vinculación del Servidor Público',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_FIN_VINCULACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CESE')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_CESE'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de cese del Servidor Público',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_CESE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ES_PERMANENTE')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ES_PERMANENTE'

end


execute sp_addextendedproperty 'MS_Description', 
   'Valores:
   0= Temporal
   1= Permanente',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ES_PERMANENTE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'servidor_publico', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Index: IX_SERVIDOR_PUBLICO_001                               */
/*==============================================================*/




create unique nonclustered index ix_servidor_publico_001 on dbo.servidor_publico (CODIGO_SERVIDOR_PUBLICO ASC)
go

/*==============================================================*/
/* Table: SERVIDOR_PUBLICO_TEMPORAL                             */
/*==============================================================*/
create table dbo.servidor_publico_temporal (
   ID_SERVIDOR_PUBLICO_TEMPORAL bigint               not null,
   ID_SERVIDOR_PUBLICO  bigint               not null,
   ID_PERSONA           int                  not null,
   ID_REGIMEN_LABORAL   int                  not null,
   ID_SITUACION_LABORAL int                  not null,
   ID_CONDICION_LABORAL int                  not null,
   ID_AFP               int                  null,
   ID_REGIMEN_PENSIONARIO int                  null,
   ID_CARGO             int                  null,
   ID_JORNADA_LABORAL   int                  null,
   ID_CATEGORIA_REMUNERATIVA int                  null,
   ID_CENTRO_TRABAJO    int                  null,
   ID_TIPO_COMISION_AFP int                  null,
   CODIGO_SERVIDOR_PUBLICO bigint               not null,
   CODIGO_PLAZA         char(12)             null,
   CUSPP                varchar(20)          null,
   FECHA_INGRESO_SPP    date                 null,
   FECHA_INICIO_VINCULACION date                 null,
   FECHA_FIN_VINCULACION date                 null,
   FECHA_CESE           date                 null,
   ES_PERMANENTE        bit                  not null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_SERVIDOR_PUBLICO_TEMPORAL primary key (ID_SERVIDOR_PUBLICO_TEMPORAL)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.servidor_publico_temporal') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'servidor_publico_temporal' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene la información de las acciones del servidor público de forma temporal. Se borra físicamente cuando finaliza la acción temporal.', 
   'user', 'dbo', 'table', 'servidor_publico_temporal'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_SERVIDOR_PUBLICO_TEMPORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_SERVIDOR_PUBLICO_TEMPORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del servidor público',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_SERVIDOR_PUBLICO_TEMPORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_SERVIDOR_PUBLICO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_SERVIDOR_PUBLICO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del servidor público',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_SERVIDOR_PUBLICO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PERSONA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_PERSONA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado persona ',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_PERSONA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_REGIMEN_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_REGIMEN_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado régimen laboral',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_REGIMEN_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_SITUACION_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_SITUACION_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Situación del Servidor Público
   
   EN ACTIVIDAD
   DESTACADO
   REASIGNADO
   ENCARGADO
   DESIGNADO
   CESADO
   EN ABANDONO DE CARGO
   CON SANCIÓN
   CON LICENCIA CON GOCE
   CON LICENCIA SIN GOCE',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_SITUACION_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CONDICION_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_CONDICION_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Condición Laboral
   1= NOMBRADO
   2= CONTRATADO',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_CONDICION_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_AFP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_AFP'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la administradora de fondos de pensiones.',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_AFP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_REGIMEN_PENSIONARIO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_REGIMEN_PENSIONARIO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado regimen pensionario',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_REGIMEN_PENSIONARIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CARGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_CARGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado cargo.',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_CARGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_JORNADA_LABORAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_JORNADA_LABORAL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la jornada laboral',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_JORNADA_LABORAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CATEGORIA_REMUNERATIVA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_CATEGORIA_REMUNERATIVA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la categoría remunerativa.',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_CATEGORIA_REMUNERATIVA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_CENTRO_TRABAJO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_CENTRO_TRABAJO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del centro de trabajo.',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_CENTRO_TRABAJO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_TIPO_COMISION_AFP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_TIPO_COMISION_AFP'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo
   1= FLUJO
   2= MIXTA',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ID_TIPO_COMISION_AFP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_SERVIDOR_PUBLICO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'CODIGO_SERVIDOR_PUBLICO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único del servidor público (Correlativo)',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'CODIGO_SERVIDOR_PUBLICO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_PLAZA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'CODIGO_PLAZA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código de plaza
   ',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'CODIGO_PLAZA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CUSPP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'CUSPP'

end


execute sp_addextendedproperty 'MS_Description', 
   'Número CUSPP del Servidor Público',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'CUSPP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_INGRESO_SPP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_INGRESO_SPP'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de ingreso del SPP del Servidor Público',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_INGRESO_SPP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_INICIO_VINCULACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_INICIO_VINCULACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de inicio de vinculación del Servidor Público',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_INICIO_VINCULACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_FIN_VINCULACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_FIN_VINCULACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de fin de vinculación del Servidor Público',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_FIN_VINCULACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CESE')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_CESE'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de cese del Servidor Público',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_CESE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ES_PERMANENTE')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ES_PERMANENTE'

end


execute sp_addextendedproperty 'MS_Description', 
   'Valores:
   0= Temporal
   1= Permanente',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ES_PERMANENTE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.servidor_publico_temporal')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'servidor_publico_temporal', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Index: IX_SERVIDOR_PUBLICO_001                               */
/*==============================================================*/




create unique nonclustered index ix_servidor_publico_001 on dbo.servidor_publico_temporal (CODIGO_SERVIDOR_PUBLICO ASC)
go

/*==============================================================*/
/* Table: TIPO_CENTRO_TRABAJO                                   */
/*==============================================================*/
create table dbo.tipo_centro_trabajo (
   ID_TIPO_CENTRO_TRABAJO int                  not null,
   ID_NIVEL_INSTANCIA   int                  not null,
   TIENE_ESTRUCTURA_ORGANICA bit                  not null,
   CODIGO_TIPO_CENTRO_TRABAJO varchar(4)           null,
   DESCRIPCION_TIPO_CENTRO_TRABAJO varchar(100)         null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_TIPO_CENTRO_TRABAJO primary key (ID_TIPO_CENTRO_TRABAJO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.tipo_centro_trabajo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'tipo_centro_trabajo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Tabla que contiene los tipo de centro de trabajo, tales como:
   * Sede administrativa MINEDU
   * Colegio alto rendimiento
   * Sede admnistrativa DRE
   * DRE Institucion Educativa
   * DRE Instituto Superior
   * Sede administratiiva UGEL
   * UGEL Institucion Educativa', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_TIPO_CENTRO_TRABAJO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'ID_TIPO_CENTRO_TRABAJO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del tipo de centro de trabajo',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'ID_TIPO_CENTRO_TRABAJO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_NIVEL_INSTANCIA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'ID_NIVEL_INSTANCIA'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Nivel instancia',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'ID_NIVEL_INSTANCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TIENE_ESTRUCTURA_ORGANICA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'TIENE_ESTRUCTURA_ORGANICA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador lógico que determina si posee estructura organizacional.',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'TIENE_ESTRUCTURA_ORGANICA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_TIPO_CENTRO_TRABAJO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'CODIGO_TIPO_CENTRO_TRABAJO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código asignado al tipo de centro de trabajo.',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'CODIGO_TIPO_CENTRO_TRABAJO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_TIPO_CENTRO_TRABAJO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'DESCRIPCION_TIPO_CENTRO_TRABAJO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción que identifica a un tipo de centro de trabajo.',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'DESCRIPCION_TIPO_CENTRO_TRABAJO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.tipo_centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'tipo_centro_trabajo', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: UGEL                                                  */
/*==============================================================*/
create table dbo.ugel (
   ID_UGEL              int                  not null,
   ID_DRE               int                  not null,
   ID_UNIDAD_EJECUTORA  int                  not null,
   ID_SERVIDOR_PUBLICO_DIRECTOR bigint               null,
   ID_DISTRITO          int                  null,
   CODIGO_UGEL          varchar(10)          not null,
   DESCRIPCION_UGEL     varchar(500)         not null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_UGEL primary key (ID_UGEL)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.ugel') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'ugel' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Contiene el listado de las ugeles.', 
   'user', 'dbo', 'table', 'ugel'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_UGEL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'ID_UGEL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de DRE',
   'user', 'dbo', 'table', 'ugel', 'column', 'ID_UGEL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DRE')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'ID_DRE'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de UGEL',
   'user', 'dbo', 'table', 'ugel', 'column', 'ID_DRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_UNIDAD_EJECUTORA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'ID_UNIDAD_EJECUTORA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la unidad ejecutora.',
   'user', 'dbo', 'table', 'ugel', 'column', 'ID_UNIDAD_EJECUTORA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_SERVIDOR_PUBLICO_DIRECTOR')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'ID_SERVIDOR_PUBLICO_DIRECTOR'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado del servidor público',
   'user', 'dbo', 'table', 'ugel', 'column', 'ID_SERVIDOR_PUBLICO_DIRECTOR'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DISTRITO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'ID_DISTRITO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID del distrito',
   'user', 'dbo', 'table', 'ugel', 'column', 'ID_DISTRITO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_UGEL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'CODIGO_UGEL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de UGEL',
   'user', 'dbo', 'table', 'ugel', 'column', 'CODIGO_UGEL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_UGEL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'DESCRIPCION_UGEL'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción de UGEL',
   'user', 'dbo', 'table', 'ugel', 'column', 'DESCRIPCION_UGEL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'ugel', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'ugel', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'ugel', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de creador del registro',
   'user', 'dbo', 'table', 'ugel', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'ugel', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'ugel', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ugel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ugel', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificador del registro',
   'user', 'dbo', 'table', 'ugel', 'column', 'IP_MODIFICACION'
go

/*==============================================================*/
/* Table: UNIDAD_EJECUTORA                                      */
/*==============================================================*/
create table dbo.unidad_ejecutora (
   ID_UNIDAD_EJECUTORA  int                  not null,
   ID_PLIEGO            int                  not null,
   CODIGO_UNIDAD_EJECUTORA varchar(10)          not null,
   SECUENCIA_UNIDAD_EJECUTORA int                  not null,
   DESCRIPCION_UNIDAD_EJECUTORA varchar(100)         not null,
   ACTIVO               bit                  not null,
   FECHA_CREACION       datetime             not null,
   USUARIO_CREACION     varchar(20)          not null,
   IP_CREACION          varchar(40)          not null,
   FECHA_MODIFICACION   datetime             null,
   USUARIO_MODIFICACION varchar(20)          null,
   IP_MODIFICACION      varchar(40)          null,
   constraint PK_UNIDAD_EJECUTORA primary key (ID_UNIDAD_EJECUTORA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.unidad_ejecutora') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'unidad_ejecutora' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'Lista las unidades ejecutoras', 
   'user', 'dbo', 'table', 'unidad_ejecutora'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_UNIDAD_EJECUTORA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'ID_UNIDAD_EJECUTORA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la unidad ejecutora.',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'ID_UNIDAD_EJECUTORA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PLIEGO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'ID_PLIEGO'

end


execute sp_addextendedproperty 'MS_Description', 
   'ID correlativo del item del catálogo Pliego',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'ID_PLIEGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CODIGO_UNIDAD_EJECUTORA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'CODIGO_UNIDAD_EJECUTORA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Código único de la unidad ejecutora',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'CODIGO_UNIDAD_EJECUTORA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SECUENCIA_UNIDAD_EJECUTORA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'SECUENCIA_UNIDAD_EJECUTORA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Secuencia unidad ejecutora',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'SECUENCIA_UNIDAD_EJECUTORA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCRIPCION_UNIDAD_EJECUTORA')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'DESCRIPCION_UNIDAD_EJECUTORA'

end


execute sp_addextendedproperty 'MS_Description', 
   'Descripción de la unidad ejecutora',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'DESCRIPCION_UNIDAD_EJECUTORA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ACTIVO')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'ACTIVO'

end


execute sp_addextendedproperty 'MS_Description', 
   'Indicador de inactividad del registro.',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'ACTIVO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'FECHA_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creación del registro',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'USUARIO_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario creador del registro',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'USUARIO_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_CREACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'IP_CREACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP creador del registro',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'IP_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FECHA_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'FECHA_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de modificación del registro',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'FECHA_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USUARIO_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'USUARIO_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario que modifica el registro',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'USUARIO_MODIFICACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.unidad_ejecutora')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP_MODIFICACION')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'IP_MODIFICACION'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP de modificación del registro',
   'user', 'dbo', 'table', 'unidad_ejecutora', 'column', 'IP_MODIFICACION'
go

alter table dbo.afp
   add constraint FK_AFP_REGIMEN_PENSIONARIO foreign key (ID_REGIMEN_PENSIONARIO)
      references dbo.regimen_pensionario (ID_REGIMEN_PENSIONARIO)
go

alter table dbo.cargo
   add constraint FK_CARGO_REGIMEN_LABORAL foreign key (ID_REGIMEN_LABORAL)
      references dbo.regimen_laboral (ID_REGIMEN_LABORAL)
go

alter table dbo.carrera_profesional
   add constraint FK_CARRERA_PROFESIONAL_CATALOGO_ITEM_GRUPO_CARRERA foreign key (ID_GRUPO_CARRERA)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.catalogo_item
   add constraint FK_CATALOGO_ITEM_CATALOGO foreign key (ID_CATALOGO)
      references dbo.catalogo (ID_CATALOGO)
go

alter table dbo.centro_estudio
   add constraint FK_CENTRO_ESTUDIO_CATALOGO_ITEM_NIVEL_CENTRO_ESTUDIO foreign key (ID_NIVEL_CENTRO_ESTUDIO)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.centro_estudio
   add constraint FK_CENTRO_ESTUDIO_DEPATAMENTO foreign key (ID_DEPARTAMENTO)
      references dbo.departamento (ID_DEPARTAMENTO)
go

alter table dbo.centro_estudio
   add constraint FK_CENTRO_ESTUDIO_DISTRITO foreign key (ID_DISTRITO)
      references dbo.distrito (ID_DISTRITO)
go

alter table dbo.centro_estudio
   add constraint FK_CENTRO_ESTUDIO_PAIS foreign key (ID_PAIS)
      references dbo.pais (ID_PAIS)
go

alter table dbo.centro_estudio
   add constraint FK_CENTRO_ESTUDIO_PROVINCIA foreign key (ID_PROVINCIA)
      references dbo.provincia (ID_PROVINCIA)
go

alter table dbo.centro_trabajo
   add constraint FK_CENTRO_TRABAJO_DRE foreign key (ID_DRE)
      references dbo.dre (ID_DRE)
go

alter table dbo.centro_trabajo
   add constraint FK_CENTRO_TRABAJO_INSTITUCION_EDUCATIVA foreign key (ID_INSTITUCION_EDUCATIVA)
      references dbo.institucion_educativa (ID_INSTITUCION_EDUCATIVA)
go

alter table dbo.centro_trabajo
   add constraint FK_CENTRO_TRABAJO_OTRA_INSTANCIA foreign key (ID_OTRA_INSTANCIA)
      references dbo.otra_instancia (ID_OTRA_INSTANCIA)
go

alter table dbo.centro_trabajo
   add constraint FK_CENTRO_TRABAJO_TIPO_CENTRO_TRABAJO foreign key (ID_TIPO_CENTRO_TRABAJO)
      references dbo.tipo_centro_trabajo (ID_TIPO_CENTRO_TRABAJO)
go

alter table dbo.centro_trabajo
   add constraint FK_CENTRO_TRABAJO_UGEL foreign key (ID_UGEL)
      references dbo.ugel (ID_UGEL)
go

alter table dbo.distrito
   add constraint FK_DISTRITO_DEPARTAMENTO foreign key (ID_DEPARTAMENTO)
      references dbo.departamento (ID_DEPARTAMENTO)
go

alter table dbo.distrito
   add constraint FK_DISTRITO_PROVINCIA foreign key (ID_PROVINCIA)
      references dbo.provincia (ID_PROVINCIA)
go

alter table dbo.dre
   add constraint FK_DRE_DISTRITO foreign key (ID_DISTRITO)
      references dbo.distrito (ID_DISTRITO)
go

alter table dbo.dre
   add constraint FK_DRE_SERVIDOR_PUBLICO foreign key (ID_SERVIDOR_PUBLICO_DIRECTOR)
      references dbo.servidor_publico (ID_SERVIDOR_PUBLICO)
go

alter table dbo.dre
   add constraint FK_DRE_UNIDAD_EJECUTORA foreign key (ID_UNIDAD_EJECUTORA)
      references dbo.unidad_ejecutora (ID_UNIDAD_EJECUTORA)
go

alter table dbo.especialidad_profesional
   add constraint FK_ESPECIALIDAD_PROFESIONAL_CARRERA_PROFESIONAL foreign key (ID_CARRERA_PROFESIONAL)
      references dbo.carrera_profesional (ID_CARRERA_PROFESIONAL)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_CARRERA_PROFESIONAL foreign key (ID_CARRERA_PROFESIONAL)
      references dbo.carrera_profesional (ID_CARRERA_PROFESIONAL)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_CATALOGO_ITEM_COLEGIO_PROFESIONAL foreign key (ID_COLEGIO_PROFESIONAL)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_CATALOGO_ITEM_GRUPO_CARRERA foreign key (ID_GRUPO_CARRERA)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_CATALOGO_ITEM_NIVEL_CARRERA foreign key (ID_NIVEL_CARRERA)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_CATALOGO_ITEM_SITUACION_ACADEMICA foreign key (ID_SITUACION_ACADEMICA)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_CENTRO_ESTUDIO foreign key (ID_CENTRO_ESTUDIO)
      references dbo.centro_estudio (ID_CENTRO_ESTUDIO)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_DEPARTAMENTO foreign key (ID_DEPARTAMENTO)
      references dbo.departamento (ID_DEPARTAMENTO)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_DISTRITO foreign key (ID_DISTRITO)
      references dbo.distrito (ID_DISTRITO)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_ESPECIALIDAD_PROFESIONAL foreign key (ID_ESPECIALIDAD_PROFESIONAL)
      references dbo.especialidad_profesional (ID_ESPECIALIDAD_PROFESIONAL)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_GRADO_INSTRUCCION foreign key (ID_GRADO_INSTRUCCION)
      references dbo.grado_instruccion (ID_GRADO_INSTRUCCION)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_PAIS foreign key (ID_PAIS)
      references dbo.pais (ID_PAIS)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_PROVINCIA foreign key (ID_PROVINCIA)
      references dbo.provincia (ID_PROVINCIA)
go

alter table dbo.formacion_academica
   add constraint FK_FORMACION_ACADEMICA_SERVIDOR_PUBLICO foreign key (ID_SERVIDOR_PUBLICO)
      references dbo.servidor_publico (ID_SERVIDOR_PUBLICO)
go

alter table dbo.institucion_educativa
   add constraint FK_INSTITUCION_EDUCATIVA_CATALOGO_ITEM_DEPENDENCIA_INSTITUCION_EDUCATIVA foreign key (ID_DEPENDENCIA_INSTITUCION_EDUCATIVA)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.institucion_educativa
   add constraint FK_INSTITUCION_EDUCATIVA_CATALOGO_ITEM_ID_TIPO_GESTION_INSTITUCION_EDUCATIVA foreign key (ID_TIPO_GESTION_INSTITUCION_EDUCATIVA)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.institucion_educativa
   add constraint FK_INSTITUCION_EDUCATIVA_CATALOGO_ITEM_TIPO_INSTITUCION_EDUCATIVA foreign key (ID_TIPO_INSTITUCION_EDUCATIVA)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.institucion_educativa
   add constraint FK_INSTITUCION_EDUCATIVA_DRE foreign key (ID_DRE)
      references dbo.dre (ID_DRE)
go

alter table dbo.institucion_educativa
   add constraint FK_INSTITUCION_EDUCATIVA_NIVEL_EDUCATIVO foreign key (ID_NIVEL_EDUCATIVO)
      references dbo.nivel_educativo (ID_NIVEL_EDUCATIVO)
go

alter table dbo.institucion_educativa
   add constraint FK_INSTITUCION_EDUCATIVA_OTRA_INSTANCIA foreign key (ID_OTRA_INSTANCIA)
      references dbo.otra_instancia (ID_OTRA_INSTANCIA)
go

alter table dbo.institucion_educativa
   add constraint FK_INSTITUCION_EDUCATIVA_SERVIDOR_PUBLICO foreign key (ID_SERVIDOR_PUBLICO_DIRECTOR)
      references dbo.servidor_publico (ID_SERVIDOR_PUBLICO)
go

alter table dbo.institucion_educativa
   add constraint FK_INSTITUCION_EDUCATIVA_UGEL foreign key (ID_UGEL)
      references dbo.ugel (ID_UGEL)
go

alter table dbo.institucion_educativa
   add constraint FK_INSTITUCION_EDUCATIVA_UNIDAD_EJECUTORA foreign key (ID_UNIDAD_EJECUTORA)
      references dbo.unidad_ejecutora (ID_UNIDAD_EJECUTORA)
go

alter table dbo.jornada_laboral
   add constraint FK_JORNADA_LABORAL_CATALOGO_ITEM_TIPO_JORNADA_LABORAL foreign key (ID_TIPO_JORNADA_LABORAL)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.nivel_educativo
   add constraint FK_NIVEL_EDUCATIVO_MODALIDAD_EDUCATIVA foreign key (ID_MODALIDAD_EDUCATIVA)
      references dbo.modalidad_educativa (ID_MODALIDAD_EDUCATIVA)
go

alter table dbo.otra_instancia
   add constraint FK_OTRA_INSTANCIA_UNIDAD_EJECUTORA foreign key (ID_UNIDAD_EJECUTORA)
      references dbo.unidad_ejecutora (ID_UNIDAD_EJECUTORA)
go

alter table dbo.persona
   add constraint FK_PERSONA_CATALOGO_ITEM_ESTADO_CIVIL foreign key (ID_TIPO_DOCUMENTO_IDENTIDAD)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.persona
   add constraint FK_PERSONA_CATALOGO_ITEM_TIPO_DOCUMENTO_IDENTIDAD foreign key (ID_ESTADO_CIVIL)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.persona
   add constraint FK_PERSONA_CATALOGO_ITEM_TIPO_PERSONA foreign key (ID_TIPO_PERSONA)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.persona
   add constraint FK_PERSONA_POSTULANTE_CATALOGO_ITEM_ID_GENERO foreign key (ID_GENERO)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.provincia
   add constraint FK_PROVINCIA_DEPARTAMENTO foreign key (ID_DEPARTAMENTO)
      references dbo.departamento (ID_DEPARTAMENTO)
go

alter table dbo.regimen_laboral
   add constraint FK_REGIMEN_LABORAL_CATALOGO_ITEM_TIPO_RETENCION_TRIBUTARIA foreign key (ID_TIPO_RETENCION_TRIBUTARIA)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.regimen_pensionario
   add constraint FK_REGIMEN_PENSIONARIO_CATALOGO_ITEM_TIPO_RETENCION_TRIBUTARIA foreign key (ID_TIPO_RETENCION_TRIBUTARIA)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_AFP foreign key (ID_AFP)
      references dbo.afp (ID_AFP)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_CARGO_TITULAR foreign key (ID_CARGO)
      references dbo.cargo (ID_CARGO)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_CATALOGO_ITEM_CONDICION_LABORAL foreign key (ID_CONDICION_LABORAL)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_CATALOGO_ITEM_SITUACION_LABORAL_TITULAR foreign key (ID_SITUACION_LABORAL)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_CATALOGO_ITEM_TIPO_COMISION_AFP foreign key (ID_TIPO_COMISION_AFP)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_CATEGORIA_REMUNERATIVA foreign key (ID_CATEGORIA_REMUNERATIVA)
      references dbo.categoria_remunerativa (ID_CATEGORIA_REMUNERATIVA)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_CENTRO_TRABAJO foreign key (ID_CENTRO_TRABAJO)
      references dbo.centro_trabajo (ID_CENTRO_TRABAJO)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_JORNADA_LABORAL_TITULAR foreign key (ID_JORNADA_LABORAL)
      references dbo.jornada_laboral (ID_JORNADA_LABORAL)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_PERSONA foreign key (ID_PERSONA)
      references dbo.persona (ID_PERSONA)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_REGIMEN_LABORAL foreign key (ID_REGIMEN_LABORAL)
      references dbo.regimen_laboral (ID_REGIMEN_LABORAL)
go

alter table dbo.servidor_publico
   add constraint FK_SERVIDOR_PUBLICO_REGIMEN_PENSIONARIO foreign key (ID_REGIMEN_PENSIONARIO)
      references dbo.regimen_pensionario (ID_REGIMEN_PENSIONARIO)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_AFP foreign key (ID_AFP)
      references dbo.afp (ID_AFP)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_CARGO foreign key (ID_CARGO)
      references dbo.cargo (ID_CARGO)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_CATALOGO_ITEM_CONDICION_LABORAL foreign key (ID_CONDICION_LABORAL)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_CATALOGO_ITEM_SITUACION_LABORAL foreign key (ID_SITUACION_LABORAL)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_CATALOGO_ITEM_TIPO_COMISION_AFP foreign key (ID_TIPO_COMISION_AFP)
      references dbo.catalogo_item (ID_CATALOGO_ITEM)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_CATEGORIA_REMUNERATIVA foreign key (ID_CATEGORIA_REMUNERATIVA)
      references dbo.categoria_remunerativa (ID_CATEGORIA_REMUNERATIVA)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_CENTRO_TRABAJO foreign key (ID_CENTRO_TRABAJO)
      references dbo.centro_trabajo (ID_CENTRO_TRABAJO)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_JORNADA_LABORAL foreign key (ID_JORNADA_LABORAL)
      references dbo.jornada_laboral (ID_JORNADA_LABORAL)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_PERSONA foreign key (ID_PERSONA)
      references dbo.persona (ID_PERSONA)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_REGIMEN_LABORAL foreign key (ID_REGIMEN_LABORAL)
      references dbo.regimen_laboral (ID_REGIMEN_LABORAL)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_REGIMEN_PENSIONARIO foreign key (ID_REGIMEN_PENSIONARIO)
      references dbo.regimen_pensionario (ID_REGIMEN_PENSIONARIO)
go

alter table dbo.servidor_publico_temporal
   add constraint FK_SERVIDOR_PUBLICO_TEMPORAL_SERVIDOR_PUBLICO foreign key (ID_SERVIDOR_PUBLICO)
      references dbo.servidor_publico (ID_SERVIDOR_PUBLICO)
go

alter table dbo.ugel
   add constraint FK_UGEL_DISTRITO foreign key (ID_DISTRITO)
      references dbo.distrito (ID_DISTRITO)
go

alter table dbo.ugel
   add constraint FK_UGEL_DRE foreign key (ID_DRE)
      references dbo.dre (ID_DRE)
go

alter table dbo.ugel
   add constraint FK_UGEL_SERVIDOR_PUBLICO foreign key (ID_SERVIDOR_PUBLICO_DIRECTOR)
      references dbo.servidor_publico (ID_SERVIDOR_PUBLICO)
go

alter table dbo.ugel
   add constraint FK_UGEL_UNIDAD_EJECUTORA foreign key (ID_UNIDAD_EJECUTORA)
      references dbo.unidad_ejecutora (ID_UNIDAD_EJECUTORA)
go
