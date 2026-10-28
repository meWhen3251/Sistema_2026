using Capa_Datos;
using Capa_Servicios;
using Capa_Sesion;
using System.Data;

namespace Capa_Vista
{
    public partial class formModificarDatos : Form
    {
        claseSP claseSP = new claseSP();
        claseEmail claseEmail = new claseEmail();
        public formModificarDatos()
        {
            InitializeComponent();
        }
        private void formModificarDatos_Load(object sender, EventArgs e)
        {
            // Largos máximos = largo de las columnas de la base de datos
            tbox_Nombre.MaxLength = 40;
            tbox_Apellido.MaxLength = 40;
            tbox_Correo.MaxLength = 50;

            // Solo el administrador puede modificar usuarios
            if (!claseVar.esAdmin)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.");
                BeginInvoke(new Action(Close));   // se cierra un instante después: un formulario no puede cerrarse dentro de su propio Load
                return;
            }

            DataTable datos = claseSP.SP_ObtenerDatosUsuario(claseVar.idUsuarioSeleccionado);
            if (datos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró el usuario seleccionado.");
                BeginInvoke(new Action(Close));
                return;
            }

            DataRow fila = datos.Rows[0];
            tbox_Usuario.Text = fila["NombreUsuario"].ToString().Trim();
            tbox_Nombre.Text = fila["Nombre"].ToString().Trim();
            tbox_Apellido.Text = fila["Apellido"].ToString().Trim();
            tbox_Correo.Text = fila["Correo"].ToString().Trim();

        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            string nombre = tbox_Nombre.Text.Trim();
            string apellido = tbox_Apellido.Text.Trim();
            string correo = tbox_Correo.Text.Trim();

            // Paso 1: campos completos
            if (nombre == "" || apellido == "" || correo == "")
            {
                MessageBox.Show("Por favor, completá todos los campos.");
                return;
            }

            // Paso 2: el correo tiene que tener formato válido
            bool correoValido;
            try
            {
                correoValido = claseEmail.validateEmail(correo);   // lanza una excepción si el formato es inválido
            }
            catch
            {
                correoValido = false;
            }

            if (!correoValido)
            {
                MessageBox.Show("El correo electrónico no es válido.");
                tbox_Correo.Focus();
                return;
            }

            try
            {
                // Paso 3: el correo no puede pertenecer a OTRO usuario
                DataTable usuarios = claseSP.SP_CargaUsuariosDetalle();
                foreach (DataRow fila in usuarios.Rows)
                {
                    bool esOtroUsuario = Convert.ToInt32(fila["ID_Usuario"]) != claseVar.idUsuarioSeleccionado;
                    bool mismoCorreo = fila["Correo"].ToString().Trim().ToLower() == correo.ToLower();

                    if (esOtroUsuario && mismoCorreo)
                    {
                        MessageBox.Show("Ese correo ya pertenece a otro usuario.");
                        tbox_Correo.Focus();
                        return;
                    }
                }

                // Paso 4: guardar los cambios
                claseSP.SP_ModificarDatosUsuario(claseVar.idUsuarioSeleccionado, nombre, apellido, correo);

                MessageBox.Show("Datos modificados correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar los datos: " + ex.Message);
            }

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
