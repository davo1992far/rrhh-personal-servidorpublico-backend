using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class ModalidadEducativaDAO: DAOBase, IModalidadEducativaDAO
    {
        public ModalidadEducativaDAO(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> ActualizarReplica(ModalidadEducativaReplica request)
        {
            const String sql = @"UPDATE dbo.modalidad_educativa
                SET
            DESCRIPCION_MODALIDAD_EDUCATIVA = @DESCRIPCION_MODALIDAD_EDUCATIVA,
            ABREVIATURA_MODALIDAD_EDUCATIVA = @ABREVIATURA_MODALIDAD_EDUCATIVA,
            ORDEN = @ORDEN,
            ACTIVO = @ACTIVO,
            FECHA_MODIFICACION = @FECHA_MODIFICACION,
            USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
            IP_MODIFICACION = @IP_MODIFICACION
                WHERE
                    ID_MODALIDAD_EDUCATIVA = @ID_MODALIDAD_EDUCATIVA";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_MODALIDAD_EDUCATIVA", SqlDbType.Int) {Value = request.idModalidadEducativa},
                new SqlParameter("@DESCRIPCION_MODALIDAD_EDUCATIVA", SqlDbType.VarChar, 50) {Value = request.descripcionModalidadEducativa},
                new SqlParameter("@ABREVIATURA_MODALIDAD_EDUCATIVA", SqlDbType.VarChar, 10) {Value = request.abreviaturaModalidadEducativa},
                new SqlParameter("@ORDEN", SqlDbType.Int) {Value = request.orden},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = request.activo},
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

        public async Task<int> CrearReplica(ModalidadEducativaReplica request)
        {
            const String sql = @"INSERT INTO dbo.modalidad_educativa(
            ID_MODALIDAD_EDUCATIVA,
            CODIGO_MODALIDAD_EDUCATIVA,
            DESCRIPCION_MODALIDAD_EDUCATIVA,
            ABREVIATURA_MODALIDAD_EDUCATIVA,
            ORDEN,
            ACTIVO,
            FECHA_CREACION,
            USUARIO_CREACION,
            IP_CREACION
            )
                output INSERTED.ID_MODALIDAD_EDUCATIVA
                VALUES (
                    NEXT VALUE FOR dbo.seq_modalidad_educativa,
                    @CODIGO_MODALIDAD_EDUCATIVA,
                    @DESCRIPCION_MODALIDAD_EDUCATIVA,
                    @ABREVIATURA_MODALIDAD_EDUCATIVA,
                    @ORDEN,
                    @ACTIVO,
                    @FECHA_CREACION,
                    @USUARIO_CREACION,
                    @IP_CREACION
                    )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@CODIGO_MODALIDAD_EDUCATIVA", SqlDbType.Int) {Value = request.codigoModalidadEducativa},
                new SqlParameter("@DESCRIPCION_MODALIDAD_EDUCATIVA", SqlDbType.VarChar, 50) {Value = request.descripcionModalidadEducativa},
                new SqlParameter("@ABREVIATURA_MODALIDAD_EDUCATIVA", SqlDbType.VarChar, 10) {Value = request.abreviaturaModalidadEducativa},
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

        public async Task<int> EliminarReplica(ModalidadEducativaReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[modalidad_educativa] a
                WHERE a.ID_MODALIDAD_EDUCATIVA = @ID_MODALIDAD_EDUCATIVA ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_MODALIDAD_EDUCATIVA", SqlDbType.Int) {Value = request.idModalidadEducativa},
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

        public async Task<int> GetModalidadEducativaByCodigo(int codigoModalidadEducativa)
        {
            const string sql = @"
                            SELECT 
                            A.ID_MODALIDAD_EDUCATIVA
                            FROM dbo.modalidad_educativa A WITH (NOLOCK)
                            WHERE A.CODIGO_MODALIDAD_EDUCATIVA = @CODIGO_MODALIDAD_EDUCATIVA";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@CODIGO_MODALIDAD_EDUCATIVA", SqlDbType.Int) {Value = codigoModalidadEducativa};

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
    }
}