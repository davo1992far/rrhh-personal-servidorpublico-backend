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
    public class CarreraProfesionalDAO: DAOBase, ICarreraProfesionalDAO
    {
        public CarreraProfesionalDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }


        public async Task<int> GetIdCarreraProfesionalPorCodigo(int codigoCarreraProfesional)
        {
            const string sql = @"SELECT
                                        a.ID_CARRERA_PROFESIONAL                                      
                                        FROM dbo.carrera_profesional a
                                        WHERE a.CODIGO_CARRERA_PROFESIONAL = @CODIGO_CARRERA_PROFESIONAL";

            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@CODIGO_CARRERA_PROFESIONAL", SqlDbType.Int) {Value = codigoCarreraProfesional};
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

        public async Task<int> Crear(CarreraProfesionalReplica request)
        {
            const string sql = @"insert into [dbo].[carrera_profesional](ID_CARRERA_PROFESIONAL,
                                                          ID_GRUPO_CARRERA,
                                                          CODIGO_CARRERA_PROFESIONAL,
                                                          DESCRIPCION_CARRERA_PROFESIONAL,
                                                          ACTIVO,
                                                          FECHA_CREACION,
                                                          USUARIO_CREACION,
                                                          IP_CREACION)
                                output inserted.ID_CARRERA_PROFESIONAL
                                values (NEXT VALUE FOR dbo.seq_carrera_profesional,
                                        @ID_GRUPO_CARRERA,
                                        @CODIGO_CARRERA_PROFESIONAL,
                                        @DESCRIPCION_CARRERA_PROFESIONAL,
                                        @ACTIVO,
                                        @FECHA_CREACION,
                                        @USUARIO_CREACION,
                                        @IP_CREACION)";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_GRUPO_CARRERA", SqlDbType.Int) {Value = request.idGrupoCarrera},
                new SqlParameter("@CODIGO_CARRERA_PROFESIONAL", SqlDbType.Int) {Value = request.codigoCarreraProfesional},
                new SqlParameter("@DESCRIPCION_CARRERA_PROFESIONAL", SqlDbType.VarChar, 300) {Value = request.descripcionCarreraProfesional},
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

        public  async Task<int> Actualizar(CarreraProfesionalReplica request)
        {
              const string sql = @"UPDATE a SET
                                        a.ID_GRUPO_CARRERA = @ID_GRUPO_CARRERA,
                                        a.DESCRIPCION_CARRERA_PROFESIONAL = @DESCRIPCION_CARRERA_PROFESIONAL,               
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[carrera_profesional] a
                                        WHERE a.ID_CARRERA_PROFESIONAL = @ID_CARRERA_PROFESIONAL ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_CARRERA_PROFESIONAL", SqlDbType.Int) {Value = request.idCarreraProfesional},
                new SqlParameter("@ID_GRUPO_CARRERA", SqlDbType.Int) {Value = request.idGrupoCarrera},
                new SqlParameter("@DESCRIPCION_CARRERA_PROFESIONAL", SqlDbType.VarChar,300) {Value = request.descripcionCarreraProfesional},
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

        public async Task<int> Eliminar(CarreraProfesionalReplica request)
        {
            const string sql = @" UPDATE a SET
                                        a.ACTIVO = @ACTIVO,
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[carrera_profesional] a
                                        WHERE a.ID_CARRERA_PROFESIONAL = @ID_CARRERA_PROFESIONAL ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_CARRERA_PROFESIONAL", SqlDbType.Int) {Value = request.idCarreraProfesional},
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