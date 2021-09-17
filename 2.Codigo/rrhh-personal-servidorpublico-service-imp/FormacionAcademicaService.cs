using System;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.dao.imp;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;
using minedu.tecnologia.util.lib.Exceptions;

namespace minedu.rrhh.personal.servidorpublico.service.imp
{
    public class FormacionAcademicaService : ServiceBase, IFormacionAcademicaService
    {
        public FormacionAcademicaService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> Crear(FormacionAcademicaReplica request)
        {
            try
            {
                ICarreraProfesionalDAO carreraProfesionalDao = new CarreraProfesionalDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);
                IEspecialidadProfesionalDAO especialidadProfesionalDao = new EspecialidadProfesionalDAO(txtConnectionString);
                IFormacionAcademicaDAO formacionAcademicaDao = new FormacionAcademicaDAO(txtConnectionString);
                IServidorPublicoDAO servidorPublicoDao = new ServidorPublicoDAO(txtConnectionString);
                IPaisDAO paisDao = new PaisDAO(txtConnectionString);
                IGradoInstruccionDAO gradoInstruccionDao = new GradoInstruccionDAO(txtConnectionString);
                ICentroEstudioDAO centroEstudioDao = new CentroEstudioDAO(txtConnectionString);

                if (request.codigoFormacionAcademica <= 0 ||
                    request.fechaRegistro.Year == 1 ||
                    request.fechaRegistro > DateTime.Now ||
                    string.IsNullOrEmpty(request.anioInicioEstudios))
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);


                if (request.codigoServidorPublico <= 0)
                    throw new ValidationCustomException(Constante.EX_SERVIDOR_PUBLICO_NOT_FOUND);
                var servidorPublico = await servidorPublicoDao.GetServidorPublicoReplicaPorCodigo(request.codigoServidorPublico);
                if (servidorPublico == null)
                    throw new NotFoundCustomException(Constante.EX_SERVIDOR_PUBLICO_NOT_FOUND);
                request.idServidorPublico = servidorPublico.idServidorPublico;

                if (string.IsNullOrEmpty(request.codigoPais))
                    request.idPais = null;
                if (!string.IsNullOrEmpty(request.codigoPais))
                {
                    var idPais = await paisDao.GetIdPaisPorCodigo(request.codigoPais);
                    if (idPais <= 0)
                        throw new NotFoundCustomException(Constante.EX_PAIS_NOTFOUND);
                    request.idPais = idPais;
                }

                if (!request.codigoGradoInstruccion.HasValue || request.codigoGradoInstruccion <= 0)
                    request.idGradoInstruccion = null;
                if (request.codigoGradoInstruccion.HasValue && request.codigoGradoInstruccion > 0)
                {
                    var idGradoInstruccion = await gradoInstruccionDao.GetIdGradoInstruccionPorCodigo(request.codigoGradoInstruccion.Value);
                    if (idGradoInstruccion <= 0)
                        throw new NotFoundCustomException(Constante.EX_GRADO_INSTRUCCION_NOTFOUND);
                    request.idGradoInstruccion = idGradoInstruccion;
                }

                if (!request.codigoCentroEstudio.HasValue || request.codigoCentroEstudio <= 0)
                    request.idCentroEstudio = null;
                if (request.codigoCentroEstudio.HasValue && request.codigoCentroEstudio > 0)
                {
                    var idCentroEstudio = await centroEstudioDao.GetIdCentroEstudioPorCodigo(request.codigoCentroEstudio.Value);
                    if (idCentroEstudio <= 0)
                        throw new NotFoundCustomException(Constante.EX_CENTRO_ESTUDIO_NOTFOUND);
                    request.idCentroEstudio = idCentroEstudio;
                }

                if (!request.codigoGrupoCarrera.HasValue || request.codigoGrupoCarrera <= 0)
                    request.idGrupoCarrera = null;
                if (request.codigoGrupoCarrera.HasValue && request.codigoGrupoCarrera > 0)
                {
                    var idGrupoCarrera = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.GRUPO_CARRERA, request.codigoGrupoCarrera.Value);
                    if (idGrupoCarrera <= 0)
                        throw new NotFoundCustomException(Constante.EX_GRUPO_CARRERA_NOTFOUND);
                    request.idGrupoCarrera = idGrupoCarrera;
                }


                if (!request.codigoNivelCarrera.HasValue || request.codigoNivelCarrera <= 0)
                    request.idNivelCarrera = null;
                if (request.codigoNivelCarrera.HasValue && request.codigoNivelCarrera > 0)
                {
                    var idNivelCarrera = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.NIVEL_CARRERA, request.codigoNivelCarrera.Value);
                    if (idNivelCarrera <= 0)
                        throw new NotFoundCustomException(Constante.EX_NIVEL_CARRERA_NOTFOUND);
                    request.idNivelCarrera = idNivelCarrera;
                }

                if (!request.codigoSituacionAcademica.HasValue || request.codigoSituacionAcademica <= 0)
                    request.idSituacionAcademica = null;
                if (request.codigoSituacionAcademica.HasValue && request.codigoSituacionAcademica > 0)
                {
                    var idSituacionAcademica =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.SITUACION_ACADEMICA, request.codigoSituacionAcademica.Value);
                    if (idSituacionAcademica <= 0)
                        throw new NotFoundCustomException(Constante.EX_SITUACION_ACADEMICA_NOTFOUND);
                    request.idSituacionAcademica = idSituacionAcademica;
                }

                if (!request.codigoColegioProfesional.HasValue || request.codigoColegioProfesional <= 0)
                    request.idColegioProfesional = null;
                if (request.codigoColegioProfesional.HasValue && request.codigoColegioProfesional > 0)
                {
                    var idColegioProfesional =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.COLEGIO_PROFESIONAL, request.codigoColegioProfesional.Value);
                    if (idColegioProfesional <= 0)
                        throw new NotFoundCustomException(Constante.EX_COLEGIO_PROFESIONAL_NOTFOUND);
                    request.idColegioProfesional = idColegioProfesional;
                }

                if (!string.IsNullOrEmpty(request.codigoDistrito))
                {
                    IDistritoDAO distritoDAO = new DistritoDAO(txtConnectionString);
                    var distrito = await distritoDAO.GetDistritoPorCodigoInei(request.codigoDistrito);
                    if (distrito == null)
                        throw new NotFoundCustomException(Constante.EX_DISTRITO_NOT_FOUND);
                    request.idDistrito = distrito.idDistrito;
                    request.idProvincia = distrito.idProvincia;
                    request.idDepartamento = distrito.idDepartamento;
                }
                else
                {
                    request.idDistrito = null;
                    if (!string.IsNullOrEmpty(request.codigoProvincia))
                    {
                        IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
                        var provincia = await provinciaDAO.GetIdProvinciaByCodigoInei(request.codigoProvincia);
                        if (provincia == null)
                            throw new NotFoundCustomException(Constante.EX_PROVINCIA_NOT_FOUND);
                        request.idDepartamento = provincia.idDepartamento;
                        request.idProvincia = provincia.idProvincia;
                    }
                    else if (!string.IsNullOrEmpty(request.codigoDepartamento))
                    {
                        request.idProvincia = null;
                        IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
                        var departamento = await departamentoDAO.GetDepartamentoPorCodigoInei(request.codigoDepartamento);
                        if (departamento == null)
                            throw new NotFoundCustomException(Constante.EX_DEPARTAMENTO_NOT_FOUND);
                        request.idDepartamento = departamento.idDepartamento;
                    }
                    else
                    {
                        request.idDepartamento = null;
                    }
                }

                if (!request.codigoEspecialidadProfesional.HasValue || request.codigoEspecialidadProfesional <= 0)
                    request.idEspecialidadProfesional = null;
                if (request.codigoEspecialidadProfesional.HasValue && request.codigoEspecialidadProfesional > 0)
                {
                    var idEspecialidadProfesional = await especialidadProfesionalDao.GetIdEspecialidadProfesionalPorCodigo(request.codigoEspecialidadProfesional.Value);
                    if (idEspecialidadProfesional <= 0)
                        throw new NotFoundCustomException(Constante.EX_ESPECIALIDAD_PROFESIONAL_NOTFOUND);
                    request.idEspecialidadProfesional = idEspecialidadProfesional;
                }

                if (!request.codigoCarreraProfesional.HasValue || request.codigoCarreraProfesional <= 0)
                    request.idCarreraProfesional = null;
                if (request.codigoCarreraProfesional.HasValue && request.codigoCarreraProfesional > 0)
                {
                    var idCarreraProfesional = await carreraProfesionalDao.GetIdCarreraProfesionalPorCodigo(request.codigoCarreraProfesional.Value);
                    if (idCarreraProfesional <= 0)
                        throw new NotFoundCustomException(Constante.EX_CARRERA_PROFESIONAL_NOTFOUND);
                    request.idCarreraProfesional = idCarreraProfesional;
                }

                var idFormacionAcademica = await formacionAcademicaDao.GetIdFormacionAcademicaPorCodigo(request.codigoFormacionAcademica);
                if (idFormacionAcademica <= 0)
                    return await formacionAcademicaDao.Crear(request);
                request.idFormacionAcademica = idFormacionAcademica;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await formacionAcademicaDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(FormacionAcademicaReplica request)
        {
            try
            {
                return await Crear(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(FormacionAcademicaReplica request)
        {
            try
            {
                IFormacionAcademicaDAO formacionAcademicaDao = new FormacionAcademicaDAO(txtConnectionString);
             
                var idFormacionAcademica = await formacionAcademicaDao.GetIdFormacionAcademicaPorCodigo(request.codigoFormacionAcademica);
                if (idFormacionAcademica <= 0)
                    return 1;
                request.idFormacionAcademica = idFormacionAcademica;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await formacionAcademicaDao.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}