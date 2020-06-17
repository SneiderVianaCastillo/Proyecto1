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
    public class DetalleFacturaService
    {
        private readonly ConnectionManager conexion;
        private readonly DetalleFacturaRepsitory repositorio;
        public DetalleFacturaService(string connectionString, string providerName)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new DetalleFacturaRepsitory(conexion);
        }

        public string Guardar(DetalleFactura detalleFactura )
        {
            try
            {
                conexion.Open();
                repositorio.Guardar(detalleFactura);
                return $"Se guardaron los datos de {detalleFactura.DetalleFac_id}  satisfactoriamente";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }

        public class BusquedaDetalleFacturaRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public DetalleFactura detalle { get; set; }
        }
        public BusquedaDetalleFacturaRespuesta BuscarxDetalle(string factu)
        {
            BusquedaDetalleFacturaRespuesta respuesta = new BusquedaDetalleFacturaRespuesta();
            try
            {

                conexion.Open();
                respuesta.detalle = repositorio.BuscarDetalle(factu);
                conexion.Close();
                respuesta.Mensaje = (respuesta.detalle != null) ? "Se encontró los detalles" : "Los detalles buscados no existe";
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
        public class ConsultaDetalleFcturaRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public IList<DetalleFactura> detalle { get; set; }
        }

        public ConsultaDetalleFcturaRespuesta Consultar()
        {
            ConsultaDetalleFcturaRespuesta respuesta = new ConsultaDetalleFcturaRespuesta();
            try
            {

                conexion.Open();
                respuesta.detalle = repositorio.Consultar();
                conexion.Close();
                respuesta.Error = false;
                if (respuesta.detalle.Count > 0)
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


        public string GenerarDetallePdf(List<DetalleFactura> detalleFacturas, string filename, Factura factura)
        {
            PDF documentoClientePdf = new PDF();
            try
            {
                documentoClientePdf.GuardarDetallesPdf(detalleFacturas, filename,factura);
                return "Se genró el Documento satisfactoriamente";
            }
            catch (Exception e)
            {

                return "Error al crear docuemnto" + e.Message;
            }
        }
    }
}
