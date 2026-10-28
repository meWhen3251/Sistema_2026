using Capa_Sesion;

namespace Capa_Vista
{
    public partial class formPanelGeneral : Form
    {
        public formPanelGeneral()
        {
            InitializeComponent();
        }

        private void formPanelGeneral_Load(object sender, EventArgs e)
        {
            // Mostrar el nombre del usuario logueado en el label de bienvenida.
            lbl_Usuario.Text = "Bienvenido, "+ claseVar.nombreUsuario;

            if (claseVar.esAdmin == true)
            {
                lbl_Rol.Text = "Rol: Administrador";
                // Mostrar el botón de gestión solo si es admin.
                btn_GestionUsuarios.Visible = true;
            }
            else
            {
                lbl_Rol.Text = "Rol: Usuario";
                // Ocultar el botón para usuarios sin permisos de admin.
                btn_GestionUsuarios.Visible = false;
            }
        }

        // Cambio voluntario de contraseña. Se abre como "hijo": al volver, este panel se muestra de nuevo.
        private void btn_CambiarContra_Click(object sender, EventArgs e)
        {
            formNuevaContrasena formNuevaContrasena = new formNuevaContrasena();
            formNuevaContrasena.FormClosed += (s, args) => this.Show();
            this.Hide();
            formNuevaContrasena.Show();
        }

        // Cambio de las preguntas de seguridad (para cualquier usuario, administrador o no)
        private void btn_CambiarPreguntas_Click(object sender, EventArgs e)
        {
            formCambiarPreguntas formCambiarPreguntas = new formCambiarPreguntas();
            formCambiarPreguntas.FormClosed += (s, args) => this.Show();
            this.Hide();
            formCambiarPreguntas.Show();
        }

        // Doble verificación: aunque el botón esté oculto para los no administradores,
        // se vuelve a comprobar por código como medida de seguridad extra.
        private void btn_GestionUsuarios_Click(object sender, EventArgs e)
        {
            if (!claseVar.esAdmin)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.");
                return;
            }

            formPanelAdmin formPanelAdmin = new formPanelAdmin();
            formPanelAdmin.Show();
            this.Hide();
        }

        // Cierra la sesión: se borran los datos del usuario y se vuelve al login.
        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            claseVar.idUsuario = 0;
            claseVar.nombreUsuario = string.Empty;
            claseVar.esAdmin = false;

            formLogin formLogin = new formLogin();
            formLogin.Show();
            this.Hide();
        }
    }
}
