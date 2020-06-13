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
                if (repositorio.BuscarFactura(factura.Factura_id) == null)
                {
                    repositorio.Guardar(factura);
                    return $"Se guardaron los datos de la factura {factura.Factura_id}  satisfactoriamente";
                }
                return $"La factura ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }

        public class BusquedaFacturaRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Factura factura { get; set; }
        }
        public BusquedaFacturaRespuesta BuscarxFactura(string factu)
        {
            BusquedaFacturaRespuesta respuesta = new BusquedaFacturaRespuesta();
            try
            {

                conexion.Open();
                respuesta.factura = repositorio.BuscarFactura(factu);
                conexion.Close();
                respuesta.Mensaje = (respuesta.factura != null) ? "Se encontró la factura" : "La factura buscada no existe";
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
