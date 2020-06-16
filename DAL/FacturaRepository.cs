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
   public  class FacturaRepository
    {
        private readonly OracleConnection _connection;
        private readonly List<Factura> facturas = new List<Factura>();
        public FacturaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Factura factura)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "PKG_FACTURA.SP_INSERTAR_FACTURA";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("Factura_id", OracleDbType.Varchar2).Value = factura.Factura_id;
                command.Parameters.Add("Totales", OracleDbType.Varchar2).Value = factura.Totales;
                command.Parameters.Add("Fecha", OracleDbType.Date).Value = factura.Fecha;
                command.Parameters.Add("Cliente_id", OracleDbType.Varchar2).Value = factura.cliente.Identificacion;
                command.Parameters.Add("FormaDePago", OracleDbType.Varchar2).Value = factura.FormaPago;
                command.ExecuteNonQuery();

            }
        }

        public Factura BuscarFactura(string factu)
        {
            OracleDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select Factura_id,Totales,Fecha,Cliente_id,FormaDePago from Factura  where Factura_id=:Factura_id";
                command.Parameters.Add("Factura_id", OracleDbType.Varchar2).Value = factu;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                Factura factura = DataReaderMapearToFactura(dataReader);
                return factura;
            }
        }

        private Factura DataReaderMapearToFactura(OracleDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Factura factura = new Factura();
            factura.Factura_id = dataReader.GetString(0);
            factura.Totales = dataReader.GetDecimal(1);
            factura.Fecha = dataReader.GetDateTime(2);
            factura.cliente.Identificacion = dataReader.GetString(3);
            factura.FormaPago= dataReader.GetString(4);

            return factura;

        }
        public IList<Factura> Consultar()
        {
            using (var comando = _connection.CreateCommand())
            {
                comando.CommandText = "PKG_FACTURA.CONSULTAR_FACTURA";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("CURSORMEMORIA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                using (var reader = comando.ExecuteReader())
                {
                    facturas.Clear();
                    while (reader.Read())
                    {
                        Factura factura = new Factura();
                        factura = DataReaderMapearToFactura(reader);
                        facturas.Add(factura);
                    }
                }
            }
            return facturas;
        }

    }
}
