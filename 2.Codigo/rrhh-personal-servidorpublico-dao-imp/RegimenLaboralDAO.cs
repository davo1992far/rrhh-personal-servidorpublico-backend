using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.tecnologia.util.lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class RegimenLaboralDAO : DAOBase, IRegimenLaboralDAO
    {
        public RegimenLaboralDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private RegimenLaboral LlenarRegimenLaboral(SqlDataReader dr)
        {
            RegimenLaboral r = new RegimenLaboral();

            int index = 0;

            r.idRegimenLaboral = SqlHelper.GetInt32(dr, index++);
            r.codigoRegimenLaboral = SqlHelper.GetInt32(dr, index++);
            r.descripcionRegimenLaboral = SqlHelper.GetString(dr, index++);
            r.abreviaturaRegimenLaboral = SqlHelper.GetString(dr, index++);
            r.administrativo = SqlHelper.GetBoolean(dr, index++);
            r.activo = SqlHelper.GetBoolean(dr, index++);

            return r;
        }

        public async Task<RegimenLaboral> GetRegimenLaboralPorCodigo(int codigoRegimenLaboral)
        {
            const String sql = @"SELECT
                                    r.ID_REGIMEN_LABORAL,
                                    r.CODIGO_REGIMEN_LABORAL,
                                    r.DESCRIPCION_REGIMEN_LABORAL,
                                    r.ABREVIATURA_REGIMEN_LABORAL,
                                    r.ADMINISTRATIVO,
                                    r.ACTIVO
                                    FROM dbo.regimen_laboral r
                                    WHERE r.CODIGO_REGIMEN_LABORAL = @CODIGO_REGIMEN_LABORAL";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@CODIGO_REGIMEN_LABORAL", SqlDbType.Int);
            par[0].Value = codigoRegimenLaboral;
            SqlDataReader dr = null;
            RegimenLaboral r = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return null;
                if (dr.ReadAsync().Result)
                    r = LlenarRegimenLaboral(dr);
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

        #region replica

        public async Task<int> Crear(RegimenLaboralReplica request)
        {
            const string sql = @"
                insert into [dbo].[regimen_laboral](
                    ID_REGIMEN_LABORAL,
                    ID_TIPO_RETENCION_TRIBUTARIA,
					CODIGO_REGIMEN_LABORAL,
					DESCRIPCION_REGIMEN_LABORAL,
					ABREVIATURA_REGIMEN_LABORAL,
					ADMINISTRATIVO,
					FECHA_INICIO_VIGENCIA,
					FECHA_FIN_VIGENCIA,
					ACTIVO,
					FECHA_CREACION,
					USUARIO_CREACION,
					IP_CREACION	)
                output inserted.ID_REGIMEN_LABORAL
                values (
                    NEXT VALUE FOR dbo.seq_regimen_laboral,
					@ID_TIPO_RETENCION_TRIBUTARIA,
					@CODIGO_REGIMEN_LABORAL,
					@DESCRIPCION_REGIMEN_LABORAL,
					@ABREVIATURA_REGIMEN_LABORAL,
					@ADMINISTRATIVO,
					@FECHA_INICIO_VIGENCIA,
					@FECHA_FIN_VIGENCIA,
					@ACTIVO,
					@FECHA_CREACION,
					@USUARIO_CREACION,
					@IP_CREACION
                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_TIPO_RETENCION_TRIBUTARIA", SqlDbType.Int) {Value = request.idTipoRetencionTributaria},
                new SqlParameter("@CODIGO_REGIMEN_LABORAL", SqlDbType.Int) {Value = request.codigoRegimenLaboral},
                new SqlParameter("@DESCRIPCION_REGIMEN_LABORAL", SqlDbType.VarChar, 200) {Value = request.descripcionRegimenLaboral},
                new SqlParameter("@ABREVIATURA_REGIMEN_LABORAL", SqlDbType.VarChar, 30) {Value = request.abreviaturaRegimenLaboral},
                new SqlParameter("@ADMINISTRATIVO", SqlDbType.Bit) {Value = request.administrativo},
                new SqlParameter("@FECHA_INICIO_VIGENCIA", SqlDbType.DateTime) {Value = request.fechaInicioVigencia},
                new SqlParameter("@FECHA_FIN_VIGENCIA", SqlDbType.DateTime) {Value = request.fechaFinVigencia},
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

        public async Task<int> Actualizar(RegimenLaboralReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ID_TIPO_RETENCION_TRIBUTARIA = @ID_TIPO_RETENCION_TRIBUTARIA,
                a.DESCRIPCION_REGIMEN_LABORAL = @DESCRIPCION_REGIMEN_LABORAL,
                a.ABREVIATURA_REGIMEN_LABORAL = @ABREVIATURA_REGIMEN_LABORAL,
                a.ADMINISTRATIVO = @ADMINISTRATIVO,
                a.FECHA_INICIO_VIGENCIA = @FECHA_INICIO_VIGENCIA,
                a.FECHA_FIN_VIGENCIA = @FECHA_FIN_VIGENCIA,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[regimen_laboral] a
                WHERE a.ID_REGIMEN_LABORAL = @ID_REGIMEN_LABORAL ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_REGIMEN_LABORAL", SqlDbType.Int) {Value = request.idRegimenLaboral},
                new SqlParameter("@ID_TIPO_RETENCION_TRIBUTARIA", SqlDbType.Int) {Value = request.idTipoRetencionTributaria},
                new SqlParameter("@DESCRIPCION_REGIMEN_LABORAL", SqlDbType.VarChar, 200) {Value = request.descripcionRegimenLaboral},
                new SqlParameter("@ABREVIATURA_REGIMEN_LABORAL", SqlDbType.VarChar, 30) {Value = request.abreviaturaRegimenLaboral},
                new SqlParameter("@ADMINISTRATIVO", SqlDbType.Bit) {Value = request.administrativo},
                new SqlParameter("@FECHA_INICIO_VIGENCIA", SqlDbType.DateTime) {Value = request.fechaInicioVigencia},
                new SqlParameter("@FECHA_FIN_VIGENCIA", SqlDbType.DateTime) {Value = request.fechaFinVigencia},
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

        public async Task<int> Eliminar(RegimenLaboralReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[regimen_laboral] a
                WHERE a.ID_REGIMEN_LABORAL = @ID_REGIMEN_LABORAL ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_REGIMEN_LABORAL", SqlDbType.Int) {Value = request.idRegimenLaboral},
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