using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class DistritoDAO: DAOBase, IDistritoDAO
    {
        public DistritoDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private Distrito CargarDistrito(SqlDataReader dr)
        {
            int index = 0;
            Distrito distrito = new Distrito();
            distrito.idDistrito = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            distrito.idDepartamento = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            distrito.idProvincia = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            distrito.codigoDistritoInei = SqlHelper.GetNullableString(dr, index);
            index = index + 1;
            distrito.codigoDistritoReniec = SqlHelper.GetNullableString(dr, index);
            index = index + 1;
            distrito.descripcion = SqlHelper.GetNullableString(dr, index);
            index = index + 1;
            distrito.abreviatura = SqlHelper.GetNullableString(dr, index);

            return distrito;
        }

        public async Task<IEnumerable<Distrito>> GetDistritosByIdProvincia(int idDepartamento, int idProvincia)
        {
            String sql = @" 
                        SELECT 
                                ID_DISTRITO,
                                ID_DEPARTAMENTO,
                                ID_PROVINCIA,
                                CODIGO_DISTRITO_INEI,
                                CODIGO_DISTRITO_RENIEC,
                                DESCRIPCION,
                                ABREVIATURA
                        FROM dbo.distrito
                        WHERE ID_DEPARTAMENTO = @ID_DEPARTAMENTO AND ID_PROVINCIA = @ID_PROVINCIA AND ACTIVO = 1 AND ELIMINADO = 0;";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int);
            parametro[0].Value = idDepartamento;
            parametro[1] = new SqlParameter("@ID_PROVINCIA", SqlDbType.Int);
            parametro[1].Value = idProvincia;

            SqlDataReader dr = null;
            SqlConnection cn = null;

            List<Distrito> response = null;
            Distrito distrito = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                {
                    response = new List<Distrito>();
                    while (dr.ReadAsync().Result)
                    {
                        distrito = CargarDistrito(dr);
                        response.Add(distrito);
                    }
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlHelper.CloseDataReader(dr);
                SqlHelper.CloseConnection(cn);
            }

            return response;
        }

        public async Task<Distrito> GetDistritoPorId(int idDistrito)
        {
            String sql = @"SELECT 
                                ID_DISTRITO,
                                ID_DEPARTAMENTO,
                                ID_PROVINCIA,
                                CODIGO_DISTRITO_INEI,
                                CODIGO_DISTRITO_RENIEC,
                                DESCRIPCION,
                                ABREVIATURA
                            FROM dbo.distrito
                            WHERE ID_DISTRITO = @ID_DISTRITO";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@ID_DISTRITO", SqlDbType.Int);
            parametro[0].Value = idDistrito;

            SqlDataReader dr = null;
            SqlConnection cn = null;
            Distrito response = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                {
                    response = new Distrito();
                    if (dr.ReadAsync().Result)
                    {
                        response = CargarDistrito(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlHelper.CloseDataReader(dr);
                SqlHelper.CloseConnection(cn);
            }

            return response;
        }

        public async Task<Distrito> GetDistritoPorCodigoInei(string codigoDistritoInei)
        {
            String sql = @"SELECT 
                                ID_DISTRITO,
                                ID_DEPARTAMENTO,
                                ID_PROVINCIA,
                                CODIGO_DISTRITO_INEI,
                                CODIGO_DISTRITO_RENIEC,
                                DESCRIPCION,
                                ABREVIATURA
                            FROM dbo.distrito
                            WHERE CODIGO_DISTRITO_INEI = @CODIGO_DISTRITO_INEI";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@CODIGO_DISTRITO_INEI", SqlDbType.Int);
            parametro[0].Value = codigoDistritoInei;

            SqlDataReader dr = null;
            SqlConnection cn = null;
            Distrito response = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                {
                    response = new Distrito();
                    if (dr.ReadAsync().Result)
                    {
                        response = CargarDistrito(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlHelper.CloseDataReader(dr);
                SqlHelper.CloseConnection(cn);
            }

            return response;
        }

        public async Task<int> CrearDistrito(Distrito d)
        {
            const String sql = @"INSERT INTO dbo.distrito(ID_DISTRITO,
ID_DEPARTAMENTO,
ID_PROVINCIA,
CODIGO_DISTRITO_INEI,
CODIGO_DISTRITO_RENIEC,
DESCRIPCION,
ABREVIATURA,
ACTIVO,
ELIMINADO,
CODIGO_USUARIO_CREACION,
FECHA_CREACION)
    output INSERTED.ID_DISTRITO
    VALUES (
        NEXT VALUE FOR dbo.seq_distrito,,
        @ID_DEPARTAMENTO,
        @ID_PROVINCIA,
        @CODIGO_DISTRITO_INEI,
        @CODIGO_DISTRITO_RENIEC,
        @DESCRIPCION,
        @ABREVIATURA,
        @ACTIVO,
        @ELIMINADO,
        @CODIGO_USUARIO_CREACION,
        @FECHA_CREACION)";

            SqlParameter[] par = new SqlParameter[10];

            par[0] = new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int);
            par[0].Value = d.idDepartamento;
            par[1] = new SqlParameter("@ID_PROVINCIA", SqlDbType.Int);
            par[1].Value = d.idProvincia;
            par[2] = new SqlParameter("@CODIGO_DISTRITO_INEI", SqlDbType.VarChar, 10);
            par[2].Value = d.codigoDistritoInei;
            par[3] = new SqlParameter("@CODIGO_DISTRITO_RENIEC", SqlDbType.VarChar, 10);
            par[3].Value = d.codigoDistritoReniec;
            par[4] = new SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 100);
            par[4].Value = d.descripcion;
            par[5] = new SqlParameter("@ABREVIATURA", SqlDbType.VarChar, 7);
            par[5].Value = d.abreviatura;
            par[6] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[6].Value = d.activo;
            par[7] = new SqlParameter("@ELIMINADO", SqlDbType.Bit);
            par[7].Value = d.eliminado;
            par[8] = new SqlParameter("@CODIGO_USUARIO_CREACION", SqlDbType.VarChar, 20);
            par[8].Value = d.usuarioCreacion;
            par[9] = new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime);
            par[9].Value = d.fechaCreacion;

            try
            {
                int idDistrito = Convert.ToInt32(await SqlHelper.ExecuteScalarAsync(txtConnectionString, CommandType.Text, sql, par));

                return idDistrito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarDistrito(Distrito d)
        {
            const String sql = @"UPDATE dbo.distrito
    SET
ID_DEPARTAMENTO = @ID_DEPARTAMENTO,
ID_PROVINCIA = @ID_PROVINCIA,
CODIGO_DISTRITO_INEI = @CODIGO_DISTRITO_INEI,
CODIGO_DISTRITO_RENIEC = @CODIGO_DISTRITO_RENIEC,
DESCRIPCION = @DESCRIPCION,
ABREVIATURA = @ABREVIATURA,
ACTIVO = @ACTIVO,
ELIMINADO = @ELIMINADO,
CODIGO_USUARIO_MODIFICACION = @CODIGO_USUARIO_MODIFICACION,
FECHA_MODIFICACION = @FECHA_MODIFICACION
    WHERE ID_DISTRITO = @ID_DISTRITO";

            SqlParameter[] par = new SqlParameter[11];

            par[0] = new SqlParameter("@ID_DISTRITO", SqlDbType.Int);
            par[0].Value = d.idDistrito;
            par[1] = new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int);
            par[1].Value = d.idDepartamento;
            par[2] = new SqlParameter("@ID_PROVINCIA", SqlDbType.Int);
            par[2].Value = d.idProvincia;
            par[3] = new SqlParameter("@CODIGO_DISTRITO_INEI", SqlDbType.VarChar, 10);
            par[3].Value = d.codigoDistritoInei;
            par[4] = new SqlParameter("@CODIGO_DISTRITO_RENIEC", SqlDbType.VarChar, 10);
            par[4].Value = d.codigoDistritoReniec;
            par[5] = new SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 100);
            par[5].Value = d.descripcion;
            par[6] = new SqlParameter("@ABREVIATURA", SqlDbType.VarChar, 7);
            par[6].Value = d.abreviatura;
            par[7] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[7].Value = d.activo;
            par[8] = new SqlParameter("@ELIMINADO", SqlDbType.Bit);
            par[8].Value = d.eliminado;
            par[9] = new SqlParameter("@CODIGO_USUARIO_MODIFICACION", SqlDbType.VarChar, 20);
            par[9].Value = d.usuarioModificacion;
            par[10] = new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime);
            par[10].Value = d.fechaModificacion;

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
