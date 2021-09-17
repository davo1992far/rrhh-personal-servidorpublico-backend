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
    public class ModalidadEducativaService : ServiceBase, IModalidadEducativaService
    {
        public ModalidadEducativaService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> ActualizarReplica(ModalidadEducativaReplica request)
        {
            try
            {
                IModalidadEducativaDAO modalidadEducativaDAO = new ModalidadEducativaDAO(txtConnectionString);
                if (request.codigoModalidadEducativa <= 0)
                    throw new ValidationCustomException(Constante.EX_MODALIDAD_EDUCATIVA_NOTFOUND);

                var idModalidadEducativa = await modalidadEducativaDAO.GetModalidadEducativaByCodigo(request.codigoModalidadEducativa);
                if (idModalidadEducativa <= 0)
                    return await modalidadEducativaDAO.CrearReplica(request);
                request.idModalidadEducativa = idModalidadEducativa;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await modalidadEducativaDAO.ActualizarReplica(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CrearReplica(ModalidadEducativaReplica request)
        {
            try
            {
                IModalidadEducativaDAO modalidadEducativaDAO = new ModalidadEducativaDAO(txtConnectionString);
                if (request.codigoModalidadEducativa <= 0)
                    throw new ValidationCustomException(Constante.EX_MODALIDAD_EDUCATIVA_NOTFOUND);

                var idModalidadEducativa = await modalidadEducativaDAO.GetModalidadEducativaByCodigo(request.codigoModalidadEducativa);
                if (idModalidadEducativa <= 0)
                    return await modalidadEducativaDAO.CrearReplica(request);
                request.idModalidadEducativa = idModalidadEducativa;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await modalidadEducativaDAO.ActualizarReplica(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarReplica(ModalidadEducativaReplica request)
        {
            try
            {
                IModalidadEducativaDAO modalidadEducativaDAO = new ModalidadEducativaDAO(txtConnectionString);
                var idModalidadEducativa = await modalidadEducativaDAO.GetModalidadEducativaByCodigo(request.codigoModalidadEducativa);
                if (idModalidadEducativa <= 0)
                    return 1;
                request.idModalidadEducativa = idModalidadEducativa;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await modalidadEducativaDAO.EliminarReplica(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}