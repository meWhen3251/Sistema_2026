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
            CargarListaFamiliaUsuario();
        }
        private void btn_AgregarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                int idFamilia = Convert.ToInt32(dgv_TablaFamilia.SelectedRows[0].Cells["ID_Familia"].Value);
                claseSP.SP_AgregarFamiliaUsuario(idFamilia, claseVar.idUsuario);
                CargarListaFamiliaUsuario();
                MessageBox.Show("Usuario agregado a la familia con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vincular familia: " + ex.Message);
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_TablaFamilia_CellClick(object sender, DataGridViewCellEventArgs e)
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
            /// PARA PODER CAMBIAR EL NOMBRE DEL BOTON CUANDO SE SELECCIONA UNA FAMILIA, NECESITO EVIDENTEMENTE EL NOMBRE DE DICHA FAMILIA
            /// ACTUALMENTE LA TABLA FamiliaUsuarios_Comp SOLO TIENE ID_Familia e ID_Usuario + razon (irrelevante a menos que se añada un textbox para añadir dicha razon)
            /// NECESITO O UN SP QUE JUNTE LAS TABLAS Familia + Usuarios O QUE SE CAMBIE LA TABLA FamiliaUsuarios_Comp PARA CONTENER DICHOS DATOS
        }

        private void CargarListaFamiliaUsuario()
        {
            dgv_TablaFamilia.DataSource = claseSP.SP_ObtenerFamiliasFaltantesUsuario(claseVar.idUsuario);

            // El ID viaja en la tabla para identificar la fila seleccionada, pero no se muestra
            if (dgv_TablaFamilia.Columns["ID_Familia"] != null)
                dgv_TablaFamilia.Columns["ID_Familia"].HeaderText = "ID_Familia";
            if (dgv_TablaFamilia.Columns["Nombre"] != null)
                dgv_TablaFamilia.Columns["Nombre"].HeaderText = "Nombre";

            dgv_TablaFamilia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_TablaFamilia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_TablaFamilia.MultiSelect = false;
            dgv_TablaFamilia.ReadOnly = true;
        }
    }
}
