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
                command.CommandText = "PKG_PRODUCTOS.INSERTAR_PRODUCTOS";
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
                command.Parameters.Add("Existencia", OracleDbType.Varchar2).Value = productos.Existencia;
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
            productos.Precio_venta = dataReader.GetDecimal(3);
            productos.Precio_costo = dataReader.GetDecimal(4);
            productos.Iva = dataReader.GetDecimal(5);
            productos.Tipo = dataReader.GetString(6);
            productos.Modelo = dataReader.GetString(7);
            productos.Cantidad = dataReader.GetInt32(8);
            productos.Existencia = dataReader.GetInt32(9);
            return productos;

        }
        public Productos BuscarCodigo(string Rut)
        {
            OracleDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select Productos_id,nombre,Descripcion,precio_venta,precio_costo,Iva,tipo,modelo,cantidad,Existencia from Productos  where Productos_id=:Productos_id";
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
                comando.CommandText = "PKG_PRODUCTOS.SP_CONSULTAR_PRODUCTOS";
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

        public int ModificarTodos(Productos productos)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PKG_PRODUCTOS.SP_MODIFICAR_PRODUCTOS";
                command.Parameters.Add("@xProductos_id", OracleDbType.Varchar2).Value = productos.Productos_id;
                command.Parameters.Add("@xnombre", OracleDbType.Varchar2).Value = productos.Nombre;
                command.Parameters.Add("@xDescripcion", OracleDbType.Varchar2).Value = productos.Descripcion;
                command.Parameters.Add("@xprecio_venta", OracleDbType.Varchar2).Value = productos.Precio_venta;
                command.Parameters.Add("@xprecio_costo", OracleDbType.Varchar2).Value = productos.Precio_costo;
                command.Parameters.Add("@xIva", OracleDbType.Varchar2).Value = productos.Iva;
                command.Parameters.Add("@xtipo", OracleDbType.Varchar2).Value = productos.Tipo;
                command.Parameters.Add("@xmodelo", OracleDbType.Varchar2).Value = productos.Modelo;
                command.Parameters.Add("@xcantidad", OracleDbType.Varchar2).Value = productos.Cantidad;
                command.Parameters.Add("@xExistencia", OracleDbType.Varchar2).Value = productos.Existencia;


                OracleTransaction transaction = _connection.BeginTransaction();
                var filas = command.ExecuteNonQuery();
                transaction.Commit();
                return filas;
            }
        }

        public int Eliminar(Productos productos )
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PKG_PRODUCTOS.SP_ELIMINAR_PRODUCTOS";
                command.Parameters.Add("xProductos_id", OracleDbType.Varchar2).Value = productos.Productos_id;
                var filas = command.ExecuteNonQuery();
                return filas;
            }
        }

    }
}
