using Capa_Datos;
using Capa_Logica;
using Capa_Servicios;
using Capa_Sesion;
using System.Data;
using System.Security.Cryptography;

namespace Capa_Vista
{
    public partial class formAjusteUsuario : Form
    {
        claseSP claseSP = new claseSP();
        claseEmail claseEmail = new claseEmail();

        public formAjusteUsuario()
        {
            InitializeComponent();
        }

        private void formAjusteUsuario_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            CargarRoles();
            CargarFamilias();
            CargarPermisos();
            CargarPreguntasRespondidas();
        }

        // =================================================================================//
        //  DATOS DEL USUARIO
        // =================================================================================//
        private void CargarDatosUsuario()
        {
            flp_InformacionUsuario.Controls.Clear();

            DataTable dtUsuario = claseSP.SP_ObtenerDatosUsuario(claseVar.idUsuario);

            if (dtUsuario == null || dtUsuario.Rows.Count == 0)
            {
                Label lblNoData = new Label { Text = "No se encontró información para este usuario.", AutoSize = true };
                flp_InformacionUsuario.Controls.Add(lblNoData);
                return;
            }

            DataRow row = dtUsuario.Rows[0];

            lbl_NombreUsuario.Text = "Usuario: " + row["NombreUsuario"].ToString().Trim(); //Usuario del cual se muestra la informacion

            AgregarLabelAlPanel("ID de Usuario:", row["ID_Usuario"].ToString(), "lbl_info_ID");
            AgregarLabelAlPanel("Nombre de Cuenta:", row["NombreUsuario"].ToString().Trim(), "lbl_info_Cuenta");
            AgregarLabelAlPanel("Nombre:", row["Nombre"].ToString().Trim(), "lbl_info_Nombre");
            AgregarLabelAlPanel("Apellido:", row["Apellido"].ToString().Trim(), "lbl_info_Apellido");
            AgregarLabelAlPanel("Correo Electrónico:", row["Correo"].ToString().Trim(), "lbl_info_Correo");

            // Último cambio de contraseña
            if (row["UltimaPass"] != DBNull.Value)
            {
                int dias = (DateTime.Today - Convert.ToDateTime(row["UltimaPass"]).Date).Days;
                string tiempo = dias <= 0 ? "hoy" : dias == 1 ? "hace 1 día" : $"hace {dias} días";
                lbl_TiempoUltimaPass.Text = "Último cambio de contraseña: " + tiempo;
            }
            else
            {
                lbl_TiempoUltimaPass.Text = "Último cambio de contraseña: sin datos";
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

        // ================================================================================= //
        //  LISTAS: roles, familias y permisos del usuario
        //  Cada ListBox MUESTRA el nombre (DisplayMember) y guarda el ID por detrás (ValueMember),
        //  sin mostrarlo: el ID se usa solo al quitar.
        // ================================================================================= //
        private void CargarLista(ListBox lista, DataTable datos, string columnaNombre, string columnaID)
        {
            lista.DataSource = null;
            lista.DisplayMember = columnaNombre;
            lista.ValueMember = columnaID;
            lista.DataSource = datos;
            lista.SelectedIndex = -1;
        }

        private void CargarRoles()
        {
            CargarLista(lbox_Roles, claseSP.SP_ObtenerRolesDeUsuario(claseVar.idUsuario), "Nombre", "ID_Rol");
        }

        private void CargarFamilias()
        {
            CargarLista(lbox_Familias, claseSP.SP_ObtenerFamiliasDeUsuario(claseVar.idUsuario), "Nombre", "ID_Familia");
        }

        private void CargarPermisos()
        {
            CargarLista(lbox_Permisos, claseSP.SP_ObtenerPermisosDeUsuario(claseVar.idUsuario), "Permiso", "ID_Permiso");
        }

        private void CargarPreguntasRespondidas()
        {
            lbox_PSRespondidas.Items.Clear();

            DataTable preguntas = claseSP.SP_ObtenerPreguntasSeguridad(claseVar.idUsuario);
            foreach (DataRow row in preguntas.Rows)
            {
                lbox_PSRespondidas.Items.Add(row["Pregunta"].ToString().Trim());
            }
        }

        // =================================================================================//
        //  QUITAR (roles, familias y permisos comparten la misma lógica)
        //  tipo: "Rol", "Familia" o "Permiso"
        // =================================================================================//
        private void QuitarAsignacion(ListBox lista, string tipo, string columnaID, string columnaNombre, Action recargar)
        {
            if (lista.SelectedItem is not DataRowView fila)
            {
                MessageBox.Show("Por favor, seleccioná un elemento de la lista.");
                return;
            }

            int id = Convert.ToInt32(fila[columnaID]);
            string nombre = fila[columnaNombre].ToString().Trim();

            if (MessageBox.Show($"¿Quitar \"{nombre}\" ({tipo.ToLower()}) de este usuario?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                claseSP.SP_QuitarAsignacionUsuario(tipo, id, claseVar.idUsuario);
                MessageBox.Show($"Se quitó \"{nombre}\" ({tipo.ToLower()}) del usuario.");
                recargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar: " + ex.Message);
            }
        }

        private void btn_QuitarRol_Click(object sender, EventArgs e)
        {
            QuitarAsignacion(lbox_Roles, "Rol", "ID_Rol", "Nombre", CargarRoles);
        }

        private void btn_QuitarFamilia_Click(object sender, EventArgs e)
        {
            QuitarAsignacion(lbox_Familias, "Familia", "ID_Familia", "Nombre", CargarFamilias);
        }

        private void btn_QuitarPermiso_Click(object sender, EventArgs e)
        {
            QuitarAsignacion(lbox_Permisos, "Permiso", "ID_Permiso", "Permiso", CargarPermisos);
        }

        // =================================================================================//
        //  Abre los respectivos formularios y, al volver, recarga la lista correspondiente
        // =================================================================================//
        private void AbrirSelector(Form selector, Action recargar)
        {
            selector.FormClosed += (s, args) =>
            {
                recargar();
                this.Show();
            };
            this.Hide();
            selector.Show();
        }

        private void btn_AgregarRol_Click(object sender, EventArgs e)
        {
            AbrirSelector(new formRolUser(), CargarRoles);
        }

        private void btn_AgregarFamilia_Click(object sender, EventArgs e)
        {
            AbrirSelector(new formFamUser(), CargarFamilias);
        }

        private void btn_AgregarPermiso_Click(object sender, EventArgs e)
        {
            AbrirSelector(new formPermUser(), CargarPermisos);
        }

        private async void btn_SolicitarNuevaPass_Click(object sender, EventArgs e)
        {
            DataTable datos = claseSP.SP_ObtenerDatosUsuario(claseVar.idUsuario);
            if (datos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró el usuario seleccionado.");
                return;
            }

            string usuario = datos.Rows[0]["NombreUsuario"].ToString().Trim();
            string correo = datos.Rows[0]["Correo"].ToString().Trim();

            if (MessageBox.Show($"Se generará una contraseña temporal y se enviará a {correo}.\n¿Continuar?",
                    "Solicitar nueva contraseña", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                btn_SolicitarNuevaPass.Enabled = false;

                string temporal = RandomNumberGenerator.GetInt32(100000, 1000000).ToString();

                // El hash usa el nombre del usuario SELECCIONADO (no el del administrador)
                string hash = claseMetodos.encryptToSHA256(temporal + usuario);

                // Primero el correo: si falla, la contraseña actual del usuario no se toca
                await claseEmail.sendEmailContraseña(usuario, correo, temporal);
                claseSP.SP_GuardarContrasena(hash, claseVar.idUsuario, validarHistorial: false);

                MessageBox.Show($"Se envió una contraseña temporal a {correo}.");
                CargarDatosUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al solicitar la nueva contraseña: " + ex.Message);
            }
            finally
            {
                btn_SolicitarNuevaPass.Enabled = true;
            }
        }
        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}