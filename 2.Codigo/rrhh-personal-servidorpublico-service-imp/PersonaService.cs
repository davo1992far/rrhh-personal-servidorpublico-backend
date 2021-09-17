using System;
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
    public class PersonaService : ServiceBase, IPersonaService
    {
        public PersonaService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> Crear(PersonaReplica request)
        {
            try
            {
                IPersonaDAO personaDao = new PersonaDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.numeroDocumentoIdentidad))
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);

                var idTipoPersona = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_PERSONA, request.codigoTipoPersona);
                if (idTipoPersona <= 0)
                    throw new NotFoundCustomException(Constante.EX_TIPO_PERSONA_NOTFOUND);
                request.idTipoPersona = idTipoPersona;

                if (request.codigoGenero <= 0)
                    request.idGenero = null;
                if (request.codigoGenero.HasValue && request.codigoGenero > 0)
                {
                    var idGenero = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.GENERO_PERSONA, request.codigoGenero.Value);
                    if (idGenero <= 0)
                        throw new NotFoundCustomException(Constante.EX_GENERO_NOTFOUND);
                    request.idGenero = idGenero;
                }

                if (request.codigoTipoDocumentoIdentidad <= 0)
                    throw new ValidationCustomException(Constante.EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND);
                var idTipoDocumentoIdentidad =
                    await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_DOCUMENTO_IDENTIDAD, request.codigoTipoDocumentoIdentidad);
                if (idTipoDocumentoIdentidad <= 0)
                    throw new NotFoundCustomException(Constante.EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND);
                request.idTipoDocumentoIdentidad = idTipoDocumentoIdentidad;

                if (!request.codigoEstadoCivil.HasValue || request.codigoEstadoCivil <= 0)
                    request.idEstadoCivil = null;
                if (request.codigoEstadoCivil.HasValue && request.codigoEstadoCivil > 0)
                {
                    var idEstadoCivil = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.ESTADO_CIVIL, request.codigoEstadoCivil.Value);
                    if (idEstadoCivil <= 0)
                        throw new NotFoundCustomException(Constante.EX_ESTADO_CIVIL_NOTFOUND);
                    request.idEstadoCivil = idEstadoCivil;
                }


                var persona = await personaDao.GetPersonaPorDocumentoIdentidad(request.idTipoDocumentoIdentidad, request.numeroDocumentoIdentidad);
                if (persona == null) return await personaDao.Crear(request);
                request.idPersona = persona.idPersona;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await personaDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(PersonaReplica request)
        {
            try
            {
                IPersonaDAO personaDao = new PersonaDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.numeroDocumentoIdentidad))
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);

                var idTipoPersona = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_PERSONA, request.codigoTipoPersona);
                if (idTipoPersona <= 0)
                    throw new NotFoundCustomException(Constante.EX_TIPO_PERSONA_NOTFOUND);
                request.idTipoPersona = idTipoPersona;

                if (request.codigoGenero <= 0)
                    request.idGenero = null;
                if (request.codigoGenero.HasValue && request.codigoGenero > 0)
                {
                    var idGenero = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.GENERO_PERSONA, request.codigoGenero.Value);
                    if (idGenero <= 0)
                        throw new NotFoundCustomException(Constante.EX_GENERO_NOTFOUND);
                    request.idGenero = idGenero;
                }

                if (request.codigoTipoDocumentoIdentidad <= 0)
                    throw new ValidationCustomException(Constante.EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND);
                var idTipoDocumentoIdentidad =
                    await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_DOCUMENTO_IDENTIDAD, request.codigoTipoDocumentoIdentidad);
                if (idTipoDocumentoIdentidad <= 0)
                    throw new NotFoundCustomException(Constante.EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND);
                request.idTipoDocumentoIdentidad = idTipoDocumentoIdentidad;

                if (!request.codigoEstadoCivil.HasValue || request.codigoEstadoCivil <= 0)
                    request.idEstadoCivil = null;
                if (request.codigoEstadoCivil.HasValue && request.codigoEstadoCivil > 0)
                {
                    var idEstadoCivil = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.ESTADO_CIVIL, request.codigoEstadoCivil.Value);
                    if (idEstadoCivil <= 0)
                        throw new NotFoundCustomException(Constante.EX_ESTADO_CIVIL_NOTFOUND);
                    request.idEstadoCivil = idEstadoCivil;
                }


                var persona = await personaDao.GetPersonaPorDocumentoIdentidad(request.idTipoDocumentoIdentidad, request.numeroDocumentoIdentidad);
                if (persona == null) return await personaDao.Crear(request);
                request.idPersona = persona.idPersona;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await personaDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(PersonaReplica request)
        {
            try
            {
                IPersonaDAO personaDao = new PersonaDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.numeroDocumentoIdentidad))
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);

                if (request.codigoTipoDocumentoIdentidad <= 0)
                    throw new ValidationCustomException(Constante.EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND);
                var idTipoDocumentoIdentidad =
                    await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_DOCUMENTO_IDENTIDAD, request.codigoTipoDocumentoIdentidad);
                if (idTipoDocumentoIdentidad <= 0)
                    throw new NotFoundCustomException(Constante.EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND);
                request.idTipoDocumentoIdentidad = idTipoDocumentoIdentidad;

                var persona = await personaDao.GetPersonaPorDocumentoIdentidad(request.idTipoDocumentoIdentidad, request.numeroDocumentoIdentidad);
                if (persona == null)
                    return 1;
                request.idPersona = persona.idPersona;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await personaDao.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}