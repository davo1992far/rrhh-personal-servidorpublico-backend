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
    public class DepartamentoDAO : DAOBase, IDepartamentoDAO
    {
        public DepartamentoDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private Departamento CargarDepartamento(SqlDataReader dr)
        {
            int index = 0;
            Departamento departamento = new Departamento();
            departamento.idDepartamento = SqlHelper.GetInt32(dr, index);
            index = index + 1;
            departamento.codigoDepartamentoInei = SqlHelper.GetNullableString(dr, index);
            index = index + 1;
            departamento.codigoDepartamentoReniec = SqlHelper.GetNullableString(dr, index);
            index = index + 1;
            departamento.descripcion = SqlHelper.GetNullableString(dr, index);
            index = index + 1;
            departamento.abreviatura = SqlHelper.GetNullableString(dr, index);

            return departamento;
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentos()
        {
            const string sql = @"SELECT ID_DEPARTAMENTO, CODIGO_DEPARTAMENTO_INEI, CODIGO_DEPARTAMENTO_RENIEC, DESCRIPCION, ABREVIATURA
                                        FROM dbo.departamento
                                        WHERE ACTIVO = 1 AND ELIMINADO = 0
                                        ORDER BY DESCRIPCION";

            SqlParameter[] parametro = new SqlParameter[0];            

            SqlDataReader dr = null;
            SqlConnection cn = null;

            List<Departamento> response = null;
            Departamento departamento = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows) 
                {
                    response = new List<Departamento>();
                    while (dr.ReadAsync().Result)
                    {
                        departamento = CargarDepartamento(dr);
                        response.Add(departamento);
                    }
                }                 
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

            return response;
        }

        public async Task<int> GetValidarDepartamentoId(int idDepartamento)
        {
            int response = 0;
            const string sql = @"SELECT COUNT(1) registro FROM dbo.departamento WHERE ID_DEPARTAMENTO = @idDepartamento and ACTIVO = 1 AND ELIMINADO = 0";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@idDepartamento", SqlDbType.Int) {Value = idDepartamento};

            SqlDataReader dr = null;
            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                    if (dr.ReadAsync().Result)
                        response = SqlHelper.GetInt32(dr, 0);
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

            return response;
        }

        public async Task<Departamento> GetDepartamentoPorId(int idDepartamento)
        {
            const string sql = @"SELECT ID_DEPARTAMENTO, CODIGO_DEPARTAMENTO_INEI, CODIGO_DEPARTAMENTO_RENIEC, DESCRIPCION, ABREVIATURA
                                    FROM dbo.departamento
                                    WHERE ID_DEPARTAMENTO = @ID_DEPARTAMENTO";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int) {Value = idDepartamento};

            SqlDataReader dr = null;
            SqlConnection cn = null;

            Departamento response = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                {
                    response = new Departamento();
                    if (dr.ReadAsync().Result)
                    {
                        response = CargarDepartamento(dr);
                    }
                }
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

            return response;
        }

        public async Task<Departamento> GetDepartamentoPorCodigoInei(string codigoDepartamentoInei)
        {
            const string sql = @"SELECT ID_DEPARTAMENTO, CODIGO_DEPARTAMENTO_INEI, CODIGO_DEPARTAMENTO_RENIEC, DESCRIPCION, ABREVIATURA
                                    FROM dbo.departamento
                                    WHERE CODIGO_DEPARTAMENTO_INEI = @CODIGO_DEPARTAMENTO_INEI";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@CODIGO_DEPARTAMENTO_INEI", SqlDbType.VarChar, 10) {Value = codigoDepartamentoInei};

            SqlDataReader dr = null;
            SqlConnection cn = null;

            Departamento response = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                {
                    response = new Departamento();
                    if (dr.ReadAsync().Result)
                    {
                        response = CargarDepartamento(dr);
                    }
                }
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

            return response;
        }

        public async Task<int> GetIdDepartamentoByCodigoInei(string codigoDepartamentoInei)
        {
            int response = 0;
            String sql = @"SELECT ID_DEPARTAMENTO FROM dbo.departamento WHERE CODIGO_DEPARTAMENTO_INEI = @CODIGO_DEPARTAMENTO_INEI;";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@CODIGO_DEPARTAMENTO_INEI", SqlDbType.VarChar, 10) {Value = codigoDepartamentoInei};

            SqlDataReader dr = null;
            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (dr.HasRows)
                    if (dr.ReadAsync().Result)
                        response = SqlHelper.GetInt32(dr, 0);
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

            return response;
        }

        public async Task<int> CrearDepartamento(Departamento d)
        {
            const String sql = @"INSERT INTO dbo.departamento(ID_DEPARTAMENTO,
                                            CODIGO_DEPARTAMENTO_INEI,
                                            CODIGO_DEPARTAMENTO_RENIEC,
                                            DESCRIPCION,
                                            ABREVIATURA,
                                            ACTIVO,
                                            ELIMINADO,
                                            CODIGO_USUARIO_CREACION,
                                            FECHA_CREACION)
                                                output INSERTED.ID_DEPARTAMENTO
                                                VALUES (
                                                    NEXT VALUE FOR dbo.seq_departamento,
                                                    @CODIGO_DEPARTAMENTO_INEI,
                                                    @CODIGO_DEPARTAMENTO_RENIEC,
                                                    @DESCRIPCION,
                                                    @ABREVIATURA,
                                                    @ACTIVO,
                                                    @ELIMINADO,
                                                    @CODIGO_USUARIO_CREACION,
                                                    @FECHA_CREACION)";

            SqlParameter[] par = new SqlParameter[8];

            par[0] = new SqlParameter("@CODIGO_DEPARTAMENTO_INEI", SqlDbType.VarChar, 10) {Value = d.codigoDepartamentoInei};
            par[1] = new SqlParameter("@CODIGO_DEPARTAMENTO_RENIEC", SqlDbType.VarChar, 10) {Value = d.codigoDepartamentoReniec};
            par[2] = new SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 100) {Value = d.descripcion};
            par[3] = new SqlParameter("@ABREVIATURA", SqlDbType.VarChar, 7) {Value = d.abreviatura};
            par[4] = new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = d.activo};
            par[5] = new SqlParameter("@ELIMINADO", SqlDbType.Bit) {Value = d.eliminado};
            par[6] = new SqlParameter("@CODIGO_USUARIO_CREACION", SqlDbType.VarChar, 20) {Value = d.usuarioCreacion};
            par[7] = new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime) {Value = d.fechaCreacion};

            try
            {
                int idDepartamento = Convert.ToInt32(await SqlHelper.ExecuteScalarAsync(txtConnectionString, CommandType.Text, sql, par));

                return idDepartamento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarDepartamento(Departamento d)
        {
            const string sql = @"UPDATE dbo.departamento
                                                SET
                                            CODIGO_DEPARTAMENTO_INEI = @CODIGO_DEPARTAMENTO_INEI,
                                            CODIGO_DEPARTAMENTO_RENIEC = @CODIGO_DEPARTAMENTO_RENIEC,
                                            DESCRIPCION = @DESCRIPCION,
                                            ABREVIATURA = @ABREVIATURA,
                                            ACTIVO = @ACTIVO,
                                            ELIMINADO = @ELIMINADO,
                                            CODIGO_USUARIO_MODIFICACION = @CODIGO_USUARIO_MODIFICACION,
                                            FECHA_MODIFICACION = @FECHA_MODIFICACION
                                                WHERE
                                                    ID_DEPARTAMENTO = @ID_DEPARTAMENTO";

            SqlParameter[] par = new SqlParameter[9];

            par[0] = new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int) {Value = d.idDepartamento};
            par[1] = new SqlParameter("@CODIGO_DEPARTAMENTO_INEI", SqlDbType.VarChar, 10) {Value = d.codigoDepartamentoInei};
            par[2] = new SqlParameter("@CODIGO_DEPARTAMENTO_RENIEC", SqlDbType.VarChar, 10) {Value = d.codigoDepartamentoReniec};
            par[3] = new SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 100) {Value = d.descripcion};
            par[4] = new SqlParameter("@ABREVIATURA", SqlDbType.VarChar, 7) {Value = d.abreviatura};
            par[5] = new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = d.activo};
            par[6] = new SqlParameter("@ELIMINADO", SqlDbType.Bit) {Value = d.eliminado};
            par[7] = new SqlParameter("@CODIGO_USUARIO_MODIFICACION", SqlDbType.VarChar, 20) {Value = d.usuarioModificacion};
            par[8] = new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime) {Value = d.fechaModificacion};

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
