/// FormLogin.cs es la primer pantalla que vera el usuario al iniciar el sistema.

using Capa_Datos;
using Capa_Logica;
using Capa_Sesion;

using System.Data;

namespace Capa_Vista
{
    public partial class formLogin : Form
    {
        claseSP claseSP = new claseSP();
        claseMetodos claseMetodos = new claseMetodos();
        public formLogin()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas de campos vacíos antes de tocar la BD.
                if (string.IsNullOrWhiteSpace(tbox_Usuario.Text))
                {
                    MessageBox.Show("Por favor, ingresa tu nombre de usuario.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbox_Contrasena.Text))
                {
                    MessageBox.Show("Por favor, ingresa tu contraseña.");
                    return;
                }

                string usuario = tbox_Usuario.Text.Trim();
                string contrasenaIngresada = tbox_Contrasena.Text.Trim();

                // -- Encriptar la contraseña
                // Se concatena contraseña + nombre de usuario antes de hashear para que el mismo texto produzca encriptaciones distintas por usuario.
                string contrasenaConcatenada = contrasenaIngresada + usuario;
                contrasenaConcatenada = claseMetodos.encryptToSHA256(contrasenaConcatenada);

                // Llama al SP que compara usuario + encriptado contra la base de datos.
                // Devuelve una fila con datos del usuario si coinciden, vacío si no.
                DataTable loginResult = claseSP.SP_LoginUsuario(usuario, contrasenaConcatenada);

                if (loginResult is null || loginResult.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos. Inténtalo de nuevo.");
                    return;
                }

                // -- Login exitoso: guardar datos de sesión en ClassData.cs
                // Convert.ToInt32 convierte el valor de la celda (que llega como object) a int.
                claseVar.idUsuario = Convert.ToInt32(loginResult.Rows[0]["ID_Usuario"]);
                claseVar.nombreUsuario = loginResult.Rows[0]["Nombre"].ToString().Trim();

                // -- Detectar si es el primer login
                // Al registrar un usuario se le crea una contraseña temporal (cuenta como 1).
                // Si CantidadContrasenas es igual a 1, nunca cambió la contraseña, por lo que es un primer login.
                DataTable contrasenaCount = claseSP.SP_ObtenerCantidadContrasenas(claseVar.idUsuario);
                int cantidadContrasenas = Convert.ToInt32(contrasenaCount.Rows[0]["CantidadContrasenas"]);

                tbox_Usuario.Clear();
                tbox_Contrasena.Clear();

                if (cantidadContrasenas == 1)
                {
                    // Primer login: el usuario debe cambiar su contraseña y configurar sus preguntas de seguridad.
                    MessageBox.Show("Es tu primer login. Debés cambiar tu contraseña y responder las preguntas de seguridad.");
                    formFirstLogin formFirstLogin = new formFirstLogin();
                    this.Hide();
                    formFirstLogin.Show();
                }
                else if (claseMetodos.EsContrasenaTemporal(contrasenaIngresada))
                {
                    // Entró con una contraseña temporal (recuperación o cambio pedido por el administrador)
                    MessageBox.Show("Ingresaste con una contraseña temporal. Por seguridad, debés elegir una nueva contraseña antes de continuar.");
                    formNuevaContrasena formNuevaContrasena = new formNuevaContrasena();
                    this.Hide();
                    formNuevaContrasena.Show();
                }
                else
                {
                    // -- Verificar si es administrador
                    // El SP devuelve filas si el usuario tiene rol "Administrador".
                    DataTable rolResult = claseSP.SP_EsAdministrador(claseVar.idUsuario);

                    // Si no hay filas, no es admin, pero si hay al menos una, es admin.
                    claseVar.esAdmin = !(rolResult is null || rolResult.Rows.Count == 0);

                    // Pedir confirmación de identidad con preguntas de seguridad.
                    formPanelGeneral formPanelGeneral = new formPanelGeneral();

                    this.Hide();
                    formPanelGeneral.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el login: {ex.Message}");
            }
        }

        private void Llabel_Recuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formRecuperarContrasena formRecuperarContrasena = new formRecuperarContrasena();
            this.Hide();
            formRecuperarContrasena.Show();

        }
        private void formLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
