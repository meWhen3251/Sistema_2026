using Capa_Datos;
using Capa_Sesion;
namespace Capa_Vista
{
    public partial class formAjusteRol : Form
    {
        claseSP claseSP = new claseSP();
        string rolSeleccionado;
        public formAjusteRol()
        {
            InitializeComponent();
        }

        private void formAjusteRol_Load(object sender, EventArgs e)
        {
            CargarListaRoles();
        }
        private void btn_ModificarRol_Click(object sender, EventArgs e)
        {
            if (dgv_Roles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccioná un rol de la lista.");
                return;
            }
            try
            {
                rolSeleccionado = Convert.ToString(dgv_Roles.SelectedRows[0].Cells["Nombre"].Value);

                tbox_RolSeleccionado.Text = rolSeleccionado;
                tbox_RolModificado.Text = rolSeleccionado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar pregunta: " + ex.Message);
            }
        }

        private void btn_EliminarRol_Click(object sender, EventArgs e)
        {
            ///HACER SABER SI ES NECESARIO O NO
        }
        private void btn_ActualizarRol_Click(object sender, EventArgs e)
        {
            if (tbox_RolModificado.Text == "")
            {
                MessageBox.Show("El nombre del rol no puede estar vacio");
                return;
            }
            try
            {
                claseSP.SP_ModificarRol(Convert.ToInt32(dgv_Roles.SelectedRows[0].Cells["ID_Rol"]), tbox_RolModificado.Text);
                CargarListaRoles();
                MessageBox.Show("Pregunta actualizada con exito.");
                tbox_RolModificado.Text = "";
                tbox_RolSeleccionado.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }
        private void btn_AgregarRol_Click(object sender, EventArgs e)
        {
            if (tbox_NuevoRol.Text == "")
            {
                MessageBox.Show("El nombre del rol no puede estar vacio");
                return;
            }
            try
            {
                claseSP.SP_InsertarRol(tbox_NuevoRol.Text);
                CargarListaRoles();
                MessageBox.Show("Rol agregado con exito");
                tbox_NuevoRol.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear nuevo rol: " + ex.Message);
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            formPanelAdmin formPanelAdmin = new formPanelAdmin();
            formPanelAdmin.Show();
            this.Hide();
        }
        private void CargarListaRoles()
        {
            dgv_Roles.DataSource = claseSP.SP_CargaRoles();

            // El ID viaja en la tabla para identificar la fila seleccionada, pero no se muestra
            if (dgv_Roles.Columns["ID_Rol"] != null)
                dgv_Roles.Columns["ID_Rol"].HeaderText = "ID_Rol";
            if (dgv_Roles.Columns["Nombre"] != null)
                dgv_Roles.Columns["Nombre"].HeaderText = "Nombre";
            if (dgv_Roles.Columns["Descripcion"] != null)
                dgv_Roles.Columns["Descripcion"].HeaderText = "Descripcion";

            dgv_Roles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Roles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Roles.MultiSelect = false;
            dgv_Roles.ReadOnly = true;
        }


    }
}
