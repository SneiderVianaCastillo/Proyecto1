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
                command.CommandText = "PKG_DETALLEFACTURA.SP_INSERTAR_DETALLEFACTURA";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("DetalleFac_id", OracleDbType.Varchar2).Value = detalleFactura.DetalleFac_id;
                command.Parameters.Add("Producto_id", OracleDbType.Varchar2).Value = detalleFactura.productos.Productos_id;
                command.Parameters.Add("Nombre", OracleDbType.Varchar2).Value = detalleFactura.productos.Nombre;
                command.Parameters.Add("Tipo", OracleDbType.Varchar2).Value = detalleFactura.productos.Tipo;
                command.Parameters.Add("Precio_venta", OracleDbType.Varchar2).Value = detalleFactura.productos.Precio_venta;
                command.Parameters.Add("Cantidad", OracleDbType.Varchar2).Value = detalleFactura.Cantidad;
                command.Parameters.Add("Total", OracleDbType.Varchar2).Value = detalleFactura.Total;
                command.Parameters.Add("Factura_id", OracleDbType.Varchar2).Value = detalleFactura.CodigoFactura;
                command.ExecuteNonQuery();

            }
        }

        private DetalleFactura DataReaderMapearToDetalle(OracleDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            DetalleFactura detalle = new DetalleFactura();
            detalle.DetalleFac_id = dataReader.GetString(0);
            detalle.productos.Productos_id = dataReader.GetString(1);
            detalle.productos.Nombre = dataReader.GetString(2);
            detalle.productos.Tipo= dataReader.GetString(3);
            detalle.productos.Precio_venta = dataReader.GetDecimal(4);
            detalle.Cantidad = dataReader.GetInt32(5);
            detalle.Total = dataReader.GetDecimal(6);
            detalle.CodigoFactura = dataReader.GetString(7);
            return detalle;

        }
        public DetalleFactura BuscarDetalle(string detalle_id)
        {
            OracleDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select DetalleFac_id,Producto_id,Nombre,Tipo,Precio_venta,Cantidad,Total,Factura_id from DetalleFactura  where DetalleFac_id=:DetalleFac_id";
                command.Parameters.Add("DetalleFac_id", OracleDbType.Varchar2).Value = detalle_id;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                DetalleFactura detalle = DataReaderMapearToDetalle(dataReader);
                return detalle;
            }
        }

        public IList<DetalleFactura> Consultar()
        {
            using (var comando = _connection.CreateCommand())
            {
                comando.CommandText = "PKG_DETALLEFACTURA.SP_CONSULTAR_DETALLEFACTURA";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("CURSORMEMORIA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                using (var reader = comando.ExecuteReader())
                {
                    detalles.Clear();
                    while (reader.Read())
                    {
                        DetalleFactura detalle = new DetalleFactura();
                        detalle = DataReaderMapearToDetalle(reader);
                        detalles.Add(detalle);
                    }
                }
            }
            return detalles;
        }

    }

}
