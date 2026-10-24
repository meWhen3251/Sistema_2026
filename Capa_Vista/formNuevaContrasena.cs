///FormNuevaContrasena.cs es un formulario que le permite al usuario que ya inicio sesion establecer una nueva contraseña.

using Capa_Datos;
using Capa_Logica;
using Capa_Sesion;

namespace Capa_Vista
{
    public partial class formNuevaContrasena : Form
    {
        claseSP claseSP = new claseSP();
        claseMetodos claseMetodos = new claseMetodos();
        public formNuevaContrasena()
        {
            InitializeComponent();
        }

        private void btn_Enviar_Click(object sender, EventArgs e)
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
                string hash = claseMetodos.encryptToSHA256(tbox_NuevaContra.Text.Trim() + claseVar.nombreUsuario);

                // SP_InsertarContrasena se encarga de:
                //   - Desactivar la contraseña anterior en Historico_Contrasenas.
                //   - Insertar la nueva contraseña en Contrasenas.
                //   - Verificar que no sea una contraseña ya utilizada.
                claseSP.SP_InsertarContrasena(hash, claseVar.idUsuario);

                MessageBox.Show("Nueva contraseña registrada.");
                // Volver al login para que el usuario autentique con la nueva contraseña.
                formLogin formLogin = new formLogin();
                this.Hide();
                formLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la contraseña: {ex.Message}");
            }

        }
    }
}
