///FormFirstLogin.cs es donde un nuevo usuario podra configurar su contraseña y preguntas de seguridad.

namespace Sistema_de_Gestion_de_Usuario.Forms;

using Sistema_de_Gestion_de_Usuario.Clases;
using Sistema_de_Gestion_de_Usuario.Metodos;
using System.Data;
using static Sistema_de_Gestion_de_Usuario.Clases.ClassData;

public partial class FormFirstLogin : Form
{
    ClassMethods ClassMethods = new ClassMethods();
    ClassSP_Methods ClassSP_Methods = new ClassSP_Methods();

    // Lista de tuplas que asocia cada pregunta (por ID) con su TextBox en pantalla.
    // Una "tupla" es una estructura liviana que agrupa dos valores sin necesitar una clase.
    // (int IdPregunta, TextBox Textbox) se accede como item.IdPregunta, item.Textbox.
    private List<(int IdPregunta, TextBox Textbox)> controles = new();

    public FormFirstLogin()
    {
        InitializeComponent();
    }

    // -- FormFirstLogin_Load
    // Se ejecuta automáticamente cuando el formulario termina de cargarse.
    // Construye dinámicamente la lista de preguntas de seguridad.
    private void FormFirstLogin_Load(object sender, EventArgs e)
    {
        flowLayoutPanel1.Controls.Clear();
        controles.Clear();

        // Obtener todas las preguntas de seguridad de la base de datos.
        DataTable preguntas = ClassSP_Methods.SP_CargaPreguntasSeguridad();

        // Filtra solo las filas donde Habilitada == 1 y las convierte a una lista.
        // "r" representa cada DataRow, Convert.ToInt32 convierte el valor de la celda a int.
        var activas = preguntas
            .AsEnumerable()
            .Where(r => Convert.ToInt32(r["Habilitada"]) == 1)
            .ToList();

        if (activas.Count == 0)
        {
            MessageBox.Show("No hay preguntas de seguridad activas. Contacte al administrador.");
            ClassMethods.abrirFormulario(this, new FormLogin());
            return;
        }

        // contadorPreguntas viene de ClassData.
        // Si vale 0 o supera la cantidad disponible, se muestran todas las activas.
        int cantidad;
        if (contadorPreguntas > 0 && contadorPreguntas <= activas.Count)
            cantidad = contadorPreguntas;
        else
            cantidad = activas.Count;

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
                TabIndex = i+3,
                Width = 200,
            };

            // Agregar los controles al panel visual.
            flowLayoutPanel1.Controls.Add(label);
            flowLayoutPanel1.Controls.Add(textBox);

            // Guardar la relación ID-pregunta con el TextBox para leerlos al enviar.
            controles.Add((idPregunta, textBox));
        }
    }

    // -- Botón "Enviar"
    // Valida que todos los campos estén completos y guarda la nueva contraseña y las respuestas de seguridad en la base de datos.
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
            string hash = ClassMethods.encryptToSHA256(tbox_Contrasena.Text.Trim() + nombreUsuario);
            ClassSP_Methods.SP_InsertarContrasena(hash, idUsuario);

            // -- Guardar respuestas de seguridad
            // Itera sobre la lista de tuplas (IdPregunta, TextBox).
            // Por cada una llama al SP con el ID de la pregunta y el texto de la respuesta.
            foreach (var (idPregunta, textBox) in controles)
            {
                ClassSP_Methods.SP_InsertarRespuestaSeguridad(idPregunta, textBox.Text.Trim(), idUsuario);
            }

            MessageBox.Show("Contraseña y respuestas registradas. Ya podés iniciar sesión.");
            ClassMethods.abrirFormulario(this, new FormLogin());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al guardar: {ex.Message}");
        }
    }

    // -- Botón "Volver"
    private void button1_Click(object sender, EventArgs e)
    {
        ClassMethods.abrirFormulario(this, new FormLogin());
    }
}