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
    public class ProveedorRepository
    {
        private readonly OracleConnection _connection;
        private readonly List<Proveedor> clientes = new List<Proveedor>();
        public ProveedorRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Proveedor proveedor)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "PKG_PROVEEDOR.SP_INSERTAR_PROVEEDOR";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("Rut", OracleDbType.Varchar2).Value = proveedor.Rut;
                command.Parameters.Add("Nombre_Comercial", OracleDbType.Varchar2).Value = proveedor.NombreComercial;
                command.Parameters.Add("Telefono", OracleDbType.Varchar2).Value = proveedor.Telefono;
                command.ExecuteNonQuery();

            }
        }

        private Proveedor DataReaderMapearToProveedor(OracleDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Proveedor proveedor = new Proveedor();
            proveedor.Rut = dataReader.GetString(0);
            proveedor.NombreComercial = dataReader.GetString(1);
            proveedor.Telefono = dataReader.GetString(2);

            return proveedor;

        }
        public Proveedor BuscarPorRut(string Rut)
        {
            OracleDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select Rut,Nombre_Comercial,Telefono from Proveedor  where Rut=:Rut";
                command.Parameters.Add("Rut", OracleDbType.Varchar2).Value = Rut;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                Proveedor proveedor = DataReaderMapearToProveedor(dataReader);
                return proveedor;
            }
        }

        public IList<Proveedor> Consultar()
        {
            using (var comando = _connection.CreateCommand())
            {
                comando.CommandText = "PKG_PROVEEDOR.SP_CONSULTAR_PROVEEDOR";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("CURSORMEMORIA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                using (var reader = comando.ExecuteReader())
                {
                    clientes.Clear();
                    while (reader.Read())
                    {
                        Proveedor proveedor = new Proveedor();
                        proveedor = DataReaderMapearToProveedor(reader);
                        clientes.Add(proveedor);
                    }
                }
            }
            return clientes;
        }

        public int Modificar(Proveedor proveedor)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PKG_PROVEEDOR.SP_MODIFICAR_PROVEEDOR";
                command.Parameters.Add("@xRut", OracleDbType.Varchar2).Value = proveedor.Rut;
                command.Parameters.Add("@xNombre_Comercial", OracleDbType.Varchar2).Value = proveedor.NombreComercial;
                command.Parameters.Add("@xSegundoNombre", OracleDbType.Varchar2).Value = proveedor.Telefono;


                OracleTransaction transaction = _connection.BeginTransaction();
                var filas = command.ExecuteNonQuery();
                transaction.Commit();
                return filas;
            }
        }
        public int Eliminar(Proveedor proveedor)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PKG_PROVEEDOR.SP_ELIMINAR_PROVEEDOR";
                command.Parameters.Add("Rut", OracleDbType.Varchar2).Value = proveedor.Rut;
                var filas = command.ExecuteNonQuery();
                return filas;
            }
        }
    }
}
