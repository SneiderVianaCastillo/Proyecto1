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
    public class ClienteService
    {
        private readonly ConnectionManager conexion;
        private readonly ClienteRepository repositorio;
        public ClienteService(string connectionString, string providerName)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ClienteRepository(conexion);
        }



        public string Guardar(Cliente cliente)
        {
            Email email = new Email();
            string mensajeEmail = string.Empty;
            try
            {

                conexion.Open();


                if (repositorio.BuscarPorIdentificacion(cliente.Identificacion) == null)
                {
                    repositorio.Guardar(cliente);
                    mensajeEmail = email.EnviarEmail(cliente);
                    return $"Se guardaron los datos de {cliente.PrimerNombre} datos satisfactoriamente" + mensajeEmail;
                }
                return $"La persona ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }

        public class ConsultaClienteRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public IList<Cliente> clientes { get; set; }
        }

        public ConsultaClienteRespuesta Consultar()
        {
            ConsultaClienteRespuesta respuesta = new ConsultaClienteRespuesta();
            try
            {

                conexion.Open();
                respuesta.clientes = repositorio.Consultar();
                conexion.Close();
                if (respuesta.clientes.Count > 0)
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

        public string Eliminar(string cliente_id)
        {
            try
            {
                conexion.Open();
                var cliente = repositorio.BuscarPorIdentificacion(cliente_id);
                if (cliente != null)
                {
                    repositorio.Eliminar(cliente);
                    conexion.Close();
                    return ($"El Cliente {cliente.PrimerNombre} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {cliente_id} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public class BusquedaClienteRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Cliente cliente { get; set; }
        }

        public BusquedaClienteRespuesta BuscarxIdentificacion(string cliente_id)
        {
            BusquedaClienteRespuesta respuesta = new BusquedaClienteRespuesta();
            try
            {

                conexion.Open();
                respuesta.cliente = repositorio.BuscarPorIdentificacion(cliente_id);
                conexion.Close();
                respuesta.Mensaje = (respuesta.cliente != null) ? "Se encontró el cliente buscado" : "El cliente buscado no existe";
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

        public string Modificar(Cliente clienteNuevo)
        {
            try
            {
                conexion.Open();
                var clienteVieja = repositorio.BuscarPorIdentificacion(clienteNuevo.Identificacion);
                if (clienteVieja != null)
                {
                    repositorio.Modificar(clienteNuevo);
                    conexion.Close();
                    return ($"El Cliente {clienteNuevo.PrimerNombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {clienteNuevo.Identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }

        public string GenerarClientePdf(List<Cliente> clientes, string filename)
        {
            PDF documentoClientePdf = new PDF();
            try
            {
                documentoClientePdf.GuardarClientePdf(clientes, filename);
                return "Se genró el Documento satisfactoriamente";
            }
            catch (Exception e)
            {

                return "Error al crear docuemnto" + e.Message;
            }
        }

        public class Respuesta
        {
            public IList<Cliente>   clientes { get; set; }
            public string Mensaje { get; set; }
            public bool IsError { get; set; }
        }
    }
}
