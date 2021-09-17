using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class TipoCentroTrabajoDAO: DAOBase, ITipoCentroTrabajoDAO
    {
        public TipoCentroTrabajoDAO(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }
        public async Task<int> GetIdTipoCentroTrabajoPorCodigo(string codigoTipoCentroTrabajo, bool activo)
        {
            const string sql = @"SELECT  ID_TIPO_CENTRO_TRABAJO 
                                FROM dbo.tipo_centro_trabajo WITH (NOLOCK)
                                WHERE CODIGO_TIPO_CENTRO_TRABAJO = @CODIGO_TIPO_CENTRO_TRABAJO
                                    AND ACTIVO = @ACTIVO;";

            SqlParameter[] parametro =
            {
                new SqlParameter("@CODIGO_TIPO_CENTRO_TRABAJO", SqlDbType.VarChar,4) {Value = codigoTipoCentroTrabajo},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = activo}
            };

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

        #region replica

        public async Task<int> Crear(TipoCentroTrabajoReplica request)
        {
            const string sql = @"
                insert into [dbo].[tipo_centro_trabajo](
                    ID_TIPO_CENTRO_TRABAJO,
					ID_NIVEL_INSTANCIA,
					TIENE_ESTRUCTURA_ORGANICA,
					CODIGO_TIPO_CENTRO_TRABAJO,
					DESCRIPCION_TIPO_CENTRO_TRABAJO,
					ACTIVO,
					FECHA_CREACION,
					USUARIO_CREACION,
					IP_CREACION	)
                output inserted.ID_TIPO_CENTRO_TRABAJO
                values (
                    NEXT VALUE FOR dbo.seq_tipo_centro_trabajo,
					@ID_NIVEL_INSTANCIA,
					@TIENE_ESTRUCTURA_ORGANICA,
					@CODIGO_TIPO_CENTRO_TRABAJO,
					@DESCRIPCION_TIPO_CENTRO_TRABAJO,
					@ACTIVO,
					@FECHA_CREACION,
					@USUARIO_CREACION,
					@IP_CREACION
                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_NIVEL_INSTANCIA", SqlDbType.Int) {Value = request.idNivelInstancia},
                new SqlParameter("@TIENE_ESTRUCTURA_ORGANICA", SqlDbType.Bit) {Value = request.tieneEstructuraOrganica},
                new SqlParameter("@CODIGO_TIPO_CENTRO_TRABAJO", SqlDbType.VarChar, 4) {Value = request.codigoTipoCentroTrabajo},
                new SqlParameter("@DESCRIPCION_TIPO_CENTRO_TRABAJO", SqlDbType.VarChar, 250) {Value = request.descripcionTipoCentroTrabajo},
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

        public async Task<int> Actualizar(TipoCentroTrabajoReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ID_NIVEL_INSTANCIA = @ID_NIVEL_INSTANCIA,                
                a.TIENE_ESTRUCTURA_ORGANICA = @TIENE_ESTRUCTURA_ORGANICA,                
                a.DESCRIPCION_TIPO_CENTRO_TRABAJO = @DESCRIPCION_TIPO_CENTRO_TRABAJO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[tipo_centro_trabajo] a
                WHERE a.ID_TIPO_CENTRO_TRABAJO = @ID_TIPO_CENTRO_TRABAJO ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_TIPO_CENTRO_TRABAJO", SqlDbType.Int) {Value = request.idTipoCentroTrabajo},
                new SqlParameter("@ID_NIVEL_INSTANCIA", SqlDbType.Int) {Value = request.idNivelInstancia},
                new SqlParameter("@TIENE_ESTRUCTURA_ORGANICA", SqlDbType.Bit) {Value = request.tieneEstructuraOrganica},
                new SqlParameter("@DESCRIPCION_TIPO_CENTRO_TRABAJO", SqlDbType.VarChar, 100) {Value = request.descripcionTipoCentroTrabajo},
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

        public async Task<int> Eliminar(TipoCentroTrabajoReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[tipo_centro_trabajo] a
                WHERE a.ID_TIPO_CENTRO_TRABAJO = @ID_TIPO_CENTRO_TRABAJO ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_TIPO_CENTRO_TRABAJO", SqlDbType.Int) {Value = request.idTipoCentroTrabajo},
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