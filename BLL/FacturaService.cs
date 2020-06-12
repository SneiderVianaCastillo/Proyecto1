using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using Infraestructura;
using System.Configuration;
using System.Net.Mail;

namespace BLL
{
   public class FacturaService
    {
        private readonly ConnectionManager conexion;
        private readonly FacturaRepository repositorio;
        public FacturaService(string connectionString, string providerName)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new FacturaRepository(conexion);
        }

        public string Guardar(Factura factura )
        {
            try
            {
                conexion.Open();
                repositorio.Guardar(factura);
                return $"Se guardaron los datos de {factura.Factura_id}  satisfactoriamente";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }


        public class ConsultaFcturaRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public IList<Factura> factura { get; set; }
        }

        public ConsultaFcturaRespuesta Consultar()
        {
            ConsultaFcturaRespuesta respuesta = new ConsultaFcturaRespuesta  ();
            try
            {

                conexion.Open();
                respuesta.factura = repositorio.Consultar();
                conexion.Close();
                respuesta.Error = false;
                if (respuesta.factura.Count > 0)
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
