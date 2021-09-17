using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class UgelDAO : DAOBase, IUgelDAO
    {
        public UgelDAO(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> GetIdUgelPorCodigo(string codigoUgel, bool activo)
        {
            const string sql = @"SELECT  ID_UGEL 
                                FROM dbo.ugel WITH (NOLOCK)
                                WHERE CODIGO_UGEL = @CODIGO_UGEL
                                    AND ACTIVO = @ACTIVO;";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@CODIGO_UGEL", SqlDbType.VarChar, 10) {Value = codigoUgel};
            parametro[1] = new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = activo};

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

        public async Task<int> Crear(UgelReplica request)
        {
            const string sql = @"
                insert into [dbo].[ugel](
                    ID_UGEL,
					ID_DRE,
					ID_UNIDAD_EJECUTORA,
					ID_SERVIDOR_PUBLICO_DIRECTOR,
					ID_DISTRITO,
					CODIGO_UGEL,
					DESCRIPCION_UGEL,
					ACTIVO,
					FECHA_CREACION,
					USUARIO_CREACION,
					IP_CREACION	)
                output inserted.ID_UGEL
                values (
                    NEXT VALUE FOR dbo.seq_ugel,
					@ID_DRE,
					@ID_UNIDAD_EJECUTORA,
					@ID_SERVIDOR_PUBLICO_DIRECTOR,
					@ID_DISTRITO,
					@CODIGO_UGEL,
					@DESCRIPCION_UGEL,
					@ACTIVO,
					@FECHA_CREACION,
					@USUARIO_CREACION,
					@IP_CREACION
                )";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_DRE", SqlDbType.Int) {Value = request.idDre},
                new SqlParameter("@ID_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.idUnidadEjecutora},
                new SqlParameter("@ID_SERVIDOR_PUBLICO_DIRECTOR", SqlDbType.BigInt) {Value = request.idServidorPublicoDirector},
                new SqlParameter("@ID_DISTRITO", SqlDbType.Int) {Value = request.idDistrito},
                new SqlParameter("@CODIGO_UGEL", SqlDbType.VarChar, 10) {Value = request.codigoUgel},
                new SqlParameter("@DESCRIPCION_UGEL", SqlDbType.VarChar, 50) {Value = request.descripcionUgel},
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

        public async Task<int> Actualizar(UgelReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ID_DRE = @ID_DRE,
                a.ID_UNIDAD_EJECUTORA = @ID_UNIDAD_EJECUTORA,
                a.ID_SERVIDOR_PUBLICO_DIRECTOR = @ID_SERVIDOR_PUBLICO_DIRECTOR,
                a.ID_DISTRITO = @ID_DISTRITO,
                a.DESCRIPCION_UGEL = @DESCRIPCION_UGEL,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[ugel] a
                WHERE a.ID_UGEL = @ID_UGEL ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_UGEL", SqlDbType.Int) {Value = request.idUgel},
                new SqlParameter("@ID_UNIDAD_EJECUTORA", SqlDbType.Int) {Value = request.idUnidadEjecutora},
                new SqlParameter("@ID_SERVIDOR_PUBLICO_DIRECTOR", SqlDbType.BigInt) {Value = request.idServidorPublicoDirector},
                new SqlParameter("@ID_DISTRITO", SqlDbType.Int) {Value = request.idDistrito},
                new SqlParameter("@ID_DRE", SqlDbType.Int) {Value = request.idDre},
                new SqlParameter("@DESCRIPCION_UGEL", SqlDbType.VarChar, 250) {Value = request.descripcionUgel},
                new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime) {Value = request.fechaModificacion},
                new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20) {Value = request.usuarioModificacion},
                new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40) {Value = request.ipModificacion}
            };

            TransactionBase tran = null;
            try
            {
                tran = await SqlHelper.BeginTransaction(txtConnectionString);
                var response = await SqlHelper.ExecuteNonQueryAsync(tran.connection, tran.transaction, CommandType.Text, sql, parameter);
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

        public async Task<int> Eliminar(UgelReplica request)
        {
            const string sql = @"
                UPDATE a SET
                a.ACTIVO = @ACTIVO,
                a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                a.IP_MODIFICACION = @IP_MODIFICACION
                FROM [dbo].[ugel] a
                WHERE a.ID_UGEL = @ID_UGEL ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_UGEL", SqlDbType.Int) {Value = request.idUgel},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = false},
                new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime) {Value = request.fechaModificacion},
                new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20) {Value = request.usuarioModificacion},
                new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40) {Value = request.ipModificacion}
            };
            TransactionBase tran = null;
            try
            {
                tran = await SqlHelper.BeginTransaction(txtConnectionString);
                var response = await SqlHelper.ExecuteNonQueryAsync(tran.connection, tran.transaction, CommandType.Text, sql, parameter);
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