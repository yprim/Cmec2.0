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
    /// Leonardo Gomez
    ///5/9/2019
    ///Clase para administrar las consultas sql para los funcionarios
    /// </summary>
    public class FuncionarioDatos
    {

        #region variables

        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Leonardo Gomez
        /// 5/9/2019
        /// Efecto: devuelve una lista con todos los funcionarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de funcionarios
        /// </summary>
        /// <param name="Funcionario"></param>
        /// <returns></returns>
        public List<Funcionario> getFuncionarios()
        {

            List<Funcionario> listaFuncionarios = new List<Funcionario>();

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Select id,usuario,nombre,apellidos,fecha_nacimiento," +
            "correo, numero_telefono1, numero_telefono2, ocupacion, habilitado from " +
            " Funcionario where habilitado = 1 ", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Funcionario funcionario = new Funcionario();

                funcionario.Id = Int32.Parse(reader.GetValue(0).ToString());
                funcionario.Usuario = reader.GetValue(1).ToString();
                funcionario.Nombre = reader.GetValue(2).ToString();
                funcionario.Apellidos = reader.GetValue(3).ToString();
                funcionario.Fecha_Nacimiento = reader.GetValue(4).ToString();
                funcionario.Correo = reader.GetValue(5).ToString();
                funcionario.Numero_Telefono1 = reader.GetValue(6).ToString();
                funcionario.Numero_Telefono2 = reader.GetValue(7).ToString();
                funcionario.Ocupacion = reader.GetValue(8).ToString();

                listaFuncionarios.Add(funcionario);
            }

            sqlConnection.Close();

            return listaFuncionarios;
        }

        /// <summary>
        /// Leonardo Gomez
        /// 5/9/2019
        /// Efecto: inserta en la base de datos un Funcionario
        /// Requiere: Funcionario
        /// Modifica: -
        /// Devuelve: id del Funcionario insertado
        /// </summary>
        /// <param name="Funcionario"></param>
        /// <returns></returns>
        public int insertarFuncionario(Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("insert into Funcionario output Inserted.usuario " +
                "values(@usuario,@nombre,@apellidos,@fecha_nacimiento,@correo,@numero_telefono1,@numero_telefono2,@ocupacion,1) "
                , sqlConnection);

            sqlCommand.Parameters.AddWithValue("@usuario", funcionario.Usuario);
            sqlCommand.Parameters.AddWithValue("@nombre", funcionario.Nombre);
            sqlCommand.Parameters.AddWithValue("@apellidos", funcionario.Apellidos);
            sqlCommand.Parameters.AddWithValue("@fecha_nacimiento", funcionario.Fecha_Nacimiento);
            sqlCommand.Parameters.AddWithValue("@correo", funcionario.Correo);
            sqlCommand.Parameters.AddWithValue("@numero_telefono1", funcionario.Numero_Telefono1);
            sqlCommand.Parameters.AddWithValue("@numero_telefono2", funcionario.Numero_Telefono2);
            sqlCommand.Parameters.AddWithValue("@ocupacion", funcionario.Ocupacion);


            sqlConnection.Open();
            int usuario_funcionario = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return usuario_funcionario;
        }

        /// <summary>
        /// Leonardo Gomez
        /// 5/9/2019
        /// Efecto: actualiza un Funcionario
        /// Requiere: Funcionario a modificar
        /// Modifica: Funcionario
        /// Devuelve: -
        /// </summary>
        /// <param name="Funcionario"></param>
        public void actualizarFuncionario(Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("update Funcionario set usuario=@usuario, nombre=@nombre, " +
                "apellidos=@apellidos, fecha_nacimiento=@fecha_nacimiento, correo=@correo, " + "" +
                "numero_telefono1=@numero_telefono1, numero_telefono2=@numero_telefono2, ocupacion=@ocupacion " +
                "output Inserted.usuario where usuario=@usuario", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@usuario", funcionario.Usuario);
            sqlCommand.Parameters.AddWithValue("@nombre", funcionario.Nombre);
            sqlCommand.Parameters.AddWithValue("@apellidos", funcionario.Apellidos);
            sqlCommand.Parameters.AddWithValue("@fecha_nacimiento", funcionario.Fecha_Nacimiento);
            sqlCommand.Parameters.AddWithValue("@correo", funcionario.Correo);
            sqlCommand.Parameters.AddWithValue("@numero_telefono1", funcionario.Numero_Telefono1);
            sqlCommand.Parameters.AddWithValue("@numero_telefono2", funcionario.Numero_Telefono2);
            sqlCommand.Parameters.AddWithValue("@ocupacion", funcionario.Ocupacion);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

        /// <summary>
        /// Leonardo Gomez
        /// 5/9/2019
        /// Efecto: Elimina un Funcionario de  la base de datos
        /// Requiere: Funcionario
        /// Modifica: Funcionario
        /// Devuelve: -
        /// </summary>
        /// <param name="Funcionario"></param>
        public void eliminarFuncionario(Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Update Funcionario set habilitado = 0 " +
                "output Inserted.usuario where usuario=@usuario", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@usuario", funcionario.Usuario);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }
        #endregion
    }

}

