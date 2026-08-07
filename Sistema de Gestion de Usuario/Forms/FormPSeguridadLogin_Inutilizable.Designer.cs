namespace Sistema_de_Gestion_de_Usuario.Forms
{
    partial class FormPSeguridadLogin_Inutilizable
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            btn_Enviar = new Button();
            label1 = new Label();
            btn_Volver = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 96);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(776, 230);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(358, 340);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 23);
            btn_Enviar.TabIndex = 0;
            btn_Enviar.Text = "Enviar";
            btn_Enviar.UseVisualStyleBackColor = true;
            btn_Enviar.Click += btn_Enviar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            label1.Location = new Point(249, 20);
            label1.Name = "label1";
            label1.Size = new Size(298, 48);
            label1.TabIndex = 2;
            label1.Text = "Formulario de Respuestas\r\n      De Seguridad";
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(713, 340);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 1;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // FormPSeguridadLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 375);
            Controls.Add(btn_Volver);
            Controls.Add(label1);
            Controls.Add(btn_Enviar);
            Controls.Add(flowLayoutPanel1);
            Name = "FormPSeguridadLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPSeguridadLogin";
            Load += FormPSeguridadLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btn_Enviar;
        private Label label1;
        private Button btn_Volver;
    }
}