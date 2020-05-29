using System;
using System.Collections.Generic;

using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class ClienteRepository
    {
        private readonly OracleConnection _connection;
        private readonly List<Cliente> _personas = new List<Cliente>();
        public ClienteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public int Guardar(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Cliente (Cliente_id,PrimerNombre,SegundoNombre, PrimerApellido, SegundoApellido,Barrio,Ciudad,Comuna,N_Casa,Telefono) 
                                      values (:Identificacion,:Nombre,:Edad,:Sexo,:Pulsacion)";
                command.Parameters.Add("Cliente_id", OracleDbType.Varchar2).Value = cliente.Cliente_id;
                command.Parameters.Add("PrimerNombre", OracleDbType.Varchar2).Value = cliente.PrimerNombre;
                command.Parameters.Add("SegundoNombre", OracleDbType.Varchar2).Value = cliente.SegundoNombre;
                command.Parameters.Add("PrimerApellido", OracleDbType.Varchar2).Value = cliente.PrimerApellido;
                command.Parameters.Add("SegundoApellido", OracleDbType.Varchar2).Value = cliente.SegundoApellido;
                command.Parameters.Add("Barrio", OracleDbType.Varchar2).Value = cliente.Barrio;
                command.Parameters.Add("Ciudad", OracleDbType.Varchar2).Value = cliente.Ciudad;
                command.Parameters.Add("Comuna", OracleDbType.Varchar2).Value = cliente.Comuna;
                command.Parameters.Add("N_Casa", OracleDbType.Varchar2).Value = cliente.N_Casa;
                command.Parameters.Add("Telefono", OracleDbType.Varchar2).Value = cliente.Telefono;

                var filas = command.ExecuteNonQuery();
                return filas;
            }
        }

        public Cliente BuscarPorIdentificacion(string cliente_id)
        {
            OracleDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select Cliente_id,PrimerNombre,SegundoNombre, PrimerApellido, SegundoApellido,Barrio,Ciudad,Comuna,N_Casa,Telefono from cliente where Cliente_id=:Cliente_id";
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
            persona.Cliente_id = dataReader.GetString(0);
            persona.PrimerNombre = dataReader.GetString(1);
            persona.SegundoNombre = dataReader.GetString(2);
            persona.PrimerApellido = dataReader.GetString(3);
            persona.SegundoApellido = dataReader.GetString(4);
            persona.PrimerNombre = dataReader.GetString(5);
            persona.Barrio = dataReader.GetString(6);
            persona.Ciudad = dataReader.GetString(7);
            persona.Barrio = dataReader.GetString(8);
            persona.N_Casa = dataReader.GetString(9);
            persona.Telefono = dataReader.GetString(10);
            return persona;

        }
        public List<Cliente> Consultar()
        {
            OracleDataReader dataReader;
            List<Cliente> clientes = new List<Cliente>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from cliente ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Cliente cliente = DataReaderMapearToClientes(dataReader);
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }
    }
}
