using Capa_Datos;
using Capa_Sesion;

namespace Capa_Vista
{
    public partial class formPanelAdmin : Form
    {
        claseSP claseSP = new claseSP();
        public formPanelAdmin()
        {
            InitializeComponent();
        }

        private void formPanelAdmin_Load(object sender, EventArgs e)
        {
            CargarListaUsuarios();
        }
        private void btn_AjusteUserSelect_Click(object sender, EventArgs e)
        {
            if (dgv_ListaUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccioná un usuario de la lista.");
                return;
            }

            claseVar.idUsuario = Convert.ToInt32(dgv_ListaUsuarios.SelectedRows[0].Cells["ID_Usuario"].Value);
            claseVar.nombreUsuario = Convert.ToString(dgv_ListaUsuarios.SelectedRows[0].Cells["NombreUsuario"].Value);

            var formAjuste = new formAjusteUsuario();
            formAjuste.FormClosed += (s, args) => { this.Show(); CargarListaUsuarios(); };
            formAjuste.Show();
            this.Hide();
        }

        private void btn_AjusteRoles_Click(object sender, EventArgs e)
        {
            var formAjusteRol = new formAjusteRol();
            formAjusteRol.FormClosed += (s, args) => this.Show();
            formAjusteRol.Show();
            this.Hide();
        }

        private void btn_AjustePreguntas_Click(object sender, EventArgs e)
        {
            var formAjustePregunta = new formAjustePregunta();
            formAjustePregunta.FormClosed += (s, args) => this.Show();
            formAjustePregunta.Show();
            this.Hide();
        }

        private void btn_ConfigSistema_Click(object sender, EventArgs e)
        {

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            formPanelGeneral formPanelGeneral = new formPanelGeneral();
            formPanelGeneral.Show();
            this.Hide();
        }
        private void CargarListaUsuarios()
        {
            dgv_ListaUsuarios.DataSource = claseSP.SP_CargaUsuariosDetalle();

            // El ID viaja en la tabla para identificar la fila seleccionada, pero no se muestra
            if (dgv_ListaUsuarios.Columns["ID_Usuario"] != null)
                dgv_ListaUsuarios.Columns["ID_Usuario"].Visible = false;
            if (dgv_ListaUsuarios.Columns["NombreUsuario"] != null)
                dgv_ListaUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario";
            if (dgv_ListaUsuarios.Columns["Nombre"] != null)
                dgv_ListaUsuarios.Columns["Nombre"].HeaderText = "Nombre";
            if (dgv_ListaUsuarios.Columns["Apellido"] != null)
                dgv_ListaUsuarios.Columns["Apellido"].HeaderText = "Apellido";
            if (dgv_ListaUsuarios.Columns["Correo"] != null)
                dgv_ListaUsuarios.Columns["Correo"].HeaderText = "Correo Electrónico";

            dgv_ListaUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ListaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ListaUsuarios.MultiSelect = false;
            dgv_ListaUsuarios.ReadOnly = true;
        }
    }
}
