using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Configuration;
using Infraestructura;
using System.Net.Mail;

namespace BLL
{
    public class TrabajadorService
    {
        private readonly ConnectionManager conexion;
        private readonly TrabajadorRepository repositorio;
        public TrabajadorService(string connectionString, string providerName)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new TrabajadorRepository(conexion);
        }

        public string Guardar(Trabajador trabajador)
        {
            Email email = new Email();
            string mensajeEmail = string.Empty;
            try
            {

                conexion.Open();


                if (repositorio.BuscarPorIdentificacionTrab(trabajador.Trabajador_Id) == null)
                {
                    repositorio.Guardar(trabajador);
                    mensajeEmail = email.EnviarEmail(trabajador);
                    return $"Se guardaron los datos de {trabajador.PrimerNombre} datos satisfactoriamente" + mensajeEmail;
                }
                return $"El trabajador ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }

        public class BusquedaTrabajadorRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Trabajador trabajador { get; set; }
        }

        public BusquedaTrabajadorRespuesta BuscarxIdentificacionTrab(string trabajador_id)
        {
            BusquedaTrabajadorRespuesta respuesta = new BusquedaTrabajadorRespuesta();
            try
            {

                conexion.Open();
                respuesta.trabajador = repositorio.BuscarPorIdentificacionTrab(trabajador_id);
                conexion.Close();
                respuesta.Mensaje = (respuesta.trabajador != null) ? "Se encontró el trabajador buscado" : "El Trabajador  no existe";
                respuesta.Error = false;
                return respuesta;
            }
            catch (Exception e)
            {

                respuesta.Mensaje = $"Error de la Aplicacion: {e.Message}";
                respuesta.Error = true;
                return respuesta;
            }
            finally { conexion.Close(); }
        }

        public class ConsultaTrabajadorRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public IList<Trabajador> trabajadores { get; set; }
        }

        public ConsultaTrabajadorRespuesta Consultar()
        {
            ConsultaTrabajadorRespuesta respuesta = new ConsultaTrabajadorRespuesta();
            try
            {

                conexion.Open();
                respuesta.trabajadores = repositorio.Consultar();
                conexion.Close();
                if (respuesta.trabajadores.Count > 0)
                {
                    respuesta.Mensaje = "Se consultan los Datos";
                }
                else
                {
                    respuesta.Mensaje = "No hay datos para consultar";
                }
                respuesta.Error = false;
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Error de la Aplicacion: {e.Message}";
                respuesta.Error = true;
                return respuesta;
            }
            finally { conexion.Close(); }

        }

        public string Modificar(Trabajador trabajadorNuevo)
        {
            try
            {
                conexion.Open();
                var trabajadorVieja = repositorio.BuscarPorIdentificacionTrab(trabajadorNuevo.Trabajador_Id);
                if (trabajadorVieja != null)
                {
                    repositorio.Modificar(trabajadorNuevo);
                    conexion.Close();
                    return ($"El Trabajador {trabajadorNuevo.PrimerNombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {trabajadorNuevo.Trabajador_Id} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
    }
}
