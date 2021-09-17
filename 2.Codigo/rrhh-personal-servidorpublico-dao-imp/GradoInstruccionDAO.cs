using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class GradoInstruccionDAO : DAOBase, IGradoInstruccionDAO
    {
        public GradoInstruccionDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }


        public async Task<int> GetIdGradoInstruccionPorCodigo(int codigoGradoInstruccion)
        {
            const string sql = @"SELECT
                                        a.ID_GRADO_INSTRUCCION                                      
                                        FROM dbo.grado_instruccion a
                                        WHERE a.CODIGO_GRADO_INSTRUCCION = @CODIGO_GRADO_INSTRUCCION";

            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@CODIGO_GRADO_INSTRUCCION", SqlDbType.Int) {Value = codigoGradoInstruccion};
            SqlDataReader dr = null;
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parameter);
                if (!dr.HasRows) return 0;
                return dr.ReadAsync().Result ? SqlHelper.GetInt32(dr, 0) : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await SqlHelper.CloseDataReaderAsync(dr);
                await SqlHelper.CloseConnectionAsync(cn);
            }
        }

        public async Task<int> Crear(GradoInstruccionReplica request)
        {
            const string sql = @"insert into [dbo].[grado_instruccion](ID_GRADO_INSTRUCCION,
                                                          CODIGO_GRADO_INSTRUCCION,
                                                          CODIGO_ORIGEN_GRADO_INSTRUCCION,
                                                          DESCRIPCION_GRADO_INSTRUCCION,
                                                          ABREVIATURA_GRADO_INSTRUCCION,
                                                          ORDEN,
                                                          ACTIVO,
                                                          FECHA_CREACION,
                                                          USUARIO_CREACION,
                                                          IP_CREACION)
                                output inserted.ID_GRADO_INSTRUCCION
                                values (NEXT VALUE FOR dbo.seq_grado_instruccion,
                                        @CODIGO_GRADO_INSTRUCCION,
                                        @CODIGO_ORIGEN_GRADO_INSTRUCCION,
                                        @DESCRIPCION_GRADO_INSTRUCCION,
                                        @ABREVIATURA_GRADO_INSTRUCCION,
                                        @ORDEN,
                                        @ACTIVO,
                                        @FECHA_CREACION,
                                        @USUARIO_CREACION,
                                        @IP_CREACION)";

            SqlParameter[] parameter =
            {
                new SqlParameter("@CODIGO_GRADO_INSTRUCCION", SqlDbType.Int) {Value = request.codigoGradoInstruccion},
                new SqlParameter("@CODIGO_ORIGEN_GRADO_INSTRUCCION", SqlDbType.VarChar, 10) {Value = request.codigoOrigenGradoInstruccion},
                new SqlParameter("@DESCRIPCION_GRADO_INSTRUCCION", SqlDbType.VarChar, 100) {Value = request.descripcionGradoInstruccion},
                new SqlParameter("@ABREVIATURA_GRADO_INSTRUCCION", SqlDbType.VarChar, 100) {Value = request.abreviaturaGradoInstruccion},
                new SqlParameter("@ORDEN", SqlDbType.Int) {Value = request.orden},
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

        public async Task<int> Actualizar(GradoInstruccionReplica request)
        {
            const string sql = @"UPDATE a SET                                       
                                        a.CODIGO_ORIGEN_GRADO_INSTRUCCION = @CODIGO_ORIGEN_GRADO_INSTRUCCION,               
                                        a.DESCRIPCION_GRADO_INSTRUCCION = @DESCRIPCION_GRADO_INSTRUCCION,               
                                        a.ABREVIATURA_GRADO_INSTRUCCION = @ABREVIATURA_GRADO_INSTRUCCION,               
                                        a.ORDEN = @ORDEN,               
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[grado_instruccion] a
                                        WHERE a.ID_GRADO_INSTRUCCION = @ID_GRADO_INSTRUCCION ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_GRADO_INSTRUCCION", SqlDbType.Int) {Value = request.idGradoInstruccion},
                new SqlParameter("@CODIGO_ORIGEN_GRADO_INSTRUCCION", SqlDbType.VarChar,10) {Value = request.codigoOrigenGradoInstruccion},
                new SqlParameter("@DESCRIPCION_GRADO_INSTRUCCION", SqlDbType.VarChar, 100) {Value = request.descripcionGradoInstruccion},
                new SqlParameter("@ABREVIATURA_GRADO_INSTRUCCION", SqlDbType.VarChar, 100) {Value = request.abreviaturaGradoInstruccion},
                new SqlParameter("@ORDEN", SqlDbType.Int) {Value = request.orden},
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

        public async Task<int> Eliminar(GradoInstruccionReplica request)
        {
            const string sql = @" UPDATE a SET
                                        a.ACTIVO = @ACTIVO,
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[grado_instruccion] a
                                        WHERE a.ID_GRADO_INSTRUCCION = @ID_GRADO_INSTRUCCION ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_GRADO_INSTRUCCION", SqlDbType.Int) {Value = request.idGradoInstruccion},
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
    }
}