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
    public class RegimenPensionarioDAO : DAOBase, IRegimenPensionarioDAO
    {
        public RegimenPensionarioDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private RegimenPensionario LlenarRegimenPensionario(SqlDataReader dr)
        {
            RegimenPensionario r = new RegimenPensionario();

            int index = 0;

            r.idRegimenPensionario = SqlHelper.GetInt32(dr, index++);
            r.codigoRegimenPensionario = SqlHelper.GetInt32(dr, index++);
            r.descripcionRegimenPensionario = SqlHelper.GetString(dr, index++);
            r.activo = SqlHelper.GetBoolean(dr, index++);

            return r;
        }

        public async Task<RegimenPensionario> GetRegimenPensionarioPorCodigo(int codigoRegimenPensionario)
        {
            const String sql = @"SELECT
                                r.ID_REGIMEN_PENSIONARIO,
                            r.CODIGO_REGIMEN_PENSIONARIO,
                            r.DESCRIPCION_REGIMEN_PENSIONARIO,
                            r.ACTIVO
                            FROM dbo.regimen_pensionario r
                            WHERE r.CODIGO_REGIMEN_PENSIONARIO = @CODIGO_REGIMEN_PENSIONARIO";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@CODIGO_REGIMEN_PENSIONARIO", SqlDbType.Int) {Value = codigoRegimenPensionario};
            SqlDataReader dr = null;
            RegimenPensionario r = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return null;
                if (dr.ReadAsync().Result)
                    r = LlenarRegimenPensionario(dr);
                return r;
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

        public async Task<int> Crear(RegimenPensionarioReplica request)
        {
            const string sql = @"
                insert into [dbo].[regimen_pensionario](
                    ID_REGIMEN_PENSIONARIO,
                    ID_TIPO_RETENCION_TRIBUTARIA,
					CODIGO_REGIMEN_PENSIONARIO,
					DESCRIPCION_REGIMEN_PENSIONARIO,
					ACTIVO,
					FECHA_CREACION,
					USUARIO_CREACION,
					IP_CREACION	)
                output inserted.ID_REGIMEN_PENSIONARIO
                values (
                    NEXT VALUE FOR dbo.seq_regimen_pensionario,
					@ID_TIPO_RETENCION_TRIBUTARIA,
					@CODIGO_REGIMEN_PENSIONARIO,
					@DESCRIPCION_REGIMEN_PENSIONARIO,
					@ACTIVO,
					@FECHA_CREACION,
					@USUARIO_CREACION,
					@IP_CREACION
                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_TIPO_RETENCION_TRIBUTARIA", SqlDbType.Int) {Value = request.idTipoRetencionTributaria},
                new SqlParameter("@CODIGO_REGIMEN_PENSIONARIO", SqlDbType.Int) {Value = request.codigoRegimenPensionario},
                new SqlParameter("@DESCRIPCION_REGIMEN_PENSIONARIO", SqlDbType.VarChar, 100) {Value = request.descripcionRegimenPensionario},
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

        public async Task<int> Actualizar(RegimenPensionarioReplica request)
        {
             const string sql = @"
                UPDATE a SET
                a.ID_TIPO_RETENCION_TRIBUTARIA = @ID_TIPO_RETENCION_TRIBUTARIA,
                a.DESCRIPCION_REGIMEN_PENSIONARIO = @DESCRIPCION_REGIMEN_PENSIONARIO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[regimen_pensionario] a
                WHERE a.ID_REGIMEN_PENSIONARIO = @ID_REGIMEN_PENSIONARIO";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_REGIMEN_PENSIONARIO", SqlDbType.Int) {Value = request.idRegimenPensionario},
                new SqlParameter("@ID_TIPO_RETENCION_TRIBUTARIA", SqlDbType.Int) {Value = request.idTipoRetencionTributaria},
                new SqlParameter("@DESCRIPCION_REGIMEN_PENSIONARIO", SqlDbType.VarChar, 100) {Value = request.descripcionRegimenPensionario},
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

        public async Task<int> Eliminar(RegimenPensionarioReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[regimen_pensionario] a
                WHERE a.ID_REGIMEN_PENSIONARIO = @ID_REGIMEN_PENSIONARIO ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_REGIMEN_PENSIONARIO", SqlDbType.Int) {Value = request.idRegimenPensionario},
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
