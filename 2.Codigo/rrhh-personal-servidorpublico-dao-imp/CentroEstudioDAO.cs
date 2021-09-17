using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class CentroEstudioDAO : DAOBase, ICentroEstudioDAO
    {
        public CentroEstudioDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }


        public async Task<int> GetIdCentroEstudioPorCodigo(int codigoCentroEstudio)
        {
            const string sql = @"SELECT
                                        a.ID_CENTRO_ESTUDIO                                      
                                        FROM dbo.centro_estudio a
                                        WHERE a.CODIGO_CENTRO_ESTUDIO = @CODIGO_CENTRO_ESTUDIO";

            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@CODIGO_CENTRO_ESTUDIO", SqlDbType.Int) {Value = codigoCentroEstudio};
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

        public async Task<int> Crear(CentroEstudioReplica request)
        {
            const string sql = @"insert into [dbo].[centro_estudio](ID_CENTRO_ESTUDIO,
                                                          ID_PAIS,
                                                          ID_DEPARTAMENTO,
                                                          ID_PROVINCIA,
                                                          ID_DISTRITO,
                                                          ID_NIVEL_CENTRO_ESTUDIO,
                                                          CODIGO_CENTRO_ESTUDIO,
                                                          CODIGO_ORIGEN_CENTRO_ESTUDIO,
                                                          DESCRIPCION_CENTRO_ESTUDIO,
                                                          ACTIVO,
                                                          ELIMINADO,
                                                          FECHA_CREACION,
                                                          USUARIO_CREACION,
                                                          IP_CREACION)
                                output inserted.ID_CENTRO_ESTUDIO
                                values (NEXT VALUE FOR dbo.seq_centro_estudio,
                                        @ID_PAIS,
                                        @ID_DEPARTAMENTO,
                                        @ID_PROVINCIA,
                                        @ID_DISTRITO,
                                        @ID_NIVEL_CENTRO_ESTUDIO,
                                        @CODIGO_CENTRO_ESTUDIO,
                                        @CODIGO_ORIGEN_CENTRO_ESTUDIO,
                                        @DESCRIPCION_CENTRO_ESTUDIO,
                                        @ACTIVO,
                                        @ELIMINADO,
                                        @FECHA_CREACION,
                                        @USUARIO_CREACION,
                                        @IP_CREACION)";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_PAIS", SqlDbType.Int) {Value = request.idPais},
                new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int) {Value = request.idDepartamento},
                new SqlParameter("@ID_PROVINCIA", SqlDbType.Int) {Value = request.idProvincia},
                new SqlParameter("@ID_DISTRITO", SqlDbType.Int) {Value = request.idDistrito},
                new SqlParameter("@ID_NIVEL_CENTRO_ESTUDIO", SqlDbType.Int) {Value = request.idNivelCentroEstudio},
                new SqlParameter("@CODIGO_CENTRO_ESTUDIO", SqlDbType.Int) {Value = request.codigoNivelCentroEstudio},
                new SqlParameter("@CODIGO_ORIGEN_CENTRO_ESTUDIO", SqlDbType.VarChar,20) {Value = request.codigoOrigenCentroEstudio},
                new SqlParameter("@DESCRIPCION_CENTRO_ESTUDIO", SqlDbType.VarChar, 100) {Value = request.descripcionCentroEstudio},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = request.activo},
                new SqlParameter("@ELIMINADO", SqlDbType.Bit) {Value = request.eliminado},
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

        public async Task<int> Actualizar(CentroEstudioReplica request)
        {
            const string sql = @"UPDATE a SET
                                        a.ID_PAIS = @ID_PAIS,
                                        a.ID_DEPARTAMENTO = @ID_DEPARTAMENTO,
                                        a.ID_PROVINCIA = @ID_PROVINCIA,
                                        a.ID_DISTRITO = @ID_DISTRITO,
                                        a.ID_NIVEL_CENTRO_ESTUDIO = @ID_NIVEL_CENTRO_ESTUDIO,               
                                        a.CODIGO_ORIGEN_CENTRO_ESTUDIO = @CODIGO_ORIGEN_CENTRO_ESTUDIO,               
                                        a.DESCRIPCION_CENTRO_ESTUDIO = @DESCRIPCION_CENTRO_ESTUDIO,               
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[centro_estudio] a
                                        WHERE a.ID_CENTRO_ESTUDIO = @ID_CENTRO_ESTUDIO ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_CENTRO_ESTUDIO", SqlDbType.Int) {Value = request.idCentroEstudio},
                new SqlParameter("@ID_PAIS", SqlDbType.Int) {Value = request.idPais},
                new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int) {Value = request.idDepartamento},
                new SqlParameter("@ID_PROVINCIA", SqlDbType.Int) {Value = request.idProvincia},
                new SqlParameter("@ID_DISTRITO", SqlDbType.Int) {Value = request.idDistrito},
                new SqlParameter("@ID_NIVEL_CENTRO_ESTUDIO", SqlDbType.Int) {Value = request.idNivelCentroEstudio},
                new SqlParameter("@CODIGO_ORIGEN_CENTRO_ESTUDIO", SqlDbType.VarChar,20) {Value = request.codigoOrigenCentroEstudio},
                new SqlParameter("@DESCRIPCION_CENTRO_ESTUDIO", SqlDbType.VarChar, 100) {Value = request.descripcionCentroEstudio},
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

        public async Task<int> Eliminar(CentroEstudioReplica request)
        {
            const string sql = @" UPDATE a SET
                                        a.ACTIVO = @ACTIVO,
                                        a.ELIMINADO = @ELIMINADO,
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[centro_estudio] a
                                        WHERE a.ID_CENTRO_ESTUDIO = @ID_CENTRO_ESTUDIO ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_CENTRO_ESTUDIO", SqlDbType.Int) {Value = request.idCentroEstudio},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = false},
                new SqlParameter("@ELIMINADO", SqlDbType.Bit) {Value = true},
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