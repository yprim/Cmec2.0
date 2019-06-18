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
    /// Steven Camacho
    /// 10/may/2019
    /// Clase para administrar las consultas sql para la tabla de activos
    /// </summary>
    public class ActivoDatos
    {
        #region variables
        private SqlConnection conexion;
        private ConexionDatos conexionDatos;
        #endregion

        #region constructor
        public ActivoDatos()
        {
            this.conexionDatos = new ConexionDatos();
            this.conexion = this.conexionDatos.conexionCMEC();
        }
        #endregion
     
        #region consultas
        /// <summary>
        /// Steven Camacho
        /// 10/5/2019
        /// Efecto: devuelve una lista con todos los activos habilitados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de activos habilitados
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public List<Activo> obtenerTodos()
        {
            //Recupera todos los activos que están habilitados
            List<Activo> listaActivos = new List<Activo>();
            SqlCommand sqlCommand = new SqlCommand("Select * from activo where habilitado= 1.", conexion);
            SqlDataReader reader;
            conexion.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Activo activo = new Activo();
                activo.Placa = Int32.Parse(reader.GetValue(0).ToString());
                activo.Serie = reader.GetValue(1).ToString();
                activo.Modelo = reader.GetValue(2).ToString();
                string fecha = reader.GetValue(3).ToString();
                if (fecha == "")
                    activo.FechaCompra = "01/01/0001";
                else
                    activo.FechaCompra = fecha;
                activo.Descripcion = reader.GetValue(4).ToString();
                activo.IsNotDeleted = Boolean.Parse(reader.GetValue(5).ToString());
                listaActivos.Add(activo);
            }
            conexion.Close();
            return listaActivos;
        }

        /// <summary>
        /// Steven Camacho
        /// 29/5/2019
        /// Efecto: devuelve una lista con todos los activos inhabilitados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de activos inhabilitados
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public List<Activo> obtenerTodosEliminado()
        {
            //Recupera todos los activos que están habilitados
            List<Activo> listaActivos = new List<Activo>();
            SqlCommand sqlCommand = new SqlCommand("Select * from activo where habilitado= 0.", conexion);
            SqlDataReader reader;
            conexion.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Activo activo = new Activo();
                activo.Placa = Int32.Parse(reader.GetValue(0).ToString());
                activo.Serie = reader.GetValue(1).ToString();
                activo.Modelo = reader.GetValue(2).ToString();
                activo.FechaCompra = reader.GetValue(3).ToString();
                activo.Descripcion = reader.GetValue(4).ToString();
                listaActivos.Add(activo);
            }
            conexion.Close();
            return listaActivos;
        }
    

        /// <summary>
        /// Steven Camacho
        /// 10/5/2019
        /// Efecto: Permite agregar un nuevo activo a la base de datos
        /// Requiere: objeto de tipo activo con los datos a almacenar
        /// Modifica: Agrega un elemento de tipo activo a la base de datos
        /// Devuelve: -
        /// </summary>
        /// <param name="activo" type="Activo"></param>
        /// <returns></returns>
        public int insertar(Activo activo)
        {
            SqlCommand sqlCommand = new SqlCommand("insert into Activo output Inserted.placa " +
                "values(@placa,@serie,@modelo,@fecha_compra,@descripcion,1) "
                , conexion);
            sqlCommand.Parameters.AddWithValue("@placa", activo.Placa);
            sqlCommand.Parameters.AddWithValue("@serie", activo.Serie);
            sqlCommand.Parameters.AddWithValue("@modelo", activo.Modelo);
            sqlCommand.Parameters.AddWithValue("@fecha_compra", activo.FechaCompra);
            sqlCommand.Parameters.AddWithValue("@descripcion", activo.Descripcion);
            conexion.Open();
            int respuesta = (int)sqlCommand.ExecuteScalar();
            conexion.Close();

            return respuesta;
        }

        /// <summary>
        /// Steven Camacho
        /// 10/5/2019
        /// Efecto: actualiza el activo determinado por su placa con los nuevos datos
        /// Requiere: elemento de tipo activo, tomando como referencia la placa contenida
        /// Modifica: - un activo almacenado que coincide con la placa que trae el elemento activo
        /// Devuelve: un entero que permite determinar si la operación se realizó correctamente
        /// </summary>
        /// <param name="activo" type="Activo"></param>
        /// <returns></returns>
        public int actualizar(Activo activo)
        {
            SqlCommand sqlCommand = new SqlCommand("update Activo set serie=@serie, modelo=@modelo, " +
                "fecha_compra=@fecha_compra, descripcion=@descripcion " +
                "output Inserted.placa where placa=@placa"
                , conexion);
            sqlCommand.Parameters.AddWithValue("@placa", activo.Placa);
            sqlCommand.Parameters.AddWithValue("@serie", activo.Serie);
            sqlCommand.Parameters.AddWithValue("@modelo", activo.Modelo);
            sqlCommand.Parameters.AddWithValue("@fecha_compra", activo.FechaCompra);
            sqlCommand.Parameters.AddWithValue("@descripcion", activo.Descripcion);
            conexion.Open();
            int respuesta = (int)sqlCommand.ExecuteScalar();
            conexion.Close();

            return respuesta;
        }

        /// <summary>
        /// Steven Camacho
        /// 10/5/2019
        /// Efecto: los activos no se eliminan, solo se inhabilitan para que no sean mostrados en la lista de activos.
        /// Requiere: numero entero de la placa a inhabilitar
        /// Modifica: El activo con el número de placa incicada por parametros.
        /// Devuelve: un entero que es la placa insertada, esto es para probar solamente que se realizó la operación.
        /// </summary>
        /// <param name="placa" type="int"></param>
        /// <returns></returns>
        public int inhabilitar(int placa)
        {
            //Permite no mostrar los activos que han sido inhabilitados como solución alternativa a no eliminarlos del todo.
            SqlCommand sqlCommand = new SqlCommand("update Activo set habilitado=@cambio " +
                "output Inserted.placa where placa=@placa"
                , conexion);
            sqlCommand.Parameters.AddWithValue("@placa", placa);
            sqlCommand.Parameters.AddWithValue("@cambio", 0);

            conexion.Open();
            int respuesta = (int)sqlCommand.ExecuteScalar();
            conexion.Close();

            return respuesta;
        }


        /// <summary>
        /// Steven Camacho
        /// 29/5/2019
        /// Efecto: restaura la habilitación del activo, lo que permite mostrarse a lista de activos.
        /// Requiere: numero entero de la placa a habilitar
        /// Modifica: El activo con el número de placa incicada por parametros.
        /// Devuelve: un entero que es la placa insertada, esto es para probar solamente que se realizó la operación.
        /// </summary>
        /// <param name="placa" type="int"></param>
        /// <returns></returns>
        public int restaurarActivo(int placa)
        {
            //Permite  mostrar los activos que han sido inhabilitados como solución alternativa a restaurarlos y usarlos del todo en mantenimeintos.
            SqlCommand sqlCommand = new SqlCommand("update Activo set habilitado=@cambio " +
                "output Inserted.placa where placa=@placa"
                , conexion);
            sqlCommand.Parameters.AddWithValue("@placa", placa);
            sqlCommand.Parameters.AddWithValue("@cambio", 1);

            conexion.Open();
            int respuesta = (int)sqlCommand.ExecuteScalar();
            conexion.Close();

            return respuesta;
        }
        #endregion consultas
    }
}
