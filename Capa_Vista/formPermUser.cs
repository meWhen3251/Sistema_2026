using Capa_Datos;
using Capa_Sesion;

namespace Capa_Vista
{
    public partial class formPermUser : Form
    {
        claseSP claseSP = new claseSP();

        public formPermUser()
        {
            InitializeComponent();
        }

        private void formPermUser_Load(object sender, EventArgs e)
        {
            CargarListaPermisoUsuario();
        }

        private void btn_AgregarPermiso_Click(object sender, EventArgs e)
        {
            if (dgv_TablaPermisos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccioná un permiso de la lista.");
                return;
            }

            try
            {
                int idPermiso = Convert.ToInt32(dgv_TablaPermisos.SelectedRows[0].Cells["ID_Permiso"].Value);
                string permiso = Convert.ToString(dgv_TablaPermisos.SelectedRows[0].Cells["Permiso"].Value).Trim();

                claseSP.SP_AgregarPermisoUsuario(idPermiso, claseVar.idUsuarioSeleccionado);

                MessageBox.Show("Permiso: '"+ permiso + "' agregado al usuario con éxito.");
                CargarListaPermisoUsuario();
                btn_AgregarPermiso.Text = "Agregar permiso (nombre de permiso)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vincular el permiso: " + ex.Message);
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();   // formAjusteUsuario lo abrió como hijo, recarga sus listas y vuelve a mostrarse solo
        }

        // Al hacer clic en una fila, el botón muestra el nombre del permiso elegido
        private void dgv_TablaPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // clic en el encabezado de una columna

            string permiso = Convert.ToString(dgv_TablaPermisos.Rows[e.RowIndex].Cells["Permiso"].Value).Trim();
            btn_AgregarPermiso.Text = "Agregar permiso (" + permiso + ")";
        }

        // Muestra solo los permisos que el usuario seleccionado TODAVÍA NO tiene
        private void CargarListaPermisoUsuario()
        {
            dgv_TablaPermisos.DataSource = claseSP.SP_ObtenerPermisosFaltantesUsuario(claseVar.idUsuarioSeleccionado);

            // El ID viaja en la tabla para identificar la fila seleccionada, pero no se muestra
            if (dgv_TablaPermisos.Columns["ID_Permiso"] != null)
                dgv_TablaPermisos.Columns["ID_Permiso"].Visible = false;
            if (dgv_TablaPermisos.Columns["Permiso"] != null)
                dgv_TablaPermisos.Columns["Permiso"].HeaderText = "Nombre de Permiso";

            dgv_TablaPermisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_TablaPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_TablaPermisos.MultiSelect = false;
            dgv_TablaPermisos.ReadOnly = true;

            dgv_TablaPermisos.ClearSelection();
            dgv_TablaPermisos.CurrentCell = null;
        }
    }
}
