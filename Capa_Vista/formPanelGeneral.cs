using Capa_Sesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista
{
    public partial class formPanelGeneral : Form
    {
        public formPanelGeneral()
        {
            InitializeComponent();
        }
        private void formPanelGeneral_Load(object sender, EventArgs e)
        {
            // Mostrar el nombre del usuario logueado en el label de bienvenida.
            lbl_Bienvenida.Text = $"Bienvenido, {claseVar.nombreUsuario}";

            if (claseVar.esAdmin == true)
            {
                lbl_Rol.Text = "Rol: Administrador";
                // Mostrar el botón de gestión solo si es admin.
                btn_GestionUsuarios.Visible = true;
            }
            else
            {
                lbl_Rol.Text = "Rol: Usuario";
                // Ocultar el botón para usuarios sin permisos de admin.
                btn_GestionUsuarios.Visible = false;
            }

        }

        private void btn_CambiarContra_Click(object sender, EventArgs e)
        {
            formNuevaContrasena formNuevaContrasena = new formNuevaContrasena();
            formNuevaContrasena.Show();
            this.Hide();

        }

        private void btn_GestionUsuarios_Click(object sender, EventArgs e)
        {
            if (!claseVar.esAdmin)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.");
                return;
            }
            formPanelAdmin formPanelAdmin = new formPanelAdmin();
            formPanelAdmin.Show();
            this.Hide();
        }

        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            formLogin formLogin = new formLogin();
            formLogin.Show();
            this.Hide();
        }
    }
}
