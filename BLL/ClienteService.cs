using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Configuration;

namespace BLL
{
    public class ClienteService
    {
        private readonly ConnectionManager conexion;
        private readonly ClienteRepository repositorio;
        public ClienteService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ClienteRepository(conexion);
        }
        public string Guardar(Cliente persona)
        {
            try
            {

                conexion.Open();


                if (repositorio.BuscarPorIdentificacion(persona.Cliente_id) == null)
                {
                    repositorio.Guardar(persona);
                    return $"Se guardaron los  de {persona.PrimerNombre}datos satisfactoriamente";
                }
                return $"La persona ya existe";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }
    }
}
