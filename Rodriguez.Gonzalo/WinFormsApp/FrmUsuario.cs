using System;
using System.Windows.Forms;
using Entidades.Final2;

namespace WinFormsApp
{
    public partial class FrmUsuario : Form
    {
        private Usuario miUsuario;

        public Usuario MiUsuario
        {
            get { return this.miUsuario; }
        }

        public FrmUsuario()
        {
            InitializeComponent();
        }

        public FrmUsuario(Usuario user) : this()
        {
            this.txtNombre.Text = user.Nombre;
            this.txtApellido.Text = user.Apellido;
            this.txtDni.Text = user.Dni.ToString();
            this.txtCorreo.Text = user.Correo;
            this.txtClave.Text = user.Clave;
            this.txtDni.ReadOnly = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string apellido = this.txtApellido.Text;
            int dni;
            string correo = this.txtCorreo.Text;
            string clave = this.txtClave.Text;

            try
            {
                dni = int.Parse(this.txtDni.Text);
                Usuario user = new Usuario(nombre, apellido, dni, correo, clave);
                this.miUsuario = user;
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }




            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
