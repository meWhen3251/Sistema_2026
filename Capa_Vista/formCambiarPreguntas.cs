/// formCambioPreguntas.cs: el usuario que inició sesión (administrador o común) cambia sus preguntas de seguridad.
///
/// CÓMO FUNCIONA:
///   1) Al abrirse, muestra las preguntas de seguridad que le tocan (activas, al azar y la cantidad configurada),
///      cada una con una caja para responder.
///   2) Al apretar "Guardar":
///        - verifica la contraseña actual (para que nadie pueda cambiar las respuestas de una sesión abierta),
///        - verifica que no haya respuestas vacías,
///        - borra las respuestas anteriores y guarda las nuevas.

using Capa_Datos;
using Capa_Logica;
using Capa_Sesion;
using System.Data;

namespace Capa_Vista
{
    public partial class formCambiarPreguntas : Form
    {
        claseSP claseSP = new claseSP();

        // Dos listas "en paralelo": la posición 0 de las dos es la primera pregunta, la 1 la segunda, etc.
        private List<int> idPreguntas = new List<int>();            // ID de cada pregunta que se muestra
        private List<TextBox> cantTextboxes = new List<TextBox>();  // caja donde se escribe cada respuesta
        public formCambiarPreguntas()
        {
            InitializeComponent();
        }

        // =====================================================================
        //  AL ABRIR: mostrar las preguntas
        // =====================================================================

        private void formCambiarPreguntas_Load(object sender, EventArgs e)
        {
            flp_PreguntaSeg.Controls.Clear();
            idPreguntas.Clear();
            cantTextboxes.Clear();

            // Las preguntas que le tocan: las activas, mezcladas al azar, y la cantidad configurada
            List<DataRow> preguntas = politicasDeSeguridad.PreguntasParaResponder();

            if (preguntas.Count == 0)
            {
                MessageBox.Show("No hay preguntas de seguridad activas. Contactá al administrador.");
                BeginInvoke(new Action(Close));   // se cierra un instante después: un formulario no puede cerrarse dentro de su propio Load
                return;
            }

            // Por cada pregunta, crear un Label (el texto) y un TextBox (la respuesta)
            foreach (DataRow pregunta in preguntas)
            {
                Label etiqueta = new Label();
                etiqueta.Text = pregunta["Pregunta"].ToString().Trim();
                etiqueta.AutoSize = true;

                TextBox caja = new TextBox();
                caja.Width = 250;
                caja.MaxLength = 45;   // largo máximo de la columna Respuesta en la base de datos

                flp_PreguntaSeg.Controls.Add(etiqueta);
                flp_PreguntaSeg.Controls.Add(caja);

                idPreguntas.Add(Convert.ToInt32(pregunta["ID_Pregunta"]));
                cantTextboxes.Add(caja);
            }
        }

        // =====================================================================
        //  GUARDAR
        // =====================================================================

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            // Paso 1: la contraseña actual tiene que ser correcta
            if (string.IsNullOrWhiteSpace(tbox_Contrasena.Text))
            {
                MessageBox.Show("Por favor, ingresá tu contraseña actual.");
                tbox_Contrasena.Focus();
                return;
            }

            // Se hashea igual que en el login: SHA256(contraseña + nombre de usuario)
            string hashActual = claseMetodos.encryptToSHA256(tbox_Contrasena.Text.Trim() + claseVar.nombreUsuario);
            DataTable login = claseSP.SP_LoginUsuario(claseVar.nombreUsuario, hashActual);
            if (login.Rows.Count == 0)
            {
                MessageBox.Show("La contraseña actual no es correcta.");
                tbox_Contrasena.Focus();
                return;
            }

            // Paso 2: no puede haber respuestas vacías
            foreach (TextBox caja in cantTextboxes)
            {
                if (string.IsNullOrWhiteSpace(caja.Text))
                {
                    MessageBox.Show("Por favor, respondé todas las preguntas.");
                    caja.Focus();
                    return;
                }
            }

            // Paso 3: borrar las respuestas anteriores y guardar las nuevas
            try
            {
                claseSP.SP_EliminarRespuestasUsuario(claseVar.idUsuario);

                for (int i = 0; i < idPreguntas.Count; i++)
                {
                    claseSP.SP_InsertarRespuestaSeguridad(idPreguntas[i], cantTextboxes[i].Text.Trim(), claseVar.idUsuario);
                }

                MessageBox.Show("Tus preguntas de seguridad se actualizaron correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar las preguntas: " + ex.Message);
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    