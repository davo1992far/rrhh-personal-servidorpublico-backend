using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class UnidadEjecutoraDAO: DAOBase, IUnidadEjecutoraDAO
    {
        public UnidadEjecutoraDAO(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> BuscarUnidadEjecutoraCodigo(string codigoUnidadEjecutora)
        {
            int response = 0;
            const string sql = @" 
                        SELECT ID_UNIDAD_EJECUTORA
                        FROM [dbo].[unidad_ejecutora] WITH (NOLOCK) 
                        WHERE CODIGO_UNIDAD_EJECUTORA = @codigoUnidadEjecutora ";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@codigoUnidadEjecutora", SqlDbType.VarChar, 10) {Value = codigoUnidadEjecutora};

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

        public async Task<int> Crear(UnidadEjecutoraReplica request)
        {
            const string sql = @"
                insert into [dbo].[unidad_ejecutora](
                    ID_UNIDAD_EJECUTORA,
                    ID_PLIEGO,
					CODIGO_UNIDAD_EJECUTORA,
					SECUENCIA_UNIDAD_EJECUTORA,
					DESCRIPCION_UNIDAD_EJECUTORA,
					ACTIVO,
					FECHA_CREACION,
					USUARIO_CREACION,
					IP_CREACION	)
                output inserted.ID_UNIDAD_EJECUTORA
                values (
                    NEXT VALUE FOR dbo.seq_unidad_ejecutora,
					@ID_PLIEGO,
					@CODIGO_UNIDAD_EJECUTORA,
					@SECUENCIA_UNIDAD_EJECUTORA,
					@DESCRIPCION_UNIDAD_EJECUTORA,
					@ACTIVO,
					@FECHA_CREACION,
					@USUARIO_CREACION,
					@IP_CREACION
                )";

            SqlParameter[] parametro =
            {
                new SqlParameter("@ID_PLIEGO", SqlDbType.Int) {Value = request.idPliego},
                new SqlParameter("@CODIGO_UNIDAD_EJECUTORA", SqlDbType.VarChar, 10) {Value = request.codigoUnidadEjecutora},
                new SqlParameter("@SECUENCIA_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.secuenciaUnidadEjecutora},
                new SqlParameter("@DESCRIPCION_UNIDAD_EJECUTORA", SqlDbType.VarChar, 100) {Value = request.descripcionUnidadEjecutora},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = request.activo},
                new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime) {Value = request.fechaCreacion},
                new SqlParameter("@USUARIO_CREACION", SqlDbType.VarChar, 20) {Value = request.usuarioCreacion},
                new SqlParameter("@IP_CREACION", SqlDbType.VarChar, 40) {Value = request.ipCreacion}
            };

            TransactionBase tran = null;
            try
            {
                tran = await SqlHelper.BeginTransaction(txtConnectionString);

                var inserted = await SqlHelper.ExecuteScalarAsync(tran.connection, tran.transaction, CommandType.Text, sql, parametro);
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

        public async Task<int> Actualizar(UnidadEjecutoraReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ID_PLIEGO = @ID_PLIEGO,
                a.SECUENCIA_UNIDAD_EJECUTORA = @SECUENCIA_UNIDAD_EJECUTORA,
                a.DESCRIPCION_UNIDAD_EJECUTORA = @DESCRIPCION_UNIDAD_EJECUTORA,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[unidad_ejecutora] a
                WHERE a.ID_UNIDAD_EJECUTORA = @ID_UNIDAD_EJECUTORA";

            SqlParameter[] parametro =
            {
                new SqlParameter("@ID_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.idUnidadEjecutora},
                new SqlParameter("@ID_PLIEGO", SqlDbType.Int) {Value = request.idPliego},
                new SqlParameter("@SECUENCIA_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.secuenciaUnidadEjecutora},
                new SqlParameter("@DESCRIPCION_UNIDAD_EJECUTORA", SqlDbType.VarChar, 100) {Value = request.descripcionUnidadEjecutora},
                new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime) {Value = request.fechaModificacion},
                new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20) {Value = request.usuarioModificacion},
                new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40) {Value = request.ipModificacion}
            };

            TransactionBase tran = null;
            try
            {
                tran = await SqlHelper.BeginTransaction(txtConnectionString);
                int response = await SqlHelper.ExecuteNonQueryAsync(tran.connection, tran.transaction, CommandType.Text, sql, parametro);
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

        public async Task<int> Eliminar(UnidadEjecutoraReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[unidad_ejecutora] a
                WHERE a.ID_UNIDAD_EJECUTORA = @ID_UNIDAD_EJECUTORA";

            SqlParameter[] parametro =
            {
                new SqlParameter("@ID_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.idUnidadEjecutora},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = false},
                new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime) {Value = request.fechaModificacion},
                new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20) {Value = request.usuarioModificacion},
                new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40) {Value = request.ipModificacion}
            };

            TransactionBase tran = null;
            try
            {
                tran = await SqlHelper.BeginTransaction(txtConnectionString);
                int response = await SqlHelper.ExecuteNonQueryAsync(tran.connection, tran.transaction, CommandType.Text, sql, parametro);
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