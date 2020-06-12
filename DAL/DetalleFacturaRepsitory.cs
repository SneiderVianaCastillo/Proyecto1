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
    public class DetalleFacturaRepsitory
    {
        private readonly OracleConnection _connection;
        private readonly List<DetalleFactura> detalles = new List<DetalleFactura>();

        public DetalleFacturaRepsitory(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(DetalleFactura detalleFactura)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "PKG_INSERTAR_DETALLEFACTURA.INSERTAR_DETALLEFACTURA";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("DetalleFac_id", OracleDbType.Varchar2).Value = detalleFactura.DetalleFac_id;
                command.Parameters.Add("Cantidad", OracleDbType.Varchar2).Value = detalleFactura.Cantidad;
                command.Parameters.Add("Costo", OracleDbType.Varchar2).Value = detalleFactura.Total;
                command.Parameters.Add("Factura_id", OracleDbType.Varchar2).Value = detalleFactura.CodigoFactura;
                command.Parameters.Add("Producto_id", OracleDbType.Varchar2).Value = detalleFactura.productos.Productos_id;
                command.ExecuteNonQuery();

            }
        }
    }

}
