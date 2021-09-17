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
    public class CentroTrabajoDAO : DAOBase, ICentroTrabajoDAO
    {
        public CentroTrabajoDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private CentroTrabajo LlenarCentroTrabajo(SqlDataReader dr)
        {
            var c = new CentroTrabajo();

            int index = 0;
            c.idCentroTrabajo = SqlHelper.GetInt32(dr, index++);
            c.idTipoCentroTrabajo = SqlHelper.GetInt32(dr, index++);
            c.idOtraInstancia = SqlHelper.GetNullableInt32(dr, index++);
            c.idDre = SqlHelper.GetNullableInt32(dr, index++);
            c.idUgel = SqlHelper.GetNullableInt32(dr, index++);
            c.idInstitucionEducativa = SqlHelper.GetNullableInt32(dr, index++);
            c.codigoCentroTrabajo = SqlHelper.GetNullableString(dr, index++);
            c.anexoCentroTrabajo = SqlHelper.GetNullableString(dr, index++);
            c.activo = SqlHelper.GetBoolean(dr, index++);

            return c;
        }

        public async Task<CentroTrabajo> GetCentroTrabajoPorCodigo(string codigoCentroTrabajo,string anexoCentroTrabajo)
        {
            const string sql = @"SELECT
                                    c.ID_CENTRO_TRABAJO,
                                    c.ID_TIPO_CENTRO_TRABAJO,
                                    c.ID_OTRA_INSTANCIA,
                                    c.ID_DRE,
                                    c.ID_UGEL,
                                    c.ID_INSTITUCION_EDUCATIVA,
                                    c.CODIGO_CENTRO_TRABAJO,
                                    c.ANEXO_CENTRO_TRABAJO,
                                    c.ACTIVO
                                    FROM dbo.centro_trabajo c
                                    WHERE c.CODIGO_CENTRO_TRABAJO = @CODIGO_CENTRO_TRABAJO AND (c.ANEXO_CENTRO_TRABAJO=@ANEXO_CENTRO_TRABAJO OR @ANEXO_CENTRO_TRABAJO IS NULL)";

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@CODIGO_CENTRO_TRABAJO", SqlDbType.VarChar, 10) {Value = codigoCentroTrabajo};
            par[1] = new SqlParameter("@ANEXO_CENTRO_TRABAJO", SqlDbType.VarChar, 5) {Value = anexoCentroTrabajo};
            SqlDataReader dr = null;
            CentroTrabajo c = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return null;
                if (dr.ReadAsync().Result)
                    c = LlenarCentroTrabajo(dr);
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

        #region replica

        public async Task<int> Crear(CentroTrabajoReplica request)
        {
            const string sql = @"
                insert into [dbo].[centro_trabajo](
                    ID_CENTRO_TRABAJO,
					ID_TIPO_CENTRO_TRABAJO,
					ID_OTRA_INSTANCIA,
					ID_DRE,
					ID_UGEL,
					ID_INSTITUCION_EDUCATIVA,
					CODIGO_CENTRO_TRABAJO,
					ANEXO_CENTRO_TRABAJO,
					ACTIVO,
					FECHA_CREACION,
					USUARIO_CREACION,
					IP_CREACION)
                output inserted.ID_CENTRO_TRABAJO
                values (
                    NEXT VALUE FOR dbo.seq_centro_trabajo,
					@ID_TIPO_CENTRO_TRABAJO,
					@ID_OTRA_INSTANCIA,
					@ID_DRE,
					@ID_UGEL,
					@ID_INSTITUCION_EDUCATIVA,
					@CODIGO_CENTRO_TRABAJO,
					@ANEXO_CENTRO_TRABAJO,
					@ACTIVO,
					@FECHA_CREACION,
					@USUARIO_CREACION,
					@IP_CREACION
                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_TIPO_CENTRO_TRABAJO", SqlDbType.Int) {Value = request.idTipoCentroTrabajo},
                new SqlParameter("@ID_OTRA_INSTANCIA", SqlDbType.Int) {Value = request.idOtraInstancia},
                new SqlParameter("@ID_DRE", SqlDbType.Int) {Value = request.idDre},
                new SqlParameter("@ID_UGEL", SqlDbType.Int) {Value = request.idUgel},
                new SqlParameter("@ID_INSTITUCION_EDUCATIVA", SqlDbType.Int) {Value = request.idInstitucionEducativa},
                new SqlParameter("@CODIGO_CENTRO_TRABAJO", SqlDbType.VarChar, 10) {Value = request.codigoCentroTrabajo},
                new SqlParameter("@ANEXO_CENTRO_TRABAJO", SqlDbType.VarChar, 5) {Value = request.anexoCentroTrabajo},
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
                var response = Convert.ToInt64(inserted);
                if (response < 1)
                {
                    await tran.transaction.RollbackAsync();
                    return 0;
                }

                await tran.transaction.CommitAsync();
                return 1;
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

        public async Task<int> Actualizar(CentroTrabajoReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ANEXO_CENTRO_TRABAJO = @ANEXO_CENTRO_TRABAJO,
                a.ID_TIPO_CENTRO_TRABAJO = @ID_TIPO_CENTRO_TRABAJO,
				a.ID_OTRA_INSTANCIA = @ID_OTRA_INSTANCIA,
				a.ID_DRE = @ID_DRE,
				a.ID_UGEL = ID_UGEL,
				a.ID_INSTITUCION_EDUCATIVA = @ID_INSTITUCION_EDUCATIVA,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[centro_trabajo] a
                WHERE a.ID_CENTRO_TRABAJO = @ID_CENTRO_TRABAJO ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_CENTRO_TRABAJO", SqlDbType.Int) {Value = request.idCentroTrabajo},
                new SqlParameter("@ANEXO_CENTRO_TRABAJO", SqlDbType.VarChar,5) {Value = request.anexoCentroTrabajo},
                new SqlParameter("@ID_TIPO_CENTRO_TRABAJO", SqlDbType.Int) {Value = request.idTipoCentroTrabajo},
                new SqlParameter("@ID_OTRA_INSTANCIA", SqlDbType.Int) {Value = request.idOtraInstancia},
                new SqlParameter("@ID_DRE", SqlDbType.Int) {Value = request.idDre},
                new SqlParameter("@ID_UGEL", SqlDbType.Int) {Value = request.idUgel},
                new SqlParameter("@ID_INSTITUCION_EDUCATIVA", SqlDbType.Int) {Value = request.idInstitucionEducativa},
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

        public async Task<int> Eliminar(CentroTrabajoReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[centro_trabajo] a
                WHERE a.ID_CENTRO_TRABAJO = @ID_CENTRO_TRABAJO ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_CENTRO_TRABAJO", SqlDbType.Int) {Value = request.idCentroTrabajo},
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