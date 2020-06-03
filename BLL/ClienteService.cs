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


                if (repositorio.BuscarPorIdentificacion(cliente.Cliente_id) == null)
                {
                    repositorio.Guardar(cliente);
                    mensajeEmail = email.EnviarEmail(cliente);
                    return $"Se guardaron los  de {cliente.PrimerNombre}datos satisfactoriamente" + mensajeEmail;
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
                respuesta.clientes = repositorio.Consultar2();
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

    }
}
