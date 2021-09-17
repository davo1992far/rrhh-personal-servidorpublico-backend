USE [master]
GO

CREATE DATABASE [db_ayni_personal_servidorpublico]
COLLATE Latin1_General_CI_AI;
GO

ALTER DATABASE [db_ayni_personal_servidorpublico]
MODIFY FILE (NAME = db_ayni_personal_servidorpublico,
FILEGROWTH = 20%);
GO

ALTER DATABASE [db_ayni_personal_servidorpublico]
MODIFY FILE (NAME = db_ayni_personal_servidorpublico_log,
FILEGROWTH = 20%);
GO

CREATE LOGIN user_ayni_personal_servidorpublico
WITH PASSWORD = 'user_ayni_personal_servidorpublico',
DEFAULT_DATABASE = [db_ayni_personal_servidorpublico],
CHECK_POLICY = OFF
GO

USE [db_ayni_personal_servidorpublico]
GO

CREATE USER [user_ayni_personal_servidorpublico] FOR LOGIN [user_ayni_personal_servidorpublico]
GO

ALTER ROLE [db_owner] ADD MEMBER [user_ayni_personal_servidorpublico]
GO
