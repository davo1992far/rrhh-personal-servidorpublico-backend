USE [db_ayni_personal_servidorpublico]
GO

INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '010000', case when '010000' = 'NULL' then NULL else '010000' end, 'AMAZONAS', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '020000', case when '020000' = 'NULL' then NULL else '020000' end, 'ANCASH', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '030000', case when '030000' = 'NULL' then NULL else '030000' end, 'APURIMAC', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '040000', case when '040000' = 'NULL' then NULL else '040000' end, 'AREQUIPA', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '050000', case when '050000' = 'NULL' then NULL else '050000' end, 'AYACUCHO', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '060000', case when '060000' = 'NULL' then NULL else '060000' end, 'CAJAMARCA', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '070000', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 'CALLAO', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '080000', case when '070000' = 'NULL' then NULL else '070000' end, 'CUSCO', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '090000', case when '080000' = 'NULL' then NULL else '080000' end, 'HUANCAVELICA', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '100000', case when '090000' = 'NULL' then NULL else '090000' end, 'HUANUCO', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '110000', case when '100000' = 'NULL' then NULL else '100000' end, 'ICA', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '120000', case when '110000' = 'NULL' then NULL else '110000' end, 'JUNIN', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '130000', case when '120000' = 'NULL' then NULL else '120000' end, 'LA LIBERTAD', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '140000', case when '130000' = 'NULL' then NULL else '130000' end, 'LAMBAYEQUE', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '150000', case when '140000' = 'NULL' then NULL else '140000' end, 'LIMA', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '160000', case when '150000' = 'NULL' then NULL else '150000' end, 'LORETO', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '170000', case when '160000' = 'NULL' then NULL else '160000' end, 'MADRE DE DIOS', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '180000', case when '170000' = 'NULL' then NULL else '170000' end, 'MOQUEGUA', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '190000', case when '180000' = 'NULL' then NULL else '180000' end, 'PASCO', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '200000', case when '190000' = 'NULL' then NULL else '190000' end, 'PIURA', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '210000', case when '200000' = 'NULL' then NULL else '200000' end, 'PUNO', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '220000', case when '210000' = 'NULL' then NULL else '210000' end, 'SAN MARTIN', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '230000', case when '220000' = 'NULL' then NULL else '220000' end, 'TACNA', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '240000', case when '230000' = 'NULL' then NULL else '230000' end, 'TUMBES', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())
INSERT INTO dbo.departamento(ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO_INEI,CODIGO_DEPARTAMENTO_RENIEC,DESCRIPCION,ABREVIATURA, ACTIVO,ELIMINADO,CODIGO_USUARIO_CREACION, FECHA_CREACION)  VALUES (NEXT VALUE FOR [dbo].[seq_departamento], '250000', case when '250000' = 'NULL' then NULL else '250000' end, 'UCAYALI', case when 'NULL' = 'NULL' then NULL else 'NULL' end, 1, 0, 'ADMIN', GETDATE())

GO