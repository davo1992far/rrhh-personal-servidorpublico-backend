using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class CatalogoDAO : DAOBase, ICatalogoDAO
    {
        public CatalogoDAO(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        private Catalogo LlenarCatalogo(SqlDataReader dr)
        {
            Catalogo c = new Catalogo();

            int index = 0;

            c.idCatalogo = SqlHelper.GetInt32(dr, index++);
            c.codigoCatalogo = SqlHelper.GetInt32(dr, index++);
            c.descripcionCatalogo = SqlHelper.GetString(dr, index++);
            c.activo = SqlHelper.GetBoolean(dr, index++);
            c.eliminado = SqlHelper.GetBoolean(dr, index++);

            return c;
        }

        public async Task<Catalogo> GetCatalogoPorCodigo(int codigoCatalogo)
        {
            const string sql = @"SELECT
                                    c.ID_CATALOGO,
                                    c.CODIGO_CATALOGO,
                                    c.DESCRIPCION_CATALOGO,
                                    c.ACTIVO,                                 
                                    c.ELIMINADO
                                        FROM dbo.catalogo c
                                        WHERE
                                            c.CODIGO_CATALOGO = @CODIGO_CATALOGO";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@CODIGO_CATALOGO", SqlDbType.Int) {Value = codigoCatalogo};
            SqlDataReader dr = null;
            Catalogo c = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return null;
                if (await dr.ReadAsync())
                    c = LlenarCatalogo(dr);
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

        public async Task<int> CrearCatalogo(Catalogo c)
        {
            const string sql = @"INSERT INTO dbo.catalogo(
                                            ID_CATALOGO,
                                            CODIGO_CATALOGO,
                                            DESCRIPCION_CATALOGO,
                                            ACTIVO,                                           
                                            ELIMINADO,
                                            FECHA_CREACION,
                                            USUARIO_CREACION,
                                            IP_CREACION)
                                                output INSERTED.ID_CATALOGO
                                                VALUES (
                                                    NEXT VALUE FOR dbo.seq_catalogo,
                                                    @CODIGO_CATALOGO,
                                                    @DESCRIPCION_CATALOGO,
                                                    @ACTIVO,                                                   
                                                    @ELIMINADO,
                                                    @FECHA_CREACION,
                                                    @USUARIO_CREACION,
                                                    @IP_CREACION)";

            SqlParameter[] par = new SqlParameter[7];

            par[0] = new SqlParameter("@CODIGO_CATALOGO", SqlDbType.Int);
            par[0].Value = c.codigoCatalogo;
            par[1] = new SqlParameter("@DESCRIPCION_CATALOGO", SqlDbType.VarChar, 100);
            par[1].Value = c.descripcionCatalogo;
            par[2] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[2].Value = c.activo;
            par[3] = new SqlParameter("@ELIMINADO", SqlDbType.Bit);
            par[3].Value = c.eliminado;
            par[4] = new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime);
            par[4].Value = c.fechaCreacion;
            par[5] = new SqlParameter("@USUARIO_CREACION", SqlDbType.VarChar, 20);
            par[5].Value = c.usuarioCreacion;
            par[6] = new SqlParameter("@IP_CREACION", SqlDbType.VarChar, 40);
            par[6].Value = c.ipCreacion;

            try
            {
                int idCatalogo = Convert.ToInt32(await SqlHelper.ExecuteScalarAsync(txtConnectionString, CommandType.Text, sql, par));

                return idCatalogo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarCatalogo(Catalogo c)
        {
            const String sql = @"UPDATE dbo.catalogo
                                            SET
                                        CODIGO_CATALOGO = @CODIGO_CATALOGO,
                                        DESCRIPCION_CATALOGO = @DESCRIPCION_CATALOGO,
                                        ACTIVO = @ACTIVO,                                       
                                        ELIMINADO = @ELIMINADO,
                                        FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        IP_MODIFICACION = @IP_MODIFICACION
                                            WHERE
                                                ID_CATALOGO = @ID_CATALOGO";

            SqlParameter[] par = new SqlParameter[8];

            par[0] = new SqlParameter("@ID_CATALOGO", SqlDbType.Int);
            par[0].Value = c.idCatalogo;
            par[1] = new SqlParameter("@CODIGO_CATALOGO", SqlDbType.Int);
            par[1].Value = c.codigoCatalogo;
            par[2] = new SqlParameter("@DESCRIPCION_CATALOGO", SqlDbType.VarChar, 100);
            par[2].Value = c.descripcionCatalogo;
            par[3] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[3].Value = c.activo;
            par[4] = new SqlParameter("@ELIMINADO", SqlDbType.Bit);
            par[4].Value = c.eliminado;
            par[5] = new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime);
            par[5].Value = c.fechaModificacion;
            par[6] = new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20);
            par[6].Value = c.usuarioModificacion;
            par[7] = new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40);
            par[7].Value = c.ipModificacion;

            try
            {
                return await SqlHelper.ExecuteNonQueryAsync(txtConnectionString, CommandType.Text, sql, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarCatalogo(Catalogo c)
        {
            const string sql = @"UPDATE dbo.catalogo
                                            SET
                                        ACTIVO = @ACTIVO,
                                        ELIMINADO = @ELIMINADO,
                                        FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        IP_MODIFICACION = @IP_MODIFICACION
                                            WHERE
                                                ID_CATALOGO = @ID_CATALOGO";

            SqlParameter[] par = new SqlParameter[6];

            par[0] = new SqlParameter("@ID_CATALOGO", SqlDbType.Int);
            par[0].Value = c.idCatalogo;
            par[1] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[1].Value = c.activo;
            par[2] = new SqlParameter("@ELIMINADO", SqlDbType.Bit);
            par[2].Value = c.eliminado;
            par[3] = new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime);
            par[3].Value = c.fechaModificacion;
            par[4] = new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20);
            par[4].Value = c.usuarioModificacion;
            par[5] = new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40);
            par[5].Value = c.ipModificacion;

            try
            {
                return await SqlHelper.ExecuteNonQueryAsync(txtConnectionString, CommandType.Text, sql, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}