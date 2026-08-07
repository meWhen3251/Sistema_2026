///FormRecuperar.cs es el formulario de recuperacion de contraseña en caso de que esta sea olvidada.

using Sistema_de_Gestion_de_Usuario.Metodos;
using Sistema_de_Gestion_de_Usuario.Clases;
using System.Data;

namespace Sistema_de_Gestion_de_Usuario.Forms
{
    public partial class FormRecuperar : Form
    {
        ClassMethods ClassMethods = new ClassMethods();
        ClassSP_Methods ClassSP_Methods = new ClassSP_Methods();
        ClassEmails ClassEmails = new ClassEmails();

        // Variables de instancia para guardar datos del usuario a recuperar.
        private int idUsuarioRecuperando = 0;
        private string nombreUsuarioRecuperando = "";
        private string correoUsuarioRecuperando = "";

        // Lista de controles dinámicos igual que en FormFirstLogin y FormPSeguridadLogin.
        private List<(int IdPregunta, TextBox Textbox)> controles = new();

        public FormRecuperar()
        {
            InitializeComponent();
        }

        private void FormRecuperar_Load(object sender, EventArgs e)
        {

        }

        //  PASO 1 - Verificar correo y mostrar preguntas de seguridad
        private void btn_Enviar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbox_Correo.Text))
            {
                MessageBox.Show("Por favor, ingresá tu correo electrónico.");
                tbox_Correo.Focus();
                return;
            }

            // SP_VerificarMail usa RETURN en SQL: devuelve 1 si el correo existe, 0 si no.
            int existe = ClassSP_Methods.SP_VerificarMail(tbox_Correo.Text.Trim());
            if (existe == 0)
            {
                MessageBox.Show("El correo ingresado no está registrado en el sistema.");
                return;
            }

            // Obtener ID y nombre del usuario asociado al correo ingresado.
            DataTable datosUsuario = ClassSP_Methods.SP_ObtenerUsuarioPorCorreo(tbox_Correo.Text.Trim());
            if (datosUsuario is null || datosUsuario.Rows.Count == 0)
            {
                MessageBox.Show("No se pudo obtener los datos del usuario. Intentá de nuevo.");
                return;
            }

            // Guardar en variables de instancia.
            idUsuarioRecuperando = Convert.ToInt32(datosUsuario.Rows[0]["ID_Usuario"]);
            nombreUsuarioRecuperando = datosUsuario.Rows[0]["Nombre"].ToString().Trim();
            correoUsuarioRecuperando = tbox_Correo.Text.Trim();

            // Obtener las preguntas de seguridad del usuario para mostrarlas.
            DataTable preguntas = ClassSP_Methods.SP_ObtenerPreguntasSeguridad(idUsuarioRecuperando);
            if (preguntas is null || preguntas.Rows.Count == 0)
            {
                MessageBox.Show("Este usuario no tiene preguntas de seguridad registradas. Contactá al administrador.");
                return;
            }

            // Limpiar y generar los controles dinámicos igual que en otros formularios.
            flowLayoutPanel1.Controls.Clear();
            controles.Clear();
            int i = 3;
            foreach (DataRow row in preguntas.Rows)
            {
                i++;
                int idPregunta = Convert.ToInt32(row["ID_Pregunta"]);
                string textoPregunta = row["Pregunta"].ToString().Trim();

                Label label = new Label
                {
                    Text = textoPregunta,
                    AutoSize = true
                    
                };
                TextBox textBox = new TextBox
                {
                    Width = 200,
                    TabIndex = i
                };

                flowLayoutPanel1.Controls.Add(label);
                flowLayoutPanel1.Controls.Add(textBox);
                controles.Add((idPregunta, textBox));
            }

            lbl_RespuestasSeguridad.Visible = true;
            flowLayoutPanel1.Visible = true;
            btn_EnviarCodigo.Visible = true;

            btn_Enviar.Enabled = false;
            tbox_Correo.Enabled = false;
        }


        //  PASO 2 — Verificar respuestas y enviar contraseña temporal

        // "async void" porque el método llama a "await ClassEmails.sendEmailContraseña(...)".
        private async void btn_EnviarCodigo_Click_1(object sender, EventArgs e)
        {
            if (controles.Any(c => string.IsNullOrWhiteSpace(c.Textbox.Text)))
            {
                MessageBox.Show($"Responda todas las preguntas de seguridad.");
                return;
            }

            // Verificar cada respuesta con la base de datos.
            bool todasCorrectas = true;
            foreach (var (idPregunta, textBox) in controles)
            {
                DataTable resultado = ClassSP_Methods.SP_VerificarRespuestasSeguridad(
                    idUsuarioRecuperando,
                    textBox.Text.Trim()
                );

                if (resultado is null || resultado.Rows.Count == 0)
                {
                    todasCorrectas = false;
                    break;
                }
            }

            if (!todasCorrectas)
            {
                MessageBox.Show("Una o más respuestas son incorrectas. Por favor, verificá tus respuestas.");
                return;
            }

            // -- Generar contraseña temporal
            // Un número de 6 dígitos aleatorio como contraseña temporal.
            Random random = new Random();
            string contrasenaTemp = random.Next(100000, 1000000).ToString();

            // Encriptar la contraseña temporal antes de guardarla en la base de datos.
            string contrasenaTempHash = ClassMethods.encryptToSHA256(contrasenaTemp + nombreUsuarioRecuperando);

            try
            {
                // Guardar la contraseña temporal encriptada en la base de datos.
                // El SP desactiva la contraseña anterior y activa la contraseña temporal.
                ClassSP_Methods.SP_InsertarContrasena(contrasenaTempHash, idUsuarioRecuperando);

                // Enviar al correo la contraseña en texto plano.
                // "await" pausa la ejecución hasta que el mail se envíe, sin bloquear la interfaz gráfica.
                await ClassEmails.sendEmailContraseña(nombreUsuarioRecuperando, correoUsuarioRecuperando, contrasenaTemp);

                MessageBox.Show(
                    "Te enviamos una nueva contraseña temporal al correo."
                );

                // Volver al login para que el usuario entre con la nueva contraseña temporal.
                ClassMethods.abrirFormulario(this, new FormLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recuperar la contraseña: {ex.Message}");
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            ClassMethods.abrirFormulario(this, new FormLogin());
        }
    }
}