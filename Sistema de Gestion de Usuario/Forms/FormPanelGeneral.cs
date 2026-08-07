///FormPanelGeneral.cs es la pantalla general del usuario una vez haya iniciado sesion correctamente.
///Muestra el nombre del usuario, el rol que tiene y opciones segun es un administrador o no.

using Sistema_de_Gestion_de_Usuario.Clases;
using Sistema_de_Gestion_de_Usuario.Metodos;

namespace Sistema_de_Gestion_de_Usuario.Forms
{
    public partial class FormPanelGeneral : Form
    {
        ClassMethods ClassMethods = new ClassMethods();

        public FormPanelGeneral()
        {
            InitializeComponent();
        }

        // -- FormPanelGeneral_Load
        // Personaliza la interfaz según los datos de sesión guardados en ClassData.
        private void FormPanelGeneral_Load(object sender, EventArgs e)
        {
            // Mostrar el nombre del usuario logueado en el label de bienvenida.
            lbl_Bienvenida.Text = $"Bienvenido, {ClassData.nombreUsuario}";

            if (ClassData.esAdmin == true)
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

        // -- Botón "Cambiar Contraseña"
        // Disponible para todos los usuarios (admin y no admin).
        private void btn_CambiarContra_Click(object sender, EventArgs e)
        {
            ClassMethods.abrirFormulario(this, new FormNuevaContrasena());
        }

        // -- Botón "Gestión de Usuarios"
        // Doble verificación: aunque el botón debería estar oculto para no admins, se verifica nuevamente por código como medida de seguridad extra.
        private void btn_GestionUsuarios_Click(object sender, EventArgs e)
        {
            if (!ClassData.esAdmin)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.");
                return;
            }

            ClassMethods.abrirFormulario(this, new FormAdmin());
        }

        // -- Botón "Cerrar Sesión"
        // Vuelve al FormLogin. No limpia ClassData explícitamente porque el login sobreescribe los valores al autenticar un nuevo usuario.
        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            ClassMethods.abrirFormulario(this, new FormLogin());
        }
    }
}