///FormPSeguridadLogin.cs se abre una vez que el usuario haya ingresado correctamente el usuario y contraseña
///El usuario debera responder a cada una de las preguntas de seguridad que haya configurado cuando inicio sesion por primera vez.
///Si son correctas, puede ahi acceder al panel principal.

using Sistema_de_Gestion_de_Usuario.Clases;
using Sistema_de_Gestion_de_Usuario.Metodos;
using System.Data;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Usuario.Forms
{
    public partial class FormPSeguridadLogin_Inutilizable : Form
    {
        ClassMethods classMethods = new ClassMethods();
        ClassSP_Methods classSP_Methods = new ClassSP_Methods();

        // Lista de tuplas que vincula cada ID de pregunta con su TextBox en pantalla.
        // Se usa al verificar: se itera y se compara cada respuesta ingresada con la base de datos.
        private List<(int IdPregunta, TextBox Textbox)> controles = new();

        public FormPSeguridadLogin_Inutilizable()
        {
            InitializeComponent();
        }

        // -- FormPSeguridadLogin_Load
        // Carga y muestra dinámicamente las preguntas de seguridad del usuario.
        // Solo se muestran las preguntas que el usuario configuró en FormFirstLogin.
        private void FormPSeguridadLogin_Load(object sender, EventArgs e)
        {
            // Obtiene las preguntas asociadas al usuario logueado (ClassData.idUsuario).
            DataTable preguntas = classSP_Methods.SP_ObtenerPreguntasSeguridad(ClassData.idUsuario);

            if (preguntas is null || preguntas.Rows.Count == 0)
            {
                MessageBox.Show("Este usuario no tiene preguntas de seguridad registradas. Contactá al administrador.");
                return;
            }

            flowLayoutPanel1.Controls.Clear();
            controles.Clear();

            // Iterar sobre cada pregunta y crear un Label + TextBox dinámicamente.
            int i = 1;
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
        }

        // -- Botón "Enviar"
        // Verifica que todas las respuestas ingresadas sean correctas.
        // Si alguna falla, se rechaza el acceso.
        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            // Verificar que no haya campos vacíos.
            if (controles.Any(c => string.IsNullOrWhiteSpace(c.Textbox.Text)))
            {
                MessageBox.Show($"Responda todas las preguntas de seguridad.");
                return;
            }

            bool todasCorrectas = true;

            // Recorrer cada respuesta y consultarla con la base de datos.
            // SP_VerificarRespuestasSeguridad devuelve filas si la respuesta existe para ese usuario, no devuelve filas si es incorrecta.
            foreach (var (idPregunta, textBox) in controles)
            {
                DataTable resultado = classSP_Methods.SP_VerificarRespuestasSeguridad(ClassData.idUsuario,textBox.Text.Trim());

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

            // Si son correctas todas, se envia al usuario al panel general.
            MessageBox.Show("Respuestas respondidas correctamente, bienvenido.");
            classMethods.abrirFormulario(this, new FormPanelGeneral());
        }

        // -- Botón "Volver"
        private void btn_Volver_Click(object sender, EventArgs e)
        {
            classMethods.abrirFormulario(this, new FormLogin());
        }
    }
}