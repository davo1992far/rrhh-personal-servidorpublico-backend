using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.tecnologia.util.lib;
using minedu.tecnologia.util.lib.Exceptions;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class ServidorPublicoDAO : DAOBase, IServidorPublicoDAO
    {
        public ServidorPublicoDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        private ServidorPublicoReplica LlenarServidorPublicoReplica(SqlDataReader dr)
        {
            ServidorPublicoReplica s = new ServidorPublicoReplica();

            int index = 0;

            s.idServidorPublico = SqlHelper.GetInt64(dr, index++);
            s.idPersona = SqlHelper.GetInt32(dr, index++);
            s.idRegimenLaboral = SqlHelper.GetInt32(dr, index++);
            s.idSituacionLaboral = SqlHelper.GetInt32(dr, index++);
            s.idCondicionLaboral = SqlHelper.GetInt32(dr, index++);
            s.idAfp = SqlHelper.GetNullableInt32(dr, index++);
            s.idRegimenPensionario = SqlHelper.GetNullableInt32(dr, index++);
            s.idCargo = SqlHelper.GetNullableInt32(dr, index++);
            s.idJornadaLaboral = SqlHelper.GetNullableInt32(dr, index++);
            s.idCategoriaRemunerativa = SqlHelper.GetNullableInt32(dr, index++);
            s.idCentroTrabajo = SqlHelper.GetNullableInt32(dr, index++);
            s.codigoServidorPublico = SqlHelper.GetInt64(dr, index++);
            s.codigoPlaza = SqlHelper.GetNullableString(dr, index++);
            s.cuspp = SqlHelper.GetNullableString(dr, index++);
            s.fechaIngresoSpp = SqlHelper.GetNullableDateTime(dr, index++);
            s.fechaInicioVinculacion = SqlHelper.GetNullableDateTime(dr, index++);
            s.fechaFinVinculacion = SqlHelper.GetNullableDateTime(dr, index++);
            s.fechaCese = SqlHelper.GetNullableDateTime(dr, index++);
            s.activo = SqlHelper.GetBoolean(dr, index++);
            s.codigoRegimenLaboral = SqlHelper.GetInt32(dr, index++);
            s.descripcionRegimenLaboral = SqlHelper.GetString(dr, index++);
            s.codigoAfp = SqlHelper.GetNullableString(dr, index++);
            s.descripcionAfp = SqlHelper.GetNullableString(dr, index++);
            s.codigoSituacionLaboral = SqlHelper.GetInt32(dr, index++);
            s.codigoCondicionLaboral = SqlHelper.GetInt32(dr, index++);
            s.descripcionRegimenPensionario = SqlHelper.GetNullableString(dr, index++);
            s.codigoCargo = SqlHelper.GetNullableInt32(dr, index++);
            s.descripcionCargo = SqlHelper.GetNullableString(dr, index++);
            s.codigoJornadaLaboral = SqlHelper.GetNullableInt32(dr, index++);
            s.descripcionJornadaLaboral = SqlHelper.GetNullableString(dr, index++);
            s.codigoCategoriaRemunerativa = SqlHelper.GetNullableInt32(dr, index++);
            s.descripcionCategoriaRemunerativa = SqlHelper.GetNullableString(dr, index++);
            s.codigoCentroTrabajo = SqlHelper.GetNullableString(dr, index++);
            s.descripcionCentroTrabajo = SqlHelper.GetNullableString(dr, index++);
            s.idTipoComisionAfp = SqlHelper.GetNullableInt32(dr, index++);
            s.codigoTipoComisionAfp = SqlHelper.GetNullableInt32(dr, index++);
            s.usuarioCreacion = SqlHelper.GetNullableString(dr, index++);
            s.ipCreacion = SqlHelper.GetNullableString(dr, index++);
            s.fechaCreacion = SqlHelper.GetDateTime(dr, index++);
            s.usuarioModificacion = SqlHelper.GetNullableString(dr, index++);
            s.ipModificacion = SqlHelper.GetNullableString(dr, index++);
            s.fechaModificacion = SqlHelper.GetNullableDateTime(dr, index++);

            return s;
        }

        public async Task<ServidorPublicoReplica> GetServidorPublicoReplicaPorId(long idServidorPublico)
        {
            const string sql = @"SELECT
                                    s.ID_SERVIDOR_PUBLICO,
                                    s.ID_PERSONA,
                                    s.ID_REGIMEN_LABORAL,
                                    s.ID_SITUACION_LABORAL,
                                    s.ID_CONDICION_LABORAL,
                                    s.ID_AFP,
                                    s.ID_REGIMEN_PENSIONARIO,
                                    s.ID_CARGO,
                                    s.ID_JORNADA_LABORAL,
                                    s.ID_CATEGORIA_REMUNERATIVA,
                                    s.ID_CENTRO_TRABAJO,
                                    s.CODIGO_SERVIDOR_PUBLICO,
                                    s.CODIGO_PLAZA,
                                    s.CUSPP,
                                    s.FECHA_INGRESO_SPP,
                                    s.FECHA_INICIO_VINCULACION,
                                    s.FECHA_FIN_VINCULACION,
                                    s.FECHA_CESE,
                                    s.ACTIVO,
                                    rl.CODIGO_REGIMEN_LABORAL,
                                    rl.DESCRIPCION_REGIMEN_LABORAL,
                                    a.CODIGO_AFP,
                                    a.DESCRIPCION_AFP,
                                    sl.CODIGO_CATALOGO_ITEM CODIGO_SITUACION_LABORAL,
                                    cl.CODIGO_CATALOGO_ITEM CODIGO_CONDICION_LABORAL,
                                    rp.DESCRIPCION_REGIMEN_PENSIONARIO,
                                    c.CODIGO_CARGO,
                                    c.DESCRIPCION_CARGO,
                                    jl.CODIGO_JORNADA_LABORAL,
                                    jl.DESCRIPCION_JORNADA_LABORAL,
                                    cr.CODIGO_CATEGORIA_REMUNERATIVA,
                                    cr.DESCRIPCION_CATEGORIA_REMUNERATIVA,
                                    ct.CODIGO_CENTRO_TRABAJO,
                                    (case when ct.ID_UGEL is not null then u.DESCRIPCION_UGEL
                                    when ct.ID_DRE is not null and ct.ID_UGEL is null then d.DESCRIPCION_DRE
                                    when ct.ID_OTRA_INSTANCIA is not null then o.DESCRIPCION_OTRA_INSTANCIA
                                    end) as DESCRIPCION_CENTRO_TRABAJO,
                                        s.ID_TIPO_COMISION_AFP,
                                        cafp.CODIGO_CATALOGO_ITEM CODIGO_TIPO_COMISION_AFP,
                                        s.USUARIO_CREACION,
                                        s.IP_CREACION,
                                        s.FECHA_CREACION,
                                        s.USUARIO_MODIFICACION,
                                        s.IP_MODIFICACION,
                                        s.FECHA_MODIFICACION
                               FROM dbo.servidor_publico s
	                                INNER JOIN dbo.regimen_laboral rl WITH(NOLOCK) ON s.ID_REGIMEN_LABORAL = rl.ID_REGIMEN_LABORAL	                               
	                                INNER JOIN dbo.catalogo_item sl WITH(NOLOCK) ON sl.ID_CATALOGO_ITEM = s.ID_SITUACION_LABORAL
	                                INNER JOIN dbo.catalogo_item cl WITH(NOLOCK) ON cl.ID_CATALOGO_ITEM = s.ID_CONDICION_LABORAL
                                    LEFT JOIN dbo.afp a WITH(NOLOCK) ON a.ID_AFP = s.ID_AFP
                                    LEFT JOIN dbo.catalogo_item cafp WITH(NOLOCK) ON s.ID_TIPO_COMISION_AFP = cafp.ID_CATALOGO_ITEM
	                                LEFT JOIN dbo.regimen_pensionario rp WITH(NOLOCK) ON rp.ID_REGIMEN_PENSIONARIO = s.ID_REGIMEN_PENSIONARIO
	                                LEFT JOIN dbo.cargo c WITH(NOLOCK) ON c.ID_CARGO = s.ID_CARGO
	                                LEFT JOIN dbo.jornada_laboral jl WITH(NOLOCK) ON jl.ID_JORNADA_LABORAL = s.ID_JORNADA_LABORAL
	                                LEFT JOIN dbo.categoria_remunerativa cr WITH(NOLOCK) ON cr.ID_CATEGORIA_REMUNERATIVA = s.ID_CATEGORIA_REMUNERATIVA
	                                LEFT JOIN dbo.centro_trabajo ct WITH(NOLOCK) ON s.ID_CENTRO_TRABAJO = ct.ID_CENTRO_TRABAJO
	                                LEFT JOIN dbo.tipo_centro_trabajo tc WITH(NOLOCK) ON tc.ID_TIPO_CENTRO_TRABAJO = ct.ID_TIPO_CENTRO_TRABAJO
	                                LEFT JOIN dbo.ugel u WITH(NOLOCK) ON u.ID_UGEL = ct.ID_UGEL and u.ID_DRE = ct.ID_DRE
	                                LEFT JOIN dbo.dre d WITH(NOLOCK) ON d.ID_DRE = ct.ID_DRE and ct.ID_UGEL is null
	                                LEFT JOIN dbo.otra_instancia o WITH(NOLOCK) ON o.ID_OTRA_INSTANCIA = ct.ID_OTRA_INSTANCIA and ct.ID_DRE is null and ct.ID_UGEL is null
                                WHERE s.ID_SERVIDOR_PUBLICO = @ID_SERVIDOR_PUBLICO";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@ID_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = idServidorPublico};

            SqlDataReader dr = null;
            try
            {
                ServidorPublicoReplica response = null;
                await using var cn = new SqlConnection(this.txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (!dr.HasRows) return response;
                if (dr.ReadAsync().Result)
                {
                    response = LlenarServidorPublicoReplica(dr);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await SqlHelper.CloseDataReaderAsync(dr);
            }
        }

        public async Task<ServidorPublicoReplica> GetServidorPublicoReplicaPorCodigo(long codigoServidorPublico)
        {
            const string sql = @"SELECT
                                        s.ID_SERVIDOR_PUBLICO,
                                        s.ID_PERSONA,
                                        s.ID_REGIMEN_LABORAL,
                                        s.ID_SITUACION_LABORAL,
                                        s.ID_CONDICION_LABORAL,
                                        s.ID_AFP,
                                        s.ID_REGIMEN_PENSIONARIO,
                                        s.ID_CARGO,
                                        s.ID_JORNADA_LABORAL,
                                        s.ID_CATEGORIA_REMUNERATIVA,
                                        s.ID_CENTRO_TRABAJO,
                                        s.CODIGO_SERVIDOR_PUBLICO,
                                        s.CODIGO_PLAZA,
                                        s.CUSPP,
                                        s.FECHA_INGRESO_SPP,
                                        s.FECHA_INICIO_VINCULACION,
                                        s.FECHA_FIN_VINCULACION,
                                        s.FECHA_CESE,
                                        s.ACTIVO,
                                        rl.CODIGO_REGIMEN_LABORAL,
                                        rl.DESCRIPCION_REGIMEN_LABORAL,
                                        a.CODIGO_AFP,
                                        a.DESCRIPCION_AFP,
                                        sl.CODIGO_CATALOGO_ITEM CODIGO_SITUACION_LABORAL,
                                        cl.CODIGO_CATALOGO_ITEM CODIGO_CONDICION_LABORAL,
                                        rp.DESCRIPCION_REGIMEN_PENSIONARIO,
                                        c.CODIGO_CARGO,
                                        c.DESCRIPCION_CARGO,
                                        jl.CODIGO_JORNADA_LABORAL,
                                        jl.DESCRIPCION_JORNADA_LABORAL,
                                        cr.CODIGO_CATEGORIA_REMUNERATIVA,
                                        cr.DESCRIPCION_CATEGORIA_REMUNERATIVA,
                                        ct.CODIGO_CENTRO_TRABAJO,                                       
                                        (case when ct.ID_UGEL is not null then u.DESCRIPCION_UGEL
                                        when ct.ID_DRE is not null and ct.ID_UGEL is null then d.DESCRIPCION_DRE
                                        when ct.ID_OTRA_INSTANCIA is not null then o.DESCRIPCION_OTRA_INSTANCIA
                                        end) as DESCRIPCION_CENTRO_TRABAJO,
                                        s.ID_TIPO_COMISION_AFP,
                                        cafp.CODIGO_CATALOGO_ITEM CODIGO_TIPO_COMISION_AFP,
                                        s.USUARIO_CREACION,
                                        s.IP_CREACION,
                                        s.FECHA_CREACION,
                                        s.USUARIO_MODIFICACION,
                                        s.IP_MODIFICACION,
                                        s.FECHA_MODIFICACION
                                   FROM dbo.servidor_publico s
	                                    INNER JOIN dbo.regimen_laboral rl WITH(NOLOCK) ON s.ID_REGIMEN_LABORAL = rl.ID_REGIMEN_LABORAL	                                   
	                                    INNER JOIN dbo.catalogo_item sl WITH(NOLOCK) ON sl.ID_CATALOGO_ITEM = s.ID_SITUACION_LABORAL
	                                    INNER JOIN dbo.catalogo_item cl WITH(NOLOCK) ON cl.ID_CATALOGO_ITEM = s.ID_CONDICION_LABORAL
	                                    LEFT JOIN dbo.regimen_pensionario rp WITH(NOLOCK) ON rp.ID_REGIMEN_PENSIONARIO = s.ID_REGIMEN_PENSIONARIO
                                        LEFT JOIN dbo.afp a WITH(NOLOCK) ON a.ID_AFP = s.ID_AFP
                                        LEFT JOIN dbo.catalogo_item cafp WITH(NOLOCK) ON s.ID_TIPO_COMISION_AFP = cafp.ID_CATALOGO_ITEM
	                                    LEFT JOIN dbo.cargo c WITH(NOLOCK) ON c.ID_CARGO = s.ID_CARGO
	                                    LEFT JOIN dbo.jornada_laboral jl WITH(NOLOCK) ON jl.ID_JORNADA_LABORAL = s.ID_JORNADA_LABORAL
	                                    LEFT JOIN dbo.categoria_remunerativa cr WITH(NOLOCK) ON cr.ID_CATEGORIA_REMUNERATIVA = s.ID_CATEGORIA_REMUNERATIVA
	                                    LEFT JOIN dbo.centro_trabajo ct WITH(NOLOCK) ON s.ID_CENTRO_TRABAJO = ct.ID_CENTRO_TRABAJO
	                                    LEFT JOIN dbo.tipo_centro_trabajo tc WITH(NOLOCK) ON tc.ID_TIPO_CENTRO_TRABAJO = ct.ID_TIPO_CENTRO_TRABAJO
	                                    LEFT JOIN dbo.ugel u WITH(NOLOCK) ON u.ID_UGEL = ct.ID_UGEL and u.ID_DRE = ct.ID_DRE
	                                    LEFT JOIN dbo.dre d WITH(NOLOCK) ON d.ID_DRE = ct.ID_DRE and ct.ID_UGEL is null
	                                    LEFT JOIN dbo.otra_instancia o WITH(NOLOCK) ON o.ID_OTRA_INSTANCIA = ct.ID_OTRA_INSTANCIA and ct.ID_DRE is null and ct.ID_UGEL is null
                                    WHERE s.CODIGO_SERVIDOR_PUBLICO = @CODIGO_SERVIDOR_PUBLICO";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@CODIGO_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = codigoServidorPublico};

            SqlDataReader dr = null;
            try
            {
                ServidorPublicoReplica response = null;
                await using var cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (!dr.HasRows) return response;
                if (dr.ReadAsync().Result)
                {
                    response = LlenarServidorPublicoReplica(dr);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await SqlHelper.CloseDataReaderAsync(dr);
            }
        }

        public async Task<long> GetIdServidorPublicoReplicaPorCodigo(long codigoServidorPublico)
        {
            const string sql = @"SELECT
                                        s.ID_SERVIDOR_PUBLICO
                                   FROM dbo.servidor_publico s
	                                    WHERE s.CODIGO_SERVIDOR_PUBLICO = @CODIGO_SERVIDOR_PUBLICO";

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@CODIGO_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = codigoServidorPublico};

            SqlDataReader dr = null;
            try
            {
                await using var cn = new SqlConnection(txtConnectionString);
                await cn.OpenAsync();
                dr = await SqlHelper.ExecuteReaderAsync(cn, CommandType.Text, sql, parametro);
                if (!dr.HasRows) return 0;
                return dr.ReadAsync().Result ? SqlHelper.GetInt64(dr, 0) : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await SqlHelper.CloseDataReaderAsync(dr);
            }
        }

        public async Task<ServidorPublico> CrearServidorPublico(ServidorPublico servidorPublico)
        {
            TransactionBase transaction = await SqlHelper.BeginTransaction(txtConnectionString);
            try
            {
                //IFamiliarPersonaDAO formacionAcademicaDAO = new FamiliarPersonaDAO(txtConnectionString);
                var idServidorPublico = await CrearServidorPublicoReplica(servidorPublico, transaction.connection, transaction.transaction);
                if (idServidorPublico <= 0)
                    throw new ValidationCustomException(Constante.EX_SERVIDOR_PUBLICO_CREATE);
                servidorPublico.idServidorPublico = idServidorPublico;
                //se asigna el id del servidor publico creado a la formacion academica
                if (servidorPublico.formacionesAcademicas != null)
                {
                    foreach (FormacionAcademica formacionAcademica in servidorPublico.formacionesAcademicas)
                    {
                        formacionAcademica.idServidorPublico = servidorPublico.idPersona;
                        //await formacionAcademicaDAO.CrearFamiliarPersona(formacionAcademica, transaction.connection, transaction.transaction);
                    }
                }

                transaction.transaction.Commit();
            }
            catch (Exception ex)
            {
                await SqlHelper.RollbackTransactionAsync(transaction);
                throw ex;
            }
            finally
            {
                await SqlHelper.DisposeTransactionAsync(transaction);
            }

            return servidorPublico;
        }

        public async Task<long> CrearServidorPublicoTransaction(ServidorPublicoTransaccionRequest servidorPublico)
        {
            TransactionBase transaction = await SqlHelper.BeginTransaction(txtConnectionString);
            try
            {
                var idServidorPublico = await CrearServidorPublicoTransaction(servidorPublico, transaction.connection, transaction.transaction);
                if (idServidorPublico <= 0)
                    throw new ValidationCustomException(Constante.EX_SERVIDOR_PUBLICO_CREATE);
                servidorPublico.idServidorPublico = idServidorPublico;
                transaction.transaction.Commit();
            }
            catch (Exception ex)
            {
                await SqlHelper.RollbackTransactionAsync(transaction);
                throw ex;
            }
            finally
            {
                await SqlHelper.DisposeTransactionAsync(transaction);
            }

            return servidorPublico.idServidorPublico;
        }

        private async Task<long> CrearServidorPublicoTransaction(ServidorPublicoTransaccionRequest s, SqlConnection con, SqlTransaction tran)
        {
            const String sql = @"INSERT INTO dbo.servidor_publico(
                                                                        ID_SERVIDOR_PUBLICO,
                                                                        ID_PERSONA,
                                                                        ID_REGIMEN_LABORAL,
                                                                        ID_SITUACION_LABORAL,
                                                                        ID_CONDICION_LABORAL,                                                                      
                                                                        ID_CATEGORIA_REMUNERATIVA,
                                                                        ID_CENTRO_TRABAJO,                                                                       
                                                                        CODIGO_SERVIDOR_PUBLICO,
                                                                        CODIGO_PLAZA,                                                                       
                                                                        FECHA_INICIO_VINCULACION,
                                                                        FECHA_CESE,
                                                                        ACTIVO,
                                                                        FECHA_CREACION,
                                                                        USUARIO_CREACION,
                                                                        IP_CREACION)
                                                                            output INSERTED.ID_SERVIDOR_PUBLICO
                                                                            VALUES (
                                                                                NEXT VALUE FOR dbo.seq_servidor_publico,
                                                                                @ID_PERSONA,
                                                                                @ID_REGIMEN_LABORAL,
                                                                                @ID_SITUACION_LABORAL,
                                                                                @ID_CONDICION_LABORAL,                                                                                
                                                                                @ID_CATEGORIA_REMUNERATIVA,
                                                                                @ID_CENTRO_TRABAJO,                                                                          
                                                                                NEXT VALUE FOR dbo.seq_codigo_servidor_publico,
                                                                                @CODIGO_PLAZA,                                                                                
                                                                                @FECHA_INICIO_VINCULACION,
                                                                                @FECHA_CESE,
                                                                                @ACTIVO,
                                                                                @FECHA_CREACION,
                                                                                @USUARIO_CREACION,
                                                                                @IP_CREACION)";

            SqlParameter[] par = new SqlParameter[14];

            par[0] = new SqlParameter("@ID_PERSONA", SqlDbType.Int) {Value = s.idPersona};
            par[1] = new SqlParameter("@ID_REGIMEN_LABORAL", SqlDbType.Int) {Value = s.idRegimenLaboral};
            par[2] = new SqlParameter("@ID_SITUACION_LABORAL", SqlDbType.Int) {Value = s.idSituacionLaboral};
            par[3] = new SqlParameter("@ID_CONDICION_LABORAL", SqlDbType.Int) {Value = s.idCondicionLaboral};
            par[4] = new SqlParameter("@ID_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = s.idCategoriaRemunerativa};
            par[5] = new SqlParameter("@ID_CENTRO_TRABAJO", SqlDbType.Int) {Value = s.idCentroTrabajo};
            par[6] = new SqlParameter("@CODIGO_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = s.codigoServidorPublico};
            par[7] = new SqlParameter("@CODIGO_PLAZA", SqlDbType.Char, 12) {Value = s.codigoPlaza};
            par[8] = new SqlParameter("@FECHA_INICIO_VINCULACION", SqlDbType.Date) {Value = s.fechaInicio};
            par[9] = new SqlParameter("@FECHA_CESE", SqlDbType.Date) {Value = s.fechaCese};
            par[10] = new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = s.activo};
            par[11] = new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime) {Value = s.fechaCreacion};
            par[12] = new SqlParameter("@USUARIO_CREACION", SqlDbType.VarChar, 20) {Value = s.usuarioCreacion};
            par[13] = new SqlParameter("@IP_CREACION", SqlDbType.VarChar, 40) {Value = s.ipCreacion};

            try
            {
                s.idServidorPublico = Convert.ToInt64(await SqlHelper.ExecuteScalarAsync(con, tran, CommandType.Text, sql, par));
                return s.idServidorPublico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> CrearServidorPublicoReplica(ServidorPublico s, SqlConnection con, SqlTransaction tran)
        {
            const String sql = @"INSERT INTO dbo.servidor_publico(
                                                                        ID_SERVIDOR_PUBLICO,
                                                                        ID_PERSONA,
                                                                        ID_REGIMEN_LABORAL,
                                                                        ID_SITUACION_LABORAL,
                                                                        ID_CONDICION_LABORAL,
                                                                        ID_AFP,
                                                                        ID_REGIMEN_PENSIONARIO,
                                                                        ID_CARGO,
                                                                        ID_JORNADA_LABORAL,
                                                                        ID_CATEGORIA_REMUNERATIVA,
                                                                        ID_CENTRO_TRABAJO,
                                                                        ID_TIPO_COMISION_AFP,
                                                                        CODIGO_SERVIDOR_PUBLICO,
                                                                        CODIGO_PLAZA,
                                                                        CUSPP,
                                                                        FECHA_INGRESO_SPP,
                                                                        FECHA_INICIO_VINCULACION,
                                                                        FECHA_FIN_VINCULACION,
                                                                        FECHA_CESE,
                                                                        ACTIVO,
                                                                        FECHA_CREACION,
                                                                        USUARIO_CREACION,
                                                                        IP_CREACION)
                                                                            output INSERTED.ID_SERVIDOR_PUBLICO
                                                                            VALUES (
                                                                                NEXT VALUE FOR dbo.seq_servidor_publico,
                                                                                @ID_PERSONA,
                                                                                @ID_REGIMEN_LABORAL,
                                                                                @ID_SITUACION_LABORAL,
                                                                                @ID_CONDICION_LABORAL,
                                                                                @ID_AFP,
                                                                                @ID_REGIMEN_PENSIONARIO,
                                                                                @ID_CARGO,
                                                                                @ID_JORNADA_LABORAL,
                                                                                @ID_CATEGORIA_REMUNERATIVA,
                                                                                @ID_CENTRO_TRABAJO,
                                                                                @ID_TIPO_COMISION_AFP,
                                                                                NEXT VALUE FOR dbo.seq_codigo_servidor_publico,
                                                                                @CODIGO_PLAZA,
                                                                                @CUSPP,
                                                                                @FECHA_INGRESO_SPP,
                                                                                @FECHA_INICIO_VINCULACION,
                                                                                @FECHA_FIN_VINCULACION,
                                                                                @FECHA_CESE,
                                                                                @ACTIVO,
                                                                                @FECHA_CREACION,
                                                                                @USUARIO_CREACION,
                                                                                @IP_CREACION)";

            SqlParameter[] par = new SqlParameter[22];

            par[0] = new SqlParameter("@ID_PERSONA", SqlDbType.Int) {Value = s.idPersona};
            par[1] = new SqlParameter("@ID_REGIMEN_LABORAL", SqlDbType.Int) {Value = s.idRegimenLaboral};
            par[2] = new SqlParameter("@ID_SITUACION_LABORAL", SqlDbType.Int) {Value = s.idSituacionLaboral};
            par[3] = new SqlParameter("@ID_CONDICION_LABORAL", SqlDbType.Int) {Value = s.idCondicionLaboral};
            par[4] = new SqlParameter("@ID_AFP", SqlDbType.Int) {Value = s.idAfp};
            par[5] = new SqlParameter("@ID_REGIMEN_PENSIONARIO", SqlDbType.Int) {Value = s.idRegimenPensionario};
            par[6] = new SqlParameter("@ID_CARGO", SqlDbType.Int) {Value = s.idCargo};
            par[7] = new SqlParameter("@ID_JORNADA_LABORAL", SqlDbType.Int) {Value = s.idJornadaLaboral};
            par[8] = new SqlParameter("@ID_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = s.idCategoriaRemunerativa};
            par[9] = new SqlParameter("@ID_CENTRO_TRABAJO", SqlDbType.Int) {Value = s.idCentroTrabajo};
            par[10] = new SqlParameter("@ID_TIPO_COMISION_AFP", SqlDbType.Int) {Value = s.idTipoComisionAfp};
            par[11] = new SqlParameter("@CODIGO_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = s.codigoServidorPublico};
            par[12] = new SqlParameter("@CODIGO_PLAZA", SqlDbType.Char, 12) {Value = s.codigoPlaza};
            par[13] = new SqlParameter("@CUSPP", SqlDbType.VarChar, 20) {Value = s.cuspp};
            par[14] = new SqlParameter("@FECHA_INGRESO_SPP", SqlDbType.Date) {Value = s.fechaIngresoSpp};
            par[15] = new SqlParameter("@FECHA_INICIO_VINCULACION", SqlDbType.Date) {Value = s.fechaInicioVinculacion};
            par[16] = new SqlParameter("@FECHA_FIN_VINCULACION", SqlDbType.Date) {Value = s.fechaFinVinculacion};
            par[17] = new SqlParameter("@FECHA_CESE", SqlDbType.Date) {Value = s.fechaCese};
            par[18] = new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = s.activo};
            par[19] = new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime) {Value = s.fechaCreacion};
            par[20] = new SqlParameter("@USUARIO_CREACION", SqlDbType.VarChar, 20) {Value = s.usuarioCreacion};
            par[21] = new SqlParameter("@IP_CREACION", SqlDbType.VarChar, 40) {Value = s.ipCreacion};

            try
            {
                s.idServidorPublico = Convert.ToInt64(await SqlHelper.ExecuteScalarAsync(con, tran, CommandType.Text, sql, par));
                return s.idServidorPublico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ServidorPublico> CrearServidorPublico(ServidorPublico s, SqlConnection con, SqlTransaction tran)
        {
            const string sql = @"INSERT INTO dbo.servidor_publico(ID_SERVIDOR_PUBLICO,
                                                                ID_PERSONA,
                                                                ID_REGIMEN_LABORAL,
                                                                ID_SITUACION_LABORAL,
                                                                ID_CONDICION_LABORAL,
                                                                ID_AFP,
                                                                ID_REGIMEN_PENSIONARIO,
                                                                ID_CARGO,
                                                                ID_JORNADA_LABORAL,
                                                                ID_CATEGORIA_REMUNERATIVA,
                                                                ID_CENTRO_TRABAJO,
                                                                ID_TIPO_COMISION_AFP,
                                                                CODIGO_SERVIDOR_PUBLICO,
                                                                CODIGO_PLAZA,
                                                                CUSPP,
                                                                FECHA_INGRESO_SPP,
                                                                FECHA_INICIO_VINCULACION,
                                                                FECHA_FIN_VINCULACION,
                                                                FECHA_CESE,
                                                                ACTIVO,
                                                                FECHA_CREACION,
                                                                USUARIO_CREACION,
                                                                IP_CREACION)
                                                                    output INSERTED.*
                                                                    VALUES (
                                                                        NEXT VALUE FOR dbo.seq_servidor_publico,
                                                                        @ID_PERSONA,
                                                                        @ID_REGIMEN_LABORAL,
                                                                        @ID_SITUACION_LABORAL,
                                                                        @ID_CONDICION_LABORAL,
                                                                        @ID_AFP,
                                                                        @ID_REGIMEN_PENSIONARIO,
                                                                        @ID_CARGO,
                                                                        @ID_JORNADA_LABORAL,
                                                                        @ID_CATEGORIA_REMUNERATIVA,
                                                                        @ID_CENTRO_TRABAJO,
                                                                        @ID_TIPO_COMISION_AFP,
                                                                        NEXT VALUE FOR dbo.seq_codigo_servidor_publico,
                                                                        @CODIGO_PLAZA,
                                                                        @CUSPP,
                                                                        @FECHA_INGRESO_SPP,
                                                                        @FECHA_INICIO_VINCULACION,
                                                                        @FECHA_FIN_VINCULACION,
                                                                        @FECHA_CESE,
                                                                        @ACTIVO,
                                                                        @FECHA_CREACION,
                                                                        @USUARIO_CREACION,
                                                                        @IP_CREACION)";

            SqlParameter[] par = new SqlParameter[21];

            par[0] = new SqlParameter("@ID_PERSONA", SqlDbType.Int) {Value = s.idPersona};
            par[1] = new SqlParameter("@ID_REGIMEN_LABORAL", SqlDbType.Int) {Value = s.idRegimenLaboral};
            par[2] = new SqlParameter("@ID_SITUACION_LABORAL", SqlDbType.Int) {Value = s.idSituacionLaboral};
            par[3] = new SqlParameter("@ID_CONDICION_LABORAL", SqlDbType.Int) {Value = s.idCondicionLaboral};
            par[4] = new SqlParameter("@ID_AFP", SqlDbType.Int) {Value = s.idAfp};
            par[5] = new SqlParameter("@ID_REGIMEN_PENSIONARIO", SqlDbType.Int) {Value = s.idRegimenPensionario};
            par[6] = new SqlParameter("@ID_CARGO", SqlDbType.Int) {Value = s.idCargo};
            par[7] = new SqlParameter("@ID_JORNADA_LABORAL", SqlDbType.Int) {Value = s.idJornadaLaboral};
            par[8] = new SqlParameter("@ID_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = s.idCategoriaRemunerativa};
            par[9] = new SqlParameter("@ID_CENTRO_TRABAJO", SqlDbType.Int) {Value = s.idCentroTrabajo};
            par[10] = new SqlParameter("@ID_TIPO_COMISION_AFP", SqlDbType.Int) {Value = s.idTipoComisionAfp};
            par[11] = new SqlParameter("@CODIGO_PLAZA", SqlDbType.Char, 12) {Value = s.codigoPlaza};
            par[12] = new SqlParameter("@CUSPP", SqlDbType.VarChar, 20) {Value = s.cuspp};
            par[13] = new SqlParameter("@FECHA_INGRESO_SPP", SqlDbType.Date) {Value = s.fechaIngresoSpp};
            par[14] = new SqlParameter("@FECHA_INICIO_VINCULACION", SqlDbType.Date) {Value = s.fechaInicioVinculacion};
            par[15] = new SqlParameter("@FECHA_FIN_VINCULACION", SqlDbType.Date) {Value = s.fechaFinVinculacion};
            par[16] = new SqlParameter("@FECHA_CESE", SqlDbType.Date) {Value = s.fechaCese};
            par[17] = new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = s.activo};
            par[18] = new SqlParameter("@FECHA_CREACION", SqlDbType.DateTime) {Value = s.fechaCreacion};
            par[19] = new SqlParameter("@USUARIO_CREACION", SqlDbType.VarChar, 20) {Value = s.usuarioCreacion};
            par[20] = new SqlParameter("@IP_CREACION", SqlDbType.VarChar, 40) {Value = s.ipCreacion};

            SqlDataReader dr = null;
            try
            {
                dr = await SqlHelper.ExecuteReaderAsync(con, tran, CommandType.Text, sql, par);
                if (!dr.HasRows) return s;
                if (!dr.ReadAsync().Result) return s;
                s.idServidorPublico = dr.GetInt64(0);
                s.codigoServidorPublico = dr.GetInt64(11);

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await SqlHelper.CloseDataReaderAsync(dr);
            }
        }

        public async Task<int> ActualizarServidorPublicoTransaction(ServidorPublicoTransaccionRequest servidorPublico)
        {
            int response = 0;
            TransactionBase transaction = await SqlHelper.BeginTransaction(txtConnectionString);
            try
            {
                response = await ActualizarServidorPublicoTransaction(servidorPublico, transaction.connection, transaction.transaction);
                if (response == 0)
                    throw new NotFoundCustomException(Constante.EX_PERSONA_NOT_FOUND);

                transaction.transaction.Commit();
            }
            catch (Exception ex)
            {
                await SqlHelper.RollbackTransactionAsync(transaction);
                throw ex;
            }
            finally
            {
                await SqlHelper.DisposeTransactionAsync(transaction);
            }

            return response;
        }

        public async Task<int> ActualizarServidorPublico(ServidorPublico servidorPublico)
        {
            int response = 0;
            TransactionBase transaction = await SqlHelper.BeginTransaction(txtConnectionString);
            try
            {
                response = await ActualizarServidorPublico(servidorPublico, transaction.connection, transaction.transaction);
                if (response == 0)
                    throw new NotFoundCustomException(Constante.EX_PERSONA_NOT_FOUND);

                if (servidorPublico.formacionesAcademicas != null)
                {
                    foreach (FormacionAcademica formacionAcademica in servidorPublico.formacionesAcademicas)
                    {
                        if (formacionAcademica.idFormacionAcademica <= 0)
                        {
                            //await familiarDAO.CrearFamiliarPersona(familiar, transaction.connection, transaction.transaction);
                        }
                        else
                        {
                            //await familiarDAO.ActualizarFamiliarPersona(familiar, transaction.connection, transaction.transaction);
                        }
                    }
                }

                transaction.transaction.Commit();
            }
            catch (Exception ex)
            {
                await SqlHelper.RollbackTransactionAsync(transaction);
                throw ex;
            }
            finally
            {
                await SqlHelper.DisposeTransactionAsync(transaction);
            }

            return response;
        }

        private async Task<int> ActualizarServidorPublicoTransaction(ServidorPublicoTransaccionRequest s, SqlConnection con, SqlTransaction tran)
        {
            const String sql = @"UPDATE dbo.servidor_publico
                                        SET
                                    ID_PERSONA = @ID_PERSONA,
                                    ID_REGIMEN_LABORAL = @ID_REGIMEN_LABORAL,
                                    ID_SITUACION_LABORAL = @ID_SITUACION_LABORAL,
                                    ID_CONDICION_LABORAL = @ID_CONDICION_LABORAL,
                                    ID_CATEGORIA_REMUNERATIVA = @ID_CATEGORIA_REMUNERATIVA,
                                    ID_CENTRO_TRABAJO = @ID_CENTRO_TRABAJO,
                                    CODIGO_SERVIDOR_PUBLICO = @CODIGO_SERVIDOR_PUBLICO,
                                    CODIGO_PLAZA = @CODIGO_PLAZA,
                                    FECHA_INICIO_VINCULACION = @FECHA_INICIO_VINCULACION,
                                    FECHA_CESE = @FECHA_CESE,
                                    ACTIVO = @ACTIVO,
                                    FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                    USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                    IP_MODIFICACION = @IP_MODIFICACION
                                        WHERE ID_SERVIDOR_PUBLICO = @ID_SERVIDOR_PUBLICO";

            SqlParameter[] par =
            {
                new SqlParameter("@ID_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = s.idServidorPublico},
                new SqlParameter("@ID_PERSONA", SqlDbType.Int) {Value = s.idPersona},
                new SqlParameter("@ID_REGIMEN_LABORAL", SqlDbType.Int) {Value = s.idRegimenLaboral},
                new SqlParameter("@ID_SITUACION_LABORAL", SqlDbType.Int) {Value = s.idSituacionLaboral},
                new SqlParameter("@ID_CONDICION_LABORAL", SqlDbType.Int) {Value = s.idCondicionLaboral},
                new SqlParameter("@ID_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = s.idCategoriaRemunerativa},
                new SqlParameter("@ID_CENTRO_TRABAJO", SqlDbType.Int) {Value = s.idCentroTrabajo},
                new SqlParameter("@CODIGO_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = s.codigoServidorPublico},
                new SqlParameter("@CODIGO_PLAZA", SqlDbType.Char, 12) {Value = s.codigoPlaza},
                new SqlParameter("@FECHA_INICIO_VINCULACION", SqlDbType.Date) {Value = s.fechaInicio},
                new SqlParameter("@FECHA_CESE", SqlDbType.Date) {Value = s.fechaCese},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = s.activo},
                new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime) {Value = s.fechaModificacion},
                new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20) {Value = s.usuarioModificacion},
                new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40) {Value = s.ipModificacion}
            };

            try
            {
                return await SqlHelper.ExecuteNonQueryAsync(con, tran, CommandType.Text, sql, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarServidorPublico(ServidorPublico s, SqlConnection con, SqlTransaction tran)
        {
            const String sql = @"UPDATE dbo.servidor_publico
                                        SET
                                    ID_PERSONA = @ID_PERSONA,
                                    ID_REGIMEN_LABORAL = @ID_REGIMEN_LABORAL,
                                    ID_SITUACION_LABORAL = @ID_SITUACION_LABORAL,
                                    ID_CONDICION_LABORAL = @ID_CONDICION_LABORAL,
                                    ID_AFP = @ID_AFP,
                                    ID_REGIMEN_PENSIONARIO = @ID_REGIMEN_PENSIONARIO,
                                    ID_CARGO = @ID_CARGO,
                                    ID_JORNADA_LABORAL = @ID_JORNADA_LABORAL,
                                    ID_CATEGORIA_REMUNERATIVA = @ID_CATEGORIA_REMUNERATIVA,
                                    ID_CENTRO_TRABAJO = @ID_CENTRO_TRABAJO,
                                    ID_TIPO_COMISION_AFP = @ID_TIPO_COMISION_AFP,
                                    CODIGO_SERVIDOR_PUBLICO = @CODIGO_SERVIDOR_PUBLICO,
                                    CODIGO_PLAZA = @CODIGO_PLAZA,
                                    CUSPP = @CUSPP,
                                    FECHA_INGRESO_SPP = @FECHA_INGRESO_SPP,
                                    FECHA_INICIO_VINCULACION = @FECHA_INICIO_VINCULACION,
                                    FECHA_FIN_VINCULACION = @FECHA_FIN_VINCULACION,
                                    FECHA_CESE = @FECHA_CESE,
                                    ACTIVO = @ACTIVO,
                                    FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                    USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                    IP_MODIFICACION = @IP_MODIFICACION
                                        WHERE ID_SERVIDOR_PUBLICO = @ID_SERVIDOR_PUBLICO";

            SqlParameter[] par =
            {
                new SqlParameter("@ID_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = s.idServidorPublico},
                new SqlParameter("@ID_PERSONA", SqlDbType.Int) {Value = s.idPersona},
                new SqlParameter("@ID_REGIMEN_LABORAL", SqlDbType.Int) {Value = s.idRegimenLaboral},
                new SqlParameter("@ID_SITUACION_LABORAL", SqlDbType.Int) {Value = s.idSituacionLaboral},
                new SqlParameter("@ID_CONDICION_LABORAL", SqlDbType.Int) {Value = s.idCondicionLaboral},
                new SqlParameter("@ID_AFP", SqlDbType.Int) {Value = s.idAfp},
                new SqlParameter("@ID_REGIMEN_PENSIONARIO", SqlDbType.Int) {Value = s.idRegimenPensionario},
                new SqlParameter("@ID_CARGO", SqlDbType.Int) {Value = s.idCargo},
                new SqlParameter("@ID_JORNADA_LABORAL", SqlDbType.Int) {Value = s.idJornadaLaboral},
                new SqlParameter("@ID_CATEGORIA_REMUNERATIVA", SqlDbType.Int) {Value = s.idCategoriaRemunerativa},
                new SqlParameter("@ID_CENTRO_TRABAJO", SqlDbType.Int) {Value = s.idCentroTrabajo},
                new SqlParameter("@ID_TIPO_COMISION_AFP", SqlDbType.Int) {Value = s.idTipoComisionAfp},
                new SqlParameter("@CODIGO_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = s.codigoServidorPublico},
                new SqlParameter("@CODIGO_PLAZA", SqlDbType.Char, 12) {Value = s.codigoPlaza},
                new SqlParameter("@CUSPP", SqlDbType.VarChar, 20) {Value = s.cuspp},
                new SqlParameter("@FECHA_INGRESO_SPP", SqlDbType.Date) {Value = s.fechaIngresoSpp},
                new SqlParameter("@FECHA_INICIO_VINCULACION", SqlDbType.Date) {Value = s.fechaInicioVinculacion},
                new SqlParameter("@FECHA_FIN_VINCULACION", SqlDbType.Date) {Value = s.fechaFinVinculacion},
                new SqlParameter("@FECHA_CESE", SqlDbType.Date) {Value = s.fechaCese},
                new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = s.activo},
                new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime) {Value = s.fechaModificacion},
                new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20) {Value = s.usuarioModificacion},
                new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40) {Value = s.ipModificacion}
            };

            try
            {
                return await SqlHelper.ExecuteNonQueryAsync(con, tran, CommandType.Text, sql, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DesactivarServidorPublico(ServidorPublico s)
        {
            const string sql = @"UPDATE dbo.servidor_publico
                                            SET
                                        ACTIVO = @ACTIVO,
                                        FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        IP_MODIFICACION = @IP_MODIFICACION
                                            WHERE ID_SERVIDOR_PUBLICO = @ID_SERVIDOR_PUBLICO";

            SqlParameter[] par = new SqlParameter[4];

            par[0] = new SqlParameter("@ACTIVO", SqlDbType.Bit) {Value = s.activo};
            par[1] = new SqlParameter("@FECHA_MODIFICACION", SqlDbType.DateTime) {Value = s.fechaModificacion};
            par[2] = new SqlParameter("@USUARIO_MODIFICACION", SqlDbType.VarChar, 20) {Value = s.usuarioModificacion};
            par[3] = new SqlParameter("@IP_MODIFICACION", SqlDbType.VarChar, 40) {Value = s.ipModificacion};

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