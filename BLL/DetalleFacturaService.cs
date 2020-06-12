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
    }
}
