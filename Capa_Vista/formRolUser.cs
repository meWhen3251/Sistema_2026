using Capa_Datos;
using Capa_Sesion;

namespace Capa_Vista
{
    public partial class formRolUser : Form
    {
        claseSP claseSP = new claseSP();
        public formRolUser()
        {
            InitializeComponent();
        }

        private void formRolUser_Load(object sender, EventArgs e)
        {
            CargarListaRolesUsuario();
        }

        private void btn_AgregarRol_Click(object sender, EventArgs e)
        {
            if (dgv_TablasRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccioná un rol de la lista.");
                return;
            }

            try
            {
                int idRol = Convert.ToInt32(dgv_TablasRoles.SelectedRows[0].Cells["ID_Rol"].Value);
                string rol = Convert.ToString(dgv_TablasRoles.SelectedRows[0].Cells["Nombre"].Value).Trim();

                claseSP.SP_AgregarRolUsuario(idRol, claseVar.idUsuarioSeleccionado);

                MessageBox.Show($"Rol \"{rol}\" agregado al usuario con éxito.");
                CargarListaRolesUsuario();
                btn_AgregarRol.Text = "Agregar rol (nombre de rol)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el rol: " + ex.Message);
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgv_TablasRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string rol = Convert.ToString(dgv_TablasRoles.Rows[e.RowIndex].Cells["Nombre"].Value).Trim();
            btn_AgregarRol.Text = "Agregar rol (" + rol + ")";
        }

        private void CargarListaRolesUsuario()
        { 
            // El ID viaja en la tabla para identificar la fila seleccionada, pero no se muestra
            dgv_TablasRoles.DataSource = claseSP.SP_ObtenerRolesFaltantesUsuario(claseVar.idUsuarioSeleccionado);

            if (dgv_TablasRoles.Columns["ID_Rol"] != null)
                dgv_TablasRoles.Columns["ID_Rol"].Visible = false;
            if (dgv_TablasRoles.Columns["Nombre"] != null)
                dgv_TablasRoles.Columns["Nombre"].HeaderText = "Nombre";

            dgv_TablasRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_TablasRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_TablasRoles.MultiSelect = false;
            dgv_TablasRoles.ReadOnly = true;
        }
    }
}
