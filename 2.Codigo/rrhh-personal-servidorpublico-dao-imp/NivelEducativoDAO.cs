using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class NivelEducativoDAO : DAOBase, INivelEducativoDAO
    {
        public NivelEducativoDAO(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> ActualizarReplica(NivelEducativoReplica request)
        {
            const string sql = @"UPDATE dbo.nivel_educativo
                                        SET
                                    ID_MODALIDAD_EDUCATIVA = @ID_MODALIDAD_EDUCATIVA,
                                    DESCRIPCION_NIVEL_EDUCATIVO = @DESCRIPCION_NIVEL_EDUCATIVO,
                                    ABREVIATURA_NIVEL_EDUCATIVO = @ABREVIATURA_NIVEL_EDUCATIVO,
                                    ORDEN = @ORDEN,
                                    ACTIVO = @ACTIVO,
                                    FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                    USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                    IP_MODIFICACION = @IP_MODIFICACION
                                        WHERE
                                            ID_NIVEL_EDUCATIVO = @ID_NIVEL_EDUCATIVO";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_NIVEL_EDUCATIVO", SqlDbType.Int) {Value = request.idNivelEducativo},
                new SqlParameter("@ID_MODALIDAD_EDUCATIVA", SqlDbType.Int) {Value = request.idModalidadEducativa},
                new SqlParameter("@DESCRIPCION_NIVEL_EDUCATIVO", SqlDbType.VarChar, 50) {Value = request.descripcionNivelEducativo},
                new SqlParameter("@ABREVIATURA_NIVEL_EDUCATIVO", SqlDbType.VarChar, 10) {Value = request.abreviaturaNivelEducativo},
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

        public async Task<int> CrearReplica(NivelEducativoReplica request)
        {
            const string sql = @"INSERT INTO dbo.nivel_educativo(
                                        ID_NIVEL_EDUCATIVO,
                                        ID_MODALIDAD_EDUCATIVA,
                                        CODIGO_NIVEL_EDUCATIVO,
                                        DESCRIPCION_NIVEL_EDUCATIVO,
                                        ABREVIATURA_NIVEL_EDUCATIVO,
                                        ORDEN,
                                        ACTIVO,
                                        FECHA_CREACION,
                                        USUARIO_CREACION,
                                        IP_CREACION
                                        )
                                            output INSERTED.ID_NIVEL_EDUCATIVO
                                            VALUES (
                                                NEXT VALUE FOR dbo.seq_nivel_educativo,
                                                @ID_MODALIDAD_EDUCATIVA,
                                                @CODIGO_NIVEL_EDUCATIVO,
                                                @DESCRIPCION_NIVEL_EDUCATIVO,
                                                @ABREVIATURA_NIVEL_EDUCATIVO,   
                                                @ORDEN,
                                                @ACTIVO,
                                                @FECHA_CREACION,
                                                @USUARIO_CREACION,
                                                @IP_CREACION
                                                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_MODALIDAD_EDUCATIVA", SqlDbType.Int) {Value = request.idModalidadEducativa},
                new SqlParameter("@CODIGO_NIVEL_EDUCATIVO", SqlDbType.VarChar,4) {Value = request.codigoNivelEducativo},
                new SqlParameter("@DESCRIPCION_NIVEL_EDUCATIVO", SqlDbType.VarChar, 50) {Value = request.descripcionNivelEducativo},
                new SqlParameter("@ABREVIATURA_NIVEL_EDUCATIVO", SqlDbType.VarChar, 10) {Value = request.abreviaturaNivelEducativo},
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

        public async Task<int> EliminarReplica(NivelEducativoReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[nivel_educativo] a
                WHERE a.ID_NIVEL_EDUCATIVO = @ID_NIVEL_EDUCATIVO ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_NIVEL_EDUCATIVO", SqlDbType.Int) {Value = request.idNivelEducativo},
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

        private NivelEducativo CargarModel(SqlDataReader dr)
        {
            int index = 0;
            NivelEducativo model = new NivelEducativo();
            model.idNivelEducativo = SqlHelper.GetInt32(dr, index);
            return model;
        }

        public async Task<int> GetNivelEducativoByCodigo(string codigoNivelEducativo)
        {
            const string sql = @"
                            SELECT 
                            A.ID_NIVEL_EDUCATIVO
                            FROM dbo.nivel_educativo A WITH (NOLOCK)
                            WHERE A.CODIGO_NIVEL_EDUCATIVO = @CODIGO_NIVEL_EDUCATIVO";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@CODIGO_NIVEL_EDUCATIVO", SqlDbType.VarChar, 4) {Value = codigoNivelEducativo};

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