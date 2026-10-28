using Capa_Datos;
using Capa_Sesion;

namespace Capa_Vista
{
    public partial class formFamUser : Form
    {
        claseSP claseSP = new claseSP();

        public formFamUser()
        {
            InitializeComponent();
        }

        private void formFamUser_Load(object sender, EventArgs e)
        {
            CargarListaFamilias();
        }

        private void btn_AgregarFamilia_Click(object sender, EventArgs e)
        {
            if (dgv_TablaFamilia.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccioná una familia de la lista.");
                return;
            }

            try
            {
                int idFamilia = Convert.ToInt32(dgv_TablaFamilia.SelectedRows[0].Cells["ID_Familia"].Value);
                string familia = Convert.ToString(dgv_TablaFamilia.SelectedRows[0].Cells["Nombre"].Value).Trim();

                claseSP.SP_AgregarFamiliaUsuario(idFamilia, claseVar.idUsuarioSeleccionado);

                MessageBox.Show("Usuario agregado a la familia '"+ familia+"' con éxito.");
                CargarListaFamilias();
                btn_AgregarFamilia.Text = "Agregar a familia (nombre de familia)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vincular la familia: " + ex.Message);
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();   // formAjusteUsuario lo abrió como hijo, recarga sus listas y vuelve a mostrarse solo
        }

        // Al hacer clic en una fila, el botón muestra el nombre de la familia elegida
        private void dgv_TablaFamilia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // clic en el encabezado de una columna

            string familia = Convert.ToString(dgv_TablaFamilia.Rows[e.RowIndex].Cells["Nombre"].Value).Trim();
            btn_AgregarFamilia.Text = "Agregar a familia (" + familia + ")";
        }

        // Muestra solo las familias a las que el usuario seleccionado TODAVÍA NO pertenece
        private void CargarListaFamilias()
        {
            dgv_TablaFamilia.DataSource = claseSP.SP_ObtenerFamiliasFaltantesUsuario(claseVar.idUsuarioSeleccionado);

            // El ID viaja en la tabla para identificar la fila seleccionada, pero no se muestra
            if (dgv_TablaFamilia.Columns["ID_Familia"] != null)
                dgv_TablaFamilia.Columns["ID_Familia"].Visible = false;
            if (dgv_TablaFamilia.Columns["Nombre"] != null)
                dgv_TablaFamilia.Columns["Nombre"].HeaderText = "Nombre de Familia";

            dgv_TablaFamilia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_TablaFamilia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_TablaFamilia.MultiSelect = false;
            dgv_TablaFamilia.ReadOnly = true;

            dgv_TablaFamilia.ClearSelection();
            dgv_TablaFamilia.CurrentCell = null;
        }
    }
}
