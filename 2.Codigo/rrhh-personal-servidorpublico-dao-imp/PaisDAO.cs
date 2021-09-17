using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.tecnologia.util.lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class PaisDAO : DAOBase, IPaisDAO
    {
        public PaisDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private Pais LlenarPais(SqlDataReader dr)
        {
            Pais p = new Pais();

            int index = 0;

            p.idPais = SqlHelper.GetInt32(dr, index++);
            p.codigoPais = SqlHelper.GetNullableString(dr, index++);
            p.descripcionPais = SqlHelper.GetNullableString(dr, index++);
            p.activo = SqlHelper.GetBoolean(dr, index++);
            p.abreviaturaPais = SqlHelper.GetNullableString(dr, index++);

            return p;
        }

        public async Task<IEnumerable<Pais>> GetPaises()
        {
            const String sql = @"SELECT
p.ID_PAIS,
p.CODIGO_PAIS,
p.DESCRIPCION_PAIS,
p.ACTIVO,
p.ABREVIATURA_PAIS
    FROM dbo.pais p
    WHERE p.ACTIVO = 1
    ORDER BY p.DESCRIPCION_PAIS";

            SqlDataReader dr = null;
            List<Pais> paises = null;
            Pais p = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = (SqlDataReader)await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, null);
                if (!dr.HasRows)
                    return null;
                paises = new List<Pais>();
                while (dr.ReadAsync().Result)
                {
                    p = LlenarPais(dr);
                    paises.Add(p);

                }
                return paises;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlHelper.CloseDataReader(dr);
                SqlHelper.CloseConnection(con);
            }
        }

        public async Task<Pais> GetPaisPorCodigo(string codigoPais)
        {
            const String sql = @"SELECT
p.ID_PAIS,
p.CODIGO_PAIS,
p.DESCRIPCION_PAIS,
p.ACTIVO,
p.ABREVIATURA_PAIS
    FROM dbo.pais p
    WHERE p.CODIGO_PAIS = @CODIGO_PAIS";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@CODIGO_PAIS", SqlDbType.VarChar, 10);
            par[0].Value = codigoPais;
            SqlDataReader dr = null;
            Pais p = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return null;
                if (dr.ReadAsync().Result)
                    p = LlenarPais(dr);
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlHelper.CloseDataReader(dr);
                SqlHelper.CloseConnection(con);
            }
        }

        public async Task<Pais> GetPaisPorId(int idPais)
        {
            const String sql = @"SELECT
p.ID_PAIS,
p.CODIGO_PAIS,
p.DESCRIPCION_PAIS,
p.ACTIVO,
p.ABREVIATURA_PAIS
    FROM dbo.pais p
    WHERE p.ID_PAIS = @ID_PAIS";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ID_PAIS", SqlDbType.Int);
            par[0].Value = idPais;
            SqlDataReader dr = null;
            Pais p = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return null;
                if (dr.ReadAsync().Result)
                    p = LlenarPais(dr);
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlHelper.CloseDataReader(dr);
                SqlHelper.CloseConnection(con);
            }
        }

        public async Task<int> GetIdPaisPorCodigo(string codigoPais)
        {
            const String sql = @"SELECT p.ID_PAIS FROM dbo.pais p WHERE p.CODIGO_PAIS = @CODIGO_PAIS";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@CODIGO_PAIS", SqlDbType.VarChar, 10);
            par[0].Value = codigoPais;
            SqlDataReader dr = null;
            int p = 0;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(txtConnectionString);
                await con.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(con, CommandType.Text, sql, par);
                if (!dr.HasRows)
                    return p;
                if (dr.ReadAsync().Result)
                    p = dr.GetInt32(0);
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlHelper.CloseDataReader(dr);
                SqlHelper.CloseConnection(con);
            }
        }

        public async Task<int> CrearPais(Pais p)
        {
            const String sql = @"INSERT INTO dbo.pais(ID_PAIS,
CODIGO_PAIS,
DESCRIPCION_PAIS,
ACTIVO,
ABREVIATURA_PAIS,
FECHA_CREACION,
USUARIO_CREACION,
IP_CREACION)
    output INSERTED.ID_PAIS
    VALUES (
        NEXT VALUE FOR dbo.seq_pais,
        @CODIGO_PAIS,
        @DESCRIPCION_PAIS,
        @ACTIVO,
        @ABREVIATURA_PAIS,
        @FECHA_CREACION,
        @USUARIO_CREACION,
        @IP_CREACION)";

            SqlParameter[] par = new SqlParameter[7];

            par[0] = new SqlParameter("@CODIGO_PAIS", SqlDbType.VarChar, 10);
            par[0].Value = p.codigoPais;
            par[1] = new SqlParameter("@DESCRIPCION_PAIS", SqlDbType.VarChar, 200);
            par[1].Value = p.descripcionPais;
            par[2] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[2].Value = p.activo;
            par[3] = new SqlParameter("@ABREVIATURA_PAIS", SqlDbType.VarChar, 10);
            par[3].Value = p.abreviaturaPais;
            par[4] = new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime);
            par[4].Value = p.fechaCreacion;
            par[5] = new SqlParameter("@USUARIO_CREACION", SqlDbType.VarChar, 20);
            par[5].Value = p.usuarioCreacion;
            par[6] = new SqlParameter("@IP_CREACION", SqlDbType.VarChar, 40);
            par[6].Value = p.ipCreacion;

            try
            {
                int idPais = Convert.ToInt32(await SqlHelper.ExecuteScalarAsync(txtConnectionString, CommandType.Text, sql, par));

                return idPais;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarPais(Pais p)
        {
            const String sql = @"UPDATE dbo.pais
    SET
CODIGO_PAIS = @CODIGO_PAIS,
DESCRIPCION_PAIS = @DESCRIPCION_PAIS,
ACTIVO = @ACTIVO,
ABREVIATURA_PAIS = @ABREVIATURA_PAIS,
FECHA_MODIFICACION = @FECHA_MODIFICACION,
USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
IP_MODIFICACION = @IP_MODIFICACION
    WHERE ID_PAIS = @ID_PAIS";
            SqlParameter[] par = new SqlParameter[8];

            par[0] = new SqlParameter("@ID_PAIS", SqlDbType.Int);
            par[0].Value = p.idPais;
            par[1] = new SqlParameter("@CODIGO_PAIS", SqlDbType.VarChar, 10);
            par[1].Value = p.codigoPais;
            par[2] = new SqlParameter("@DESCRIPCION_PAIS", SqlDbType.VarChar, 200);
            par[2].Value = p.descripcionPais;
            par[3] = new SqlParameter("@ACTIVO", SqlDbType.Bit);
            par[3].Value = p.activo;
            par[4] = new SqlParameter("@ABREVIATURA_PAIS", SqlDbType.VarChar, 10);
            par[4].Value = p.abreviaturaPais;
            par[5] = new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime);
            par[5].Value = p.fechaModificacion;
            par[6] = new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20);
            par[6].Value = p.usuarioModificacion;
            par[7] = new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40);
            par[7].Value = p.ipModificacion;

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
