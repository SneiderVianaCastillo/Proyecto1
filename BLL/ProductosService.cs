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
   public class ProductosService
    {
        private readonly ConnectionManager conexion;
        private readonly ProductosRepository repositorio;
        public ProductosService(string connectionString, string providerName)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ProductosRepository(conexion);
        }

        public string Guardar(Productos productos )
        {

            try
            {
                conexion.Open();

                if (repositorio.BuscarCodigo(productos.Productos_id) == null)
                {
                    repositorio.Guardar(productos);
                    return $"Se guardaron los datos de {productos.Nombre}  satisfactoriamente";
                }
                return $"El producto ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }

        public class BusquedaProductosRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Productos productos { get; set; }
        }
        public BusquedaProductosRespuesta BuscarxCodigo(string rut)
        {
            BusquedaProductosRespuesta respuesta = new BusquedaProductosRespuesta();
            try
            {

                conexion.Open();
                respuesta.productos = repositorio.BuscarCodigo(rut);
                conexion.Close();
                respuesta.Mensaje = (respuesta.productos != null) ? "Se encontró el Produco" : "El Producto buscado no existe";
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

        public class ConsultaProductosRespuesta
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public IList<Productos> productos { get; set; }
        }

        public ConsultaProductosRespuesta Consultar()
        {
            ConsultaProductosRespuesta respuesta = new ConsultaProductosRespuesta();
            try
            {

                conexion.Open();
                respuesta.productos = repositorio.Consultar();
                conexion.Close();
                respuesta.Error = false;
                if (respuesta.productos.Count > 0)
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

  
        public class Respuesta
        {
            public IList<Productos> Productos { get; set; }
            public string Mensaje { get; set; }
            public bool IsError { get; set; }
        }

        public string ModificarTodos(Productos productosNuevo)
        {
            try
            {
                conexion.Open();
                var proveedorVieja = repositorio.BuscarCodigo(productosNuevo.Productos_id);
                if (proveedorVieja != null)
                {
                    repositorio.ModificarTodos(productosNuevo);
                    conexion.Close();
                    return ($"El Proveedor {productosNuevo.Nombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {productosNuevo.Productos_id} no se encuentra registrada.");
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
                var productos = repositorio.BuscarCodigo(rut);
                if (productos != null)
                {
                    repositorio.Eliminar(productos);
                    conexion.Close();
                    return ($"El Producto {productos.Nombre} se ha eliminado satisfactoriamente.");
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
