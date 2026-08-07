namespace Sistema_de_Gestion_de_Usuario.Forms
{
    partial class FormRecuperar
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
            lbl_BienvenidaRecuperar = new Label();
            lbl_Correo = new Label();
            tbox_Correo = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lbl_RespuestasSeguridad = new Label();
            btn_Enviar = new Button();
            btn_EnviarCodigo = new Button();
            btn_Volver = new Button();
            SuspendLayout();
            // 
            // lbl_BienvenidaRecuperar
            // 
            lbl_BienvenidaRecuperar.AutoSize = true;
            lbl_BienvenidaRecuperar.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lbl_BienvenidaRecuperar.Location = new Point(160, 24);
            lbl_BienvenidaRecuperar.Name = "lbl_BienvenidaRecuperar";
            lbl_BienvenidaRecuperar.Size = new Size(478, 24);
            lbl_BienvenidaRecuperar.TabIndex = 0;
            lbl_BienvenidaRecuperar.Text = "Formulario para recuperar tu contraseña";
            // 
            // lbl_Correo
            // 
            lbl_Correo.AutoSize = true;
            lbl_Correo.Font = new Font("Consolas", 9.75F);
            lbl_Correo.Location = new Point(328, 71);
            lbl_Correo.Name = "lbl_Correo";
            lbl_Correo.Size = new Size(133, 15);
            lbl_Correo.TabIndex = 2;
            lbl_Correo.Text = "Correo Electronico";
            // 
            // tbox_Correo
            // 
            tbox_Correo.Location = new Point(278, 89);
            tbox_Correo.Name = "tbox_Correo";
            tbox_Correo.Size = new Size(232, 23);
            tbox_Correo.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 169);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(776, 230);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.Visible = false;
            // 
            // lbl_RespuestasSeguridad
            // 
            lbl_RespuestasSeguridad.AutoSize = true;
            lbl_RespuestasSeguridad.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_RespuestasSeguridad.Location = new Point(12, 139);
            lbl_RespuestasSeguridad.Name = "lbl_RespuestasSeguridad";
            lbl_RespuestasSeguridad.Size = new Size(168, 15);
            lbl_RespuestasSeguridad.TabIndex = 6;
            lbl_RespuestasSeguridad.Text = "Respuestas de Seguridad";
            lbl_RespuestasSeguridad.Visible = false;
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(353, 118);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 23);
            btn_Enviar.TabIndex = 1;
            btn_Enviar.Text = "Confirmar";
            btn_Enviar.UseVisualStyleBackColor = true;
            btn_Enviar.Click += btn_Enviar_Click_1;
            // 
            // btn_EnviarCodigo
            // 
            btn_EnviarCodigo.Location = new Point(353, 415);
            btn_EnviarCodigo.Name = "btn_EnviarCodigo";
            btn_EnviarCodigo.Size = new Size(75, 23);
            btn_EnviarCodigo.TabIndex = 8;
            btn_EnviarCodigo.Text = "Enviar";
            btn_EnviarCodigo.UseVisualStyleBackColor = true;
            btn_EnviarCodigo.Click += btn_EnviarCodigo_Click_1;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(706, 415);
            btn_Volver.Margin = new Padding(3, 2, 3, 2);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(82, 23);
            btn_Volver.TabIndex = 9;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // FormRecuperar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Volver);
            Controls.Add(btn_EnviarCodigo);
            Controls.Add(btn_Enviar);
            Controls.Add(lbl_RespuestasSeguridad);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tbox_Correo);
            Controls.Add(lbl_Correo);
            Controls.Add(lbl_BienvenidaRecuperar);
            Name = "FormRecuperar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recuperar tu Contraseña";
            Load += FormRecuperar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_BienvenidaRecuperar;
        private Label lbl_Correo;
        private TextBox tbox_Correo;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lbl_RespuestasSeguridad;
        private Button btn_Enviar;
        private Button btn_EnviarCodigo;
        private Button btn_Volver;
    }
}