using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.dao.imp;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;
using minedu.tecnologia.util.lib.Exceptions;

namespace minedu.rrhh.personal.servidorpublico.service.imp
{
    public class ProvinciaService : ServiceBase, IProvinciaService
    {
        public ProvinciaService(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        public async Task<IEnumerable<Provincia>> GetProvinciasByIdDepartamento(int idDepartamento)
        {
            IEnumerable<Provincia> response = null;
            try
            {
                if (idDepartamento <= 0) throw new ValidationCustomException(Constante.EX_PARAMETROS_INCORRECTOS);

                IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
                int result = await departamentoDAO.GetValidarDepartamentoId(idDepartamento);

                if (result == 0) throw new ValidationCustomException(Constante.DEPARTAMENTO_VALIDAR);

                IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
                response = await provinciaDAO.GetProvinciasByIdDepartamento(idDepartamento);

                if (response == null) throw new NotFoundCustomException(Constante.EX_PROVINCIA_NOT_FOUND);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }


        public async Task<Provincia> GetProvinciaPorId(int idProvincia)
        {
            Provincia response = null;
            try
            {
                IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
                response = await provinciaDAO.GetProvinciaPorId(idProvincia);

                if (response == null)
                    throw new NotFoundCustomException(Constante.EX_DEPARTAMENTO_NOT_FOUND);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<Provincia> GetProvinciaPorCodigoInei(string codigoProvinciaInei)
        {
            Provincia response = null;
            try
            {
                IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
                response = await provinciaDAO.GetProvinciaPorCodigoInei(codigoProvinciaInei);

                if (response == null)
                    throw new NotFoundCustomException(Constante.EX_DEPARTAMENTO_NOT_FOUND);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<IEnumerable<Provincia>> GetProvinciasByCodigoDepartamentoInei(string codigoDepartamentoInei)
        {
            IEnumerable<Provincia> response = null;
            int idDepartamento;
            try
            {
                if (string.IsNullOrEmpty(codigoDepartamentoInei)) throw new ValidationCustomException(Constante.EX_PARAMETROS_INCORRECTOS);

                IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);

                idDepartamento = await departamentoDAO.GetIdDepartamentoByCodigoInei(codigoDepartamentoInei);
                if (idDepartamento == 0) throw new ValidationCustomException(Constante.DEPARTAMENTO_VALIDAR);

                int result = await departamentoDAO.GetValidarDepartamentoId(idDepartamento);

                if (result == 0) throw new ValidationCustomException(Constante.DEPARTAMENTO_VALIDAR);

                IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
                response = await provinciaDAO.GetProvinciasByIdDepartamento(idDepartamento);

                if (response == null) throw new NotFoundCustomException(Constante.EX_PROVINCIA_NOT_FOUND);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<int> CrearReplica(ProvinciaReplica request)
        {
            IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
            IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
            Provincia provincia = new Provincia
            {
                codigoProvinciaInei = request.codigoProvinciaInei,
                codigoProvinciaReniec = request.codigoProvinciaReniec,
                descripcion = request.descripcion,
                abreviatura = request.abreviatura,
                activo = request.activo,
                eliminado = request.eliminado,
                fechaCreacion = DateTime.Now,
                usuarioCreacion = request.usuarioCreacion
            };

            Departamento departamento = await departamentoDAO.GetDepartamentoPorCodigoInei(request.codigoDepartamentoInei);
            if (departamento == null)
                throw new NotFoundCustomException(Constante.EX_DEPARTAMENTO_NOT_FOUND);

            var provinciaResponse = await provinciaDAO.GetIdProvinciaByCodigoInei(request.codigoProvinciaInei);
            if (provinciaResponse == null)
                return await provinciaDAO.CrearProvincia(provincia);
            provincia.idDepartamento = departamento.idDepartamento;
            provincia.idProvincia = provinciaResponse.idProvincia;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await provinciaDAO.ActualizarProvincia(provincia);
        }

        public async Task<int> ActualizarReplica(ProvinciaReplica request)
        {
            IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
            IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
            Provincia provincia = new Provincia
            {
                codigoProvinciaInei = request.codigoProvinciaInei,
                codigoProvinciaReniec = request.codigoProvinciaReniec,
                descripcion = request.descripcion,
                abreviatura = request.abreviatura,
                activo = request.activo,
                eliminado = request.eliminado,
                fechaModificacion = DateTime.Now,
                usuarioModificacion = request.usuarioModificacion
            };

            Departamento departamento = await departamentoDAO.GetDepartamentoPorCodigoInei(request.codigoDepartamentoInei);
            if (departamento == null)
                throw new NotFoundCustomException(Constante.EX_DEPARTAMENTO_NOT_FOUND);

            var provinciaResponse = await provinciaDAO.GetIdProvinciaByCodigoInei(request.codigoProvinciaInei);
            if (provinciaResponse == null)
                return await provinciaDAO.CrearProvincia(provincia);
            provincia.idDepartamento = departamento.idDepartamento;
            provincia.idProvincia = provinciaResponse.idProvincia;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await provinciaDAO.ActualizarProvincia(provincia);
        }

        public async Task<int> EliminarReplica(ProvinciaReplica request)
        {
            IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
            IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
            Provincia provincia = new Provincia
            {
                codigoProvinciaInei = request.codigoProvinciaInei,
                codigoProvinciaReniec = request.codigoProvinciaReniec,
                descripcion = request.descripcion,
                abreviatura = request.abreviatura,
                activo = false,
                eliminado = true,
                fechaModificacion = DateTime.Now,
                usuarioModificacion = request.usuarioModificacion
            };

            Departamento departamento = await departamentoDAO.GetDepartamentoPorCodigoInei(request.codigoDepartamentoInei);
            if (departamento == null)
                throw new NotFoundCustomException(Constante.EX_DEPARTAMENTO_NOT_FOUND);

            var provinciaResponse = await provinciaDAO.GetIdProvinciaByCodigoInei(request.codigoProvinciaInei);
            if (provinciaResponse == null)
                return 1;
            provincia.idProvincia = provinciaResponse.idProvincia;
            provincia.idDepartamento = departamento.idDepartamento;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await provinciaDAO.ActualizarProvincia(provincia);
        }
    }
}