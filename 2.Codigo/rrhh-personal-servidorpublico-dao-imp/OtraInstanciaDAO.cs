using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class OtraInstanciaDAO: DAOBase, IOtraInstanciaDAO
    {
        public OtraInstanciaDAO(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> GetIdOtraInstanciaPorCodigo(string codigoOtraEntidad, bool activo)
        {
            int response = 0;
            const string sql = @"SELECT  ID_OTRA_INSTANCIA
                                FROM dbo.otra_instancia WITH (NOLOCK)
                                WHERE CODIGO_OTRA_INSTANCIA = @CODIGO_OTRA_INSTANCIA
                                    AND ACTIVO = @ACTIVO;";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@CODIGO_OTRA_INSTANCIA", SqlDbType.VarChar, 10) {Value = codigoOtraEntidad};
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
        
        public async Task<int> Crear(OtraInstanciaReplica request)
        {
            const string sql = @"
                insert into [dbo].[otra_instancia](
                    ID_OTRA_INSTANCIA,
                    ID_UNIDAD_EJECUTORA,
					CODIGO_OTRA_INSTANCIA,
					DESCRIPCION_OTRA_INSTANCIA,
					ACTIVO,
					FECHA_CREACION,
					USUARIO_CREACION,
					IP_CREACION	)
                output inserted.ID_OTRA_INSTANCIA
                values (
                    NEXT VALUE FOR dbo.seq_otra_instancia,
					@ID_UNIDAD_EJECUTORA,
					@CODIGO_OTRA_INSTANCIA,
					@DESCRIPCION_OTRA_INSTANCIA,
					@ACTIVO,
					@FECHA_CREACION,
					@USUARIO_CREACION,
					@IP_CREACION
                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.idUnidadEjecutora},
                new SqlParameter("@CODIGO_OTRA_INSTANCIA", SqlDbType.VarChar, 10) {Value = request.codigoOtraInstancia},
                new SqlParameter("@DESCRIPCION_OTRA_INSTANCIA", SqlDbType.VarChar, 100) {Value = request.descripcionOtraInstancia},
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

        public async Task<int> Actualizar(OtraInstanciaReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ID_UNIDAD_EJECUTORA = @ID_UNIDAD_EJECUTORA,
                a.DESCRIPCION_OTRA_INSTANCIA = @DESCRIPCION_OTRA_INSTANCIA,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[otra_instancia] a
                WHERE a.ID_OTRA_INSTANCIA = @ID_OTRA_INSTANCIA ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_OTRA_INSTANCIA", SqlDbType.Int) {Value = request.idOtraInstancia},
                new SqlParameter("@ID_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.idUnidadEjecutora},
                new SqlParameter("@DESCRIPCION_OTRA_INSTANCIA", SqlDbType.VarChar, 100) {Value = request.descripcionOtraInstancia},
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

        public async Task<int> Eliminar(OtraInstanciaReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[otra_instancia] a
                WHERE a.ID_OTRA_INSTANCIA = @ID_OTRA_INSTANCIA ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_OTRA_INSTANCIA", SqlDbType.Int) {Value = request.idOtraInstancia},
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