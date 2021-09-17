using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;
using minedu.tecnologia.util.lib.Exceptions;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class PersonaDAO : DAOBase, IPersonaDAO
    {
        public PersonaDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private Persona LlenarPersona(SqlDataReader dr)
        {
            Persona p = new Persona();

            int index = 0;

            p.idPersona = SqlHelper.GetInt32(dr, index++);
            p.idTipoPersona = SqlHelper.GetInt32(dr, index++);
            p.idGenero = SqlHelper.GetNullableInt32(dr, index++);
            p.idTipoDocumentoIdentidad = SqlHelper.GetInt32(dr, index++);
            p.idEstadoCivil = SqlHelper.GetNullableInt32(dr, index++);
            p.numeroDocumentoIdentidad = SqlHelper.GetNullableString(dr, index++);
            p.nombres = SqlHelper.GetNullableString(dr, index++);
            p.primerApellido = SqlHelper.GetNullableString(dr, index++);
            p.segundoApellido = SqlHelper.GetNullableString(dr, index++);
            p.fechaNacimiento = SqlHelper.GetDateTime(dr, index++);
            p.ultimaActualizacionReniec = SqlHelper.GetNullableDateTime(dr, index++);
            p.fechaConsultaReniec = SqlHelper.GetNullableDateTime(dr, index++);
            p.emailLaboral = SqlHelper.GetNullableString(dr, index++);
            p.emailPersonal = SqlHelper.GetNullableString(dr, index++);
            p.telefonoFijo = SqlHelper.GetNullableString(dr, index++);
            p.telefonoMovil = SqlHelper.GetNullableString(dr, index++);
            p.activo = SqlHelper.GetBoolean(dr, index++);
            p.fechaCreacion = SqlHelper.GetDateTime(dr, index++);
            p.usuarioCreacion = SqlHelper.GetString(dr, index++);
            p.ipCreacion = SqlHelper.GetString(dr, index++);
            p.fechaModificacion = SqlHelper.GetNullableDateTime(dr, index++);
            p.usuarioModificacion = SqlHelper.GetNullableString(dr, index++);
            p.ipModificacion = SqlHelper.GetNullableString(dr, index++);

            return p;
        }

        private PersonaReplica LlenarPersonaReplica(SqlDataReader dr)
        {
            PersonaReplica p = new PersonaReplica();

            int index = 0;

            p.idPersona = SqlHelper.GetInt32(dr, index++);
            p.idTipoPersona = SqlHelper.GetInt32(dr, index++);
            p.idGenero = SqlHelper.GetNullableInt32(dr, index++);
            p.idTipoDocumentoIdentidad = SqlHelper.GetInt32(dr, index++);
            p.idEstadoCivil = SqlHelper.GetNullableInt32(dr, index++);
            p.numeroDocumentoIdentidad = SqlHelper.GetNullableString(dr, index++);
            p.nombres = SqlHelper.GetNullableString(dr, index++);
            p.primerApellido = SqlHelper.GetNullableString(dr, index++);
            p.segundoApellido = SqlHelper.GetNullableString(dr, index++);
            p.fechaNacimiento = SqlHelper.GetDateTime(dr, index++);
            p.ultimaActualizacionReniec = SqlHelper.GetNullableDateTime(dr, index++);
            p.fechaConsultaReniec = SqlHelper.GetNullableDateTime(dr, index++);
            p.emailLaboral = SqlHelper.GetNullableString(dr, index++);
            p.emailPersonal = SqlHelper.GetNullableString(dr, index++);
            p.telefonoFijo = SqlHelper.GetNullableString(dr, index++);
            p.telefonoMovil = SqlHelper.GetNullableString(dr, index++);
            p.activo = SqlHelper.GetBoolean(dr, index++);
            p.codigoTipoPersona = SqlHelper.GetInt32(dr, index++);
            p.codigoTipoDocumentoIdentidad = SqlHelper.GetInt32(dr, index++);
            p.codigoEstadoCivil = SqlHelper.GetNullableInt32(dr, index++);
            p.codigoGenero = SqlHelper.GetNullableInt32(dr, index++);

            return p;
        }

        public async Task<Persona> GetPersonaPorId(int idPersona)
        {
            const string sql = @"SELECT
                                        p.ID_PERSONA,
                                        p.ID_TIPO_PERSONA,
                                        p.ID_GENERO,
                                        p.ID_TIPO_DOCUMENTO_IDENTIDAD,
                                        p.ID_ESTADO_CIVIL,                                      
                                        p.NUMERO_DOCUMENTO_IDENTIDAD,
                                        p.NOMBRES,
                                        p.PRIMER_APELLIDO,
                                        p.SEGUNDO_APELLIDO,
                                        p.FECHA_NACIMIENTO,
                                        p.ULTIMA_ACTUALIZACION_RENIEC,
                                        p.FECHA_CONSULTA_RENIEC,
                                        p.EMAIL_LABORAL,
                                        p.EMAIL_PERSONAL,
                                        p.TELEFONO_FIJO,
                                        p.TELEFONO_MOVIL,                                       
                                        p.ACTIVO,
                                        p.FECHA_CREACION,
                                        p.USUARIO_CREACION,
                                        p.IP_CREACION,
                                        p.FECHA_MODIFICACION,
                                        p.USUARIO_MODIFICACION,
                                        p.IP_MODIFICACION
                                        FROM dbo.persona p
                                        WHERE p.ID_PERSONA = @ID_PERSONA";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ID_PERSONA", SqlDbType.Int) {Value = idPersona};
            SqlDataReader dr = null;
            Persona p = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows) return null;
                if (dr.ReadAsync().Result)
                    p = LlenarPersona(dr);
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await SqlHelper.CloseDataReaderAsync(dr);
                await SqlHelper.CloseConnectionAsync(con);
            }
        }

        public async Task<Persona> GetPersonaPorDocumentoIdentidad(int idTipoDocumentoIdentidad, string numeroDocumentoIdentidad)
        {
            const string sql = @"SELECT
                                        p.ID_PERSONA,
                                        p.ID_TIPO_PERSONA,
                                        p.ID_GENERO,
                                        p.ID_TIPO_DOCUMENTO_IDENTIDAD,
                                        p.ID_ESTADO_CIVIL,                                    
                                        p.NUMERO_DOCUMENTO_IDENTIDAD,
                                        p.NOMBRES,
                                        p.PRIMER_APELLIDO,
                                        p.SEGUNDO_APELLIDO,
                                        p.FECHA_NACIMIENTO,
                                        p.ULTIMA_ACTUALIZACION_RENIEC,
                                        p.FECHA_CONSULTA_RENIEC,
                                        p.EMAIL_LABORAL,
                                        p.EMAIL_PERSONAL,
                                        p.TELEFONO_FIJO,
                                        p.TELEFONO_MOVIL,                                       
                                        p.ACTIVO,
                                        p.FECHA_CREACION,
                                        p.USUARIO_CREACION,
                                        p.IP_CREACION,
                                        p.FECHA_MODIFICACION,
                                        p.USUARIO_MODIFICACION,
                                        p.IP_MODIFICACION
                                        FROM dbo.persona p
                                        WHERE p.ID_TIPO_DOCUMENTO_IDENTIDAD = @ID_TIPO_DOCUMENTO_IDENTIDAD 
                                        AND p.NUMERO_DOCUMENTO_IDENTIDAD = @NUMERO_DOCUMENTO_IDENTIDAD";

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@ID_TIPO_DOCUMENTO_IDENTIDAD", SqlDbType.Int) {Value = idTipoDocumentoIdentidad};
            par[1] = new SqlParameter("@NUMERO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar, 12) {Value = numeroDocumentoIdentidad};
            SqlDataReader dr = null;
            Persona p = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows) return null;
                if (dr.ReadAsync().Result)
                    p = LlenarPersona(dr);
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await SqlHelper.CloseDataReaderAsync(dr);
                await SqlHelper.CloseConnectionAsync(con);
            }
        }

        public async Task<PersonaReplica> GetPersonaReplicaPorId(int idPersona)
        {
            var sql = @"SELECT
                                    p.ID_PERSONA,
                                    p.ID_TIPO_PERSONA,
                                    p.ID_GENERO,
                                    p.ID_TIPO_DOCUMENTO_IDENTIDAD,
                                    p.ID_ESTADO_CIVIL,                                   
                                    p.NUMERO_DOCUMENTO_IDENTIDAD,
                                    p.NOMBRES,
                                    p.PRIMER_APELLIDO,
                                    p.SEGUNDO_APELLIDO,
                                    p.FECHA_NACIMIENTO,
                                    p.ULTIMA_ACTUALIZACION_RENIEC,
                                    p.FECHA_CONSULTA_RENIEC,
                                    p.EMAIL_LABORAL,
                                    p.EMAIL_PERSONAL,
                                    p.TELEFONO_FIJO,
                                    p.TELEFONO_MOVIL,                                    
                                    p.ACTIVO, 
                                    (select ci.CODIGO_CATALOGO_ITEM from dbo.catalogo c inner join dbo.catalogo_item ci on c.ID_CATALOGO = ci.ID_CATALOGO where c.CODIGO_CATALOGO = " +
                      ((int) VariablesGlobales.TablaCatalogo.TIPO_PERSONA).ToString() + @" and ci.ID_CATALOGO_ITEM = p.ID_TIPO_PERSONA) as codigoTipoPersona,
                                    (select ci.CODIGO_CATALOGO_ITEM from dbo.catalogo c inner join dbo.catalogo_item ci on c.ID_CATALOGO = ci.ID_CATALOGO where c.CODIGO_CATALOGO = " +
                      ((int) VariablesGlobales.TablaCatalogo.TIPO_DOCUMENTO_IDENTIDAD).ToString() + @" and ci.ID_CATALOGO_ITEM = p.ID_TIPO_DOCUMENTO_IDENTIDAD) as codigoTipoDocumentoIdentidad,
                                    (select ci.CODIGO_CATALOGO_ITEM from dbo.catalogo c inner join dbo.catalogo_item ci on c.ID_CATALOGO = ci.ID_CATALOGO where c.CODIGO_CATALOGO = " +
                      ((int) VariablesGlobales.TablaCatalogo.ESTADO_CIVIL).ToString() + @" and ci.ID_CATALOGO_ITEM = p.ID_ESTADO_CIVIL) as codigoEstadoCivil,
                                    (select ci.CODIGO_CATALOGO_ITEM from dbo.catalogo c inner join dbo.catalogo_item ci on c.ID_CATALOGO = ci.ID_CATALOGO where c.CODIGO_CATALOGO = " +
                      ((int) VariablesGlobales.TablaCatalogo.GENERO_PERSONA).ToString() + @" and ci.ID_CATALOGO_ITEM = p.ID_GENERO) as codigoGenero
                                    FROM dbo.persona p		                               
                                    WHERE p.ID_PERSONA = @ID_PERSONA";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ID_PERSONA", SqlDbType.Int) {Value = idPersona};
            SqlDataReader dr = null;
            PersonaReplica p = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows) return null;
                if (dr.ReadAsync().Result)
                    p = LlenarPersonaReplica(dr);
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await SqlHelper.CloseDataReaderAsync(dr);
                await SqlHelper.CloseConnectionAsync(con);
            }
        }

        public async Task<PersonaReplica> GetPersonaReplicaPorDocumento(int idTipoDocumentoIdentidad, string numeroDocumentoIdentidad)
        {
            var sql = @"SELECT
                                    p.ID_PERSONA,
                                    p.ID_TIPO_PERSONA,
                                    p.ID_GENERO,
                                    p.ID_TIPO_DOCUMENTO_IDENTIDAD,
                                    p.ID_ESTADO_CIVIL,                                   
                                    p.NUMERO_DOCUMENTO_IDENTIDAD,
                                    p.NOMBRES,
                                    p.PRIMER_APELLIDO,
                                    p.SEGUNDO_APELLIDO,
                                    p.FECHA_NACIMIENTO,
                                    p.ULTIMA_ACTUALIZACION_RENIEC,
                                    p.FECHA_CONSULTA_RENIEC,
                                    p.EMAIL_LABORAL,
                                    p.EMAIL_PERSONAL,
                                    p.TELEFONO_FIJO,
                                    p.TELEFONO_MOVIL,                                    
                                    p.ACTIVO, 
                                    (select ci.CODIGO_CATALOGO_ITEM from dbo.catalogo c inner join dbo.catalogo_item ci on c.ID_CATALOGO = ci.ID_CATALOGO where c.CODIGO_CATALOGO = " +
                      ((int) VariablesGlobales.TablaCatalogo.TIPO_PERSONA).ToString() + @" and ci.ID_CATALOGO_ITEM = p.ID_TIPO_PERSONA) as codigoTipoPersona,
                                    (select ci.CODIGO_CATALOGO_ITEM from dbo.catalogo c inner join dbo.catalogo_item ci on c.ID_CATALOGO = ci.ID_CATALOGO where c.CODIGO_CATALOGO = " +
                      ((int) VariablesGlobales.TablaCatalogo.TIPO_DOCUMENTO_IDENTIDAD).ToString() + @" and ci.ID_CATALOGO_ITEM = p.ID_TIPO_DOCUMENTO_IDENTIDAD) as codigoTipoDocumentoIdentidad,
                                    (select ci.CODIGO_CATALOGO_ITEM from dbo.catalogo c inner join dbo.catalogo_item ci on c.ID_CATALOGO = ci.ID_CATALOGO where c.CODIGO_CATALOGO = " +
                      ((int) VariablesGlobales.TablaCatalogo.ESTADO_CIVIL).ToString() + @" and ci.ID_CATALOGO_ITEM = p.ID_ESTADO_CIVIL) as codigoEstadoCivil,
                                    (select ci.CODIGO_CATALOGO_ITEM from dbo.catalogo c inner join dbo.catalogo_item ci on c.ID_CATALOGO = ci.ID_CATALOGO where c.CODIGO_CATALOGO = " +
                      ((int) VariablesGlobales.TablaCatalogo.GENERO_PERSONA).ToString() + @" and ci.ID_CATALOGO_ITEM = p.ID_GENERO) as codigoGenero
                                    FROM dbo.persona p		                                
                                    WHERE p.ID_PERSONA = @ID_PERSONA";

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@ID_TIPO_DOCUMENTO_IDENTIDAD", SqlDbType.Int) {Value = idTipoDocumentoIdentidad};
            par[1] = new SqlParameter("@NUMERO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar, 12) {Value = numeroDocumentoIdentidad};
            SqlDataReader dr = null;
            PersonaReplica p = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows) return null;
                if (dr.ReadAsync().Result)
                    p = LlenarPersonaReplica(dr);
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await SqlHelper.CloseDataReaderAsync(dr);
                await SqlHelper.CloseConnectionAsync(con);
            }
        }


        #region replica

        public async Task<int> Crear(PersonaReplica request)
        {
            const string sql = @"
                insert into [dbo].[persona](
                    ID_PERSONA,
                    ID_TIPO_PERSONA,
                    ID_GENERO,
                    ID_TIPO_DOCUMENTO_IDENTIDAD,
                    ID_ESTADO_CIVIL,
                    NUMERO_DOCUMENTO_IDENTIDAD,
                    NOMBRES,
					PRIMER_APELLIDO,
					SEGUNDO_APELLIDO,
					FECHA_NACIMIENTO,
					ULTIMA_ACTUALIZACION_RENIEC,
					FECHA_CONSULTA_RENIEC,
					EMAIL_LABORAL,
					EMAIL_PERSONAL,
					TELEFONO_FIJO,
					TELEFONO_MOVIL,					
					ACTIVO,
					FECHA_CREACION,
					USUARIO_CREACION,
					IP_CREACION)
                output inserted.ID_PERSONA
                values (
                    NEXT VALUE FOR dbo.seq_persona,
					@ID_TIPO_PERSONA,
					@ID_GENERO,
					@ID_TIPO_DOCUMENTO_IDENTIDAD,
					@ID_ESTADO_CIVIL,
					@NUMERO_DOCUMENTO_IDENTIDAD,
					@NOMBRES,
					@PRIMER_APELLIDO,
					@SEGUNDO_APELLIDO,
					@FECHA_NACIMIENTO,
					@ULTIMA_ACTUALIZACION_RENIEC,
					@FECHA_CONSULTA_RENIEC,
					@EMAIL_LABORAL,
					@EMAIL_PERSONAL,
					@TELEFONO_FIJO,
					@TELEFONO_MOVIL,
					@ACTIVO,
					@FECHA_CREACION,
					@USUARIO_CREACION,
					@IP_CREACION
                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_TIPO_PERSONA", SqlDbType.Int) {Value = request.idTipoPersona},
                new SqlParameter("@ID_GENERO", SqlDbType.Int) {Value = request.idGenero},
                new SqlParameter("@ID_TIPO_DOCUMENTO_IDENTIDAD", SqlDbType.Int) {Value = request.idTipoDocumentoIdentidad},
                new SqlParameter("@ID_ESTADO_CIVIL", SqlDbType.Int) {Value = request.idEstadoCivil},
                new SqlParameter("@NUMERO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar, 12) {Value = request.numeroDocumentoIdentidad},
                new SqlParameter("@NOMBRES", SqlDbType.VarChar, 100) {Value = request.nombres},
                new SqlParameter("@PRIMER_APELLIDO", SqlDbType.VarChar, 100) {Value = request.primerApellido},
                new SqlParameter("@SEGUNDO_APELLIDO", SqlDbType.VarChar, 100) {Value = request.segundoApellido},
                new SqlParameter("@FECHA_NACIMIENTO", SqlDbType.Date) {Value = request.fechaNacimiento},
                new SqlParameter("@ULTIMA_ACTUALIZACION_RENIEC", SqlDbType.Date) {Value = request.ultimaActualizacionReniec},
                new SqlParameter("@FECHA_CONSULTA_RENIEC", SqlDbType.Date) {Value = request.fechaConsultaReniec},
                new SqlParameter("@EMAIL_LABORAL", SqlDbType.VarChar, 60) {Value = request.emailLaboral},
                new SqlParameter("@EMAIL_PERSONAL", SqlDbType.VarChar, 60) {Value = request.emailPersonal},
                new SqlParameter("@TELEFONO_FIJO", SqlDbType.VarChar, 10) {Value = request.telefonoFijo},
                new SqlParameter("@TELEFONO_MOVIL", SqlDbType.VarChar, 10) {Value = request.telefonoMovil},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = request.activo},
                new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime) {Value = request.fechaCreacion},
                new SqlParameter("@USUARIO_CREACION", SqlDbType.VarChar, 20) {Value = request.usuarioCreacion},
                new SqlParameter("@IP_CREACION", SqlDbType.VarChar, 40) {Value = request.ipCreacion}
            };

            TransactionBase tran = null;
            try
            {
                tran = await SqlHelper.BeginTransaction(txtConnectionString);

                var inserted = await SqlHelper.ExecuteScalarAsync(tran.connection, tran.transaction, CommandType.Text, sql, parameter);
                var response = Convert.ToInt32(inserted);
                if (response < 1)
                {
                    await tran.transaction.RollbackAsync();
                    return response;
                }

                await tran.transaction.CommitAsync();
                return response;
            }
            catch (Exception ex)
            {
                await SqlHelper.RollbackTransactionAsync(tran);
                throw ex;
            }
            finally
            {
                await SqlHelper.DisposeTransactionAsync(tran);
            }
        }

        public async Task<int> Actualizar(PersonaReplica request)
        {
            const string sql = @"
                                    UPDATE a
                                            SET a.ID_GENERO=@ID_GENERO,
                                                a.ID_TIPO_PERSONA=@ID_TIPO_PERSONA,
                                                a.ID_TIPO_DOCUMENTO_IDENTIDAD=@ID_TIPO_DOCUMENTO_IDENTIDAD,
                                                a.ID_ESTADO_CIVIL=@ID_ESTADO_CIVIL,
                                                a.NUMERO_DOCUMENTO_IDENTIDAD=@NUMERO_DOCUMENTO_IDENTIDAD,
                                                a.NOMBRES=@NOMBRES,
                                                a.PRIMER_APELLIDO=@PRIMER_APELLIDO,
                                                a.SEGUNDO_APELLIDO=@SEGUNDO_APELLIDO,
                                                a.FECHA_NACIMIENTO=@FECHA_NACIMIENTO,
                                                a.ULTIMA_ACTUALIZACION_RENIEC=@ULTIMA_ACTUALIZACION_RENIEC,
                                                a.FECHA_CONSULTA_RENIEC=@FECHA_CONSULTA_RENIEC,
                                                a.EMAIL_LABORAL=@EMAIL_LABORAL,
                                                a.EMAIL_PERSONAL=@EMAIL_PERSONAL,
                                                a.TELEFONO_FIJO=@TELEFONO_FIJO,
                                                a.TELEFONO_MOVIL=@TELEFONO_MOVIL,
                                                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                                a.IP_MODIFICACION = @IP_MODIFICACION
                                            FROM [dbo].[persona] a
                                            WHERE a.ID_PERSONA = @ID_PERSONA";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_PERSONA", SqlDbType.Int) {Value = request.idPersona},
                new SqlParameter("@ID_TIPO_PERSONA", SqlDbType.Int) {Value = request.idTipoPersona},
                new SqlParameter("@ID_GENERO", SqlDbType.Int) {Value = request.idGenero},
                new SqlParameter("@ID_TIPO_DOCUMENTO_IDENTIDAD", SqlDbType.Int) {Value = request.idTipoDocumentoIdentidad},
                new SqlParameter("@ID_ESTADO_CIVIL", SqlDbType.Int) {Value = request.idEstadoCivil},
                new SqlParameter("@NUMERO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar, 12) {Value = request.numeroDocumentoIdentidad},
                new SqlParameter("@NOMBRES", SqlDbType.VarChar, 100) {Value = request.nombres},
                new SqlParameter("@PRIMER_APELLIDO", SqlDbType.VarChar, 100) {Value = request.primerApellido},
                new SqlParameter("@SEGUNDO_APELLIDO", SqlDbType.VarChar, 100) {Value = request.segundoApellido},
                new SqlParameter("@FECHA_NACIMIENTO", SqlDbType.Date) {Value = request.fechaNacimiento},
                new SqlParameter("@ULTIMA_ACTUALIZACION_RENIEC", SqlDbType.Date) {Value = request.ultimaActualizacionReniec},
                new SqlParameter("@FECHA_CONSULTA_RENIEC", SqlDbType.Date) {Value = request.fechaConsultaReniec},
                new SqlParameter("@EMAIL_LABORAL", SqlDbType.VarChar, 60) {Value = request.emailLaboral},
                new SqlParameter("@EMAIL_PERSONAL", SqlDbType.VarChar, 60) {Value = request.emailPersonal},
                new SqlParameter("@TELEFONO_FIJO", SqlDbType.VarChar, 10) {Value = request.telefonoFijo},
                new SqlParameter("@TELEFONO_MOVIL", SqlDbType.VarChar, 10) {Value = request.telefonoMovil},
                new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime) {Value = request.fechaModificacion},
                new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20) {Value = request.usuarioModificacion},
                new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40) {Value = request.ipModificacion}
            };

            TransactionBase tran = null;
            try
            {
                tran = await SqlHelper.BeginTransaction(txtConnectionString);
                int response = await SqlHelper.ExecuteNonQueryAsync(tran.connection, tran.transaction, CommandType.Text, sql, parameter);
                if (response < 1)
                {
                    await tran.transaction.RollbackAsync();
                    return response;
                }

                await tran.transaction.CommitAsync();
                return response;
            }
            catch (Exception ex)
            {
                await SqlHelper.RollbackTransactionAsync(tran);
                throw ex;
            }
            finally
            {
                await SqlHelper.DisposeTransactionAsync(tran);
            }
        }

        public async Task<int> Eliminar(PersonaReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[persona] a
                WHERE a.ID_PERSONA = @ID_PERSONA ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_PERSONA", SqlDbType.Int) {Value = request.idPersona},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = false},
                new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime) {Value = request.fechaModificacion},
                new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20) {Value = request.usuarioModificacion},
                new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40) {Value = request.ipModificacion}
            };

            TransactionBase tran = null;
            try
            {
                tran = await SqlHelper.BeginTransaction(txtConnectionString);
                int response = await SqlHelper.ExecuteNonQueryAsync(tran.connection, tran.transaction, CommandType.Text, sql, parameter);
                if (response < 1)
                {
                    await tran.transaction.RollbackAsync();
                    return response;
                }

                await tran.transaction.CommitAsync();
                return response;
            }
            catch (Exception ex)
            {
                await SqlHelper.RollbackTransactionAsync(tran);
                throw ex;
            }
            finally
            {
                await SqlHelper.DisposeTransactionAsync(tran);
            }
        }

        #endregion
    }
}