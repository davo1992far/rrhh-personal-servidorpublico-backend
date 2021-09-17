USE [db_ayni_personal_servidorpublico]
GO

insert into [dbo].[tipo_centro_trabajo] (ID_TIPO_CENTRO_TRABAJO, ID_NIVEL_INSTANCIA, TIENE_ESTRUCTURA_ORGANICA, CODIGO_TIPO_CENTRO_TRABAJO, DESCRIPCION_TIPO_CENTRO_TRABAJO, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_tipo_centro_trabajo], 8, 1, 1, 'SEDE MINEDU', 1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[tipo_centro_trabajo] (ID_TIPO_CENTRO_TRABAJO, ID_NIVEL_INSTANCIA, TIENE_ESTRUCTURA_ORGANICA, CODIGO_TIPO_CENTRO_TRABAJO, DESCRIPCION_TIPO_CENTRO_TRABAJO, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_tipo_centro_trabajo], 9, 1, 2, 'SEDE ADMINISTRATIVA DRE', 1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[tipo_centro_trabajo] (ID_TIPO_CENTRO_TRABAJO, ID_NIVEL_INSTANCIA, TIENE_ESTRUCTURA_ORGANICA, CODIGO_TIPO_CENTRO_TRABAJO, DESCRIPCION_TIPO_CENTRO_TRABAJO, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_tipo_centro_trabajo], 9, 0, 3, 'INSTITUCIÓN EDUCATIVA DRE', 1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[tipo_centro_trabajo] (ID_TIPO_CENTRO_TRABAJO, ID_NIVEL_INSTANCIA, TIENE_ESTRUCTURA_ORGANICA, CODIGO_TIPO_CENTRO_TRABAJO, DESCRIPCION_TIPO_CENTRO_TRABAJO, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_tipo_centro_trabajo], 9, 0, 4, 'INSTITUTO SUPERIOR DRE', 1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[tipo_centro_trabajo] (ID_TIPO_CENTRO_TRABAJO, ID_NIVEL_INSTANCIA, TIENE_ESTRUCTURA_ORGANICA, CODIGO_TIPO_CENTRO_TRABAJO, DESCRIPCION_TIPO_CENTRO_TRABAJO, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_tipo_centro_trabajo], 10, 1, 5, 'SEDE ADMINISTRATIVA UGEL', 1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[tipo_centro_trabajo] (ID_TIPO_CENTRO_TRABAJO, ID_NIVEL_INSTANCIA, TIENE_ESTRUCTURA_ORGANICA, CODIGO_TIPO_CENTRO_TRABAJO, DESCRIPCION_TIPO_CENTRO_TRABAJO, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_tipo_centro_trabajo], 10, 0, 6, 'INSTITUCIÓN EDUCATIVA UGEL', 1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[tipo_centro_trabajo] (ID_TIPO_CENTRO_TRABAJO, ID_NIVEL_INSTANCIA, TIENE_ESTRUCTURA_ORGANICA, CODIGO_TIPO_CENTRO_TRABAJO, DESCRIPCION_TIPO_CENTRO_TRABAJO, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_tipo_centro_trabajo], 10, 0, 7, 'INSTITUTO SUPERIOR UGEL', 1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[tipo_centro_trabajo] (ID_TIPO_CENTRO_TRABAJO, ID_NIVEL_INSTANCIA, TIENE_ESTRUCTURA_ORGANICA, CODIGO_TIPO_CENTRO_TRABAJO, DESCRIPCION_TIPO_CENTRO_TRABAJO, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_tipo_centro_trabajo], 14, 0, 8, 'SEDE CENTRO LABORAL DRE', 1, GETDATE(), 'ADMIN', 'SISTEMAS')
insert into [dbo].[tipo_centro_trabajo] (ID_TIPO_CENTRO_TRABAJO, ID_NIVEL_INSTANCIA, TIENE_ESTRUCTURA_ORGANICA, CODIGO_TIPO_CENTRO_TRABAJO, DESCRIPCION_TIPO_CENTRO_TRABAJO, ACTIVO, FECHA_CREACION, USUARIO_CREACION, IP_CREACION) values(NEXT VALUE FOR [dbo].[seq_tipo_centro_trabajo], 15, 0, 9, 'SEDE CENTRO LABORAL UGEL', 1, GETDATE(), 'ADMIN', 'SISTEMAS')

GO