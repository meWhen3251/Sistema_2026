/// formAltaUsuario.cs es el formulario con el que el administrador registra un nuevo usuario.
/// El sistema genera una contraseña temporal (6 dígitos), la envía por correo y guarda la contraseña encriptada en la base de datos.
/// En el primer ingreso el usuario debe cambiarla y registrar sus preguntas de seguridad.

using Capa_Datos;
using Capa_Logica;
using Capa_Servicios;
using System.Data;
using System.Security.Cryptography;

namespace Capa_Vista
{
    public partial class formNuevoUsuario : Form
    {
        claseSP claseSP = new claseSP();
        claseEmail claseEmail = new claseEmail();
        public formNuevoUsuario()
        {
            InitializeComponent();
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btn_Enviar_Click(object sender, EventArgs e)
        {
            string nombre = tbox_Nombre.Text.Trim();
            string apellido = tbox_Apellido.Text.Trim();
            string correo = tbox_Correo.Text.Trim();
            string usuario = tbox_NombreUsuario.Text.Trim();

            // -- Validaciones de los campos
            if (nombre == "" || apellido == "" || correo == "" || usuario == "")
            {
                MessageBox.Show("Por favor, completá todos los campos.");
                return;
            }

            if (usuario.Contains(' '))
            {
                MessageBox.Show("El nombre de usuario no puede tener espacios.");
                tbox_NombreUsuario.Focus();
                return;
            }

            bool correoValido;
            try
            {
                correoValido = claseEmail.validateEmail(correo);
            }
            catch
            {
                correoValido = false;
            }

            if (!correoValido)
            {
                MessageBox.Show("El correo electrónico no es válido.");
                tbox_Correo.Focus();
                return;
            }

            try
            {
                btn_Enviar.Enabled = false;

                // -- Que el correo y el nombre de usuario no estén ya registrados
                int correoExiste = claseSP.SP_VerificarMail(correo);   // 1 = existe, 0 = no existe, -1 = error
                if (correoExiste == 1)
                {
                    MessageBox.Show("Ese correo ya está registrado en el sistema.");
                    tbox_Correo.Focus();
                    return;
                }
                if (correoExiste < 0)
                {
                    MessageBox.Show("No se pudo verificar el correo. Intentá de nuevo.");
                    return;
                }

                DataTable usuarios = claseSP.SP_CargaUsuariosDetalle();
                bool usuarioExiste = usuarios.AsEnumerable().Any(r =>
                    string.Equals(r["NombreUsuario"].ToString().Trim(), usuario, StringComparison.OrdinalIgnoreCase)); //compara entre el nombre de usuario ingresado y los que ya existen en la base de datos.
                                                                                                                       //StringComparison.OrdinalIgnoreCase le dice al sistema que no importe si son mayúsculas o minúsculas, que solo compare el texto.
                if (usuarioExiste)
                {
                    MessageBox.Show("Ese nombre de usuario ya existe. Elegí otro.");
                    tbox_NombreUsuario.Focus();
                    return;
                }

                // -- Contraseña temporal: 6 dígitos, hasheada igual que en el login: SHA256(contraseña + usuario)
                string temporal = RandomNumberGenerator.GetInt32(100000, 1000000).ToString();
                string hash = claseMetodos.encryptToSHA256(temporal + usuario);

                // Primero el correo: si salta error, no se crea nada en la base de datos
                await claseEmail.sendEmailContraseña(usuario, correo, temporal);

                // -- Guardar el usuario (el SP le asigna el rol "Usuario")
                claseSP.SP_InsertarUsuarioCompleto(nombre, apellido, correo, usuario, hash);

                MessageBox.Show("Usuario " + usuario + " registrado. Se envió una contraseña temporal a " + correo + ".");
                tbox_Nombre.Clear();
                tbox_Apellido.Clear();
                tbox_Correo.Clear();
                tbox_NombreUsuario.Clear();
                tbox_Nombre.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
            finally
            {
                btn_Enviar.Enabled = true;
            }
        }
    }
}
