using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class CatalogoItemDAO : DAOBase, ICatalogoItemDAO
    {
        public CatalogoItemDAO(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        private CatalogoItemReplica LlenarCatalogoItem(SqlDataReader dr)
        {
            CatalogoItemReplica c = new CatalogoItemReplica();

            int index = 0;

            c.idCatalogoItem = SqlHelper.GetInt32(dr, index++);
            c.idCatalogo = SqlHelper.GetInt32(dr, index++);
            c.codigoCatalogoItem = SqlHelper.GetInt32(dr, index++);
            c.orden = SqlHelper.GetNullableInt32(dr, index++);
            c.descripcionCatalogoItem = SqlHelper.GetString(dr, index++);
            c.abreviaturaCatalogoItem = SqlHelper.GetString(dr, index++);

            return c;
        }

        public async Task<CatalogoItemReplica> GetCatalogoItemPorcodigo(int codigoCatalogoItem)
        {
            const string sql = @"SELECT
                                        c.ID_CATALOGO_ITEM,
                                        c.ID_CATALOGO,
                                        c.CODIGO_CATALOGO_ITEM,
                                        c.ORDEN,
                                        c.DESCRIPCION_CATALOGO_ITEM,
                                        c.ABREVIATURA_CATALOGO_ITEM
                                            FROM dbo.catalogo_item c
                                            WHERE
                                                c.CODIGO_CATALOGO_ITEM = @CODIGO_CATALOGO_ITEM";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@CODIGO_CATALOGO_ITEM", SqlDbType.Int) {Value = codigoCatalogoItem};
            SqlDataReader dr = null;
            CatalogoItemReplica c = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return null;
                if (await dr.ReadAsync())
                    c = LlenarCatalogoItem(dr);
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


        public async Task<int> CrearCatalogoItem(CatalogoItemReplica c)
        {
            const string sql = @"INSERT INTO dbo.catalogo_item(
                                                            ID_CATALOGO_ITEM,
                                                            ID_CATALOGO,
                                                            CODIGO_CATALOGO_ITEM,
                                                            ORDEN,
                                                            DESCRIPCION_CATALOGO_ITEM,
                                                            ABREVIATURA_CATALOGO_ITEM,
                                                            ACTIVO,
                                                            ELIMINADO,
                                                            FECHA_CREACION,
                                                            USUARIO_CREACION,
                                                            IP_CREACION)
                                                                output INSERTED.ID_CATALOGO_ITEM
                                                                VALUES (
                                                                    NEXT VALUE FOR dbo.seq_catalogo_item,
                                                                    @ID_CATALOGO,
                                                                    @CODIGO_CATALOGO_ITEM,
                                                                    @ORDEN,
                                                                    @DESCRIPCION_CATALOGO_ITEM,
                                                                    @ABREVIATURA_CATALOGO_ITEM,
                                                                    @ACTIVO,
                                                                    @ELIMINADO,
                                                                    @FECHA_CREACION,
                                                                    @USUARIO_CREACION,
                                                                    @IP_CREACION)";

            SqlParameter[] par = new SqlParameter[10];

            par[0] = new SqlParameter("@ID_CATALOGO", SqlDbType.Int);
            par[0].Value = c.idCatalogo;
            par[1] = new SqlParameter("@CODIGO_CATALOGO_ITEM", SqlDbType.Int);
            par[1].Value = c.codigoCatalogoItem;
            par[2] = new SqlParameter("@ORDEN", SqlDbType.Int);
            par[2].Value = c.orden;
            par[3] = new SqlParameter("@DESCRIPCION_CATALOGO_ITEM", SqlDbType.VarChar, 250);
            par[3].Value = c.descripcionCatalogoItem;
            par[4] = new SqlParameter("@ABREVIATURA_CATALOGO_ITEM", SqlDbType.VarChar, 50);
            par[4].Value = c.abreviaturaCatalogoItem;
            par[5] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[5].Value = c.activo;
            par[6] = new SqlParameter("@ELIMINADO", SqlDbType.Bit);
            par[6].Value = c.eliminado;
            par[7] = new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime);
            par[7].Value = c.fechaCreacion;
            par[8] = new SqlParameter("@USUARIO_CREACION", SqlDbType.VarChar, 20);
            par[8].Value = c.usuarioCreacion;
            par[9] = new SqlParameter("@IP_CREACION", SqlDbType.VarChar, 40);
            par[9].Value = c.ipCreacion;

            try
            {
                int idCatalogoItem = Convert.ToInt32(await SqlHelper.ExecuteScalarAsync(txtConnectionString, CommandType.Text, sql, par));

                return idCatalogoItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarCatalogoItem(CatalogoItemReplica c)
        {
            const string sql = @"UPDATE dbo.catalogo_item
                                                SET
                                            ID_CATALOGO = @ID_CATALOGO,
                                            CODIGO_CATALOGO_ITEM = @CODIGO_CATALOGO_ITEM,
                                            ORDEN = @ORDEN,
                                            DESCRIPCION_CATALOGO_ITEM = @DESCRIPCION_CATALOGO_ITEM,
                                            ABREVIATURA_CATALOGO_ITEM = @ABREVIATURA_CATALOGO_ITEM,
                                            ACTIVO = @ACTIVO,
                                            ELIMINADO = @ELIMINADO,
                                            FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                            USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                            IP_MODIFICACION = @IP_MODIFICACION
                                                WHERE
                                                    ID_CATALOGO_ITEM = @ID_CATALOGO_ITEM";

            SqlParameter[] par = new SqlParameter[11];

            par[0] = new SqlParameter("@ID_CATALOGO_ITEM", SqlDbType.Int);
            par[0].Value = c.idCatalogoItem;
            par[1] = new SqlParameter("@ID_CATALOGO", SqlDbType.Int);
            par[1].Value = c.idCatalogo;
            par[2] = new SqlParameter("@CODIGO_CATALOGO_ITEM", SqlDbType.Int);
            par[2].Value = c.codigoCatalogoItem;
            par[3] = new SqlParameter("@ORDEN", SqlDbType.Int);
            par[3].Value = c.orden;
            par[4] = new SqlParameter("@DESCRIPCION_CATALOGO_ITEM", SqlDbType.VarChar, 250);
            par[4].Value = c.descripcionCatalogoItem;
            par[5] = new SqlParameter("@ABREVIATURA_CATALOGO_ITEM", SqlDbType.VarChar, 50);
            par[5].Value = c.abreviaturaCatalogoItem;
            par[6] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[6].Value = c.activo;
            par[7] = new SqlParameter("@ELIMINADO", SqlDbType.Bit);
            par[7].Value = c.eliminado;
            par[8] = new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime);
            par[8].Value = c.fechaModificacion;
            par[9] = new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20);
            par[9].Value = c.usuarioModificacion;
            par[10] = new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40);
            par[10].Value = c.ipModificacion;

            try
            {
                return await SqlHelper.ExecuteNonQueryAsync(txtConnectionString, CommandType.Text, sql, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarCatalogoItem(CatalogoItemReplica c)
        {
            const string sql = @"UPDATE dbo.catalogo_item
                                            SET
                                        ACTIVO = @ACTIVO,
                                        ELIMINADO = @ELIMINADO,
                                        FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        IP_MODIFICACION = @IP_MODIFICACION
                                            WHERE
                                                ID_CATALOGO_ITEM = @ID_CATALOGO_ITEM";

            SqlParameter[] par = new SqlParameter[5];

            par[0] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[0].Value = c.activo;
            par[1] = new SqlParameter("@ELIMINADO", SqlDbType.Bit);
            par[1].Value = c.eliminado;
            par[2] = new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime);
            par[2].Value = c.fechaModificacion;
            par[3] = new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20);
            par[3].Value = c.usuarioModificacion;
            par[4] = new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40);
            par[4].Value = c.ipModificacion;

            try
            {
                return await SqlHelper.ExecuteNonQueryAsync(txtConnectionString, CommandType.Text, sql, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetIdCatalogoItemPorCodigoCatalogo(int codigoCatalogo, int codigoCatalogoItem)
        {
            const string sql = @"
                            SELECT 
                            A.ID_CATALOGO_ITEM
                            FROM dbo.catalogo_item A WITH (NOLOCK)
                            INNER JOIN dbo.catalogo c WITH (NOLOCK) on A.ID_CATALOGO = c.ID_CATALOGO
                            WHERE c.CODIGO_CATALOGO = @CODIGO_CATALOGO and A.CODIGO_CATALOGO_ITEM = @CODIGO_CATALOGO_ITEM";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@CODIGO_CATALOGO", SqlDbType.Int) {Value = codigoCatalogo};
            parametro[1] = new SqlParameter("@CODIGO_CATALOGO_ITEM", SqlDbType.Int) {Value = codigoCatalogoItem};

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


        private CatalogoItem CargarModel(SqlDataReader dr)
        {
            int index = 0;
            CatalogoItem model = new CatalogoItem();
            model.idCatalogoItem = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            model.codigoCatalogoItem = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            model.abreviaturaCatalogoItem = SqlHelper.GetNullableString(dr, index);
            index = index + 1;
            model.descripcionCatalogoItem = SqlHelper.GetNullableString(dr, index);

            return model;
        }

        public async Task<CatalogoItem> GetCatalogoItemPorId(int codigoCatalogo, int idCatalogoItem)
        {
            const string sql = @"
                            SELECT 
                            A.ID_CATALOGO_ITEM,
                            A.CODIGO_CATALOGO_ITEM,
                            A.ABREVIATURA_CATALOGO_ITEM,
                            A.DESCRIPCION_CATALOGO_ITEM
                            FROM dbo.catalogo_item A WITH (NOLOCK)
                            INNER JOIN dbo.catalogo c WITH (NOLOCK) on A.ID_CATALOGO = c.ID_CATALOGO
                            WHERE c.CODIGO_CATALOGO = @CODIGO_CATALOGO and A.ID_CATALOGO_ITEM = @ID_CATALOGO_ITEM";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@CODIGO_CATALOGO", SqlDbType.Int) {Value = codigoCatalogo};
            parametro[1] = new SqlParameter("@ID_CATALOGO_ITEM", SqlDbType.Int) {Value = idCatalogoItem};

            SqlDataReader dr = null;
            SqlConnection cn = null;

            CatalogoItem response = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (!dr.HasRows) return response;
                if (dr.ReadAsync().Result)
                    response = CargarModel(dr);

                return response;
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

        private TipoDocumentoIdentidad CargarTipoDocumentoidentidad(SqlDataReader dr)
        {
            int index = 0;
            TipoDocumentoIdentidad model = new TipoDocumentoIdentidad();
            model.idTipoDocumentoIdentidad = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            model.codigoTipoDocumentoIdentidad = SqlHelper.GetInt32(dr, index);
            return model;
        }

        public async Task<TipoDocumentoIdentidad> GetTipoDocumentoIdentidadByCodigo(int codigoTipoDocumentoIdentidad)
        {
            const string sql = @"
                            SELECT 
                            A.ID_CATALOGO_ITEM,
                            A.CODIGO_CATALOGO_ITEM
                            FROM dbo.catalogo_item A WITH (NOLOCK)
                            INNER JOIN dbo.catalogo c WITH (NOLOCK) on A.ID_CATALOGO = c.ID_CATALOGO
                            WHERE c.CODIGO_CATALOGO = @CODIGO_CATALOGO and A.CODIGO_CATALOGO_ITEM = @CODIGO_CATALOGO_ITEM";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@CODIGO_CATALOGO", SqlDbType.Int) {Value = (int) VariablesGlobales.TablaCatalogo.TIPO_DOCUMENTO_IDENTIDAD};
            parametro[1] = new SqlParameter("@CODIGO_CATALOGO_ITEM", SqlDbType.Int) {Value = codigoTipoDocumentoIdentidad};

            SqlDataReader dr = null;
            SqlConnection cn = null;

            TipoDocumentoIdentidad response = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (!dr.HasRows) return response;
                if (dr.ReadAsync().Result)
                    response = CargarTipoDocumentoidentidad(dr);

                return response;
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

        private SituacionLaboral CargarSituacionLaboral(SqlDataReader dr)
        {
            int index = 0;
            SituacionLaboral model = new SituacionLaboral();
            model.idSituacionLaboral = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            model.codigoSituacionLaboral = SqlHelper.GetInt32(dr, index);
            return model;
        }

        public async Task<SituacionLaboral> GetSituacionLaboralByCodigo(int codigoSituacionLaboral)
        {
            const string sql = @"
                             SELECT
                            A.ID_CATALOGO_ITEM,
                            A.CODIGO_CATALOGO_ITEM
                            FROM dbo.catalogo_item A WITH (NOLOCK)
                            INNER JOIN dbo.catalogo c WITH (NOLOCK) on A.ID_CATALOGO = c.ID_CATALOGO
                            WHERE c.CODIGO_CATALOGO = @CODIGO_CATALOGO and A.CODIGO_CATALOGO_ITEM = @CODIGO_CATALOGO_ITEM";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@CODIGO_CATALOGO", SqlDbType.Int) {Value = (int) VariablesGlobales.TablaCatalogo.SITUACION_LABORAL};
            parametro[1] = new SqlParameter("@CODIGO_CATALOGO_ITEM", SqlDbType.Int) {Value = codigoSituacionLaboral};

            SqlDataReader dr = null;
            SqlConnection cn = null;

            SituacionLaboral response = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (!dr.HasRows)
                    return response;
                if (dr.ReadAsync().Result)
                    response = CargarSituacionLaboral(dr);

                return response;
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

        private CondicionLaboral CargarCondicionLaboral(SqlDataReader dr)
        {
            int index = 0;
            CondicionLaboral model = new CondicionLaboral();
            model.idCondicionLaboral = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            model.codigoCondicionLaboral = SqlHelper.GetInt32(dr, index);
            return model;
        }

        public async Task<CondicionLaboral> GetCondicionLaboralByCodigo(int codigoCondicionLaboral)
        {
            const string sql = @"
                             SELECT
                            A.ID_CATALOGO_ITEM,
                            A.CODIGO_CATALOGO_ITEM
                            FROM dbo.catalogo_item A WITH (NOLOCK)
                            INNER JOIN dbo.catalogo c WITH (NOLOCK) on A.ID_CATALOGO = c.ID_CATALOGO
                            WHERE c.CODIGO_CATALOGO = @CODIGO_CATALOGO and A.CODIGO_CATALOGO_ITEM = @CODIGO_CATALOGO_ITEM";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@CODIGO_CATALOGO", SqlDbType.Int) {Value = (int) VariablesGlobales.TablaCatalogo.CONDICICION_LABORAL};
            parametro[1] = new SqlParameter("@CODIGO_CATALOGO_ITEM", SqlDbType.Int) {Value = codigoCondicionLaboral};

            SqlDataReader dr = null;
            SqlConnection cn = null;

            CondicionLaboral response = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (!dr.HasRows)
                    return response;
                if (dr.ReadAsync().Result)
                    response = CargarCondicionLaboral(dr);

                return response;
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