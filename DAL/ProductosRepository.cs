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
    public class ProductosRepository
    {
        private readonly OracleConnection _connection;
        private readonly List<Productos> productos = new List<Productos>();
        public ProductosRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Productos productos)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "PKG_INSERTAR_PRODUCTOS.INSERTAR_PRODUCTOS";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("Productos_id", OracleDbType.Varchar2).Value = productos.Productos_id;
                command.Parameters.Add("nombre", OracleDbType.Varchar2).Value = productos.Nombre;
                command.Parameters.Add("Descripcion", OracleDbType.Varchar2).Value = productos.Descripcion;
                command.Parameters.Add("precio_venta", OracleDbType.Varchar2).Value = productos.Precio_venta;
                command.Parameters.Add("precio_costo", OracleDbType.Varchar2).Value = productos.Precio_costo;
                command.Parameters.Add("Iva", OracleDbType.Varchar2).Value = productos.Iva;
                command.Parameters.Add("tipo", OracleDbType.Varchar2).Value = productos.Tipo;
                command.Parameters.Add("modelo", OracleDbType.Varchar2).Value = productos.Modelo;
                command.Parameters.Add("cantidad", OracleDbType.Varchar2).Value = productos.Cantidad;
                command.ExecuteNonQuery();

            }
        }

        private Productos DataReaderMapearToProductos(OracleDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Productos productos = new Productos();
            productos.Productos_id = dataReader.GetString(0);
            productos.Nombre = dataReader.GetString(1);
            productos.Descripcion = dataReader.GetString(2);
            productos.Precio_venta = Convert.ToDecimal(dataReader.GetString(3));
            productos.Precio_costo = Convert.ToDecimal(dataReader.GetString(4));
            productos.Iva = Convert.ToDecimal(dataReader.GetString(5));
            productos.Tipo = dataReader.GetString(6);
            productos.Modelo = dataReader.GetString(7);
            productos.Cantidad = Convert.ToInt32(dataReader.GetString(8));

            return productos;

        }
        public Productos BuscarCodigo(string Rut)
        {
            OracleDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select Productos_id,nombre,Descripcion,precio_venta,precio_costo,Iva,tipo,modelo,cantidad from Productos  where Productos_id=:Productos_id";
                command.Parameters.Add("Productos_id", OracleDbType.Varchar2).Value = Rut;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                Productos productos = DataReaderMapearToProductos(dataReader);
                return productos;
            }
        }

        public IList<Productos> Consultar()
        {
            using (var comando = _connection.CreateCommand())
            {
                comando.CommandText = "PKG_CONSULTAR_PRODUCTOS.CONSULTAR_PRODUCTOS";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("CURSORMEMORIA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                using (var reader = comando.ExecuteReader())
                {
                    productos.Clear();
                    while (reader.Read())
                    {
                        Productos producto = new Productos();
                        producto = DataReaderMapearToProductos(reader);
                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }

    }
}
