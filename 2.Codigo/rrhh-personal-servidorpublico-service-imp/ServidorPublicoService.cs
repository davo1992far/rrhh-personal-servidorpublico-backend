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
    public class ServidorPublicoService : ServiceBase, IServidorPublicoService
    {
        public ServidorPublicoService(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        public async Task<ServidorPublicoReplica> GetServidorPublicoReplicaPorId(long idServidorPublico, bool todo, bool formacionAcademica)
        {
            if (idServidorPublico <= 0)
                throw new ValidationCustomException(Constante.EX_PARAMETROS_INCORRECTOS);

            IServidorPublicoDAO servidorPublicoDAO = new ServidorPublicoDAO(this.txtConnectionString);
            ServidorPublicoReplica servidorPublico = await servidorPublicoDAO.GetServidorPublicoReplicaPorId(idServidorPublico);
            if (servidorPublico == null)
                throw new NotFoundCustomException(Constante.EX_SERVIDOR_PUBLICO_NOT_FOUND);

            return servidorPublico;
        }

        public async Task<ServidorPublicoReplica> GetServidorPublicoReplicaPorCodigo(long codigoServidorPublico, bool todo = false, bool formacionAcademica = false)
        {
            if (codigoServidorPublico <= 0)
                throw new ValidationCustomException(Constante.EX_PARAMETROS_INCORRECTOS);

            IServidorPublicoDAO servidorPublicoDAO = new ServidorPublicoDAO(this.txtConnectionString);
            ServidorPublicoReplica servidorPublico = await servidorPublicoDAO.GetServidorPublicoReplicaPorCodigo(codigoServidorPublico);
            if (servidorPublico == null)
                throw new NotFoundCustomException(Constante.EX_SERVIDOR_PUBLICO_NOT_FOUND);

            IPersonaDAO personaDAO = new PersonaDAO(this.txtConnectionString);
            Persona persona = await personaDAO.GetPersonaPorId(servidorPublico.idPersona);
            if (persona == null)
                throw new NotFoundCustomException(Constante.EX_PERSONA_NOT_FOUND);

            ICatalogoItemDAO catalogoItemDAO = new CatalogoItemDAO(this.txtConnectionString);
            CatalogoItem catalogoItem = await catalogoItemDAO.GetCatalogoItemPorId((int) VariablesGlobales.TablaCatalogo.TIPO_DOCUMENTO_IDENTIDAD, persona.idTipoDocumentoIdentidad);
            servidorPublico.codigoTipoDocumentoIdentidad = catalogoItem.codigoCatalogoItem;
            servidorPublico.numeroDocumentoIdentidad = persona.numeroDocumentoIdentidad;
            servidorPublico.fechaConsultaReniec = persona.fechaConsultaReniec;
            servidorPublico.fechaNacimiento = persona.fechaNacimiento;

            return servidorPublico;
        }

        public async Task<ServidorPublicoTransaccionRequest> CrearServidorPublicoTransaccion(ServidorPublicoTransaccionRequest request)
        {
            try
            {
                ICatalogoItemDAO catalogoItemDAO = new CatalogoItemDAO(txtConnectionString);
                IPersonaDAO personaDAO = new PersonaDAO(txtConnectionString);
                IRegimenLaboralDAO regimenLaboralDAO = new RegimenLaboralDAO(txtConnectionString);

                if (request.codigoTipoDocumentoIdentidad <= 0)
                    throw new ValidationCustomException(Constante.EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND);
                TipoDocumentoIdentidad tipoDocumentoIdentidad = catalogoItemDAO.GetTipoDocumentoIdentidadByCodigo(request.codigoTipoDocumentoIdentidad).Result;
                if (tipoDocumentoIdentidad == null)
                    throw new NotFoundCustomException(Constante.EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND);

                if (string.IsNullOrEmpty(request.numeroDocumentoIdentidad))
                    throw new ValidationCustomException(Constante.EX_NUMERO_DOCUMENTO_IDENTIDAD_NOTFOUND);
                Persona persona = personaDAO.GetPersonaPorDocumentoIdentidad(tipoDocumentoIdentidad.idTipoDocumentoIdentidad, request.numeroDocumentoIdentidad).Result;
                if (persona == null)
                    throw new NotFoundCustomException(Constante.EX_PERSONA_NOT_FOUND);
                request.idPersona = persona.idPersona;

                if (request.codigoRegimenLaboral <= 0)
                    throw new ValidationCustomException(Constante.EX_REGIMEN_LABORAL_NOTFOUND);
                RegimenLaboral regimenLaboral = regimenLaboralDAO.GetRegimenLaboralPorCodigo(request.codigoRegimenLaboral).Result;
                if (regimenLaboral == null)
                    throw new NotFoundCustomException(Constante.EX_REGIMEN_LABORAL_NOTFOUND);
                request.idRegimenLaboral = regimenLaboral.idRegimenLaboral;

                if (request.codigoSituacionLaboral <= 0)
                    throw new ValidationCustomException(Constante.EX_SITUACION_LABORAL_NOTFOUND);
                SituacionLaboral situacionLaboral = catalogoItemDAO.GetSituacionLaboralByCodigo(request.codigoSituacionLaboral).Result;
                if (situacionLaboral == null)
                    throw new NotFoundCustomException(Constante.EX_SITUACION_LABORAL_NOTFOUND);
                request.idSituacionLaboral = situacionLaboral.idSituacionLaboral;

                if (request.codigoCondicionLaboral <= 0)
                    throw new ValidationCustomException(Constante.EX_CONDICION_LABORAL_NOTFOUND);
                CondicionLaboral condicionLaboral = catalogoItemDAO.GetCondicionLaboralByCodigo(request.codigoCondicionLaboral).Result;
                if (condicionLaboral == null)
                    throw new NotFoundCustomException(Constante.EX_CONDICION_LABORAL_NOTFOUND);
                request.idCondicionLaboral = condicionLaboral.idCondicionLaboral;


                if (request.codigoCategoriaRemunerativa.HasValue && request.codigoCategoriaRemunerativa > 0)
                {
                    ICategoriaRemunerativaDAO categoriaRemunerativaDao = new CategoriaRemunerativaDAO(txtConnectionString);
                    CategoriaRemunerativa categoriaRemunerativa = categoriaRemunerativaDao.GetCategoriaRemunerativaPorCodigo(request.codigoCategoriaRemunerativa.Value).Result;
                    if (categoriaRemunerativa == null)
                        throw new NotFoundCustomException(Constante.EX_CATEGORIA_REMUNERATIVA_NOTFOUND);
                    request.idCategoriaRemunerativa = categoriaRemunerativa.idCategoriaRemunerativa;
                }
                else
                {
                    request.idCategoriaRemunerativa = null;
                }

                if (!string.IsNullOrEmpty(request.codigoCentroTrabajo))
                {
                    ICentroTrabajoDAO centroTrabajoDao = new CentroTrabajoDAO(txtConnectionString);
                    CentroTrabajo centroTrabajo = await centroTrabajoDao.GetCentroTrabajoPorCodigo(request.codigoCentroTrabajo, request.anexoCentroTrabajo);
                    if (centroTrabajo == null)
                        throw new NotFoundCustomException(Constante.EX_CENTRO_TRABAJO_NOTFOUND);
                    request.idCentroTrabajo = centroTrabajo.idCentroTrabajo;
                }
                else
                {
                    request.idCentroTrabajo = null;
                }

                request.fechaCreacion = DateTime.Now;


                IServidorPublicoDAO servidorPublicoDAO = new ServidorPublicoDAO(txtConnectionString);

                //si el servidor publico no existe se crea
                ServidorPublico servidorPublicoOld = await servidorPublicoDAO.GetServidorPublicoReplicaPorCodigo(request.codigoServidorPublico);
                if (servidorPublicoOld == null)
                {
                    var idServidorPublico = await servidorPublicoDAO.CrearServidorPublicoTransaction(request);
                    if (idServidorPublico <= 0)
                        throw new CustomException(Constante.EX_SERVIDOR_PUBLICO_CREATE);
                    request.idServidorPublico = idServidorPublico;
                }
                else
                {
                    //si el servidor publico ya existe se actualizan sus datos
                    request.idServidorPublico = servidorPublicoOld.idServidorPublico;
                    request.fechaModificacion = DateTime.Now;
                    request.usuarioModificacion = request.usuarioCreacion;
                    await servidorPublicoDAO.ActualizarServidorPublicoTransaction(request);
                }

                var servidorPublicoNew = await servidorPublicoDAO.GetServidorPublicoReplicaPorId(request.idServidorPublico);
                request.codigoServidorPublico = servidorPublicoNew.codigoServidorPublico;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return request;
        }

        public async Task<int> Crear(ServidorPublicoReplica request)
        {
            try
            {
                ICatalogoItemDAO catalogoItemDAO = new CatalogoItemDAO(txtConnectionString);
                IPersonaDAO personaDAO = new PersonaDAO(txtConnectionString);
                IRegimenLaboralDAO regimenLaboralDAO = new RegimenLaboralDAO(txtConnectionString);
                IAfpDAO afpDAO = new AfpDAO(txtConnectionString);
                ICargoDAO cargoDAO = new CargoDAO(txtConnectionString);
                IJornadaLaboralDAO jornadaLaboralDAO = new JornadaLaboralDAO(txtConnectionString);
                IRegimenPensionarioDAO regimenPensionarioDao = new RegimenPensionarioDAO(txtConnectionString);

                if (request.codigoTipoDocumentoIdentidad <= 0)
                    throw new ValidationCustomException(Constante.EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND);
                TipoDocumentoIdentidad tipoDocumentoIdentidad = catalogoItemDAO.GetTipoDocumentoIdentidadByCodigo(request.codigoTipoDocumentoIdentidad).Result;
                if (tipoDocumentoIdentidad == null)
                    throw new NotFoundCustomException(Constante.EX_TIPO_DOCUMENTO_IDENTIDAD_NOTFOUND);

                if (string.IsNullOrEmpty(request.numeroDocumentoIdentidad))
                    throw new ValidationCustomException(Constante.EX_NUMERO_DOCUMENTO_IDENTIDAD_NOTFOUND);
                Persona persona = personaDAO.GetPersonaPorDocumentoIdentidad(tipoDocumentoIdentidad.idTipoDocumentoIdentidad, request.numeroDocumentoIdentidad).Result;
                if (persona == null)
                    throw new NotFoundCustomException(Constante.EX_PERSONA_NOT_FOUND);
                request.idPersona = persona.idPersona;

                if (request.codigoRegimenLaboral <= 0)
                    throw new ValidationCustomException(Constante.EX_REGIMEN_LABORAL_NOTFOUND);
                RegimenLaboral regimenLaboral = regimenLaboralDAO.GetRegimenLaboralPorCodigo(request.codigoRegimenLaboral).Result;
                if (regimenLaboral == null)
                    throw new NotFoundCustomException(Constante.EX_REGIMEN_LABORAL_NOTFOUND);
                request.idRegimenLaboral = regimenLaboral.idRegimenLaboral;

                if (request.codigoSituacionLaboral <= 0)
                    throw new ValidationCustomException(Constante.EX_SITUACION_LABORAL_NOTFOUND);
                SituacionLaboral situacionLaboral = catalogoItemDAO.GetSituacionLaboralByCodigo(request.codigoSituacionLaboral).Result;
                if (situacionLaboral == null)
                    throw new NotFoundCustomException(Constante.EX_SITUACION_LABORAL_NOTFOUND);
                request.idSituacionLaboral = situacionLaboral.idSituacionLaboral;

                if (request.codigoCondicionLaboral <= 0)
                    throw new ValidationCustomException(Constante.EX_CONDICION_LABORAL_NOTFOUND);
                CondicionLaboral condicionLaboral = catalogoItemDAO.GetCondicionLaboralByCodigo(request.codigoCondicionLaboral).Result;
                if (condicionLaboral == null)
                    throw new NotFoundCustomException(Constante.EX_CONDICION_LABORAL_NOTFOUND);
                request.idCondicionLaboral = condicionLaboral.idCondicionLaboral;

                if (string.IsNullOrEmpty(request.codigoAfp))
                    request.idAfp = null;
                if (!string.IsNullOrEmpty(request.codigoAfp))
                {
                    Afp afp = afpDAO.GetAfpPorCodigo(request.codigoAfp).Result;
                    if (afp == null)
                        throw new NotFoundCustomException(Constante.EX_AFP_NOTFOUND);
                    request.idAfp = afp.idAfp;
                }

                if (!request.codigoRegimenPensionario.HasValue || request.codigoRegimenPensionario <= 0)
                    request.idRegimenPensionario = null;
                if (request.codigoRegimenPensionario.HasValue && request.codigoRegimenPensionario > 0)
                {
                    var regimenPensionario = regimenPensionarioDao.GetRegimenPensionarioPorCodigo(request.codigoRegimenPensionario.Value).Result;
                    if (regimenPensionario == null)
                        throw new NotFoundCustomException(Constante.EX_REGIMEN_PENSIONARIO_NOTFOUND);
                    request.idRegimenPensionario = regimenPensionario.idRegimenPensionario;
                }

                if (!request.codigoCargo.HasValue || request.codigoCargo <= 0)
                    request.idCargo = null;
                if (request.codigoCargo.HasValue && request.codigoCargo > 0)
                {
                    Cargo cargo = cargoDAO.GetCargoPorCodigo(request.codigoCargo.Value).Result;
                    if (cargo == null)
                        throw new NotFoundCustomException(Constante.EX_CARGO_NOTFOUND);
                    request.idCargo = cargo.idCargo;
                }

                if (!request.codigoJornadaLaboral.HasValue || request.codigoJornadaLaboral <= 0)
                    request.idJornadaLaboral = null;
                if (request.codigoJornadaLaboral.HasValue && request.codigoJornadaLaboral > 0)
                {
                    JornadaLaboral jornadaLaboral = jornadaLaboralDAO.GetJornadaLaboralPorCodigo(request.codigoJornadaLaboral.Value).Result;
                    if (jornadaLaboral == null)
                        throw new NotFoundCustomException(Constante.EX_JORNADA_LABORAL_NOTFOUND);
                    request.idJornadaLaboral = jornadaLaboral.idJornadaLaboral;
                }

                if (!request.codigoTipoComisionAfp.HasValue || request.codigoTipoComisionAfp <= 0)
                    request.idTipoComisionAfp = null;
                if (request.codigoTipoComisionAfp.HasValue && request.codigoTipoComisionAfp > 0)
                {
                    var idTipoComisionAfp = await catalogoItemDAO.GetIdCatalogoItemPorCodigoCatalogo((int)VariablesGlobales.TablaCatalogo.TIPO_COMISION_AFP, request.codigoTipoComisionAfp.Value);
                    if (idTipoComisionAfp <=0)
                        throw new NotFoundCustomException(Constante.EX_TIPO_COMISION_NOTFOUND);
                    request.idTipoComisionAfp = idTipoComisionAfp;
                }

                if (request.codigoCategoriaRemunerativa.HasValue && request.codigoCategoriaRemunerativa > 0)
                {
                    ICategoriaRemunerativaDAO categoriaRemunerativaDao = new CategoriaRemunerativaDAO(txtConnectionString);
                    CategoriaRemunerativa categoriaRemunerativa = categoriaRemunerativaDao.GetCategoriaRemunerativaPorCodigo(request.codigoCategoriaRemunerativa.Value).Result;
                    if (categoriaRemunerativa == null)
                        throw new NotFoundCustomException(Constante.EX_CATEGORIA_REMUNERATIVA_NOTFOUND);
                    request.idCategoriaRemunerativa = categoriaRemunerativa.idCategoriaRemunerativa;
                }
                else
                {
                    request.idCategoriaRemunerativa = null;
                }

                if (!string.IsNullOrEmpty(request.codigoCentroTrabajo))
                {
                    ICentroTrabajoDAO centroTrabajoDao = new CentroTrabajoDAO(txtConnectionString);
                    CentroTrabajo centroTrabajo = await centroTrabajoDao.GetCentroTrabajoPorCodigo(request.codigoCentroTrabajo, request.anexoCentroTrabajo);
                    if (centroTrabajo == null)
                        throw new NotFoundCustomException(Constante.EX_CENTRO_TRABAJO_NOTFOUND);
                    request.idCentroTrabajo = centroTrabajo.idCentroTrabajo;
                }
                else
                {
                    request.idCentroTrabajo = null;
                }

                request.fechaCreacion = DateTime.Now;

                if (request.formacionesAcademicas != null)
                {
                    foreach (FormacionAcademica formacionAcademica in request.formacionesAcademicas)
                    {
                        if (formacionAcademica.idFormacionAcademica <= 0)
                        {
                            formacionAcademica.fechaCreacion = DateTime.Now;
                        }
                    }
                }

                IServidorPublicoDAO servidorPublicoDAO = new ServidorPublicoDAO(txtConnectionString);
                if (request.codigoServidorPublico <= 0)
                    throw new ValidationCustomException(Constante.EX_SERVIDOR_PUBLICO_NOT_FOUND);

                //si el servidor publico no existe se crea
                ServidorPublico servidorPublicoOld = await servidorPublicoDAO.GetServidorPublicoReplicaPorCodigo(request.codigoServidorPublico);
                if (servidorPublicoOld == null)
                {
                    var servidorPublico = await servidorPublicoDAO.CrearServidorPublico(request);
                    return servidorPublico.idServidorPublico <= 0 ? 0 : 1;
                }

                request.idServidorPublico = servidorPublicoOld.idServidorPublico;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await servidorPublicoDAO.ActualizarServidorPublico(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(ServidorPublicoReplica request)
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

        public async Task<int> Eliminar(ServidorPublicoReplica request)
        {
            try
            {
                IServidorPublicoDAO servidorPublicoDAO = new ServidorPublicoDAO(txtConnectionString);
                
                ServidorPublico servidorPublicoOld = await servidorPublicoDAO.GetServidorPublicoReplicaPorCodigo(request.codigoServidorPublico);
                if (servidorPublicoOld == null)
                    return 1;
                request.idServidorPublico = servidorPublicoOld.idServidorPublico;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await servidorPublicoDAO.DesactivarServidorPublico(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}