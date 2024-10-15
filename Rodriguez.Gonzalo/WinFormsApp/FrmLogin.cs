using System;
using System.Windows.Forms;
using Entidades.Final2;

namespace WinFormsApp
{

    public partial class FrmLogin : Form
    {
        private Boolean usuarioLogueado;

        public Boolean UsuarioLogueado
        {
            get { return this.usuarioLogueado; }
        }

        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            MessageBox.Show("La primera vez, utilizar 'juan@perez.com' y '123456'.");
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            ///Se genra una instancia de la clase Login y se invoca al método Loguear.
            Login obj = new Login(this.txtCorreo.Text, this.txtClave.Text);

            ///Se establece el valor al atributo usuarioLogueado.
            this.usuarioLogueado = obj.Loguear();

            this.DialogResult = this.usuarioLogueado ? DialogResult.OK : DialogResult.Retry;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
