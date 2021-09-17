using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.tecnologia.util.lib;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class CategoriaRemunerativaDAO : DAOBase, ICategoriaRemunerativaDAO
    {
        public CategoriaRemunerativaDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private CategoriaRemunerativa LlenarCategoriaRemunerativa(SqlDataReader dr)
        {
            CategoriaRemunerativa c = new CategoriaRemunerativa();

            int index = 0;

            c.idCategoriaRemunerativa = SqlHelper.GetInt32(dr, index++);
            c.codigoCategoriaRemunerativa = SqlHelper.GetInt32(dr, index++);
            c.codigoOrigenCategoriaRemunerativa = SqlHelper.GetNullableString(dr, index++);
            c.descripcionCategoriaRemunerativa = SqlHelper.GetString(dr, index++);
            c.abreviaturaCategoriaRemunerativa = SqlHelper.GetNullableString(dr, index++);
            c.ordenCategoriaRemunerativa = SqlHelper.GetNullableInt32(dr, index++);
            c.esEscala = SqlHelper.GetBoolean(dr, index++);
            c.activo = SqlHelper.GetBoolean(dr, index++);

            return c;
        }

        public async Task<CategoriaRemunerativa> GetCategoriaRemunerativaPorCodigo(int codigoCategoriaRemunerativa)
        {
            const string sql = @"SELECT
                                        c.ID_CATEGORIA_REMUNERATIVA,
                                        c.CODIGO_CATEGORIA_REMUNERATIVA,
                                        c.CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA,
                                        c.DESCRIPCION_CATEGORIA_REMUNERATIVA,
                                        c.ABREVIATURA_CATEGORIA_REMUNERATIVA,
                                        c.ORDEN_CATEGORIA_REMUNERATIVA,
                                        c.ES_ESCALA,
                                        c.ACTIVO
                                        FROM dbo.categoria_remunerativa c
                                        WHERE c.CODIGO_CATEGORIA_REMUNERATIVA = @CODIGO_CATEGORIA_REMUNERATIVA";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@CODIGO_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = codigoCategoriaRemunerativa};
            SqlDataReader dr = null;
            CategoriaRemunerativa c = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows) return null;
                if (dr.ReadAsync().Result)
                    c = LlenarCategoriaRemunerativa(dr);
                return c;
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

        public async Task<int> Crear(CategoriaRemunerativaReplica request)
        {
            const string sql = @"
                insert into [dbo].[categoria_remunerativa](
                    ID_CATEGORIA_REMUNERATIVA,
					CODIGO_CATEGORIA_REMUNERATIVA,
					CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA,
					DESCRIPCION_CATEGORIA_REMUNERATIVA,
					ABREVIATURA_CATEGORIA_REMUNERATIVA,
					ORDEN_CATEGORIA_REMUNERATIVA,
					ES_ESCALA,
					ACTIVO,
					FECHA_CREACION,
					USUARIO_CREACION,
					IP_CREACION	)
                output inserted.ID_CATEGORIA_REMUNERATIVA
                values (
                    NEXT VALUE FOR dbo.seq_categoria_remunerativa,
					@CODIGO_CATEGORIA_REMUNERATIVA,
					@CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA,
					@DESCRIPCION_CATEGORIA_REMUNERATIVA,
					@ABREVIATURA_CATEGORIA_REMUNERATIVA,
					@ORDEN_CATEGORIA_REMUNERATIVA,
					@ES_ESCALA,
					@ACTIVO,
					@FECHA_CREACION,
					@USUARIO_CREACION,
					@IP_CREACION
                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@CODIGO_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = request.codigoCategoriaRemunerativa},
                new SqlParameter("@CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA", SqlDbType.VarChar, 10) {Value = request.codigoOrigenCategoriaRemunerativa},
                new SqlParameter("@DESCRIPCION_CATEGORIA_REMUNERATIVA", SqlDbType.VarChar, 50) {Value = request.descripcionCategoriaRemunerativa},
                new SqlParameter("@ABREVIATURA_CATEGORIA_REMUNERATIVA", SqlDbType.VarChar, 10) {Value = request.abreviaturaCategoriaRemunerativa},
                new SqlParameter("@ORDEN_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = request.ordenCategoriaRemunerativa},
                new SqlParameter("@ES_ESCALA", SqlDbType.Bit) {Value = request.esEscala},
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

        public async Task<int> Actualizar(CategoriaRemunerativaReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.CODIGO_CATEGORIA_REMUNERATIVA = @CODIGO_CATEGORIA_REMUNERATIVA,
                a.CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA = @CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA,
                a.DESCRIPCION_CATEGORIA_REMUNERATIVA = @DESCRIPCION_CATEGORIA_REMUNERATIVA,
                a.ABREVIATURA_CATEGORIA_REMUNERATIVA = @ABREVIATURA_CATEGORIA_REMUNERATIVA,
                a.ORDEN_CATEGORIA_REMUNERATIVA = @ORDEN_CATEGORIA_REMUNERATIVA,
                a.ES_ESCALA = @ES_ESCALA,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[categoria_remunerativa] a
                WHERE a.ID_CATEGORIA_REMUNERATIVA = @ID_CATEGORIA_REMUNERATIVA ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = request.idCategoriaRemunerativa},
                new SqlParameter("@CODIGO_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = request.codigoCategoriaRemunerativa},
                new SqlParameter("@CODIGO_ORIGEN_CATEGORIA_REMUNERATIVA", SqlDbType.VarChar, 10) {Value = request.codigoOrigenCategoriaRemunerativa},
                new SqlParameter("@DESCRIPCION_CATEGORIA_REMUNERATIVA", SqlDbType.VarChar, 50) {Value = request.descripcionCategoriaRemunerativa},
                new SqlParameter("@ABREVIATURA_CATEGORIA_REMUNERATIVA", SqlDbType.VarChar, 10) {Value = request.abreviaturaCategoriaRemunerativa},
                new SqlParameter("@ORDEN_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = request.ordenCategoriaRemunerativa},
                new SqlParameter("@ES_ESCALA", SqlDbType.Bit) {Value = request.esEscala},
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

        public async Task<int> Eliminar(CategoriaRemunerativaReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[categoria_remunerativa] a
                WHERE a.ID_CATEGORIA_REMUNERATIVA = @ID_CATEGORIA_REMUNERATIVA ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = request.idCategoriaRemunerativa},
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