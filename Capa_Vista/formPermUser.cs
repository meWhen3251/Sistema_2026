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
            try
            {
                int idRol = Convert.ToInt32(dgv_TablaPermisos.SelectedRows[0].Cells["ID_Permiso"].Value);
                claseSP.SP_AgregarPermisoUsuario(idRol, claseVar.idUsuario);
                CargarListaPermisoUsuario();
                MessageBox.Show("Permiso agregado al usuario con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vincular permiso: " + ex.Message);
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_TablaPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_TablaPermisos.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                }
                else
                {
                }
            }
            /// PARA PODER CAMBIAR EL NOMBRE DEL BOTON CUANDO SE SELECCIONA UNA PERMISO, NECESITO EVIDENTEMENTE EL NOMBRE DE DICHO PERMISO
            /// ACTUALMENTE LA TABLA PermisosUsuarios_Comp SOLO TIENE ID_Permiso e ID_Usuario + razon (irrelevante a menos que se añada un textbox para añadir dicha razon)
            /// NECESITO O UN SP QUE JUNTE LAS TABLAS Permisos + Usuarios O QUE SE CAMBIE LA TABLA PermisosUsuarios_Comp PARA CONTENER DICHOS DATOS
        }
        private void CargarListaPermisoUsuario()
        {
            dgv_TablaPermisos.DataSource = claseSP.SP_ObtenerPermisosFaltantesUsuario(claseVar.idUsuario);

            // El ID viaja en la tabla para identificar la fila seleccionada, pero no se muestra
            if (dgv_TablaPermisos.Columns["ID_Permiso"] != null)
                dgv_TablaPermisos.Columns["ID_Permiso"].HeaderText = "ID_Permiso";
            if (dgv_TablaPermisos.Columns["Permiso"] != null)
                dgv_TablaPermisos.Columns["Permiso"].HeaderText = "Nombre de Permiso";

            dgv_TablaPermisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_TablaPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_TablaPermisos.MultiSelect = false;
            dgv_TablaPermisos.ReadOnly = true;
        }
    }
}
