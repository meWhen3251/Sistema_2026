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
            try
            {
                int idRol = Convert.ToInt32(dgv_TablasRoles.SelectedRows[0].Cells["ID_Rol"].Value);
                //claseSP.SP_AgregarRolUsuario(idRol, claseVar.idUsuario); //SP_AgregarRolUsuario se tiene que cambiar para que tenga que necesite ID_Rol e ID_Usuario en vez del nombre del rol y nombre de usuario
                CargarListaRolesUsuario();
                MessageBox.Show("Usuario agregado a la familia con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vincular familia: " + ex.Message);
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            formPanelAdmin formPanelAdmin = new formPanelAdmin();
            formPanelAdmin.Show();
            this.Hide();
        }


        private void dgv_TablasRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dgv_TablaFamilia.Rows[e.RowIndex];

            //    if (row.Cells[0].Value != null)
            //    {
            //    }
            //    else
            //    {
            //    }
            //}
            ///PARA PODER CAMBIAR EL NOMBRE DEL BOTON CUANDO SE SELECCIONA UNA ROL, NECESITO EVIDENTEMENTE EL NOMBRE DE DICHO ROL
            /// ACTUALMENTE LA TABLA RolesUsuarios_Comp SOLO TIENE ID_Rol e ID_Usuario + razon (irrelevante a menos que se añada un textbox para añadir dicha razon)
            /// NECESITO O UN SP QUE JUNTE LAS TABLAS Roles + Usuarios O QUE SE CAMBIE LA TABLA RolesUsuarios_Comp PARA CONTENER DICHOS DATOS
        }

        private void CargarListaRolesUsuario()
        {
            //dgv_TablasRoles.DataSource = //SP_CargaRolesUsuarios FALTANTE//

            // El ID viaja en la tabla para identificar la fila seleccionada, pero no se muestra
            if (dgv_TablasRoles.Columns["ID_Rol"] != null)
                dgv_TablasRoles.Columns["ID_Rol"].HeaderText = "ID_Rol";
            if (dgv_TablasRoles.Columns["ID_Usuario"] != null)
                dgv_TablasRoles.Columns["ID_Usuario"].HeaderText = "ID_Usuario";

            dgv_TablasRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_TablasRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_TablasRoles.MultiSelect = false;
            dgv_TablasRoles.ReadOnly = true;
        }
    }
}
