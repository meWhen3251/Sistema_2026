using Capa_Datos;
using Capa_Sesion;
using System.Data;

namespace Capa_Vista
{
    public partial class formAjustePregunta : Form
    {
        claseSP claseSP = new claseSP();
        string preguntaSeleccionada = "";   // la pregunta que se está modificando ("" = ninguna elegida)

        public formAjustePregunta()
        {
            InitializeComponent();
        }

        private void formAjustePregunta_Load(object sender, EventArgs e)
        {
            // Largo máximo = largo de la columna Pregunta de la base de datos
            tbox_NuevaPregunta.MaxLength = 40;
            tbox_PreguntaNueva.MaxLength = 40;

            CargaPreguntasSeguridad();
        }

        // Elige la pregunta de la grilla para modificarla:
        //   tbox_PreguntaAnterior (solo lectura) = la pregunta actual, de referencia
        //   tbox_NuevaPregunta                   = la caja donde se escribe la pregunta modificada
        private void btn_ModificarPregunta_Click(object sender, EventArgs e)
        {
            if (dgv_PreguntasS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccioná una pregunta de la lista.");
                return;
            }

            claseTemp.preguntaSeleccionada = Convert.ToString(dgv_PreguntasS.SelectedRows[0].Cells["Pregunta"].Value).Trim();

            formModificarPregunta formModificarPregunta = new formModificarPregunta();
            formModificarPregunta.FormClosed += (s, args) => this.Show();
            formModificarPregunta.Show();
            this.Hide();
        }

        // Guarda la pregunta modificada (la que se eligió con "Modificar")
        private void btn_ActualizarPregunta_Click(object sender, EventArgs e)
        {
            if (preguntaSeleccionada == "")
            {
                MessageBox.Show("Primero seleccioná una pregunta y apretá 'Modificar pregunta seleccionada'.");
                return;
            }

            string preguntaModificada = tbox_NuevaPregunta.Text.Trim();

            if (preguntaModificada == "")
            {
                MessageBox.Show("La nueva pregunta no puede estar vacia");
                return;
            }

            try
            {
                claseSP.SP_ModificarPreguntaSeguridad(preguntaModificada, preguntaSeleccionada);
                CargaPreguntasSeguridad();
                MessageBox.Show("Pregunta actualizada con exito.");

                preguntaSeleccionada = "";
                tbox_PreguntaAnterior.Text = "";
                tbox_NuevaPregunta.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        // Agrega una pregunta completamente nueva (se escribe en tbox_PreguntaNueva)
        private void btn_AgregarPregunta_Click(object sender, EventArgs e)
        {
            string preguntaNueva = tbox_PreguntaNueva.Text.Trim();

            if (preguntaNueva == "")
            {
                MessageBox.Show("La pregunta no puede estar vacia");
                return;
            }

            // No puede haber dos preguntas iguales
            DataTable preguntasActuales = (DataTable)dgv_PreguntasS.DataSource; //(DataTable) es un 'Cast', que trata lo que sea que haya en
                                                                                //.DataSource como un, en este caso, DataTable.
                                                                                //Osea, el Cast es un conversor explicito de tipos
            foreach (DataRow fila in preguntasActuales.Rows)
            {
                if (fila["Pregunta"].ToString().Trim().ToLower() == preguntaNueva.ToLower())
                {
                    MessageBox.Show("Esa pregunta ya existe.");
                    return;
                }
            }

            try
            {
                claseSP.SP_AgregarPreguntaSeguridad(preguntaNueva);
                CargaPreguntasSeguridad();
                MessageBox.Show("Pregunta agregada con exito");
                tbox_PreguntaNueva.Text = "";
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
                string pregunta = Convert.ToString(dgv_PreguntasS.SelectedRows[0].Cells["Pregunta"].Value).Trim();
                claseSP.SP_ActualizarEstadoPregunta(pregunta);
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
            this.Close();   // formPanelAdmin lo abrió como hijo y vuelve a mostrarse solo
        }

        private void CargaPreguntasSeguridad()
        {
            dgv_PreguntasS.DataSource = claseSP.SP_CargaPreguntasSeguridad();

            if (dgv_PreguntasS.Columns["ID_Pregunta"] != null)
                dgv_PreguntasS.Columns["ID_Pregunta"].HeaderText = "ID_Pregunta";
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
