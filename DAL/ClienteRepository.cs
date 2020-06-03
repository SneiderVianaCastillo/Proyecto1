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
    public class ClienteRepository
    {
        private readonly OracleConnection _connection;
        private readonly List<Cliente> clientes = new List<Cliente>();
        public ClienteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        //
        public void Guardar(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "PKG_INSERTAR.INSERTAR_CLIENTE";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("Cliente_id", OracleDbType.Varchar2).Value = cliente.Identificacion;
                command.Parameters.Add("PrimerNombre", OracleDbType.Varchar2).Value = cliente.PrimerNombre;
                command.Parameters.Add("SegundoNombre", OracleDbType.Varchar2).Value = cliente.SegundoNombre;
                command.Parameters.Add("PrimerApellido", OracleDbType.Varchar2).Value = cliente.PrimerApellido;
                command.Parameters.Add("SegundoApellido", OracleDbType.Varchar2).Value = cliente.SegundoApellido;
                command.Parameters.Add("Barrio", OracleDbType.Varchar2).Value = cliente.Barrio;
                command.Parameters.Add("Ciudad", OracleDbType.Varchar2).Value = cliente.Ciudad;
                command.Parameters.Add("Comuna", OracleDbType.Varchar2).Value = cliente.Comuna;
                command.Parameters.Add("N_Casa", OracleDbType.Varchar2).Value = cliente.N_Casa;
                command.Parameters.Add("Telefono", OracleDbType.Varchar2).Value = cliente.Telefono;
                command.Parameters.Add("Email", OracleDbType.Varchar2).Value = cliente.Email;


                command.ExecuteNonQuery();
                
            }
        }

        public Cliente BuscarPorIdentificacion(string cliente_id)
        {
            OracleDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select Cliente_id,PrimerNombre,SegundoNombre, PrimerApellido, SegundoApellido,Barrio,Ciudad,Comuna,N_Casa,Telefono,Email from cliente where Cliente_id=:Cliente_id";
                command.Parameters.Add("Cliente_id", OracleDbType.Varchar2).Value = cliente_id;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                Cliente persona = DataReaderMapearToClientes(dataReader);
                return persona;
            }
        }
        private Cliente DataReaderMapearToClientes(OracleDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Cliente persona = new Cliente();
            persona.Identificacion = dataReader.GetString(0);
            persona.PrimerNombre = dataReader.GetString(1);
            persona.SegundoNombre = dataReader.GetString(2);
            persona.PrimerApellido = dataReader.GetString(3);
            persona.SegundoApellido = dataReader.GetString(4);
            persona.Barrio = dataReader.GetString(5);
            persona.Ciudad = dataReader.GetString(6);
            persona.Comuna = dataReader.GetString(7);
            persona.N_Casa = dataReader.GetString(8);
            persona.Telefono = dataReader.GetString(9);
            persona.Email = dataReader.GetString(10);

            return persona;

        }
        public IList<Cliente> Consultar()
        {
            using (var comando = _connection.CreateCommand())
            {
                comando.CommandText = "PKG_CONSULTAR.CONSULTAR_CLIENTE";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("CURSORMEMORIA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                using (var reader = comando.ExecuteReader())
                {
                    clientes.Clear();
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente = DataReaderMapearToClientes(reader);
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }
        public int Eliminar(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from cliente where Cliente_id=:Identificacion";
                command.Parameters.Add("cliente_id", OracleDbType.Varchar2).Value = cliente.Identificacion;
                var filas = command.ExecuteNonQuery();
                return filas;
            }
        }

        public int Modificar(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update cliente set Cliente_id=:Identificacion,PrimerNombre=:PrimerNombre,SegundoNombre=:SegundoNombre, 
                PrimerApellido=:PrimerApellido, SegundoApellido=:SegundoApellido,Barrio=:Barrio,Ciudad=:Ciudad,
                Comuna=:Comuna,N_Casa=:N_Casa,Telefono=:Telefono,Email=:Email
                                        where Cliente_id=:Identificacion";

                command.Parameters.Add("Cliente_id", OracleDbType.Varchar2).Value = cliente.Identificacion;
                command.Parameters.Add("PrimerNombre", OracleDbType.Varchar2).Value = cliente.PrimerNombre;
                command.Parameters.Add("SegundoNombre", OracleDbType.Varchar2).Value = cliente.SegundoNombre;
                command.Parameters.Add("PrimerApellido", OracleDbType.Varchar2).Value = cliente.PrimerApellido;
                command.Parameters.Add("SegundoApellido", OracleDbType.Varchar2).Value = cliente.SegundoApellido;
                command.Parameters.Add("Barrio", OracleDbType.Varchar2).Value = cliente.Barrio;
                command.Parameters.Add("Ciudad", OracleDbType.Varchar2).Value = cliente.Ciudad;
                command.Parameters.Add("Comuna", OracleDbType.Varchar2).Value = cliente.Comuna;
                command.Parameters.Add("N_Casa", OracleDbType.Varchar2).Value = cliente.N_Casa;
                command.Parameters.Add("Telefono", OracleDbType.Varchar2).Value = cliente.Telefono;
                command.Parameters.Add("Email", OracleDbType.Varchar2).Value = cliente.Email;


                OracleTransaction transaction = _connection.BeginTransaction();
                var filas = command.ExecuteNonQuery();
                transaction.Commit();
                return filas;
            }


        }



    }
    }
