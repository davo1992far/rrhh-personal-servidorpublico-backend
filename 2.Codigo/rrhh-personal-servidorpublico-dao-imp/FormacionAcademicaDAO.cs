using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.dao.imp
{
    public class FormacionAcademicaDAO : DAOBase, IFormacionAcademicaDAO
    {
        public FormacionAcademicaDAO(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }


        public async Task<int> GetIdFormacionAcademicaPorCodigo(int codigoFormacionAcademica)
        {
            const string sql = @"SELECT
                                        a.ID_FORMACION_ACADEMICA                                      
                                        FROM dbo.formacion_academica a
                                        WHERE a.CODIGO_FORMACION_ACADEMICA = @CODIGO_FORMACION_ACADEMICA";

            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@CODIGO_FORMACION_ACADEMICA", SqlDbType.Int) {Value = codigoFormacionAcademica};
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

        public async Task<int> Crear(FormacionAcademicaReplica request)
        {
            const string sql = @"insert into [dbo].[formacion_academica](ID_FORMACION_ACADEMICA, ID_SERVIDOR_PUBLICO, ID_PAIS, ID_GRADO_INSTRUCCION,
                                        ID_CENTRO_ESTUDIO, ID_GRUPO_CARRERA, ID_NIVEL_CARRERA, ID_SITUACION_ACADEMICA,
                                        ID_COLEGIO_PROFESIONAL, ID_DEPARTAMENTO, ID_PROVINCIA, ID_DISTRITO,
                                        ID_ESPECIALIDAD_PROFESIONAL, ID_CARRERA_PROFESIONAL, CODIGO_FORMACION_ACADEMICA,
                                        FECHA_REGISTRO, ANIO_INICIO_ESTUDIOS, ANIO_FIN_ESTUDIOS,
                                        FECHA_EXPEDICION_GRADO_ACADEMICO, NUMERO_COLEGIATURA, FECHA_COLEGIATURA, ACTIVO,
                                        FECHA_CREACION, USUARIO_CREACION, IP_CREACION)
                                            output inserted.ID_FORMACION_ACADEMICA
                                            values (NEXT VALUE FOR dbo.seq_formacion_academica,
                                                    @ID_SERVIDOR_PUBLICO, @ID_PAIS, @ID_GRADO_INSTRUCCION,
                                                    @ID_CENTRO_ESTUDIO, @ID_GRUPO_CARRERA, @ID_NIVEL_CARRERA, @ID_SITUACION_ACADEMICA,
                                                    @ID_COLEGIO_PROFESIONAL, @ID_DEPARTAMENTO, @ID_PROVINCIA, @ID_DISTRITO,
                                                    @ID_ESPECIALIDAD_PROFESIONAL, @ID_CARRERA_PROFESIONAL, @CODIGO_FORMACION_ACADEMICA,
                                                    @FECHA_REGISTRO, @ANIO_INICIO_ESTUDIOS, @ANIO_FIN_ESTUDIOS,
                                                    @FECHA_EXPEDICION_GRADO_ACADEMICO, @NUMERO_COLEGIATURA, @FECHA_COLEGIATURA, @ACTIVO,
                                                    @FECHA_CREACION, @USUARIO_CREACION, @IP_CREACION)";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = request.idServidorPublico},
                new SqlParameter("@ID_PAIS", SqlDbType.Int) {Value = request.idPais},
                new SqlParameter("@ID_GRADO_INSTRUCCION", SqlDbType.Int) {Value = request.idGradoInstruccion},
                new SqlParameter("@ID_CENTRO_ESTUDIO", SqlDbType.Int) {Value = request.idCentroEstudio},
                new SqlParameter("@ID_GRUPO_CARRERA", SqlDbType.Int) {Value = request.idGrupoCarrera},
                new SqlParameter("@ID_NIVEL_CARRERA", SqlDbType.Int) {Value = request.idNivelCarrera},
                new SqlParameter("@ID_SITUACION_ACADEMICA", SqlDbType.Int) {Value = request.idSituacionAcademica},
                new SqlParameter("@ID_COLEGIO_PROFESIONAL", SqlDbType.Int) {Value = request.idColegioProfesional},
                new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int) {Value = request.idDepartamento},
                new SqlParameter("@ID_PROVINCIA", SqlDbType.Int) {Value = request.idProvincia},
                new SqlParameter("@ID_DISTRITO", SqlDbType.Int) {Value = request.idDistrito},
                new SqlParameter("@ID_ESPECIALIDAD_PROFESIONAL", SqlDbType.Int) {Value = request.idEspecialidadProfesional},
                new SqlParameter("@ID_CARRERA_PROFESIONAL", SqlDbType.Int) {Value = request.idCarreraProfesional},
                new SqlParameter("@CODIGO_FORMACION_ACADEMICA", SqlDbType.Int) {Value = request.codigoFormacionAcademica},
                new SqlParameter("@FECHA_REGISTRO", SqlDbType.DateTime) {Value = request.fechaRegistro},
                new SqlParameter("@ANIO_INICIO_ESTUDIOS", SqlDbType.VarChar,4) {Value = request.anioInicioEstudios},
                new SqlParameter("@ANIO_FIN_ESTUDIOS", SqlDbType.VarChar, 4) {Value = request.anioFinEstudios},
                new SqlParameter("@FECHA_EXPEDICION_GRADO_ACADEMICO", SqlDbType.DateTime) {Value = request.fechaExpedicionGradoEstudios},
                new SqlParameter("@NUMERO_COLEGIATURA", SqlDbType.VarChar, 20) {Value = request.numeroColegiatura},
                new SqlParameter("@FECHA_COLEGIATURA", SqlDbType.DateTime) {Value = request.fechaColegiatura},
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

        public async Task<int> Actualizar(FormacionAcademicaReplica request)
        {
            const string sql = @"UPDATE a
                                        SET a.ID_SERVIDOR_PUBLICO=@ID_SERVIDOR_PUBLICO,
                                            a.ID_PAIS=@ID_PAIS,
                                            a.ID_GRADO_INSTRUCCION=@ID_GRADO_INSTRUCCION,
                                            a.ID_CENTRO_ESTUDIO=@ID_CENTRO_ESTUDIO,
                                            a.ID_GRUPO_CARRERA=@ID_GRUPO_CARRERA,
                                            a.ID_NIVEL_CARRERA=@ID_NIVEL_CARRERA,
                                            a.ID_SITUACION_ACADEMICA=@ID_SITUACION_ACADEMICA,
                                            a.ID_COLEGIO_PROFESIONAL=@ID_COLEGIO_PROFESIONAL,
                                            a.ID_DEPARTAMENTO=@ID_DEPARTAMENTO,
                                            a.ID_PROVINCIA=@ID_PROVINCIA,
                                            a.ID_DISTRITO=@ID_DISTRITO,
                                            a.ID_ESPECIALIDAD_PROFESIONAL=@ID_ESPECIALIDAD_PROFESIONAL,
                                            a.ID_CARRERA_PROFESIONAL=@ID_CARRERA_PROFESIONAL,
                                            a.FECHA_REGISTRO=@FECHA_REGISTRO,
                                            a.ANIO_INICIO_ESTUDIOS=@ANIO_INICIO_ESTUDIOS,
                                            a.ANIO_FIN_ESTUDIOS=@ANIO_FIN_ESTUDIOS,
                                            a.FECHA_EXPEDICION_GRADO_ACADEMICO=@FECHA_EXPEDICION_GRADO_ACADEMICO,
                                            a.NUMERO_COLEGIATURA=@NUMERO_COLEGIATURA,
                                            a.FECHA_COLEGIATURA=@FECHA_COLEGIATURA,
                                            a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                            a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                            a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[formacion_academica] a
                                        WHERE a.ID_FORMACION_ACADEMICA = @ID_FORMACION_ACADEMICA ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_FORMACION_ACADEMICA", SqlDbType.BigInt) {Value = request.idFormacionAcademica},
                new SqlParameter("@ID_SERVIDOR_PUBLICO", SqlDbType.BigInt) {Value = request.idServidorPublico},
                new SqlParameter("@ID_PAIS", SqlDbType.Int) {Value = request.idPais},
                new SqlParameter("@ID_GRADO_INSTRUCCION", SqlDbType.Int) {Value = request.idGradoInstruccion},
                new SqlParameter("@ID_CENTRO_ESTUDIO", SqlDbType.Int) {Value = request.idCentroEstudio},
                new SqlParameter("@ID_GRUPO_CARRERA", SqlDbType.Int) {Value = request.idGrupoCarrera},
                new SqlParameter("@ID_NIVEL_CARRERA", SqlDbType.Int) {Value = request.idNivelCarrera},
                new SqlParameter("@ID_SITUACION_ACADEMICA", SqlDbType.Int) {Value = request.idSituacionAcademica},
                new SqlParameter("@ID_COLEGIO_PROFESIONAL", SqlDbType.Int) {Value = request.idColegioProfesional},
                new SqlParameter("@ID_DEPARTAMENTO", SqlDbType.Int) {Value = request.idDepartamento},
                new SqlParameter("@ID_PROVINCIA", SqlDbType.Int) {Value = request.idProvincia},
                new SqlParameter("@ID_DISTRITO", SqlDbType.Int) {Value = request.idDistrito},
                new SqlParameter("@ID_ESPECIALIDAD_PROFESIONAL", SqlDbType.Int) {Value = request.idEspecialidadProfesional},
                new SqlParameter("@ID_CARRERA_PROFESIONAL", SqlDbType.Int) {Value = request.idCarreraProfesional},
                new SqlParameter("@FECHA_REGISTRO", SqlDbType.DateTime) {Value = request.fechaRegistro},
                new SqlParameter("@ANIO_INICIO_ESTUDIOS", SqlDbType.VarChar,4) {Value = request.anioInicioEstudios},
                new SqlParameter("@ANIO_FIN_ESTUDIOS", SqlDbType.VarChar, 4) {Value = request.anioFinEstudios},
                new SqlParameter("@FECHA_EXPEDICION_GRADO_ACADEMICO", SqlDbType.DateTime) {Value = request.fechaExpedicionGradoEstudios},
                new SqlParameter("@NUMERO_COLEGIATURA", SqlDbType.VarChar, 20) {Value = request.numeroColegiatura},
                new SqlParameter("@FECHA_COLEGIATURA", SqlDbType.DateTime) {Value = request.fechaColegiatura},
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

        public async Task<int> Eliminar(FormacionAcademicaReplica request)
        {
            const string sql = @" UPDATE a SET
                                        a.ACTIVO = @ACTIVO,
                                        a.FECHA_MODIFICACION = @FECHA_MODIFICACION,
                                        a.USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
                                        a.IP_MODIFICACION = @IP_MODIFICACION
                                        FROM [dbo].[formacion_academica] a
                                        WHERE a.ID_FORMACION_ACADEMICA = @ID_FORMACION_ACADEMICA ";

            SqlParameter[] parameter =
            {
                new SqlParameter("@ID_FORMACION_ACADEMICA", SqlDbType.Int) {Value = request.idFormacionAcademica},
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