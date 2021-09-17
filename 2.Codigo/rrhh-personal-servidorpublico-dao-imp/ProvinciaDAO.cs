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
    public class ProvinciaDAO: DAOBase, IProvinciaDAO
    {
        public ProvinciaDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private Provincia CargarProvincia(SqlDataReader dr)
        {
            int index = 0;
            Provincia provincia = new Provincia();
            provincia.idProvincia = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            provincia.idDepartamento = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            provincia.codigoProvinciaInei = SqlHelper.GetNullableString(dr, index);
            index = index + 1;
            provincia.codigoProvinciaReniec = SqlHelper.GetNullableString(dr, index);
            index = index + 1;
            provincia.descripcion = SqlHelper.GetNullableString(dr, index);
            index = index + 1;
            provincia.abreviatura = SqlHelper.GetNullableString(dr, index);

            return provincia;
        }

        public async Task<IEnumerable<Provincia>> GetProvinciasByIdDepartamento(int idDepartamento)
        {
            String sql = @" 
                        SELECT 
                        ID_PROVINCIA, 
                        ID_DEPARTAMENTO,
                        CODIGO_PROVINCIA_INEI,
                        CODIGO_PROVINCIA_RENIEC,                       
                        DESCRIPCION,
                        ABREVIATURA
                        FROM dbo.provincia
                        WHERE ID_DEPARTAMENTO = @ID_DEPARTAMENTO AND ACTIVO = 1 AND ELIMINADO = 0;";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int);
            parametro[0].Value = idDepartamento;

            SqlDataReader dr = null;
            SqlConnection cn = null;

            List<Provincia> response = null;
            Provincia provincia = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                {
                    response = new List<Provincia>();
                    while (dr.ReadAsync().Result)
                    {
                        provincia = CargarProvincia(dr);
                        response.Add(provincia);
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

        public async Task<int> GetValidarProvinciaId(int idDepartamento, int idProvincia)
        {
            int response = 0;
            String sql = @" 
                        SELECT 
                        COUNT(1) registro
                        FROM dbo.provincia
                        WHERE ID_DEPARTAMENTO = @ID_DEPARTAMENTO and ID_PROVINCIA = @ID_PROVINCIA AND ACTIVO = 1 AND ELIMINADO = 0;";

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int);
            parametro[0].Value = idDepartamento;
            parametro[1] = new SqlParameter("@ID_PROVINCIA", SqlDbType.Int);
            parametro[1].Value = idProvincia;            

            SqlDataReader dr = null;
            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                    if (dr.ReadAsync().Result) response = SqlHelper.GetInt32(dr, 0);
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

        public async Task<Provincia> GetProvinciaPorId(int idProvincia)
        {
            String sql = @"SELECT 
                        ID_PROVINCIA, 
                        ID_DEPARTAMENTO,
                        CODIGO_PROVINCIA_INEI,
                        CODIGO_PROVINCIA_RENIEC,                       
                        DESCRIPCION,
                        ABREVIATURA
                            FROM dbo.provincia
                            WHERE ID_PROVINCIA = @ID_PROVINCIA";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@ID_PROVINCIA", SqlDbType.Int);
            parametro[0].Value = idProvincia;

            SqlDataReader dr = null;
            SqlConnection cn = null;

            Provincia response = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                {
                    response = new Provincia();
                    if (dr.ReadAsync().Result)
                    {
                        response = CargarProvincia(dr);
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

        public async Task<Provincia> GetProvinciaPorCodigoInei(string codigoProvinciaInei)
        {
            String sql = @"SELECT 
                        ID_PROVINCIA, 
                        ID_DEPARTAMENTO,
                        CODIGO_PROVINCIA_INEI,
                        CODIGO_PROVINCIA_RENIEC,                       
                        DESCRIPCION,
                        ABREVIATURA
                        FROM dbo.provincia
                        WHERE CODIGO_PROVINCIA_INEI = @CODIGO_PROVINCIA_INEI";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@CODIGO_PROVINCIA_INEI", SqlDbType.VarChar, 10);
            parametro[0].Value = codigoProvinciaInei;

            SqlDataReader dr = null;
            SqlConnection cn = null;

            Provincia response = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                {
                    response = new Provincia();
                    if (dr.ReadAsync().Result)
                    {
                        response = CargarProvincia(dr);
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

        public async Task<Provincia> GetIdProvinciaByCodigoInei(string codigoProvinciaInei)
        {
            Provincia response = null;
            String sql = @"SELECT ID_DEPARTAMENTO, ID_PROVINCIA FROM dbo.provincia WHERE CODIGO_PROVINCIA_INEI = @CODIGO_PROVINCIA_INEI;";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@CODIGO_PROVINCIA_INEI", SqlDbType.VarChar, 10);
            parametro[0].Value = codigoProvinciaInei;

            SqlDataReader dr = null;
            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                    if (dr.ReadAsync().Result)
                    {
                        response = new Provincia();
                        response.idDepartamento = SqlHelper.GetInt32(dr, 0);
                        response.idProvincia = SqlHelper.GetInt32(dr, 1);
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

        public async Task<int> CrearProvincia(Provincia p)
        {
            const String sql = @"INSERT INTO dbo.provincia(ID_PROVINCIA,
ID_DEPARTAMENTO,
CODIGO_PROVINCIA_INEI,
CODIGO_PROVINCIA_RENIEC,
DESCRIPCION,
ABREVIATURA,
ACTIVO,
ELIMINADO,
CODIGO_USUARIO_CREACION,
FECHA_CREACION)
    output INSERTED.ID_PROVINCIA
    VALUES (
        NEXT VALUE FOR dbo.seq_provincia,
        @ID_DEPARTAMENTO,
        @CODIGO_PROVINCIA_INEI,
        @CODIGO_PROVINCIA_RENIEC,
        @DESCRIPCION,
        @ABREVIATURA,
        @ACTIVO,
        @ELIMINADO,
        @CODIGO_USUARIO_CREACION,
        @FECHA_CREACION)";

            SqlParameter[] par = new SqlParameter[9];

            par[0] = new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int);
            par[0].Value = p.idDepartamento;
            par[1] = new SqlParameter("@CODIGO_PROVINCIA_INEI", SqlDbType.VarChar, 10);
            par[1].Value = p.codigoProvinciaInei;
            par[2] = new SqlParameter("@CODIGO_PROVINCIA_RENIEC", SqlDbType.VarChar, 10);
            par[2].Value = p.codigoProvinciaReniec;
            par[3] = new SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 100);
            par[3].Value = p.descripcion;
            par[4] = new SqlParameter("@ABREVIATURA", SqlDbType.VarChar, 7);
            par[4].Value = p.abreviatura;
            par[5] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[5].Value = p.activo;
            par[6] = new SqlParameter("@ELIMINADO", SqlDbType.Bit);
            par[6].Value = p.eliminado;
            par[7] = new SqlParameter("@CODIGO_USUARIO_CREACION", SqlDbType.VarChar, 20);
            par[7].Value = p.usuarioCreacion;
            par[8] = new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime);
            par[8].Value = p.fechaCreacion;

            try
            {
                int idProvincia = Convert.ToInt32(await SqlHelper.ExecuteScalarAsync(txtConnectionString, CommandType.Text, sql, par));

                return idProvincia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarProvincia(Provincia p)
        {
            const String sql = @"UPDATE dbo.provincia
    SET
ID_DEPARTAMENTO = @ID_DEPARTAMENTO,
CODIGO_PROVINCIA_INEI = @CODIGO_PROVINCIA_INEI,
CODIGO_PROVINCIA_RENIEC = @CODIGO_PROVINCIA_RENIEC,
DESCRIPCION = @DESCRIPCION,
ABREVIATURA = @ABREVIATURA,
ACTIVO = @ACTIVO,
ELIMINADO = @ELIMINADO,
CODIGO_USUARIO_MODIFICACION = @CODIGO_USUARIO_MODIFICACION,
FECHA_MODIFICACION = @FECHA_MODIFICACION
    WHERE ID_PROVINCIA = @ID_PROVINCIA";

            SqlParameter[] par = new SqlParameter[10];

            par[0] = new SqlParameter("@ID_PROVINCIA", SqlDbType.Int);
            par[0].Value = p.idProvincia;
            par[1] = new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int);
            par[1].Value = p.idDepartamento;
            par[2] = new SqlParameter("@CODIGO_PROVINCIA_INEI", SqlDbType.VarChar, 10);
            par[2].Value = p.codigoProvinciaInei;
            par[3] = new SqlParameter("@CODIGO_PROVINCIA_RENIEC", SqlDbType.VarChar, 10);
            par[3].Value = p.codigoProvinciaReniec;
            par[4] = new SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 100);
            par[4].Value = p.descripcion;
            par[5] = new SqlParameter("@ABREVIATURA", SqlDbType.VarChar, 7);
            par[5].Value = p.abreviatura;
            par[6] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[6].Value = p.activo;
            par[7] = new SqlParameter("@ELIMINADO", SqlDbType.Bit);
            par[7].Value = p.eliminado;
            par[8] = new SqlParameter("@CODIGO_USUARIO_MODIFICACION", SqlDbType.VarChar, 20);
            par[8].Value = p.usuarioModificacion;
            par[9] = new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime);
            par[9].Value = p.fechaModificacion;

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
