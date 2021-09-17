using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class DreDAO : DAOBase, IDreDAO
    {
        public DreDAO(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> GetValidarDreId(int idDre, bool activo)
        {
            int response = 0;
            const string sql = @"SELECT  COUNT(1) registro 
                                FROM dbo.dre WITH (NOLOCK)
                                WHERE ID_DRE = @ID_DRE
                                    AND ACTIVO = @ACTIVO;";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@ID_DRE", SqlDbType.Int) {Value = idDre};
            parametro[1] = new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = activo};

            SqlDataReader dr = null;
            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                    if (dr.ReadAsync().Result)
                        response = SqlHelper.GetInt32(dr, 0);
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

            return response;
        }

        public async Task<int> GetIdDrePorCodigo(string codigoDre, bool activo)
        {
            const string sql = @"SELECT  ID_DRE 
                                FROM dbo.dre WITH (NOLOCK)
                                WHERE CODIGO_DRE = @CODIGO_DRE
                                    AND ACTIVO = @ACTIVO;";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@CODIGO_DRE", SqlDbType.VarChar,10) {Value = codigoDre};
            parametro[1] = new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = activo};

            SqlDataReader dr = null;
            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
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

        #region replica

        public async Task<int> Crear(DreReplica request)
        {
            const string sql = @"
                insert into [dbo].[dre](
                    ID_DRE,
                    ID_UNIDAD_EJECUTORA,
                    ID_SERVIDOR_PUBLICO_DIRECTOR,
                    ID_DISTRITO,
					CODIGO_DRE,
					DESCRIPCION_DRE,
					ACTIVO,
					FECHA_CREACION,
					USUARIO_CREACION,
					IP_CREACION)
                output inserted.ID_DRE
                values (
                    NEXT VALUE FOR dbo.seq_dre,
					@ID_UNIDAD_EJECUTORA,
					@ID_SERVIDOR_PUBLICO_DIRECTOR,
					@ID_DISTRITO,
					@CODIGO_DRE,
					@DESCRIPCION_DRE,
					@ACTIVO,
					@FECHA_CREACION,
					@USUARIO_CREACION,
					@IP_CREACION
                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.idUnidadEjecutora},
                new SqlParameter("@ID_SERVIDOR_PUBLICO_DIRECTOR", SqlDbType.BigInt) {Value = request.idServidorPublicoDirector},
                new SqlParameter("@ID_DISTRITO", SqlDbType.Int) {Value = request.idDistrito},
                new SqlParameter("@CODIGO_DRE", SqlDbType.VarChar, 10) {Value = request.codigoDre},
                new SqlParameter("@DESCRIPCION_DRE", SqlDbType.VarChar, 250) {Value = request.descripcionDre},
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

        public async Task<int> Actualizar(DreReplica request)
        {
            const string sql = @"
                UPDATE a SET
				a.ID_UNIDAD_EJECUTORA = @ID_UNIDAD_EJECUTORA,
				a.ID_SERVIDOR_PUBLICO_DIRECTOR = @ID_SERVIDOR_PUBLICO_DIRECTOR,
				a.ID_DISTRITO = @ID_DISTRITO,
				a.DESCRIPCION_DRE = @DESCRIPCION_DRE,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[dre] a
                WHERE a.ID_DRE = @ID_DRE ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.idUnidadEjecutora},
                new SqlParameter("@ID_SERVIDOR_PUBLICO_DIRECTOR", SqlDbType.BigInt) {Value = request.idServidorPublicoDirector},
                new SqlParameter("@ID_DISTRITO", SqlDbType.Int) {Value = request.idDistrito},
                new SqlParameter("@ID_DRE", SqlDbType.Int) {Value = request.idDre},
                new SqlParameter("@DESCRIPCION_DRE", SqlDbType.VarChar, 250) {Value = request.descripcionDre},
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

        public async Task<int> Eliminar(DreReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[dre] a
                WHERE a.ID_DRE = @ID_DRE ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_DRE", SqlDbType.Int) {Value = request.idDre},
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