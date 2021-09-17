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
    public class CargoDAO : DAOBase, ICargoDAO
    {
        public CargoDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private Cargo LlenarCargo(SqlDataReader dr)
        {
            Cargo c = new Cargo();

            int index = 0;

            c.idCargo = SqlHelper.GetInt32(dr, index++);
            c.idRegimenLaboral = SqlHelper.GetInt32(dr, index++);
            c.codigoCargo = SqlHelper.GetInt32(dr, index++);
            c.descripcionCargo = SqlHelper.GetString(dr, index++);
            c.abreviaturaCargo = SqlHelper.GetNullableString(dr, index++);
            c.activo = SqlHelper.GetBoolean(dr, index++);

            return c;
        }

        public async Task<Cargo> GetCargoPorCodigo(int codigoCargo)
        {
            const String sql = @"SELECT
                                        c.ID_CARGO,
                                        c.ID_REGIMEN_LABORAL,
                                        c.CODIGO_CARGO,
                                        c.DESCRIPCION_CARGO,
                                        c.ABREVIATURA_CARGO,
                                        c.ACTIVO
                                        FROM dbo.cargo c
                                        WHERE c.CODIGO_CARGO = @CODIGO_CARGO";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@CODIGO_CARGO", SqlDbType.Int);
            par[0].Value = codigoCargo;
            SqlDataReader dr = null;
            Cargo c = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return null;
                if (dr.ReadAsync().Result)
                    c = LlenarCargo(dr);
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
         public async Task<int> GetIdCargoPorCodigo(int codigoCargo, bool activo)
        {
            const string sql = @"SELECT ID_CARGO
                                        FROM dbo.cargo A WITH (NOLOCK)
                                        WHERE A.CODIGO_CARGO = @CODIGO_CARGO
                                            AND A.ACTIVO = @ACTIVO";

            SqlParameter[] parameter =
            {
                new SqlParameter("@CODIGO_CARGO", SqlDbType.Int) {Value = codigoCargo},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = activo}
            };

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

        #region replica

        public async Task<int> Crear(CargoReplica request)
        {
            const string sql = @"insert into [dbo].[cargo](ID_CARGO,
                                                          ID_REGIMEN_LABORAL,
                                                          CODIGO_CARGO,
                                                          DESCRIPCION_CARGO,
                                                          ABREVIATURA_CARGO,
                                                          ACTIVO,
                                                          FECHA_CREACION,
                                                          USUARIO_CREACION,
                                                          IP_CREACION)
                                output inserted.ID_CARGO
                                values (NEXT VALUE FOR dbo.seq_cargo,
                                        @ID_REGIMEN_LABORAL,
                                        @CODIGO_CARGO,
                                        @DESCRIPCION_CARGO,
                                        @ABREVIATURA_CARGO,
                                        @ACTIVO,
                                        @FECHA_CREACION,
                                        @USUARIO_CREACION,
                                        @IP_CREACION)";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_REGIMEN_LABORAL", SqlDbType.Int) {Value = request.idRegimenLaboral},
                new SqlParameter("@CODIGO_CARGO", SqlDbType.Int) {Value = request.codigoCargo},
                new SqlParameter("@DESCRIPCION_CARGO", SqlDbType.VarChar, 100) {Value = request.descripcionCargo},
                new SqlParameter("@ABREVIATURA_CARGO", SqlDbType.VarChar, 20) {Value = request.abreviaturaCargo},
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

        public async Task<int> Actualizar(CargoReplica request)
        {
            const string sql = @"UPDATE a SET
                                        a.ID_REGIMEN_LABORAL = @ID_REGIMEN_LABORAL,
                                        a.DESCRIPCION_CARGO = @DESCRIPCION_CARGO,               
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[cargo] a
                                        WHERE a.ID_CARGO = @ID_CARGO ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_CARGO", SqlDbType.Int) {Value = request.idCargo},
                new SqlParameter("@ID_REGIMEN_LABORAL", SqlDbType.Int) {Value = request.idRegimenLaboral},
                new SqlParameter("@DESCRIPCION_CARGO", SqlDbType.VarChar, 100) {Value = request.descripcionCargo},
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

        public async Task<int> Eliminar(CargoReplica request)
        {
            const string sql = @" UPDATE a SET
                                        a.ACTIVO = @ACTIVO,
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[cargo] a
                                        WHERE a.ID_CARGO = @ID_CARGO ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_CARGO", SqlDbType.Int) {Value = request.idCargo},
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
