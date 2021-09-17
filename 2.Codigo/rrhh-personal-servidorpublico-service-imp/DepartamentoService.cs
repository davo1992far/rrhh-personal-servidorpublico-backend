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
    public class DepartamentoService : ServiceBase, IDepartamentoService
    {
        public DepartamentoService(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentos()
        {
            IEnumerable<Departamento> response = null;
            try
            {
                IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
                response = await departamentoDAO.GetDepartamentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<Departamento> GetDepartamentoPorId(int idDepartamento)
        {
            Departamento response = null;
            try
            {
                IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
                response = await departamentoDAO.GetDepartamentoPorId(idDepartamento);

                if (response == null)
                    throw new NotFoundCustomException(Constante.EX_DEPARTAMENTO_NOT_FOUND);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<Departamento> GetDepartamentoPorCodigoInei(string codigoDepartamentoInei)
        {
            Departamento response = null;
            try
            {
                IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
                response = await departamentoDAO.GetDepartamentoPorCodigoInei(codigoDepartamentoInei);

                if (response == null)
                    throw new NotFoundCustomException(Constante.EX_DEPARTAMENTO_NOT_FOUND);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<int> CrearReplica(DepartamentoReplica request)
        {
            IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
            Departamento departamento = new Departamento
            {
                codigoDepartamentoInei = request.codigoDepartamentoInei,
                codigoDepartamentoReniec = request.codigoDepartamentoReniec,
                descripcion = request.descripcion,
                abreviatura = request.abreviatura,
                activo = request.activo,
                eliminado = request.eliminado,
                fechaCreacion = DateTime.Now,
                usuarioCreacion = request.usuarioCreacion
            };

            departamento.idDepartamento = await departamentoDAO.GetIdDepartamentoByCodigoInei(request.codigoDepartamentoInei);
            if (departamento.idDepartamento <= 0)
                return await departamentoDAO.CrearDepartamento(departamento);

            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await departamentoDAO.ActualizarDepartamento(departamento);
        }

        public async Task<int> ActualizarReplica(DepartamentoReplica request)
        {
            IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
            Departamento departamento = new Departamento
            {
                codigoDepartamentoInei = request.codigoDepartamentoInei,
                codigoDepartamentoReniec = request.codigoDepartamentoReniec,
                descripcion = request.descripcion,
                abreviatura = request.abreviatura,
                activo = request.activo,
                eliminado = request.eliminado,
                fechaModificacion = DateTime.Now,
                usuarioModificacion = request.usuarioModificacion
            };

            departamento.idDepartamento = await departamentoDAO.GetIdDepartamentoByCodigoInei(request.codigoDepartamentoInei);
            if (departamento.idDepartamento <= 0)
                return await departamentoDAO.CrearDepartamento(departamento);
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await departamentoDAO.ActualizarDepartamento(departamento);
        }

        public async Task<int> EliminarReplica(DepartamentoReplica request)
        {
            IDepartamentoDAO departamentoDAO = new DepartamentoDAO(txtConnectionString);
            Departamento departamento = new Departamento
            {
                codigoDepartamentoInei = request.codigoDepartamentoInei,
                codigoDepartamentoReniec = request.codigoDepartamentoReniec,
                descripcion = request.descripcion,
                abreviatura = request.abreviatura,
                activo = false,
                eliminado = true,
                fechaModificacion = DateTime.Now,
                usuarioModificacion = request.usuarioModificacion
            };

            departamento.idDepartamento = await departamentoDAO.GetIdDepartamentoByCodigoInei(request.codigoDepartamentoInei);
            if (departamento.idDepartamento <= 0)
                return 1;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await departamentoDAO.ActualizarDepartamento(departamento);
        }
    }
}