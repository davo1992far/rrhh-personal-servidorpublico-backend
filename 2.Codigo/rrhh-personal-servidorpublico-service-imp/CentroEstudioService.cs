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
    public class CentroEstudioService : ServiceBase, ICentroEstudioService
    {
        public CentroEstudioService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> Crear(CentroEstudioReplica request)
        {
            try
            {
                IPaisDAO paisDao = new PaisDAO(txtConnectionString);
                ICentroEstudioDAO centroEstudioDao = new CentroEstudioDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.codigoPais))
                    throw new ValidationCustomException(Constante.EX_PAIS_NOTFOUND);
                var idPais = await paisDao.GetIdPaisPorCodigo(request.codigoPais);
                if (idPais <= 0)
                    throw new NotFoundCustomException(Constante.EX_PAIS_NOTFOUND);
                request.idPais = idPais;

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

                if (!request.codigoNivelCentroEstudio.HasValue || request.codigoNivelCentroEstudio <= 0)
                    request.idNivelCentroEstudio = null;
                if (request.codigoNivelCentroEstudio.HasValue && request.codigoNivelCentroEstudio > 0)
                {
                    var idNivelCentroEstudio =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.NIVEL_CENTRO_ESTUDIO, request.codigoNivelCentroEstudio.Value);
                    if (idNivelCentroEstudio <= 0)
                        throw new NotFoundCustomException(Constante.EX_NIVEL_CENTRO_ESTUDIO_NOTFOUND);
                    request.idNivelCentroEstudio = idNivelCentroEstudio;
                }

                var idCentroEstudio = await centroEstudioDao.GetIdCentroEstudioPorCodigo(request.codigoCentroEstudio);
                if (idCentroEstudio <= 0)
                    return await centroEstudioDao.Crear(request);
                request.idCentroEstudio = idCentroEstudio;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await centroEstudioDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(CentroEstudioReplica request)
        {
            try
            {
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);
                IPaisDAO paisDao = new PaisDAO(txtConnectionString);
                ICentroEstudioDAO centroEstudioDao = new CentroEstudioDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.codigoPais))
                    throw new ValidationCustomException(Constante.EX_PAIS_NOTFOUND);
                var idPais = await paisDao.GetIdPaisPorCodigo(request.codigoPais);
                if (idPais <= 0)
                    throw new NotFoundCustomException(Constante.EX_PAIS_NOTFOUND);
                request.idPais = idPais;

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

                if (!request.codigoNivelCentroEstudio.HasValue || request.codigoNivelCentroEstudio <= 0)
                    request.idNivelCentroEstudio = null;
                if (request.codigoNivelCentroEstudio.HasValue && request.codigoNivelCentroEstudio > 0)
                {
                    var idNivelCentroEstudio =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.NIVEL_CENTRO_ESTUDIO, request.codigoNivelCentroEstudio.Value);
                    if (idNivelCentroEstudio <= 0)
                        throw new NotFoundCustomException(Constante.EX_NIVEL_CENTRO_ESTUDIO_NOTFOUND);
                    request.idNivelCentroEstudio = idNivelCentroEstudio;
                }

                var idCentroEstudio = await centroEstudioDao.GetIdCentroEstudioPorCodigo(request.codigoCentroEstudio);
                if (idCentroEstudio <= 0)
                    return await centroEstudioDao.Crear(request);
                request.idCentroEstudio = idCentroEstudio;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await centroEstudioDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(CentroEstudioReplica request)
        {
            try
            {
                ICentroEstudioDAO centroEstudioDao = new CentroEstudioDAO(txtConnectionString);

                var idCentroEstudio = await centroEstudioDao.GetIdCentroEstudioPorCodigo(request.codigoCentroEstudio);
                if (idCentroEstudio <= 0)
                    return 1;
                request.idCentroEstudio = idCentroEstudio;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await centroEstudioDao.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}