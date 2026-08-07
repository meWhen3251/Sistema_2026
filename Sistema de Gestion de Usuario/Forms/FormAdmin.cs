///FormAdmin.cs es el panel de administrador/gestor de usuarios
///Es unicamente accesible para usuarios con el rol de "Administrador"

using Sistema_de_Gestion_de_Usuario.Clases;
using Sistema_de_Gestion_de_Usuario.Metodos;
using System.Data;
using System.Data.SqlClient;
using System;
using static Sistema_de_Gestion_de_Usuario.Clases.ClassData;

namespace Sistema_de_Gestion_de_Usuario.Forms
{
    public partial class FormAdmin : Form
    {
        ClassEmails classEmails = new ClassEmails();
        ClassMethods ClassMethods = new ClassMethods();
        ClassSP_Methods classSP_Methods = new ClassSP_Methods();

        // DataTables en memoria que almacenan las preguntas y datos cargados al inicio.
        // Se usan para calcular índices al seleccionar items en el ComboBox.
        public DataTable PSActivas;
        public DataTable PSDesactivadas;
        public DataTable RolesTotales;
        public DataTable UsuariosTotales;

        public FormAdmin()
        {
            InitializeComponent();
        }

        //  SECCIÓN: REGISTRO DE USUARIOS

        // -- Botón "Registrar Usuario" 
        // "async void" porque llama a await classEmails.sendEmailContraseña(...)
        private async void btn_Registrar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén completos.
            if (tbox_Nombre.Text.Trim() == "" || tbox_Apellido.Text.Trim() == "" ||
                tbox_Usuario.Text.Trim() == "" || tbox_Email.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // El nombre de usuario no puede tener espacios.
            if (tbox_Usuario.Text.Contains(" "))
            {
                MessageBox.Show("El nombre de usuario no puede contener espacios.");
                return;
            }

            // Validar formato de email usando ClassEmails.
            if (!classEmails.validateEmail(tbox_Email.Text))
                return; // validateEmail ya muestra el MessageBox de error

            // Generar contraseña temporal aleatoria de 6 dígitos.
            Random random = new Random();
            string contrasenaTemporal = random.Next(100000, 1000000).ToString();

            btn_Registrar.Enabled = false;

            try
            {
                // Paso 1: enviar el email con la contraseña en texto plano.
                // "await" espera que el mail se envíe antes de continuar.
                await classEmails.sendEmailContraseña(tbox_Usuario.Text.Trim(), tbox_Email.Text.Trim(), contrasenaTemporal);

                // Paso 2: encriptar la contraseña antes de guardarla en la base de datos.
                // Se concatena la contraseña temporal con el nombre de usuario.
                contrasenaTemporal = contrasenaTemporal + tbox_Usuario.Text.Trim();
                contrasenaTemporal = ClassMethods.encryptToSHA256(contrasenaTemporal);

                // Paso 3: insertar el usuario completo.
                classSP_Methods.SP_InsertarUsuarioCompleto(
                    tbox_Nombre.Text.Trim(),
                    tbox_Apellido.Text.Trim(),
                    tbox_Email.Text.Trim(),
                    tbox_Usuario.Text.Trim(),
                    contrasenaTemporal
                );

                MessageBox.Show(
                    $"Usuario '{tbox_Usuario.Text.Trim()}' registrado exitosamente.\n" +
                    $"Se envió la contraseña temporal al correo {tbox_Email.Text.Trim()}."
                );

                // Limpiar campos tras el registro.
                tbox_Nombre.Clear();
                tbox_Apellido.Clear();
                tbox_Usuario.Clear();
                tbox_Email.Clear();
                btn_Registrar.Enabled = true;
                RefreshComboBox();
            }
            catch (Exception ex)
            {
                btn_Registrar.Enabled = true;
                MessageBox.Show($"Error al registrar el usuario: {ex.Message}");
            }
        }

        //  CARGA INICIAL DEL FORMULARIO

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            // Cargar el ComboBox de preguntas de seguridad (activas + desactivadas).
            RefreshComboBox();

            DataTable PSTotales = classSP_Methods.SP_CargaPreguntasSeguridad();

            // Separar preguntas activas: filtrar donde Habilitada == 1.
            // CopyToDataTable() convierte el resultado a una DataTable nueva.
            bool hayPSActivas = PSTotales.AsEnumerable().Any(row => Convert.ToInt32(row["Habilitada"]) == 1);

            if (hayPSActivas)
            {
                PSActivas = PSTotales.AsEnumerable()
                     .Where(row => Convert.ToInt32(row["Habilitada"]) == 1)
                     .CopyToDataTable();
            }
            else
            {
                MessageBox.Show("No hay preguntas de seguridad activas. Por favor, añade preguntas de seguridad para poder establecer preguntas activas.");
                PSActivas = PSTotales.Clone(); // Clone() crea una tabla vacía con la misma estructura
            }

            // Separar preguntas desactivadas: mismo proceso con Habilitada == 0.
            bool hayPSDesactivadas = PSTotales.AsEnumerable().Any(row => Convert.ToInt32(row["Habilitada"]) == 0);
            if (hayPSDesactivadas)
            {
                PSDesactivadas = classSP_Methods.SP_CargaPreguntasSeguridad().AsEnumerable()
                    .Where(row => Convert.ToInt32(row["Habilitada"]) == 0)
                    .CopyToDataTable();
            }
            else
            {
                MessageBox.Show("No hay preguntas de seguridad desactivadas. Por favor, añade preguntas de seguridad para poder establecer preguntas desactivadas.");
                PSDesactivadas = PSTotales.Clone();
            }

            // Cargar roles en el ComboBox de asignación de rol.
            RolesTotales = classSP_Methods.SP_CargaRoles();
            if (RolesTotales is null || RolesTotales.Rows.Count == 0)
            {
                MessageBox.Show("No existen roles para cargar");
                return;
            }
            foreach (DataRow row in RolesTotales.Rows)
            {
                cbox_RolNuevo.Items.Add(row["Nombre"].ToString().Trim());
            }

            // Cargar usuarios en el ComboBox de selección de usuario.
            cbox_UserSeleccionado.Items.Clear();
            UsuariosTotales = classSP_Methods.SP_CargaUsuarios();

            if (UsuariosTotales is null || UsuariosTotales.Rows.Count == 0)
            {
                MessageBox.Show("No existen usuarios.");
                return;
            }

            foreach (DataRow row in UsuariosTotales.Rows)
            {
                cbox_UserSeleccionado.Items.Add(row["Nombre"].ToString().Trim());
            }
        }

        //  SECCIÓN: GESTIÓN DE PREGUNTAS DE SEGURIDAD

        // -- RefreshComboBox
        // Recarga los ComboBox de preguntas de seguridad y usuariosRoles desde la base de datos.
        // Se llama al inicio y después de cualquier operación.
        private void RefreshComboBox()
        {
            cbox_PS.Items.Clear();
            cbox_PS.SelectedIndex = -1; // Deseleccionar cualquier item actual
            cbox_UserSeleccionado.Items.Clear();
            DataTable PSTotales = classSP_Methods.SP_CargaPreguntasSeguridad();

            bool hayPSActivas = PSTotales.AsEnumerable().Any(row => Convert.ToInt32(row["Habilitada"]) == 1);
            if (hayPSActivas)
            {
                PSActivas = PSTotales.AsEnumerable()
                     .Where(row => Convert.ToInt32(row["Habilitada"]) == 1)
                     .CopyToDataTable();
            }
            else
            {
                MessageBox.Show("No hay preguntas de seguridad activas. Por favor, añade preguntas de seguridad para poder establecer preguntas activas.");
                PSActivas = PSTotales.Clone();
            }

            bool hayPSDesactivadas = PSTotales.AsEnumerable().Any(row => Convert.ToInt32(row["Habilitada"]) == 0);
            if (hayPSDesactivadas)
            {
                PSDesactivadas = classSP_Methods.SP_CargaPreguntasSeguridad().AsEnumerable()
                    .Where(row => Convert.ToInt32(row["Habilitada"]) == 0)
                    .CopyToDataTable();
            }
            else
            {
                MessageBox.Show("No hay preguntas de seguridad desactivadas. Por favor, añade preguntas de seguridad para poder establecer preguntas desactivadas.");
                PSDesactivadas = PSTotales.Clone();
            }

            cbox_UserSeleccionado.Items.Clear();
            UsuariosTotales = classSP_Methods.SP_CargaUsuarios();
            if (UsuariosTotales is null || UsuariosTotales.Rows.Count == 0)
            {
                MessageBox.Show("No existen usuarios.");
                return;
            }

            foreach (DataRow row in UsuariosTotales.Rows)
            {
                cbox_UserSeleccionado.Items.Add(row["Nombre"].ToString().Trim());
            }



            // OfType<DataRow>() convierte la colección DataRowCollection (no genérica) a IEnumerable<DataRow> para poder usar Where().
            foreach (DataRow pregunta in PSTotales.Rows.OfType<DataRow>().Where(r => Convert.ToInt32(r["Habilitada"]) == 1))
            {
                cbox_PS.Items.Add("[ ACTIVA ] " + pregunta["Pregunta"].ToString().Trim());
            }

            foreach (DataRow pregunta in PSTotales.Rows.OfType<DataRow>().Where(r => Convert.ToInt32(r["Habilitada"]) == 0))
            {
                cbox_PS.Items.Add("[ DESACTIVADA ] " + pregunta["Pregunta"].ToString().Trim());
            }
        }

        // -- Botón "Añadir Pregunta"
        private void btn_PSAñadir_Click(object sender, EventArgs e)
        {
            if (tbox_PSAnadir.Text == "")
            {
                MessageBox.Show("Por favor, ingresa una pregunta de seguridad.");
                return;
            }

            try
            {
                // Verificar que la pregunta no exista ya en la base de datos.
                // Any() con una condición de igualdad (Equals) busca duplicados.
                DataTable preguntasSeguridad = classSP_Methods.SP_CargaPreguntasSeguridad();
                if (preguntasSeguridad.AsEnumerable().Any(row => row["Pregunta"].ToString().Trim().Equals(tbox_PSAnadir.Text.Trim())))
                {
                    MessageBox.Show("La pregunta de seguridad ya existe. Por favor, ingresa una pregunta diferente.");
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar la existencia de la pregunta: {ex.Message}");
                return;
            }

            try
            {
                classSP_Methods.SP_AgregarPreguntaSeguridad(tbox_PSAnadir.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al añadir la pregunta: {ex.Message}");
                return;
            }

            tbox_PSAnadir.Clear();
            RefreshComboBox(); // Recargar para mostrar la nueva pregunta
        }

        // -- Evento: selección en ComboBox de preguntas
        // Cuando el usuario elige una pregunta en el ComboBox, muestra los botones de acción y determina el texto del botón toggle (Activar/Desactivar).
        private void cbox_PS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_PS.SelectedIndex == -1) return;

            int selectedIndex = cbox_PS.SelectedIndex;
            int activasCount = PSActivas.Rows.Count;
            int desactivadasCount = PSDesactivadas.Rows.Count;

            if (selectedIndex < (activasCount + desactivadasCount))
            {
                // Mostrar controles de edición.
                tbox_PSSeleccionado.Visible = true;
                btn_PSDesactivar.Visible = true;
                btn_PSModificar.Visible = true;

                if (cbox_PS.Items[selectedIndex].ToString().Contains("[ ACTIVA ]"))
                {
                    // Pregunta activa: el botón toggle dirá "Desactivar".
                    tbox_PSSeleccionado.Text = cbox_PS.Items[selectedIndex].ToString().Replace("[ ACTIVA ] ", "");
                    btn_PSDesactivar.Text = "Desactivar";
                }
                else
                {
                    // Pregunta desactivada: el botón toggle dirá "Activar".
                    tbox_PSSeleccionado.Text = cbox_PS.Items[selectedIndex].ToString().Replace("[ DESACTIVADA ] ", "");
                    btn_PSDesactivar.Text = "Activar";
                }
            }
            else
            {
                tbox_PSSeleccionado.Clear();
                tbox_PSSeleccionado.Visible = false;
                btn_PSDesactivar.Visible = false;
                btn_PSModificar.Visible = false;
            }
        }

        // -- Botón "Modificar Pregunta"
        // Actualiza el texto de la pregunta seleccionada en la base de datos.
        private void btn_PSModificar_Click(object sender, EventArgs e)
        {
            if (cbox_PS.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, selecciona una pregunta.");
                return;
            }

            try
            {
                // Primer parámetro: nuevo texto (lo que hay en el TextBox).
                // Segundo parámetro: texto actual para identificar la pregunta en la base de datos
                // (se le quita el prefijo "[ ACTIVA ] " o "[ DESACTIVADA ] " del ComboBox).
                classSP_Methods.SP_ModificarPreguntaSeguridad(tbox_PSSeleccionado.Text, cbox_PS.SelectedItem.ToString().Replace("[ ACTIVA ] ", "").Replace("[ DESACTIVADA ] ", ""));

                MessageBox.Show("Pregunta de seguridad modificada exitosamente.");

                // Actualizar el texto del item en el ComboBox sin recargar todo.
                if (cbox_PS.Items[cbox_PS.SelectedIndex].ToString().Contains("[ ACTIVA ]"))
                {
                    cbox_PS.Items[cbox_PS.SelectedIndex] = "[ ACTIVA ] " + tbox_PSSeleccionado.Text;
                }
                else if (cbox_PS.Items[cbox_PS.SelectedIndex].ToString().Contains("[ DESACTIVADA ]")) 
                {
                    cbox_PS.Items[cbox_PS.SelectedIndex] = "[ DESACTIVADA ] " + tbox_PSSeleccionado.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la pregunta de seguridad: {ex.Message}");
            }

            RefreshComboBox();
        }

        // -- Botón "Activar / Desactivar Pregunta"
        // Alterna el estado de la pregunta seleccionada.
        // El mismo botón sirve para activar y desactivar; el texto cambia según el estado.
        private void btn_PSDesactivar_Click(object sender, EventArgs e)
        {
            if (cbox_PS.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, selecciona una pregunta.");
                return;
            }

            try
            {
                classSP_Methods.SP_ActualizarEstadoPregunta(tbox_PSSeleccionado.Text);
                MessageBox.Show("Estado de la pregunta de seguridad actualizado exitosamente.");

                // Actualizar el prefijo en el ComboBox para reflejar el nuevo estado.
                if (cbox_PS.Items[cbox_PS.SelectedIndex].ToString().Contains("[ ACTIVA ]"))
                {
                    cbox_PS.Items[cbox_PS.SelectedIndex] = "[ DESACTIVADA ] " + tbox_PSSeleccionado.Text;
                }
                else if (cbox_PS.Items[cbox_PS.SelectedIndex].ToString().Contains("[ DESACTIVADA ]"))
                {
                    cbox_PS.Items[cbox_PS.SelectedIndex] = "[ ACTIVA ] " + tbox_PSSeleccionado.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el estado de la pregunta de seguridad: {ex.Message}");
            }

            RefreshComboBox();
        }

        //  SECCIÓN: CAMBIO DE ROL DE USUARIO

        // Habilita el ComboBox de roles cuando se selecciona un usuario.
        private void cbox_UserSeleccionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbox_RolNuevo.Enabled = true;
        }

        // Habilita el botón de cambiar rol cuando se selecciona un rol.
        private void cbox_RolNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_CambiarRol.Enabled = true;
        }

        // -- Botón "Cambiar Rol"
        // Asigna el rol seleccionado al usuario seleccionado.
        // El SP ignora la operación si el usuario ya tiene ese rol.
        private void btn_CambiarRol_Click(object sender, EventArgs e)
        {
            try
            {
                classSP_Methods.SP_AgregarRolUsuario(cbox_RolNuevo.SelectedItem.ToString(), cbox_UserSeleccionado.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el rol del usuario: {ex.Message}");
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            ClassMethods.abrirFormulario(this, new FormPanelGeneral());
        }
    }
}