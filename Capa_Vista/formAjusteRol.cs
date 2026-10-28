using Capa_Datos;
using System.Data;

namespace Capa_Vista
{
    public partial class formAjusteRol : Form
    {
        claseSP claseSP = new claseSP();
        string rolSeleccionado = "";   // nombre del rol que se está modificando
        int idRolSeleccionado = 0;     // ID del rol que se está modificando (0 = ninguno elegido)

        public formAjusteRol()
        {
            InitializeComponent();
        }

        private void formAjusteRol_Load(object sender, EventArgs e)
        {
            // Largo máximo = largo de la columna Nombre de la tabla Roles
            tbox_RolModificado.MaxLength = 30;
            tbox_NuevoRol.MaxLength = 30;

            CargarListaRoles();
        }

        // Elige el rol de la grilla para modificarlo: muestra su nombre en las dos cajas
        private void btn_ModificarRol_Click(object sender, EventArgs e)
        {
            if (dgv_Roles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccioná un rol de la lista.");
                return;
            }

            string nombre = Convert.ToString(dgv_Roles.SelectedRows[0].Cells["Nombre"].Value).Trim();

            if (EsRolBase(nombre))
            {
                MessageBox.Show("Los roles 'Administrador' y 'Usuario' no se pueden modificar.");
                return;
            }

            idRolSeleccionado = Convert.ToInt32(dgv_Roles.SelectedRows[0].Cells["ID_Rol"].Value);
            rolSeleccionado = nombre;

            tbox_RolSeleccionado.Text = rolSeleccionado;
            tbox_RolModificado.Text = rolSeleccionado;
        }

        // Guarda el nombre nuevo del rol elegido con "Modificar"
        private void btn_ActualizarRol_Click(object sender, EventArgs e)
        {
            if (idRolSeleccionado == 0)
            {
                MessageBox.Show("Primero seleccioná un rol y apretá \"Modificar\".");
                return;
            }

            string nuevoNombre = tbox_RolModificado.Text.Trim();

            if (nuevoNombre == "")
            {
                MessageBox.Show("El nombre del rol no puede estar vacio");
                return;
            }

            if (EsRolBase(nuevoNombre))
            {
                MessageBox.Show("Ese nombre está reservado para un rol del sistema.");
                return;
            }

            try
            {
                claseSP.SP_ModificarRol(idRolSeleccionado, nuevoNombre);
                CargarListaRoles();
                MessageBox.Show("Rol modificado con exito.");

                idRolSeleccionado = 0;
                rolSeleccionado = "";
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
            string nuevoRol = tbox_NuevoRol.Text.Trim();

            if (nuevoRol == "")
            {
                MessageBox.Show("El nombre del rol no puede estar vacio");
                return;
            }

            if (EsRolBase(nuevoRol))
            {
                MessageBox.Show("Ese nombre está reservado para un rol del sistema.");
                return;
            }

            // No puede haber dos roles con el mismo nombre
            DataTable rolesActuales = (DataTable)dgv_Roles.DataSource;
            foreach (DataRow fila in rolesActuales.Rows)
            {
                if (fila["Nombre"].ToString().Trim().ToLower() == nuevoRol.ToLower())
                {
                    MessageBox.Show("Ya existe un rol con ese nombre.");
                    return;
                }
            }

            try
            {
                claseSP.SP_InsertarRol(nuevoRol);
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
            this.Close();   // formPanelAdmin lo abrió como hijo y vuelve a mostrarse solo
        }

        // "Administrador" y "Usuario" son roles del sistema: el sistema los busca por nombre, así que
        // no se pueden renombrar, eliminar ni crear de nuevo.
        private bool EsRolBase(string nombre)
        {
            string minuscula = nombre.Trim().ToLower();
            return minuscula == "administrador" || minuscula == "usuario";
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
