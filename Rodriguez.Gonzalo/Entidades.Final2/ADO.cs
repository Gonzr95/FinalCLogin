using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Data.SqlClient;
using System.Collections.Specialized;


namespace Entidades.Final2
{
    public class ADO
    {
        public delegate void ApellidoUsuarioExistentDelegadoHandler(object sender, UsuariosConApellidosRepetidosEventArgs e);
        public event ApellidoUsuarioExistentDelegadoHandler ApellidoUsuarioExistenteON;
        private static string conexion = "Server=.;Database=laboratorio_2;Trusted_Connection=True";
        //private static string conexion = "Server=PCLGR3353\\SQLEXPRESS;Database=laboratorio_2;Trusted_Connection=True"; PARA EL LABURO

        public ADO()
        {
            // = "Server=.;Database=laboratorio_2;Trusted_Connection=True";
        }


        #region METODOS
        public bool Agregar(Usuario usuario)
        {
            if (this.VerificarApellido(usuario.Apellido) &&
                ApellidoUsuarioExistenteON is not null)
            {
                UsuariosConApellidosRepetidosEventArgs args = new UsuariosConApellidosRepetidosEventArgs(this.ObtenerTodos(usuario.Apellido));
                ApellidoUsuarioExistenteON.Invoke(this, args);
            }
            using (SqlConnection connection = new SqlConnection(ADO.conexion))
            {
                string sentenciaSQL = "INSERT INTO usuarios(nombre, apellido, dni, correo, clave) values (@nombre, @apellido, @dni, @correo, @clave)";
                SqlCommand cmd = new SqlCommand(sentenciaSQL, connection);


                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1) return true;
                else return false;

            }

        }
        public bool Eliminar(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(ADO.conexion))
            {
                string sentenciaSQL = "DELETE FROM usuarios WHERE dni = @dni";
                SqlCommand cmd = new SqlCommand(sentenciaSQL, connection);


                cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else return false;

            }
        }
        public bool Modificar(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(ADO.conexion))
            {
                string query = "UPDATE usuarios SET nombre = @nombre, apellido = @apellido, dni = @dni, correo = @correo, clave = @clave WHERE dni = @dni";
                SqlCommand cmd = new SqlCommand(query, connection);

                //primer param (@xxxx) hace referencia a la etiqueta de arriba, la cual el valor sera reemplazado por el e.id por ej
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery(); //para las tareas que no sean de lectura, devuelve int de rows affected

                if (rowsAffected > 0)
                {
                    return true;
                }
                else return false;
            }

        }
        public static List<Usuario> ObtenerTodos()
        {
            List<Usuario> listUsuario = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(ADO.conexion))
            {
                string sentenciaSQL = "SELECT * FROM usuarios";
                SqlCommand cmd = new SqlCommand(sentenciaSQL, connection);
                connection.Open();
                //ExecuteReader para sentencias de lectura
                SqlDataReader reader = cmd.ExecuteReader();

                //NonQuery para los casos donde la sentencia sea delete update y insert
                //todas menos select
                //cmd.ExecuteNonQuery();

                while (reader.Read()) //mientras que sigas leyendo hace lo siguiente (read() devuelve bool)
                {
                    Usuario e = new Usuario(reader.GetString(0), reader.GetString(1),
                                                reader.GetInt32(2), reader.GetString(3),
                                                reader.GetString(4));

                    listUsuario.Add(e);
                }
                return listUsuario;
            }
        }
        public List<Usuario> ObtenerTodos(string apellidoUsuario)
        {
            List<Usuario> usuariosConApellidoIgual = new List<Usuario>();
            List<Usuario> listaUsuarios = ADO.ObtenerTodos();

            foreach (Usuario u in listaUsuarios)
            {
                if (u.Apellido == apellidoUsuario)
                {
                    usuariosConApellidoIgual.Add(u);
                }
            }

            return usuariosConApellidoIgual;
        }
        #endregion



        public bool VerificarApellido(string apellido)
        {
            List<Usuario> usuarios = ADO.ObtenerTodos();

            foreach (Usuario u in usuarios)
            {
                if (apellido == u.Apellido) return true;
            }
            return false;

        }



    }
    public class UsuariosConApellidosRepetidosEventArgs : EventArgs
    {
        public List<Usuario> usuarios;

        public UsuariosConApellidosRepetidosEventArgs(List<Usuario> usuariosRepetidos)
        {
            this.usuarios = usuariosRepetidos;  
        }
    }
}