USE [db_ayni_personal_servidorpublico]
GO

alter table dbo.ugel add ES_UGEL bit null;
alter table dbo.dre add ES_DRE bit null;
alter table dbo.institucion_educativa add ID_DRE_ORIGINAL int null;
alter table dbo.institucion_educativa add ID_UGEL_ORIGINAL int null;
alter table dbo.institucion_educativa add constraint FK_INSTITUCION_EDUCATIVA_DRE_ORIGINAL foreign key (ID_DRE_ORIGINAL) references dbo.dre (ID_DRE);
alter table dbo.institucion_educativa add constraint FK_INSTITUCION_EDUCATIVA_UGEL_ORIGINAL foreign key (ID_UGEL_ORIGINAL) references dbo.ugel (ID_UGEL);
alter table dbo.centro_trabajo add ID_DRE_ORIGINAL int null;
alter table dbo.centro_trabajo add ID_UGEL_ORIGINAL int null;
alter table dbo.centro_trabajo add ID_INSTITUCION_EDUCATIVA_ORIGINAL int null;
alter table dbo.centro_trabajo add constraint FK_CENTRO_TRABAJO_DRE_ORIGINAL foreign key (ID_DRE_ORIGINAL) references dbo.dre (ID_DRE);
alter table dbo.centro_trabajo add constraint FK_CENTRO_TRABAJO_UGEL_ORIGINAL foreign key (ID_UGEL_ORIGINAL) references dbo.ugel (ID_UGEL);
alter table dbo.centro_trabajo add constraint FK_CENTRO_TRABAJO_INSTITUCION_EDUCATIVA_ORIGINAL foreign key (ID_INSTITUCION_EDUCATIVA_ORIGINAL) references dbo.institucion_educativa (ID_INSTITUCION_EDUCATIVA);

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DRE_ORIGINAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_DRE_ORIGINAL'
end

execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la DRE de administración original',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_DRE_ORIGINAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.institucion_educativa')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_UGEL_ORIGINAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_UGEL_ORIGINAL'
end

execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la UGEL de administración original',
   'user', 'dbo', 'table', 'institucion_educativa', 'column', 'ID_UGEL_ORIGINAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DRE_ORIGINAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_DRE_ORIGINAL'
end

execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la DRE de administración original',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_DRE_ORIGINAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_UGEL_ORIGINAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_UGEL_ORIGINAL'
end

execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la UGEL de administración original',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_UGEL_ORIGINAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.centro_trabajo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_INSTITUCION_EDUCATIVA_ORIGINAL')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_INSTITUCION_EDUCATIVA_ORIGINAL'

end

execute sp_addextendedproperty 'MS_Description', 
   'Identificador autogenerado de la Institución educativa original',
   'user', 'dbo', 'table', 'centro_trabajo', 'column', 'ID_INSTITUCION_EDUCATIVA_ORIGINAL'
go
