using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Entidades.Final2
{
    public static class Manejadora
    {
        static Manejadora() { }

        public static bool DeserializarJSON(string path, out List<Usuario> usuarios)
        {
            bool resultado = false;
            List<Usuario> users = new List<Usuario>();
            string archivoJson = File.ReadAllText(path);

            users = JsonSerializer.Deserialize<List<Usuario>>(archivoJson);
            

            if (string.IsNullOrEmpty(archivoJson)) resultado = false;
            else resultado = true;

            usuarios = users;
            return resultado;
        }

        //escribe en un json
        public static bool EscribirArchivo(List<Usuario> users)
        {
            DateTime dt = DateTime.Now;
            StringBuilder sb = new StringBuilder();


            sb.AppendLine(dt.ToShortDateString() + " " +  dt.ToLongTimeString() ); //FECHA Y HORA
            sb.AppendLine(users[0].Apellido); //MATCH APELLIDO

            foreach ( Usuario usuario in users )
            {
                sb.Append( usuario.Correo + ", ");
            }

            string path = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments);
            string nombreArchivo = "usuarios.log";
            nombreArchivo = Path.Join( path, nombreArchivo );

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(nombreArchivo, true);
                sw.WriteLine(sb.ToString());
            }
            finally
            {
                sw.Close();
                sw.Dispose();
                

            }


            if (File.Exists(nombreArchivo))
            {
                return true;
            }
            return false;

            
        }

        /// <summary>
        /// serializar a JSON la lista de objetos de tipo Usuario que contiene a los usuarios cuyos apellidos 
        /// coinciden con el del nuevo usuario agregado.El archivo se guardará en el escritorio del cliente con
        /// el nombre 'usuarios_repetidos.json'.El manejador de eventos (Manejador_apellidoExistenteJSON) invocará
        /// al método (de clase)SerializarJSON(List<Usuario>, string). Dicho método, se alojará en la clase Manejadora
        /// en Entidades.Final, yretorna un booleano indicando si se pudo escribir o no.
        /// </summary>
        /// <param name="usuarios"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool SerializarJSON(List<Usuario> usuarios, string path)
        {
            string rutaArchivo = "usuarios_repetidos.json";
            rutaArchivo = Path.Join(path, rutaArchivo);

            using (StreamWriter sw = new StreamWriter(rutaArchivo))
            {
                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true; //para identar la lista y hacerla mas legible
                string json = JsonSerializer.Serialize<List<Usuario>>(usuarios, opciones);
                sw.Write(json);


                if (!string.IsNullOrEmpty(json) &&
                     File.Exists(rutaArchivo))
                {
                    return true;
                }
                else return false;
            }
        }
    }
}
