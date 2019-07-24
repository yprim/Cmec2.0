using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    /// <summary>
    /// Priscilla Mena Monge
    /// 24/7/2019
    /// Clase para administrar las consultas sql para los funcionarios
    /// </summary>
    public class FuncionarioDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Priscilla Mena Monge
        /// 24/7/2019
        /// Efecto: devuelve una lista con todos los funcionarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de funcionarios
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public List<Funcionario> getFuncionarios()
        {

            List<Funcionario> listaFuncionarios = new List<Funcionario>();

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand(@"Select id,usuario,nombre,apellidos,fecha_nacimiento,correo,
                numero_telefono1, numero_telefono2, ocupacion, habilitado from Funcionario ", sqlConnection);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Funcionario funcionario = new Funcionario();
                funcionario.id = Int32.Parse(reader.GetValue(0).ToString());
                funcionario.usuario = reader.GetValue(1).ToString();
                funcionario.nombre = reader.GetValue(2).ToString();
                funcionario.apellidos = reader.GetValue(3).ToString();
                funcionario.fecha_nacimiento = Convert.ToDateTime(reader.GetValue(4).ToString()); 
                funcionario.correo = reader.GetValue(5).ToString();
                funcionario.numero_telefono1 = reader.GetValue(6).ToString();
                funcionario.numero_telefono2 = reader.GetValue(7).ToString();
                funcionario.ocupacion = reader.GetValue(8).ToString();

                listaFuncionarios.Add(funcionario);
            }

            sqlConnection.Close();

            return listaFuncionarios;
        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 24/7/2019
        /// Efecto: inserta en la base de datos un Funcionario
        /// Requiere: Funcionario
        /// Modifica: -
        /// Devuelve: id del Funcionario insertado
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public int insertarFuncionario(Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand(@"insert into Funcionario 
                values(@usuario,@nombre,@apellidos,@fecha_nacimiento,@correo,@numero_telefono1,@numero_telefono2,@ocupacion,1);
                                                        SELECT SCOPE_IDENTITY(); "
                , sqlConnection);

            sqlCommand.Parameters.AddWithValue("@usuario", funcionario.usuario);
            sqlCommand.Parameters.AddWithValue("@nombre", funcionario.nombre);
            sqlCommand.Parameters.AddWithValue("@apellidos", funcionario.apellidos);
            sqlCommand.Parameters.AddWithValue("@fecha_nacimiento", funcionario.fecha_nacimiento);
            sqlCommand.Parameters.AddWithValue("@correo", funcionario.correo);
            sqlCommand.Parameters.AddWithValue("@numero_telefono1", funcionario.numero_telefono1);
            sqlCommand.Parameters.AddWithValue("@numero_telefono2", funcionario.numero_telefono2);
            sqlCommand.Parameters.AddWithValue("@ocupacion", funcionario.ocupacion);


            sqlConnection.Open();
            int id = Convert.ToInt32(sqlCommand.ExecuteScalar());

            sqlConnection.Close();

            return id;
        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 24/7/2019
        /// Efecto: actualiza un Funcionario
        /// Requiere: Funcionario a modificar
        /// Modifica: Funcionario
        /// Devuelve: -
        /// </summary>
        /// <param name="funcionario"></param>
        public void actualizarFuncionario(Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand(@"update Funcionario set usuario=@usuario, nombre=@nombre,
                    apellidos=@apellidos, fecha_nacimiento=@fecha_nacimiento, correo=@correo,
                    numero_telefono1=@numero_telefono1, numero_telefono2=@numero_telefono2, ocupacion=@ocupacion where usuario=@usuario", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@usuario", funcionario.usuario);
            sqlCommand.Parameters.AddWithValue("@nombre", funcionario.nombre);
            sqlCommand.Parameters.AddWithValue("@apellidos", funcionario.apellidos);
            sqlCommand.Parameters.AddWithValue("@fecha_nacimiento", funcionario.fecha_nacimiento);
            sqlCommand.Parameters.AddWithValue("@correo", funcionario.correo);
            sqlCommand.Parameters.AddWithValue("@numero_telefono1", funcionario.numero_telefono1);
            sqlCommand.Parameters.AddWithValue("@numero_telefono2", funcionario.numero_telefono2);
            sqlCommand.Parameters.AddWithValue("@ocupacion", funcionario.ocupacion);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 24/7/2019
        /// Efecto: Elimina un Funcionario de  la base de datos
        /// Requiere: Funcionario
        /// Modifica: Funcionario
        /// Devuelve: -
        /// </summary>
        /// <param name="Funcionario"></param>
        public void eliminarFuncionario(Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Update Funcionario set habilitado = 0 where usuario=@usuario", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@usuario", funcionario.usuario);

            sqlConnection.Open();
            int resultado = (int)sqlCommand.ExecuteScalar();

            sqlConnection.Close();

        }
        #endregion


    }
}
