/// FormLogin.cs es la primer pantalla que vera el usuario al iniciar el sistema.

using Sistema_de_Gestion_de_Usuario.Clases;
using Sistema_de_Gestion_de_Usuario.Forms;
using Sistema_de_Gestion_de_Usuario.Metodos;
using System.Data;

namespace Sistema_de_Gestion_de_Usuario
{
    public partial class FormLogin : Form
    {
        // Instancias de las clases de lógica y acceso a datos.
        // Se crean al instanciar el formulario y se reutilizan en todos los eventos.
        ClassMethods ClassMethods = new ClassMethods();
        ClassSP_Methods ClassSP_Methods = new ClassSP_Methods();

        public FormLogin()
        {
            InitializeComponent();
        }

        // -- Botón "Iniciar sesión"
        // Evento principal del formulario. Valida las credenciales y decide a qué formulario navegar.
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
                contrasenaConcatenada = ClassMethods.encryptToSHA256(contrasenaConcatenada);

                // Llama al SP que compara usuario + encriptado contra la base de datos.
                // Devuelve una fila con datos del usuario si coinciden, vacío si no.
                DataTable loginResult = ClassSP_Methods.SP_LoginUsuario(usuario, contrasenaConcatenada);

                if (loginResult is null || loginResult.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos. Inténtalo de nuevo.");
                    return;
                }

                // -- Login exitoso: guardar datos de sesión en ClassData.cs
                // Convert.ToInt32 convierte el valor de la celda (que llega como object) a int.
                ClassData.idUsuario = Convert.ToInt32(loginResult.Rows[0]["ID_Usuario"]);
                ClassData.nombreUsuario = loginResult.Rows[0]["Nombre"].ToString().Trim();

                // -- Detectar si es el primer login
                // Al registrar un usuario se le crea una contraseña temporal (cuenta como 1).
                // Si CantidadContrasenas es igual a 1, nunca cambió la contraseña, por lo que es un primer login.
                DataTable contrasenaCount = ClassSP_Methods.SP_ObtenerCantidadContrasenas(ClassData.idUsuario);
                int cantidadContrasenas = Convert.ToInt32(contrasenaCount.Rows[0]["CantidadContrasenas"]);

                tbox_Usuario.Clear();
                tbox_Contrasena.Clear();

                if (cantidadContrasenas == 1)
                {
                    // Primer login: el usuario debe cambiar su contraseña y configurar sus preguntas de seguridad.
                    MessageBox.Show("Es tu primer login. Debés cambiar tu contraseña y responder las preguntas de seguridad.");
                    ClassMethods.abrirFormulario(this, new FormFirstLogin());
                }
                else
                {
                    // -- Verificar si es administrador
                    // El SP devuelve filas si el usuario tiene rol "Administrador".
                    DataTable rolResult = ClassSP_Methods.SP_EsAdministrador(ClassData.idUsuario);

                    // Si no hay filas, no es admin, pero si hay al menos una, es admin.
                    ClassData.esAdmin = !(rolResult is null || rolResult.Rows.Count == 0);

                    // Pedir confirmación de identidad con preguntas de seguridad.
                    ClassMethods.abrirFormulario(this, new FormPanelGeneral());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el login: {ex.Message}");
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        // -- Link "¿Olvidaste tu contraseña?"
        // LinkLabel es un control que parece un hipervínculo.
        private void Llabel_Recuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClassMethods.abrirFormulario(this, new FormRecuperar());
        }
    }
}