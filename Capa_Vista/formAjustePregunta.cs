using Capa_Datos;

namespace Capa_Vista
{
    public partial class formAjustePregunta : Form
    {
        claseSP claseSP = new claseSP();
        string preguntaSeleccionada;

        public formAjustePregunta()
        {
            InitializeComponent();
        }

        private void formAjustePregunta_Load(object sender, EventArgs e)
        {
            CargaPreguntasSeguridad();
        }

        private void btn_ModificarPregunta_Click(object sender, EventArgs e)
        {
            if (dgv_PreguntasS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccioná una pregunta de la lista.");
                return;
            }

            try
            {
                preguntaSeleccionada = Convert.ToString(dgv_PreguntasS.SelectedRows[0].Cells["Pregunta"].Value);

                tbox_PreguntaAnterior.Text = preguntaSeleccionada;

                tbox_NuevaPregunta.Text = preguntaSeleccionada;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar pregunta: " + ex.Message);
            }
        }

        private void btn_ActualizarPregunta_Click(object sender, EventArgs e)
        {
            if (tbox_NuevaPregunta.Text == "")
            {
                MessageBox.Show("La nueva pregunta no puede estar vacia");
                return;
            }
            try
            {
                claseSP.SP_ModificarPreguntaSeguridad(tbox_NuevaPregunta.Text, preguntaSeleccionada);
                CargaPreguntasSeguridad();
                MessageBox.Show("Pregunta actualizada con exito.");
                tbox_PreguntaAnterior.Text = "";
                tbox_NuevaPregunta.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void btn_AgregarPregunta_Click(object sender, EventArgs e)
        {
            if (tbox_NuevaPregunta.Text == "")
            {
                MessageBox.Show("La pregunta no puede estar vacia");
                return;
            }
            try
            {
                claseSP.SP_AgregarPreguntaSeguridad(tbox_NuevaPregunta.Text);
                CargaPreguntasSeguridad();
                MessageBox.Show("Pregunta agregada con exito");
                tbox_NuevaPregunta.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la pregunta: " + ex.Message);
            }
        }

        private void btn_HabilitarPregunta_Click(object sender, EventArgs e)
        {
            if (dgv_PreguntasS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccioná una pregunta de la lista.");
                return;
            }
            try
            {
                preguntaSeleccionada = Convert.ToString(dgv_PreguntasS.SelectedRows[0].Cells["Pregunta"].Value);
                claseSP.SP_ActualizarEstadoPregunta(preguntaSeleccionada);
                CargaPreguntasSeguridad();
                MessageBox.Show("Pregunta actualizada con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al habilitar/deshabilitar pregunta: " + ex.Message);
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargaPreguntasSeguridad()
        {
            dgv_PreguntasS.DataSource = claseSP.SP_CargaPreguntasSeguridad();

            if (dgv_PreguntasS.Columns["ID_Pregunta"] != null)
                dgv_PreguntasS.Columns["ID_Pregunta"].Visible = false;
            if (dgv_PreguntasS.Columns["Pregunta"] != null)
                dgv_PreguntasS.Columns["Pregunta"].HeaderText = "Pregunta";
            if (dgv_PreguntasS.Columns["Habilitada"] != null)
                dgv_PreguntasS.Columns["Habilitada"].HeaderText = "Habilitada";

            dgv_PreguntasS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_PreguntasS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_PreguntasS.MultiSelect = false;
            dgv_PreguntasS.ReadOnly = true;

        }
    }
}
