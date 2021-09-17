USE [db_ayni_personal_servidorpublico]
GO

insert into [dbo].[modalidad_educativa] (ID_MODALIDAD_EDUCATIVA, CODIGO_MODALIDAD_EDUCATIVA, DESCRIPCION_MODALIDAD_EDUCATIVA, ABREVIATURA_MODALIDAD_EDUCATIVA, ORDEN, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_modalidad_educativa], 1, 'EDUCACIÓN BASICA REGULAR', 'EBR', CASE WHEN '1' ='NULL' THEN NULL ELSE '1' END,1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[modalidad_educativa] (ID_MODALIDAD_EDUCATIVA, CODIGO_MODALIDAD_EDUCATIVA, DESCRIPCION_MODALIDAD_EDUCATIVA, ABREVIATURA_MODALIDAD_EDUCATIVA, ORDEN, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_modalidad_educativa], 4, 'EDUCACIÓN BASICA ALTERNATIVA', 'EBA', CASE WHEN '2' ='NULL' THEN NULL ELSE '2' END,1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[modalidad_educativa] (ID_MODALIDAD_EDUCATIVA, CODIGO_MODALIDAD_EDUCATIVA, DESCRIPCION_MODALIDAD_EDUCATIVA, ABREVIATURA_MODALIDAD_EDUCATIVA, ORDEN, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_modalidad_educativa], 5, 'EDUCACIÓN BASICA ESPECIAL', 'EBE', CASE WHEN '3' ='NULL' THEN NULL ELSE '3' END,1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[modalidad_educativa] (ID_MODALIDAD_EDUCATIVA, CODIGO_MODALIDAD_EDUCATIVA, DESCRIPCION_MODALIDAD_EDUCATIVA, ABREVIATURA_MODALIDAD_EDUCATIVA, ORDEN, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_modalidad_educativa], 6, 'EDUCACIÓN SUPERIOR', 'SUP', CASE WHEN '4' ='NULL' THEN NULL ELSE '4' END,1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[modalidad_educativa] (ID_MODALIDAD_EDUCATIVA, CODIGO_MODALIDAD_EDUCATIVA, DESCRIPCION_MODALIDAD_EDUCATIVA, ABREVIATURA_MODALIDAD_EDUCATIVA, ORDEN, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_modalidad_educativa], 7, 'EDUCACIÓN TÉCNICA - PRODUCTIVA', 'ETP', CASE WHEN '5' ='NULL' THEN NULL ELSE '5' END,1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[modalidad_educativa] (ID_MODALIDAD_EDUCATIVA, CODIGO_MODALIDAD_EDUCATIVA, DESCRIPCION_MODALIDAD_EDUCATIVA, ABREVIATURA_MODALIDAD_EDUCATIVA, ORDEN, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_modalidad_educativa], 8, 'SEDE ADMINISTRATIVA', 'SEDE ADM.', CASE WHEN '6' ='NULL' THEN NULL ELSE '6' END,1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[modalidad_educativa] (ID_MODALIDAD_EDUCATIVA, CODIGO_MODALIDAD_EDUCATIVA, DESCRIPCION_MODALIDAD_EDUCATIVA, ABREVIATURA_MODALIDAD_EDUCATIVA, ORDEN, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_modalidad_educativa], 900, 'NO APLICA', '', CASE WHEN '7' ='NULL' THEN NULL ELSE '7' END,1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[modalidad_educativa] (ID_MODALIDAD_EDUCATIVA, CODIGO_MODALIDAD_EDUCATIVA, DESCRIPCION_MODALIDAD_EDUCATIVA, ABREVIATURA_MODALIDAD_EDUCATIVA, ORDEN, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_modalidad_educativa], 10, 'NO ESPECIFICADO', 'N.E.', CASE WHEN '8' ='NULL' THEN NULL ELSE '8' END,0, GETDATE(), 'ADMIN', 'SISTEMAS')

GO