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
    public class TrabajadorRepository
    {
        private readonly OracleConnection _connection;
        private readonly List<Trabajador> trabajadores = new List<Trabajador>();
        public TrabajadorRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
    
        public void Guardar(Trabajador trabajador)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "PKG_TRABAJADOR.SP_INSERTAR_TRABAJADOR";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("Trabajador_id", OracleDbType.Varchar2).Value = trabajador.Identificacion;
                command.Parameters.Add("PrimerNombre", OracleDbType.Varchar2).Value = trabajador.PrimerNombre;
                command.Parameters.Add("SegundoNombre", OracleDbType.Varchar2).Value = trabajador.SegundoNombre;
                command.Parameters.Add("PrimerApellido", OracleDbType.Varchar2).Value = trabajador.PrimerApellido;
                command.Parameters.Add("SegundoApellido", OracleDbType.Varchar2).Value = trabajador.SegundoApellido;
                command.Parameters.Add("Telefono", OracleDbType.Varchar2).Value = trabajador.Telefono;
                command.Parameters.Add("Cargo", OracleDbType.Varchar2).Value = trabajador.Cargo;
                command.Parameters.Add("Barrio", OracleDbType.Varchar2).Value = trabajador.Barrio;
                command.Parameters.Add("Ciudad", OracleDbType.Varchar2).Value = trabajador.Ciudad;
                command.Parameters.Add("Comuna", OracleDbType.Varchar2).Value = trabajador.Comuna;
                command.Parameters.Add("N_Casa", OracleDbType.Varchar2).Value = trabajador.N_Casa;
                command.Parameters.Add("Email", OracleDbType.Varchar2).Value = trabajador.Email;


                command.ExecuteNonQuery();

            }


        }

        private Trabajador DataReaderMapearToTrabajador(OracleDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Trabajador trabajador = new Trabajador();
            trabajador.Identificacion = dataReader.GetString(0);
            trabajador.PrimerNombre = dataReader.GetString(1);
            trabajador.SegundoNombre = dataReader.GetString(2);
            trabajador.PrimerApellido = dataReader.GetString(3);
            trabajador.SegundoApellido = dataReader.GetString(4);
            trabajador.Telefono = dataReader.GetString(5);
            trabajador.Cargo= dataReader.GetString(6);
            trabajador.Barrio = dataReader.GetString(7);
            trabajador.Ciudad = dataReader.GetString(8);
            trabajador.Comuna = dataReader.GetString(9);
            trabajador.N_Casa = dataReader.GetString(10);
            trabajador.Email = dataReader.GetString(11);

            return trabajador;

        }

        public Trabajador BuscarPorIdentificacionTrab(string trabajador_id)
        {
            OracleDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select Trabajador_id,PrimerNombre,SegundoNombre, PrimerApellido, SegundoApellido,Telefono,Cargo,Barrio,Ciudad,Comuna,N_Casa,Email from Trabajador where Trabajador_id=:Trabajador_id";
                command.Parameters.Add("Trabajador_id", OracleDbType.Varchar2).Value = trabajador_id;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                Trabajador trabajador = DataReaderMapearToTrabajador(dataReader);
                return trabajador;
            }
        }

        public IList<Trabajador> Consultar()
        {
            using (var comando = _connection.CreateCommand())
            {
                comando.CommandText = "PKG_TRABAJADOR.SP_CONSULTAR_TRABAJADOR";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("CURSORMEMORIA1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                using (var reader = comando.ExecuteReader())
                {
                    trabajadores.Clear();
                    while (reader.Read())
                    {
                        Trabajador trabajador = new Trabajador();
                        trabajador = DataReaderMapearToTrabajador(reader);
                        trabajadores.Add(trabajador);
                    }
                }
            }
            return trabajadores;
        }
        public int Modificar(Trabajador trabajador)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PKG_TRABAJADOR.SP_MODIFICAR_TRABAJADOR";
                command.Parameters.Add("@xTrabajador_id", OracleDbType.Varchar2).Value = trabajador.Identificacion;
                command.Parameters.Add("@xPrimerNombre", OracleDbType.Varchar2).Value = trabajador.PrimerNombre;
                command.Parameters.Add("@xSegundoNombre", OracleDbType.Varchar2).Value = trabajador.SegundoNombre;
                command.Parameters.Add("@xPrimerApellido", OracleDbType.Varchar2).Value = trabajador.PrimerApellido;
                command.Parameters.Add("@xSegundoApellido", OracleDbType.Varchar2).Value = trabajador.SegundoApellido;
                command.Parameters.Add("@xTelefono", OracleDbType.Varchar2).Value = trabajador.Telefono;
                command.Parameters.Add("@xCargo", OracleDbType.Varchar2).Value = trabajador.Cargo;
                command.Parameters.Add("@xBarrio", OracleDbType.Varchar2).Value = trabajador.Barrio;
                command.Parameters.Add("@xCiudad", OracleDbType.Varchar2).Value = trabajador.Ciudad;
                command.Parameters.Add("@xComuna", OracleDbType.Varchar2).Value = trabajador.Comuna;
                command.Parameters.Add("@xN_Casa", OracleDbType.Varchar2).Value = trabajador.N_Casa;
                command.Parameters.Add("@xEmail", OracleDbType.Varchar2).Value = trabajador.Email;


                OracleTransaction transaction = _connection.BeginTransaction();
                var filas = command.ExecuteNonQuery();
                transaction.Commit();
                return filas;
            }


        }

        public int Eliminar(Trabajador trabajador)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PKG_TRABAJADOR.SP_ELIMINAR_TRABAJADOR";
                command.Parameters.Add("@cliente_id", OracleDbType.Varchar2).Value = trabajador.Identificacion;
                var filas = command.ExecuteNonQuery();
                return filas;
            }
        }
    }
}
