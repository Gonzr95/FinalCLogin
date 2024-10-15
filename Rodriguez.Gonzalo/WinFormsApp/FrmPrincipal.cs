using Entidades.Final2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    ///Agregar manejo de excepciones en TODOS los lugares críticos!!!

    public delegate void DelegadoThreadConParam(object param);

    public partial class FrmPrincipal : Form
    {
        protected Task hilo;
        protected CancellationTokenSource cts;

        public FrmPrincipal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
            this.Text = "Cambiar por su apellido y nombre";
            MessageBox.Show(this.Text);  
            
        }

        #region LISTO
        ///
        /// CRUD
        ///
        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListado frm = new FrmListado();
            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.Show(this);
        }
        ///
        /// VER LOG
        ///
        private void verLogToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Instancio y configuro el open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Abrir archivo de usuarios";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "Archivos de log (*.log)|*.log";
            openFileDialog.Multiselect = false;
            openFileDialog.FileName = "usuarios";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                string contenidoDelArchivo = File.ReadAllText(openFileDialog.FileName);
                this.txtUsuariosLog.Text = "";
                this.txtUsuariosLog.Text = contenidoDelArchivo;
            }




            /*
            DialogResult rta = DialogResult.Cancel;///Reemplazar por la llamada al método correspondiente del OpenFileDialog
            if (rta == DialogResult.OK)
            {
                /// Mostrar en txtUsuariosLog.Text el contenido del archivo .log
            }
            else
            {
                MessageBox.Show("No se muestra .log");
            }
            */

        }
        ///
        /// DESERIALIZAR JSON
        ///
        private void deserializarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Entidades.Final2.Usuario> listado = null;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); /// Reemplazar por el path correspondiente
            string nombreArchivo = "usuarios_repetidos.json";
            nombreArchivo = Path.Join(path, nombreArchivo);



            bool todoOK = false; /// Reemplazar por la llamada al método correspondiente de Manejadora
            todoOK = Manejadora.DeserializarJSON(nombreArchivo, out listado);

            if (todoOK)
            {
                StringBuilder sb = new StringBuilder();
                this.txtUsuariosLog.Clear();
                foreach (Usuario u in listado)
                {
                    sb.AppendLine(u.ToString());
                }

                this.txtUsuariosLog.Text = sb.ToString();
                /// Mostrar en txtUsuariosLog.Text el contenido de la deserialización.
            }
            else MessageBox.Show("NO se pudo deserializar a JSON");

        }

        #endregion


        ///
        /// TASK
        ///
        private void taskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cts = new CancellationTokenSource();
            ///Se inicia el hilo.
            this.hilo = null; /// inicializar tarea
                              ///Se desasocia al manejador de eventos.
            this.taskToolStripMenuItem.Click -= new EventHandler(this.taskToolStripMenuItem_Click);


            ActualizarListadoUsuarios(null);
        }


        ///PARA ACTUALIZAR LISTADO DESDE BD EN HILO
        public void ActualizarListadoUsuarios(object param)
        {
            bool cambioDeCalor = true;
            CancellationToken token = this.cts.Token;


            this.hilo = Task.Run(() =>
            {
                while (this.hilo is not null && !this.cts.IsCancellationRequested)
                {
                    List<Usuario> lista = ADO.ObtenerTodos();
                 
                    if(this.lstUsuarios.InvokeRequired)
                    {
                        this.lstUsuarios.Invoke(new Action(() =>
                        {
                            this.lstUsuarios.Items.Clear();
                            foreach (Usuario u in lista) this.lstUsuarios.Items.Add(u);
                            
                            if(cambioDeCalor)
                            {
                                this.lstUsuarios.ForeColor = System.Drawing.Color.White;
                                this.lstUsuarios.BackColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                this.lstUsuarios.ForeColor = System.Drawing.Color.Black;
                                this.lstUsuarios.BackColor = System.Drawing.Color.White;
                            }
                            cambioDeCalor = !cambioDeCalor;
                        }));

                        Thread.Sleep(1500);

                    }   
                }
            });
        }
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( this.hilo != null && 
                !this.hilo.IsCompleted && 
                this.hilo.Status == TaskStatus.Running)
                
            {
                this.cts.Cancel();
            }
        }

    }   
    
}
