USE master
GO

ALTER DATABASE [db_ayni_personal_servidorpublico]
SET SINGLE_USER
WITH ROLLBACK IMMEDIATE;
GO

drop DATABASE [db_ayni_personal_servidorpublico];
go

IF EXISTS (select loginname from master.dbo.syslogins 
    where name = 'user_ayni_personal_servidorpublico' and dbname = 'db_ayni_personal_servidorpublico')
Begin
    DROP LOGIN user_ayni_personal_servidorpublico;
end
