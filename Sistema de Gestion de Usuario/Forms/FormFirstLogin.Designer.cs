namespace Sistema_de_Gestion_de_Usuario.Forms
{
    partial class FormFirstLogin
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
            button1 = new Button();
            lbl_FormPrimerContra = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tbox_Contrasena = new TextBox();
            lbl_NuevaPass = new Label();
            btn_Enviar = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(885, 395);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lbl_FormPrimerContra
            // 
            lbl_FormPrimerContra.AutoSize = true;
            lbl_FormPrimerContra.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lbl_FormPrimerContra.Location = new Point(256, 9);
            lbl_FormPrimerContra.Name = "lbl_FormPrimerContra";
            lbl_FormPrimerContra.Size = new Size(466, 48);
            lbl_FormPrimerContra.TabIndex = 2;
            lbl_FormPrimerContra.Text = "Cambio y primer registro de contraseña\r\npor el usuario";
            lbl_FormPrimerContra.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 159);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(948, 230);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // tbox_Contrasena
            // 
            tbox_Contrasena.Location = new Point(12, 87);
            tbox_Contrasena.Name = "tbox_Contrasena";
            tbox_Contrasena.Size = new Size(200, 23);
            tbox_Contrasena.TabIndex = 0;
            // 
            // lbl_NuevaPass
            // 
            lbl_NuevaPass.AutoSize = true;
            lbl_NuevaPass.Font = new Font("Consolas", 9.75F);
            lbl_NuevaPass.Location = new Point(12, 69);
            lbl_NuevaPass.Name = "lbl_NuevaPass";
            lbl_NuevaPass.Size = new Size(119, 15);
            lbl_NuevaPass.TabIndex = 5;
            lbl_NuevaPass.Text = "Nueva contraseña";
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(456, 400);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 23);
            btn_Enviar.TabIndex = 1;
            btn_Enviar.Text = "Enviar";
            btn_Enviar.UseVisualStyleBackColor = true;
            btn_Enviar.Click += btn_Enviar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 9.75F);
            label1.Location = new Point(12, 113);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 6;
            label1.Text = "Repetir contraseña";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 130);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(198, 23);
            textBox1.TabIndex = 7;
            // 
            // FormFirstLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 435);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(btn_Enviar);
            Controls.Add(lbl_NuevaPass);
            Controls.Add(tbox_Contrasena);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Controls.Add(lbl_FormPrimerContra);
            Name = "FormFirstLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormFirstLogin";
            Load += FormFirstLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lbl_FormPrimerContra;
        public FlowLayoutPanel flowLayoutPanel1;
        private TextBox tbox_Contrasena;
        private Label lbl_NuevaPass;
        private Button btn_Enviar;
        private Label label1;
        private TextBox textBox1;
    }
}