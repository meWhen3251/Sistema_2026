using Sistema_de_Gestion_de_Usuario.Metodos;
using Sistema_de_Gestion_de_Usuario.Clases;
using System.Data;

namespace Sistema_de_Gestion_de_Usuario.Forms
{
    public partial class Form2FA : Form
    {
        ClassEmails classEmails = new ClassEmails();
        ClassSP_Methods classSPMethods = new ClassSP_Methods();
        ClassMethods classMethods = new ClassMethods();
        string user = ClassData.nombreUsuario;
        DataTable correoObtenido;
        string contrasenaTemporal;

        public Form2FA()
        {
            InitializeComponent();
        }

        private async void Form2FA_Load(object sender, EventArgs e)
        {
            try
            {
                correoObtenido = classSPMethods.SP_ObtenerCorreoPorUsuario(user);
                if (correoObtenido is null || correoObtenido.Rows.Count == 0)
                {
                    MessageBox.Show("No se pudo obtener los datos necesarios.");
                    classMethods.abrirFormulario(this, new FormLogin());
                }
                string correo = correoObtenido.Rows[0]["Correo"].ToString().Trim();

                Random random = new Random();
                contrasenaTemporal = random.Next(100000, 999999).ToString();
                await classEmails.sendEmailContraseña(user, correo, contrasenaTemporal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la carga: {ex.Message}");
            }
        }

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            if (tbox_2FA.Text == contrasenaTemporal)
            {
                MessageBox.Show("Verificado exitosamente, bienvenido");
                classMethods.abrirFormulario(this, new FormPanelGeneral());
            }
            else 
            {
                MessageBox.Show("El código de verificación no coincide.");
            }
        }

        private void btn_Reenviar_Click(object sender, EventArgs e)
        {
            tmr_1seg.Start();
            btn_Reenviar.Enabled = false;
            btn_Reenviar.Text = "30";
        }

        private void tmr_1seg_Tick(object sender, EventArgs e)
        {
            btn_Reenviar.Text = (int.Parse(btn_Reenviar.Text) - 1).ToString();
            if (btn_Reenviar.Text == "0")
            {
                btn_Reenviar.Enabled = true;
                btn_Reenviar.Text = "Reenviar";
                tmr_1seg.Stop();
            }
        }
    }
}
