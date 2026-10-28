namespace Capa_Vista
{
    partial class formFirstLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_BievenidaForm = new Label();
            lbl_NuevaPass = new Label();
            lbl_RepetirPass = new Label();
            tbox_RepetirContra = new TextBox();
            tbox_Contrasena = new TextBox();
            btn_Enviar = new Button();
            btn_Volver = new Button();
            flp_PreguntasSeg = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lbl_BievenidaForm
            // 
            lbl_BievenidaForm.AutoSize = true;
            lbl_BievenidaForm.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lbl_BievenidaForm.Location = new Point(274, 19);
            lbl_BievenidaForm.Name = "lbl_BievenidaForm";
            lbl_BievenidaForm.Size = new Size(478, 48);
            lbl_BievenidaForm.TabIndex = 0;
            lbl_BievenidaForm.Text = "Cambio y primer registro de contraseña \r\npor el usuario";
            lbl_BievenidaForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_NuevaPass
            // 
            lbl_NuevaPass.AutoSize = true;
            lbl_NuevaPass.Font = new Font("Consolas", 9.75F);
            lbl_NuevaPass.Location = new Point(12, 69);
            lbl_NuevaPass.Name = "lbl_NuevaPass";
            lbl_NuevaPass.Size = new Size(119, 15);
            lbl_NuevaPass.TabIndex = 2;
            lbl_NuevaPass.Text = "Nueva contraseña";
            // 
            // lbl_RepetirPass
            // 
            lbl_RepetirPass.AutoSize = true;
            lbl_RepetirPass.Font = new Font("Consolas", 9.75F);
            lbl_RepetirPass.Location = new Point(12, 113);
            lbl_RepetirPass.Name = "lbl_RepetirPass";
            lbl_RepetirPass.Size = new Size(133, 15);
            lbl_RepetirPass.TabIndex = 1;
            lbl_RepetirPass.Text = "Repetir contraseña";
            // 
            // tbox_RepetirContra
            // 
            tbox_RepetirContra.Location = new Point(12, 131);
            tbox_RepetirContra.Name = "tbox_RepetirContra";
            tbox_RepetirContra.Size = new Size(200, 23);
            tbox_RepetirContra.TabIndex = 4;
            // 
            // tbox_Contrasena
            // 
            tbox_Contrasena.Location = new Point(12, 87);
            tbox_Contrasena.Name = "tbox_Contrasena";
            tbox_Contrasena.Size = new Size(200, 23);
            tbox_Contrasena.TabIndex = 3;
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(456, 400);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 23);
            btn_Enviar.TabIndex = 5;
            btn_Enviar.Text = "Enviar";
            btn_Enviar.UseVisualStyleBackColor = true;
            btn_Enviar.Click += btn_Enviar_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(885, 395);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 6;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // flp_PreguntasSeg
            // 
            flp_PreguntasSeg.FlowDirection = FlowDirection.TopDown;
            flp_PreguntasSeg.Location = new Point(12, 159);
            flp_PreguntasSeg.Name = "flp_PreguntasSeg";
            flp_PreguntasSeg.Size = new Size(948, 230);
            flp_PreguntasSeg.TabIndex = 7;
            // 
            // formFirstLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 450);
            Controls.Add(flp_PreguntasSeg);
            Controls.Add(btn_Volver);
            Controls.Add(btn_Enviar);
            Controls.Add(tbox_RepetirContra);
            Controls.Add(tbox_Contrasena);
            Controls.Add(lbl_NuevaPass);
            Controls.Add(lbl_RepetirPass);
            Controls.Add(lbl_BievenidaForm);
            Name = "formFirstLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += formFirstLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_BievenidaForm;
        private Label lbl_NuevaPass;
        private Label lbl_RepetirPass;
        private TextBox tbox_RepetirContra;
        private TextBox tbox_Contrasena;
        private Button btn_Enviar;
        private Button btn_Volver;
        private FlowLayoutPanel flp_PreguntasSeg;
    }
}