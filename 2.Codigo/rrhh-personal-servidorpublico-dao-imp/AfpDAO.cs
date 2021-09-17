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
    public class AfpDAO : DAOBase, IAfpDAO
    {
        public AfpDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private Afp LlenarAfp(SqlDataReader dr)
        {
            Afp a = new Afp();

            int index = 0;

            a.idAfp = SqlHelper.GetInt32(dr, index++);
            a.idRegimenPensionario = SqlHelper.GetInt32(dr, index++);
            a.codigoAfp = SqlHelper.GetString(dr, index++);
            a.descripcionAfp = SqlHelper.GetNullableString(dr, index++);
            a.abreviaturaAfpSunat = SqlHelper.GetNullableString(dr, index++);
            a.activo = SqlHelper.GetBoolean(dr, index++);

            return a;
        }

        public async Task<Afp> GetAfpPorCodigo(string codigoAfp)
        {
            const string sql = @"SELECT
                                        a.ID_AFP,
                                        a.ID_REGIMEN_PENSIONARIO,
                                        a.CODIGO_AFP,
                                        a.DESCRIPCION_AFP,
                                        a.ABREVIATURA_AFP_SUNAT,
                                        a.ACTIVO
                                        FROM dbo.afp a
                                        WHERE a.CODIGO_AFP = @CODIGO_AFP";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@CODIGO_AFP", SqlDbType.VarChar, 2) {Value = codigoAfp};
            SqlDataReader dr = null;
            Afp a = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return null;
                if (dr.ReadAsync().Result)
                    a = LlenarAfp(dr);
                return a;
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

        public async Task<int> Crear(AfpReplica request)
        {
            const string sql = @"insert into [dbo].[afp](ID_AFP,
                                                          ID_REGIMEN_PENSIONARIO,
                                                          CODIGO_AFP,
                                                          DESCRIPCION_AFP,
                                                          ABREVIATURA_AFP_SUNAT,
                                                          ACTIVO,
                                                          FECHA_CREACION,
                                                          USUARIO_CREACION,
                                                          IP_CREACION)
                                output inserted.ID_AFP
                                values (NEXT VALUE FOR dbo.seq_afp,
                                        @ID_REGIMEN_PENSIONARIO,
                                        @CODIGO_AFP,
                                        @DESCRIPCION_AFP,
                                        @ABREVIATURA_AFP_SUNAT,
                                        @ACTIVO,
                                        @FECHA_CREACION,
                                        @USUARIO_CREACION,
                                        @IP_CREACION)";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_REGIMEN_PENSIONARIO", SqlDbType.Int) {Value = request.idRegimenPensionario},
                new SqlParameter("@CODIGO_AFP", SqlDbType.VarChar,2) {Value = request.codigoAfp},
                new SqlParameter("@DESCRIPCION_AFP", SqlDbType.VarChar, 50) {Value = request.descripcionAfp},
                new SqlParameter("@ABREVIATURA_AFP_SUNAT", SqlDbType.VarChar, 20) {Value = request.abreviaturaAfpSunat},
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

        public  async Task<int> Actualizar(AfpReplica request)
        {
              const string sql = @"UPDATE a SET
                                        a.ID_REGIMEN_PENSIONARIO = @ID_REGIMEN_PENSIONARIO,
                                        a.DESCRIPCION_AFP = @DESCRIPCION_AFP,               
                                        a.ABREVIATURA_AFP_SUNAT = @ABREVIATURA_AFP_SUNAT,               
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[afp] a
                                        WHERE a.ID_AFP = @ID_AFP ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_AFP", SqlDbType.Int) {Value = request.idAfp},
                new SqlParameter("@ID_REGIMEN_PENSIONARIO", SqlDbType.Int) {Value = request.idRegimenPensionario},
                new SqlParameter("@DESCRIPCION_AFP", SqlDbType.VarChar,50) {Value = request.descripcionAfp},
                new SqlParameter("@ABREVIATURA_AFP_SUNAT", SqlDbType.VarChar, 10) {Value = request.abreviaturaAfpSunat},
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

        public async Task<int> Eliminar(AfpReplica request)
        {
            const string sql = @" UPDATE a SET
                                        a.ACTIVO = @ACTIVO,
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[afp] a
                                        WHERE a.ID_AFP = @ID_AFP ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_AFP", SqlDbType.Int) {Value = request.idAfp},
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
