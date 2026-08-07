///FormNuevaContrasena.cs es un formulario que le permite al usuario que ya inicio sesion establecer una nueva contraseña.

using Sistema_de_Gestion_de_Usuario.Clases;
using Sistema_de_Gestion_de_Usuario.Metodos;

namespace Sistema_de_Gestion_de_Usuario.Forms
{
    public partial class FormNuevaContrasena : Form
    {
        ClassMethods ClassMethods = new ClassMethods();
        ClassSP_Methods ClassSP_Methods = new ClassSP_Methods();

        public FormNuevaContrasena()
        {
            InitializeComponent();
        }

        // -- Botón "Enviar"
        private void btn_Enviar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbox_NuevaContra.Text))
            {
                MessageBox.Show("Por favor, ingresá tu nueva contraseña.");
                tbox_NuevaContra.Focus();
                return;
            }

            try
            {
                // Encripta en SHA256(nuevaContraseña + nombreUsuario)
                // ClassData.nombreUsuario contiene el nombre del usuario logueado.
                string hash = ClassMethods.encryptToSHA256(tbox_NuevaContra.Text.Trim() + ClassData.nombreUsuario);

                // SP_InsertarContrasena se encarga de:
                //   - Desactivar la contraseña anterior en Historico_Contrasenas.
                //   - Insertar la nueva contraseña en Contrasenas.
                //   - Verificar que no sea una contraseña ya utilizada.
                ClassSP_Methods.SP_InsertarContrasena(hash, ClassData.idUsuario);

                MessageBox.Show("Nueva contraseña registrada.");
                // Volver al login para que el usuario autentique con la nueva contraseña.
                ClassMethods.abrirFormulario(this, new FormLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la contraseña: {ex.Message}");
            }
        }
    }
}