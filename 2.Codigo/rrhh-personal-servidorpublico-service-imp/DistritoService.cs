using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.dao.imp;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personas.service.intf;
using minedu.tecnologia.util.lib;
using minedu.tecnologia.util.lib.Exceptions;

namespace minedu.rrhh.personal.servidorpublico.service.imp
{
    public class DistritoService : ServiceBase, IDistritoService
    {
        public DistritoService(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        public async Task<IEnumerable<Distrito>> GetDistritosByIdProvincia(int idDepartamento, int idProvincia)
        {
            string mensajes = "";
            IEnumerable<Distrito> response = null;
            Utilitario utilitario = new Utilitario();
            try
            {
                if (idDepartamento <= 0 || idProvincia <= 0)
                    throw new ValidationCustomException(Constante.EX_PARAMETROS_INCORRECTOS);

                IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
                int dep = await departamentoDAO.GetValidarDepartamentoId(idDepartamento);

                if (dep == 0) mensajes = mensajes + Constante.DEPARTAMENTO_VALIDAR + "|";

                IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
                int pro = await provinciaDAO.GetValidarProvinciaId(idDepartamento, idProvincia);

                if (pro == 0) mensajes = mensajes + Constante.PROVINCIA_VALIDAR + "|";

                if (mensajes != "")
                {
                    mensajes = utilitario.RemoverUltimoCaracter(mensajes);
                    throw new ValidationCustomException(mensajes);
                }

                IDistritoDAO distritoDAO = new DistritoDAO(txtConnectionString);
                response = await distritoDAO.GetDistritosByIdProvincia(idDepartamento, idProvincia);

                if (response == null) throw new NotFoundCustomException(Constante.EX_DISTRITO_NOT_FOUND);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<Distrito> GetDistritoPorId(int idDistrito)
        {
            Distrito response = null;
            try
            {
                IDistritoDAO distritoDAO = new DistritoDAO(txtConnectionString);
                response = await distritoDAO.GetDistritoPorId(idDistrito);

                if (response == null)
                    throw new NotFoundCustomException(Constante.EX_DEPARTAMENTO_NOT_FOUND);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<Distrito> GetDistritoPorCodigoInei(string codigoDistritoinei)
        {
            Distrito response = null;
            try
            {
                IDistritoDAO distritoDAO = new DistritoDAO(txtConnectionString);
                response = await distritoDAO.GetDistritoPorCodigoInei(codigoDistritoinei);

                if (response == null)
                    throw new NotFoundCustomException(Constante.EX_DEPARTAMENTO_NOT_FOUND);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<IEnumerable<Distrito>> GetDistritosByCodigoProvinciaInei(string codigoProvinciaInei)
        {
            //string mensajes = "";
            IEnumerable<Distrito> response = null;
            Utilitario utilitario = new Utilitario();
            Provincia provincia;
            try
            {
                if (string.IsNullOrEmpty(codigoProvinciaInei))
                    throw new ValidationCustomException(Constante.EX_PARAMETROS_INCORRECTOS);

                IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
                provincia = await provinciaDAO.GetIdProvinciaByCodigoInei(codigoProvinciaInei);

                IDistritoDAO distritoDAO = new DistritoDAO(txtConnectionString);
                response = await distritoDAO.GetDistritosByIdProvincia(provincia.idDepartamento, provincia.idProvincia);

                if (response == null) throw new NotFoundCustomException(Constante.EX_DISTRITO_NOT_FOUND);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }


        public async Task<int> CrearReplica(DistritoReplica request)
        {
            IDistritoDAO distritoDAO = new DistritoDAO(txtConnectionString);
            IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
            Distrito distrito = new Distrito
            {
                codigoDistritoInei = request.codigoDistritoInei,
                codigoDistritoReniec = request.codigoDistritoReniec,
                descripcion = request.descripcion,
                abreviatura = request.abreviatura,
                activo = request.activo,
                eliminado = request.eliminado,
                fechaCreacion = DateTime.Now,
                usuarioCreacion = request.usuarioCreacion
            };

            Provincia provincia = await provinciaDAO.GetProvinciaPorCodigoInei(request.codigoProvinciaInei);
            if (provincia == null)
                throw new NotFoundCustomException(Constante.EX_PROVINCIA_NOT_FOUND);

            var distritoResponse = await distritoDAO.GetDistritoPorCodigoInei(request.codigoDistritoInei);
            if (distritoResponse == null)
                return await distritoDAO.CrearDistrito(distrito);
            distrito.idDepartamento = provincia.idDepartamento;
            distrito.idProvincia = provincia.idProvincia;
            distrito.idDistrito = distritoResponse.idDistrito;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await distritoDAO.ActualizarDistrito(distrito);
        }

        public async Task<int> ActualizarReplica(DistritoReplica request)
        {
            IDistritoDAO distritoDAO = new DistritoDAO(txtConnectionString);
            IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
            Distrito distrito = new Distrito
            {
                codigoDistritoInei = request.codigoDistritoInei,
                codigoDistritoReniec = request.codigoDistritoReniec,
                descripcion = request.descripcion,
                abreviatura = request.abreviatura,
                activo = request.activo,
                eliminado = request.eliminado,
                fechaModificacion = DateTime.Now,
                usuarioModificacion = request.usuarioModificacion
            };

            Provincia provincia = await provinciaDAO.GetProvinciaPorCodigoInei(request.codigoProvinciaInei);
            if (provincia == null)
                throw new NotFoundCustomException(Constante.EX_PROVINCIA_NOT_FOUND);

            var distritoResponse = await distritoDAO.GetDistritoPorCodigoInei(request.codigoDistritoInei);
            if (distritoResponse == null)
                return await distritoDAO.CrearDistrito(distrito);
            distrito.idDepartamento = provincia.idDepartamento;
            distrito.idProvincia = provincia.idProvincia;
            distrito.idDistrito = distritoResponse.idDistrito;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await distritoDAO.ActualizarDistrito(distrito);
        }

        public async Task<int> EliminarReplica(DistritoReplica request)
        {
            IDistritoDAO distritoDAO = new DistritoDAO(txtConnectionString);
            IProvinciaDAO provinciaDAO = new ProvinciaDAO(txtConnectionString);
            Distrito distrito = new Distrito
            {
                codigoDistritoInei = request.codigoDistritoInei,
                codigoDistritoReniec = request.codigoDistritoReniec,
                descripcion = request.descripcion,
                abreviatura = request.abreviatura,
                activo = false,
                eliminado = true,
                fechaModificacion = DateTime.Now,
                usuarioModificacion = request.usuarioModificacion
            };

            Provincia provincia = await provinciaDAO.GetProvinciaPorCodigoInei(request.codigoProvinciaInei);
            if (provincia == null)
                throw new NotFoundCustomException(Constante.EX_PROVINCIA_NOT_FOUND);

            var distritoResponse = await distritoDAO.GetDistritoPorCodigoInei(request.codigoDistritoInei);
            if (distritoResponse == null)
                return 1;
            distrito.idDepartamento = provincia.idDepartamento;
            distrito.idProvincia = provincia.idProvincia;
            distrito.idDistrito = distritoResponse.idDistrito;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await distritoDAO.ActualizarDistrito(distrito);
        }
    }
}