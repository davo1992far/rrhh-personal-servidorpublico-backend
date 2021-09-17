using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.negocio.comunes.rabbitmq.lib.ReplicaRegistro.rrhh_negocio_comunes_maestros_backend;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class InstitucionEducativaDAO: DAOBase, IInstitucionEducativaDAO
    {
        public InstitucionEducativaDAO(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> GetIdInstitucionEducativaPorCodigo(string codigoInstitucionEducativa,string anexoInstitucionEducativa, bool activo)
        {
            const string sql = @"SELECT  ID_INSTITUCION_EDUCATIVA
                                FROM dbo.institucion_educativa WITH (NOLOCK)
                                WHERE CODIGO_MODULAR = @CODIGO_MODULAR
                                    AND (ANEXO_INSTITUCION_EDUCATIVA = @ANEXO_INSTITUCION_EDUCATIVA OR @ANEXO_INSTITUCION_EDUCATIVA IS NULL)
                                    AND ACTIVO = @ACTIVO;";

            SqlParameter[] parametro =
            {
                new SqlParameter("@CODIGO_MODULAR", SqlDbType.VarChar,7) {Value = codigoInstitucionEducativa},
                new SqlParameter("@ANEXO_INSTITUCION_EDUCATIVA", SqlDbType.VarChar,5) {Value = anexoInstitucionEducativa},
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

        public async Task<int> Crear(InstitucionEducativaReplica request)
        {
            const string sql = @"
                insert into [dbo].[institucion_educativa](
                    ID_INSTITUCION_EDUCATIVA,
                    ID_UGEL,
                    ID_DRE,
                    ID_OTRA_INSTANCIA,
                    ID_NIVEL_EDUCATIVO,
                    ID_TIPO_INSTITUCION_EDUCATIVA,
                    ID_DEPENDENCIA_INSTITUCION_EDUCATIVA,
                    ID_TIPO_GESTION_INSTITUCION_EDUCATIVA,
                    ID_UNIDAD_EJECUTORA,
                    ID_SERVIDOR_PUBLICO_DIRECTOR,
                    CODIGO_MODULAR,
                    ANEXO_INSTITUCION_EDUCATIVA,
                    INSTITUCION_EDUCATIVA,
                    ACTIVO,
                    FECHA_CREACION,
                    USUARIO_CREACION,
                    IP_CREACION)
                output inserted.ID_INSTITUCION_EDUCATIVA
                values (
                    NEXT VALUE FOR dbo.seq_institucion_educativa,
					@ID_UGEL,
                    @ID_DRE,
                    @ID_OTRA_INSTANCIA,
                    @ID_NIVEL_EDUCATIVO,
                    @ID_TIPO_INSTITUCION_EDUCATIVA,
                    @ID_DEPENDENCIA_INSTITUCION_EDUCATIVA,
                    @ID_TIPO_GESTION_INSTITUCION_EDUCATIVA,
                    @ID_UNIDAD_EJECUTORA,
                    @ID_SERVIDOR_PUBLICO_DIRECTOR,
                    @CODIGO_MODULAR,
                    @ANEXO_INSTITUCION_EDUCATIVA,
                    @INSTITUCION_EDUCATIVA,
                    @ACTIVO,
                    @FECHA_CREACION,
                    @USUARIO_CREACION,
                    @IP_CREACION
                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_UGEL", SqlDbType.Int) {Value = request.idUgel},
                new SqlParameter("@ID_DRE", SqlDbType.Int) {Value = request.idDre},
                new SqlParameter("@ID_OTRA_INSTANCIA", SqlDbType.Int) {Value = request.idOtraInstancia},
                new SqlParameter("@ID_NIVEL_EDUCATIVO", SqlDbType.Int) {Value = request.idNivelEducativo},
                new SqlParameter("@ID_TIPO_INSTITUCION_EDUCATIVA", SqlDbType.Int) {Value = request.idTipoInstitucionEducativa},
                new SqlParameter("@ID_DEPENDENCIA_INSTITUCION_EDUCATIVA", SqlDbType.Int) {Value = request.idDependenciaInstitucionEducativa},
                new SqlParameter("@ID_TIPO_GESTION_INSTITUCION_EDUCATIVA", SqlDbType.Int) {Value = request.idTipoGestionInstitucionEducativa},
                new SqlParameter("@ID_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.idUnidadEjecutora},
                new SqlParameter("@ID_SERVIDOR_PUBLICO_DIRECTOR", SqlDbType.BigInt) {Value = request.idServidorPublicoDirector},
                new SqlParameter("@CODIGO_MODULAR", SqlDbType.VarChar, 7) {Value = request.codigoModular},
                new SqlParameter("@ANEXO_INSTITUCION_EDUCATIVA", SqlDbType.VarChar, 5) {Value = request.anexoInstitucionEducativa},
                new SqlParameter("@INSTITUCION_EDUCATIVA", SqlDbType.VarChar, 200) {Value = request.institucionEducativa},
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

        public async Task<int> Actualizar(InstitucionEducativaReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ID_UGEL = @ID_UGEL,
                a.ID_DRE = @ID_DRE,
                a.ID_OTRA_INSTANCIA = @ID_OTRA_INSTANCIA,
                a.ID_NIVEL_EDUCATIVO = @ID_NIVEL_EDUCATIVO,
                a.ID_TIPO_INSTITUCION_EDUCATIVA = @ID_TIPO_INSTITUCION_EDUCATIVA,
                a.ID_DEPENDENCIA_INSTITUCION_EDUCATIVA = @ID_DEPENDENCIA_INSTITUCION_EDUCATIVA,
                a.ID_TIPO_GESTION_INSTITUCION_EDUCATIVA = @ID_TIPO_GESTION_INSTITUCION_EDUCATIVA,
                a.ID_UNIDAD_EJECUTORA = @ID_UNIDAD_EJECUTORA,
                a.ID_SERVIDOR_PUBLICO_DIRECTOR = @ID_SERVIDOR_PUBLICO_DIRECTOR,
                a.ANEXO_INSTITUCION_EDUCATIVA = @ANEXO_INSTITUCION_EDUCATIVA,
                a.INSTITUCION_EDUCATIVA = @INSTITUCION_EDUCATIVA,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[institucion_educativa] a
                WHERE a.ID_INSTITUCION_EDUCATIVA = @ID_INSTITUCION_EDUCATIVA ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_INSTITUCION_EDUCATIVA", SqlDbType.Int) {Value = request.idInstitucionEducativa},
                new SqlParameter("@ID_UGEL", SqlDbType.Int) {Value = request.idUgel},
                new SqlParameter("@ID_DRE", SqlDbType.Int) {Value = request.idDre},
                new SqlParameter("@ID_OTRA_INSTANCIA", SqlDbType.Int) {Value = request.idOtraInstancia},
                new SqlParameter("@ID_NIVEL_EDUCATIVO", SqlDbType.Int) {Value = request.idNivelEducativo},
                new SqlParameter("@ID_TIPO_INSTITUCION_EDUCATIVA", SqlDbType.Int) {Value = request.idTipoInstitucionEducativa},
                new SqlParameter("@ID_DEPENDENCIA_INSTITUCION_EDUCATIVA", SqlDbType.Int) {Value = request.idDependenciaInstitucionEducativa},
                new SqlParameter("@ID_TIPO_GESTION_INSTITUCION_EDUCATIVA", SqlDbType.Int) {Value = request.idTipoGestionInstitucionEducativa},
                new SqlParameter("@ID_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.idUnidadEjecutora},
                new SqlParameter("@ID_SERVIDOR_PUBLICO_DIRECTOR", SqlDbType.BigInt) {Value = request.idServidorPublicoDirector},
                new SqlParameter("@ANEXO_INSTITUCION_EDUCATIVA", SqlDbType.VarChar, 5) {Value = request.anexoInstitucionEducativa},
                new SqlParameter("@INSTITUCION_EDUCATIVA", SqlDbType.VarChar, 200) {Value = request.institucionEducativa},
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

        public async Task<int> Eliminar(InstitucionEducativaReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[institucion_educativa] a
                WHERE a.ID_INSTITUCION_EDUCATIVA = @ID_INSTITUCION_EDUCATIVA ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_INSTITUCION_EDUCATIVA", SqlDbType.Int) {Value = request.idInstitucionEducativa},
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