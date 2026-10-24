using Capa_Datos;
using Capa_Sesion;
using System.Data;

namespace Capa_Vista
{
    public partial class formAjusteUsuario : Form
    {
        claseSP claseSP = new claseSP();
        public formAjusteUsuario()
        {
            InitializeComponent();
        }

        private void formAjusteUsuario_Load(object sender, EventArgs e)
        {
            lbl_NombreUsuario.Text = "Usuario: " + claseVar.nombreUsuario.ToString();
            //lbl_TiempoUltimaPass.Text = "Ultimo cambio de contraseña: "+ ///FALTA SP PARA REGISTRAR EL TIEMPO APROX, PARA MI ES NO TENER ESTO PARA AHORRARNOS TIEMPO Y PROBLEMAS
            CargarPreguntasRespondidas();
            CargarDatosUsuario();
            
        }

        private void btn_AgregarRol_Click(object sender, EventArgs e)
        {
            ///NECESARIO UN SP PARA CARGAR ROLES VINCULADOS A UN USUARIO
        }

        private void btn_AgregarFamilia_Click(object sender, EventArgs e)
        {
            ///NECESARIO UN SP PARA CARGAR LAS FAMILIAS VINCULADAS A UN USUARIO
        }

        private void btn_AgregarPermiso_Click(object sender, EventArgs e)
        {
            ///NECESARIO UN SP PARA CARGAR LOS PERMISOS VINCULADOS A UN USUARIO
        }
        private void CargarPreguntasRespondidas()
        {
            DataTable preguntas = claseSP.SP_ObtenerPreguntasSeguridad(claseVar.idUsuario);
            if (preguntas is null || preguntas.Rows.Count == 0)
            {
                MessageBox.Show("Este usuario no tiene preguntas de seguridad registradas. Contactá al administrador.");
                return;
            }
            foreach (DataRow row in preguntas.Rows)
            {
                string textoPregunta = row["Pregunta"].ToString().Trim();
                lbox_PSRespondidas.Items.Add(textoPregunta);
            }
        }
        private void AgregarLabelAlPanel(string titulo, string valor, string nombreControl)
        {
            Label lbl = new Label();
            lbl.Name = nombreControl;
            lbl.Text = $"{titulo} {valor}";
            lbl.AutoSize = true;
            lbl.Margin = new Padding(5, 8, 5, 8);

            flp_InformacionUsuario.Controls.Add(lbl);
        }

        private void CargarDatosUsuario()
        {
            int idUsuario = claseVar.idUsuario;
            DataTable dtUsuario = claseSP.SP_CargaDatosUsuario(idUsuario);

            if (dtUsuario != null && dtUsuario.Rows.Count > 0)
            {
                DataRow row = dtUsuario.Rows[0];

                // 4. Crear y agregar las etiquetas de texto dinámicamente con los datos de la fila
                AgregarLabelAlPanel("ID de Usuario:", row["ID_Usuario"].ToString(), "lbl_IDUsuario");
                AgregarLabelAlPanel("Nombre de Cuenta:", row["NombreUsuario"].ToString(), "lbl_NombreUsuario");
                AgregarLabelAlPanel("Nombre:", row["Nombre"].ToString(), "lbl_Nombre");
                AgregarLabelAlPanel("Apellido:", row["Apellido"].ToString(), "lbl_Apellido");
                AgregarLabelAlPanel("Correo Electrónico:", row["Correo"].ToString(), "lbl_Correo");
            }
            else
            {
                Label lblNoData = new Label { Text = "No se encontró información para este usuario.", AutoSize = true };
                flp_InformacionUsuario.Controls.Add(lblNoData);
            }
        }
    }
}
