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
    public class NivelEducativoService : ServiceBase, INivelEducativoService
    {
        public NivelEducativoService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> ActualizarReplica(NivelEducativoReplica request)
        {
            try
            {
                INivelEducativoDAO nivelEducativoDAO = new NivelEducativoDAO(txtConnectionString);
                IModalidadEducativaDAO modalidadEducativaDao = new ModalidadEducativaDAO(txtConnectionString);

                if (!request.codigoModalidadEducativa.HasValue || request.codigoModalidadEducativa <= 0)
                    request.idModalidadEducativa = null;
                if (request.codigoModalidadEducativa.HasValue && request.codigoModalidadEducativa > 0)
                {
                    var idModalidadEducativa = await modalidadEducativaDao.GetModalidadEducativaByCodigo(request.codigoModalidadEducativa.Value);
                    if (idModalidadEducativa <= 0)
                        throw new NotFoundCustomException(Constante.EX_MODALIDAD_EDUCATIVA_NOTFOUND);
                    request.idModalidadEducativa = idModalidadEducativa;
                }

                var idNivelEducativo = await nivelEducativoDAO.GetNivelEducativoByCodigo(request.codigoNivelEducativo);
                if (idNivelEducativo <= 0)
                    return await nivelEducativoDAO.CrearReplica(request);
                request.idNivelEducativo = idNivelEducativo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await nivelEducativoDAO.ActualizarReplica(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> CrearReplica(NivelEducativoReplica request)
        {
            try
            {
                INivelEducativoDAO nivelEducativoDAO = new NivelEducativoDAO(txtConnectionString);
                IModalidadEducativaDAO modalidadEducativaDao = new ModalidadEducativaDAO(txtConnectionString);

                if (!request.codigoModalidadEducativa.HasValue || request.codigoModalidadEducativa <= 0)
                    request.idModalidadEducativa = null;
                if (request.codigoModalidadEducativa.HasValue && request.codigoModalidadEducativa > 0)
                {
                    var idModalidadEducativa = await modalidadEducativaDao.GetModalidadEducativaByCodigo(request.codigoModalidadEducativa.Value);
                    if (idModalidadEducativa <= 0)
                        throw new NotFoundCustomException(Constante.EX_MODALIDAD_EDUCATIVA_NOTFOUND);
                    request.idModalidadEducativa = idModalidadEducativa;
                }

                var idNivelEducativo = await nivelEducativoDAO.GetNivelEducativoByCodigo(request.codigoNivelEducativo);
                if (idNivelEducativo <= 0)
                    return await nivelEducativoDAO.CrearReplica(request);
                request.idNivelEducativo = idNivelEducativo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await nivelEducativoDAO.ActualizarReplica(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarReplica(NivelEducativoReplica request)
        {
            try
            {
                INivelEducativoDAO nivelEducativoDAO = new NivelEducativoDAO(txtConnectionString);
                var idNivelEducativo = await nivelEducativoDAO.GetNivelEducativoByCodigo(request.codigoNivelEducativo);
                if (idNivelEducativo <= 0)
                    return 1;
                request.idNivelEducativo = idNivelEducativo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await nivelEducativoDAO.EliminarReplica(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}