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
    public class JornadaLaboralDAO : DAOBase, IJornadaLaboralDAO
    {
        public JornadaLaboralDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private JornadaLaboral LlenarJornadaLaboral(SqlDataReader dr)
        {
            JornadaLaboral j = new JornadaLaboral();

            int index = 0;

            j.idJornadaLaboral = SqlHelper.GetInt32(dr, index++);
            j.idTipoJornadaLaboral = SqlHelper.GetNullableInt32(dr, index++);
            j.codigoJornadaLaboral = SqlHelper.GetInt32(dr, index++);
            j.codigoOrigenJornadaLaboral = SqlHelper.GetNullableString(dr, index++);
            j.descripcionJornadaLaboral = SqlHelper.GetString(dr, index++);
            j.abreviaturaJornadaLaboral = SqlHelper.GetNullableString(dr, index++);
            j.ordenJornadaLaboral = SqlHelper.GetNullableInt32(dr, index++);
            j.cantidadJornadaLaboral = SqlHelper.GetNullableInt32(dr, index++);
            j.activo = SqlHelper.GetBoolean(dr, index++);

            return j;
        }

        public async Task<JornadaLaboral> GetJornadaLaboralPorCodigo(int codigoJornadaLaboral)
        {
            const string sql = @"SELECT
                                        j.ID_JORNADA_LABORAL,
                                        j.ID_TIPO_JORNADA_LABORAL,
                                        j.CODIGO_JORNADA_LABORAL,
                                        j.CODIGO_ORIGEN_JORNADA_LABORAL,
                                        j.DESCRIPCION_JORNADA_LABORAL,
                                        j.ABREVIATURA_JORNADA_LABORAL,
                                        j.ORDEN_JORNADA_LABORAL,
                                        j.CANTIDAD_JORNADA_LABORAL,
                                        j.ACTIVO
                                        FROM dbo.jornada_laboral j
                                        WHERE j.CODIGO_JORNADA_LABORAL = @CODIGO_JORNADA_LABORAL";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@CODIGO_JORNADA_LABORAL", SqlDbType.Int) {Value = codigoJornadaLaboral};
            SqlDataReader dr = null;
            JornadaLaboral j = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return null;
                if (dr.ReadAsync().Result)
                    j = LlenarJornadaLaboral(dr);
                return j;
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
        
         public async Task<int> Crear(JornadaLaboralReplica request)
        {
            const string sql = @"insert into [dbo].[jornada_laboral](ID_JORNADA_LABORAL,
                                                          ID_TIPO_JORNADA_LABORAL,
                                                          CODIGO_JORNADA_LABORAL,
                                                          CODIGO_ORIGEN_JORNADA_LABORAL,
                                                          DESCRIPCION_JORNADA_LABORAL,
                                                          ABREVIATURA_JORNADA_LABORAL,
                                                          ORDEN_JORNADA_LABORAL,
                                                          CANTIDAD_JORNADA_LABORAL,
                                                          ACTIVO,
                                                          FECHA_CREACION,
                                                          USUARIO_CREACION,
                                                          IP_CREACION)
                                output inserted.ID_JORNADA_LABORAL
                                values (NEXT VALUE FOR dbo.seq_jornada_laboral,
                                        @ID_TIPO_JORNADA_LABORAL,
                                        @CODIGO_JORNADA_LABORAL,
                                        @CODIGO_ORIGEN_JORNADA_LABORAL,
                                        @DESCRIPCION_JORNADA_LABORAL,
                                        @ABREVIATURA_JORNADA_LABORAL,
                                        @ORDEN_JORNADA_LABORAL,
                                        @CANTIDAD_JORNADA_LABORAL,
                                        @ACTIVO,
                                        @FECHA_CREACION,
                                        @USUARIO_CREACION,
                                        @IP_CREACION)";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_TIPO_JORNADA_LABORAL", SqlDbType.Int) {Value = request.idTipoJornadaLaboral},
                new SqlParameter("@CODIGO_JORNADA_LABORAL", SqlDbType.Int) {Value = request.codigoJornadaLaboral},
                new SqlParameter("@CODIGO_ORIGEN_JORNADA_LABORAL", SqlDbType.VarChar,10) {Value = request.codigoOrigenJornadaLaboral},
                new SqlParameter("@DESCRIPCION_JORNADA_LABORAL", SqlDbType.VarChar, 50) {Value = request.descripcionJornadaLaboral},
                new SqlParameter("@ABREVIATURA_JORNADA_LABORAL", SqlDbType.VarChar, 10) {Value = request.abreviaturaJornadaLaboral},
                new SqlParameter("@ORDEN_JORNADA_LABORAL", SqlDbType.Int) {Value = request.ordenJornadaLaboral},
                new SqlParameter("@CANTIDAD_JORNADA_LABORAL", SqlDbType.Int) {Value = request.cantidadJornadaLaboral},
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

        public async Task<int> Actualizar(JornadaLaboralReplica request)
        {
            const string sql = @"UPDATE a SET                                       
                                        a.ID_TIPO_JORNADA_LABORAL = @ID_TIPO_JORNADA_LABORAL,               
                                        a.CODIGO_ORIGEN_JORNADA_LABORAL = @CODIGO_ORIGEN_JORNADA_LABORAL,               
                                        a.DESCRIPCION_JORNADA_LABORAL = @DESCRIPCION_JORNADA_LABORAL,               
                                        a.ABREVIATURA_JORNADA_LABORAL = @ABREVIATURA_JORNADA_LABORAL,               
                                        a.ORDEN_JORNADA_LABORAL = @ORDEN_JORNADA_LABORAL,               
                                        a.CANTIDAD_JORNADA_LABORAL = @CANTIDAD_JORNADA_LABORAL,               
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[jornada_laboral] a
                                        WHERE a.ID_JORNADA_LABORAL = @ID_JORNADA_LABORAL ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_JORNADA_LABORAL", SqlDbType.Int) {Value = request.idJornadaLaboral},
                new SqlParameter("@ID_TIPO_JORNADA_LABORAL", SqlDbType.Int) {Value = request.idTipoJornadaLaboral},
                new SqlParameter("@CODIGO_ORIGEN_JORNADA_LABORAL", SqlDbType.VarChar,10) {Value = request.codigoOrigenJornadaLaboral},
                new SqlParameter("@DESCRIPCION_JORNADA_LABORAL", SqlDbType.VarChar, 50) {Value = request.descripcionJornadaLaboral},
                new SqlParameter("@ABREVIATURA_JORNADA_LABORAL", SqlDbType.VarChar, 10) {Value = request.abreviaturaJornadaLaboral},
                new SqlParameter("@ORDEN_JORNADA_LABORAL", SqlDbType.Int) {Value = request.ordenJornadaLaboral},
                new SqlParameter("@CANTIDAD_JORNADA_LABORAL", SqlDbType.Int) {Value = request.cantidadJornadaLaboral},
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

        public async Task<int> Eliminar(JornadaLaboralReplica request)
        {
            const string sql = @" UPDATE a SET
                                        a.ACTIVO = @ACTIVO,
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[jornada_laboral] a
                                        WHERE a.ID_JORNADA_LABORAL = @ID_JORNADA_LABORAL ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_JORNADA_LABORAL", SqlDbType.Int) {Value = request.idJornadaLaboral},
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
