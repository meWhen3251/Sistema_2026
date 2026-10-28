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
    public partial class formModificarPregunta : Form
    {
        public formModificarPregunta()
        {
            InitializeComponent();
        }

        private void formModificarPregunta_Load(object sender, EventArgs e)
        {
            tbox_PreguntaSelect.Text = claseTemp.preguntaSeleccionada;
            tbox_PreguntaModificada.Text = claseTemp.preguntaSeleccionada;
        }
    }
}
