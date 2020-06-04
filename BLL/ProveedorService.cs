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
    public class ProveedorService
    {
        private readonly ConnectionManager conexion;
        private readonly ProveedorRepository repositorio;
        public ProveedorService(string connectionString, string providerName)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ProveedorRepository(conexion);
        }

        public string Guardar(Proveedor proveedor )
        {

            try
            {
                conexion.Open();

                if (repositorio.BuscarPorRut(proveedor.Rut) == null)
                {
                    repositorio.Guardar(proveedor);
                    return $"Se guardaron los datos de {proveedor.NombreComercial}  satisfactoriamente";
                }
                return $"La Empresa ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }

        public class BusquedaProveedorRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Proveedor proveedor  { get; set; }
        }
        public BusquedaProveedorRespuesta BuscarxRut(string rut)
        {
            BusquedaProveedorRespuesta respuesta = new BusquedaProveedorRespuesta();
            try
            {

                conexion.Open();
                respuesta.proveedor = repositorio.BuscarPorRut(rut);
                conexion.Close();
                respuesta.Mensaje = (respuesta.proveedor!= null) ? "Se encontró el Proveedor" : "El Proveedor buscado no existe";
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

        public class ConsultaProveedorRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public IList<Proveedor> proveedors { get; set; }
        }

        public ConsultaProveedorRespuesta Consultar()
        {
            ConsultaProveedorRespuesta respuesta = new ConsultaProveedorRespuesta();
            try
            {

                conexion.Open();
                respuesta.proveedors = repositorio.Consultar();
                conexion.Close();
                if (respuesta.proveedors.Count > 0)
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

        public string Modificar(Proveedor proveedorNuevo)
        {
            try
            {
                conexion.Open();
                var proveedorVieja = repositorio.BuscarPorRut(proveedorNuevo.Rut);
                if (proveedorVieja != null)
                {
                    repositorio.Modificar(proveedorNuevo);
                    conexion.Close();
                    return ($"El Proveedor {proveedorNuevo.NombreComercial} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {proveedorNuevo.Rut} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }

        public string Eliminar(string rut)
        {
            try
            {
                conexion.Open();
                var proveedor = repositorio.BuscarPorRut(rut);
                if (proveedor != null)
                {
                    repositorio.Eliminar(proveedor);
                    conexion.Close();
                    return ($"El Proveedor {proveedor.NombreComercial} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {rut} no se encuentra registrada.");
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
