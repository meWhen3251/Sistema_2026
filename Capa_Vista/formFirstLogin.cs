///FormFirstLogin.cs es donde un nuevo usuario podra configurar su contraseña y preguntas de seguridad.

using Capa_Datos;
using Capa_Logica;
using System.Data;
using static Capa_Sesion.claseVar;

namespace Capa_Vista
{

    public partial class formFirstLogin : Form
    {
        // Lista de tuplas que asocia cada pregunta (por ID) con su TextBox en pantalla.
        // Una "tupla" es una estructura liviana que agrupa dos valores sin necesitar una clase.
        // (int IdPregunta, TextBox Textbox) se accede como item.IdPregunta, item.Textbox.
        private List<(int IdPregunta, TextBox Textbox)> controles = new();
        claseSP claseSP = new claseSP();
        public formFirstLogin()
        {
            InitializeComponent();
        }

        private void formFirstLogin_Load(object sender, EventArgs e)
        {
            flp_PreguntasSeg.Controls.Clear();
            controles.Clear();

            // Obtener todas las preguntas de seguridad de la base de datos.
            DataTable preguntas = claseSP.SP_CargaPreguntasSeguridad();

            // Filtra solo las filas donde Habilitada == 1 y las convierte a una lista.
            // "r" representa cada DataRow, Convert.ToInt32 convierte el valor de la celda a int.
            var activas = preguntas
                .AsEnumerable()
                .Where(r => Convert.ToInt32(r["Habilitada"]) == 1)
                .ToList();

            if (activas.Count == 0)
            {
                MessageBox.Show("No hay preguntas de seguridad activas. Contacte al administrador.");
                formLogin formLogin = new formLogin();
                this.Hide();
                formLogin.Show();
                return;
            }

            // contadorPreguntas viene de ClassData.
            // Si vale 0 o supera la cantidad disponible, se muestran todas las activas.
            int cantidad;
            if (contadorPreguntas > 0 && contadorPreguntas <= activas.Count)
            {
                cantidad = contadorPreguntas;
            }
            else
            {
                cantidad = activas.Count;

            }

            // -- Generar preguntas dinámicamente
            // Por cada pregunta activa se crean un Label y un TextBox en código y se agregan al FlowLayoutPanel.

            for (int i = 0; i < cantidad; i++)
            {
                int idPregunta = Convert.ToInt32(activas[i]["ID_Pregunta"]);
                string textoPregunta = activas[i]["Pregunta"].ToString().Trim();

                // Label: muestra el texto de la pregunta.
                Label label = new Label
                {
                    Text = textoPregunta,
                    AutoSize = true,
                };

                // TextBox: campo donde el usuario escribe la respuesta.
                TextBox textBox = new TextBox
                {
                    Name = "tbox_PS_" + i,
                    TabIndex = i + 3,
                    Width = 200,
                };

                // Agregar los controles al panel visual.
                flp_PreguntasSeg.Controls.Add(label);
                flp_PreguntasSeg.Controls.Add(textBox);

                // Guardar la relación ID-pregunta con el TextBox para leerlos al enviar.
                controles.Add((idPregunta, textBox));
            }
        }

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            // Any() recorre la lista y retorna true si al menos un elemento cumple la condición.
            // Se verifica si algún TextBox de respuesta está vacío.
            if (controles.Any(c => string.IsNullOrWhiteSpace(c.Textbox.Text)))
            {
                MessageBox.Show($"Por favor, completá las {controles.Count} respuestas.");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbox_Contrasena.Text))
            {
                MessageBox.Show("Por favor, ingresá tu nueva contraseña.");
                tbox_Contrasena.Focus();
                return;
            }

            try
            {
                // -- Guardar nueva contraseña
                // Se encripta igual que en el login: SHA256(contraseña + nombreUsuario)
                // nombreUsuario e idUsuario vienen de ClassData (se llenaron en el login).
                string hash = claseMetodos.encryptToSHA256(tbox_Contrasena.Text.Trim() + nombreUsuario);
                claseSP.SP_InsertarContrasena(hash, idUsuario);

                // -- Guardar respuestas de seguridad
                // Itera sobre la lista de tuplas (IdPregunta, TextBox).
                // Por cada una llama al SP con el ID de la pregunta y el texto de la respuesta.
                foreach (var (idPregunta, textBox) in controles)
                {
                    claseSP.SP_InsertarRespuestaSeguridad(idPregunta, textBox.Text.Trim(), idUsuario);
                }

                MessageBox.Show("Contraseña y respuestas registradas. Ya podés iniciar sesión.");
                formLogin formLogin = new formLogin();
                this.Hide();
                formLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}");
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
