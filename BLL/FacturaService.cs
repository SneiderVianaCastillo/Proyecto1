using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Configuration;
using Infraestructura;
using System.Net.Mail;
using System;

namespace BLL
{
   public class FacturaService
    {
        private readonly ConnectionManager conexion;
        private readonly ClienteRepository repositorio;
        public FacturaService(string connectionString, string providerName)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ClienteRepository(conexion);
        }

    }
}
