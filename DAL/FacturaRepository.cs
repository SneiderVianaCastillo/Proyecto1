using System;
using System.Collections.Generic;

using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL
{
    class FacturaRepository
    {
        private readonly OracleConnection _connection;
        private readonly List<Cliente> clientes = new List<Cliente>();
        public FacturaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

    }
}
