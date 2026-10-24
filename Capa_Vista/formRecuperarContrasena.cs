///FormRecuperar.cs es el formulario de recuperacion de contraseña en caso de que esta sea olvidada.

using Capa_Datos;
using Capa_Logica;
using Capa_Servicios;
using System.Data;

namespace Capa_Vista
{
    public partial class formRecuperarContrasena : Form
    {
        claseSP claseSP = new claseSP();
        claseEmail claseEmail = new claseEmail();

        // Variables de instancia para guardar datos del usuario a recuperar.
        private int idUsuarioRecuperando = 0;
        private string nombreUsuarioRecuperando = "";
        private string correoUsuarioRecuperando = "";

        // Lista de controles dinámicos igual que en FormFirstLogin y FormPSeguridadLogin.
        private List<(int IdPregunta, TextBox Textbox)> controles = new();
        public formRecuperarContrasena()
        {
            InitializeComponent();
        }

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbox_Correo.Text))
            {
                MessageBox.Show("Por favor, ingresá tu correo electrónico.");
                tbox_Correo.Focus();
                return;
            }

            // SP_VerificarMail usa RETURN en SQL: devuelve 1 si el correo existe, 0 si no.
            int existe = claseSP.SP_VerificarMail(tbox_Correo.Text.Trim());
            if (existe == 0)
            {
                MessageBox.Show("El correo ingresado no está registrado en el sistema.");
                return;
            }

            // Obtener ID y nombre del usuario asociado al correo ingresado.
            DataTable datosUsuario = claseSP.SP_ObtenerUsuarioPorCorreo(tbox_Correo.Text.Trim());
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
            DataTable preguntas = claseSP.SP_ObtenerPreguntasSeguridad(idUsuarioRecuperando);
            if (preguntas is null || preguntas.Rows.Count == 0)
            {
                MessageBox.Show("Este usuario no tiene preguntas de seguridad registradas. Contactá al administrador.");
                return;
            }

            // Limpiar y generar los controles dinámicos igual que en otros formularios.
            flp_PSeguridad.Controls.Clear();
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

                flp_PSeguridad.Controls.Add(label);
                flp_PSeguridad.Controls.Add(textBox);
                controles.Add((idPregunta, textBox));
            }

            lbl_RSeguridad.Visible = true;
            flp_PSeguridad.Visible = true;
            btn_EnviarCodigo.Visible = true;

            btn_Enviar.Enabled = false;
            tbox_Correo.Enabled = false;
        }

        private async void btn_EnviarCodigo_Click(object sender, EventArgs e)
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
                DataTable resultado = claseSP.SP_VerificarRespuestasSeguridad(
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
            string contrasenaTempHash = claseMetodos.encryptToSHA256(contrasenaTemp + nombreUsuarioRecuperando);

            try
            {
                // Guardar la contraseña temporal encriptada en la base de datos.
                // El SP desactiva la contraseña anterior y activa la contraseña temporal.
                claseSP.SP_InsertarContrasena(contrasenaTempHash, idUsuarioRecuperando);

                // Enviar al correo la contraseña en texto plano.
                // "await" pausa la ejecución hasta que el mail se envíe, sin bloquear la interfaz gráfica.
                await claseEmail.sendEmailContraseña(nombreUsuarioRecuperando, correoUsuarioRecuperando, contrasenaTemp);

                MessageBox.Show(
                    "Te enviamos una nueva contraseña temporal al correo."
                );

                // Volver al login para que el usuario entre con la nueva contraseña temporal.
                formLogin formLogin = new formLogin();
                this.Hide();
                formLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recuperar la contraseña: {ex.Message}");
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            formLogin formLogin = new formLogin();
            this.Hide();
            formLogin.Show();
        }
    }
}
