namespace Capa_Vista
{
    partial class formRecuperarContrasena
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
            lbl_Bienvenida = new Label();
            lbl_Correo = new Label();
            lbl_RSeguridad = new Label();
            tbox_Correo = new TextBox();
            flp_PSeguridad = new FlowLayoutPanel();
            btn_Enviar = new Button();
            btn_EnviarCodigo = new Button();
            btn_Volver = new Button();
            SuspendLayout();
            // 
            // lbl_Bienvenida
            // 
            lbl_Bienvenida.AutoSize = true;
            lbl_Bienvenida.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lbl_Bienvenida.Location = new Point(160, 24);
            lbl_Bienvenida.Name = "lbl_Bienvenida";
            lbl_Bienvenida.Size = new Size(478, 24);
            lbl_Bienvenida.TabIndex = 0;
            lbl_Bienvenida.Text = "Formulario para recuperar tu contraseña";
            // 
            // lbl_Correo
            // 
            lbl_Correo.AutoSize = true;
            lbl_Correo.Font = new Font("Consolas", 9.75F);
            lbl_Correo.Location = new Point(328, 71);
            lbl_Correo.Name = "lbl_Correo";
            lbl_Correo.Size = new Size(133, 15);
            lbl_Correo.TabIndex = 1;
            lbl_Correo.Text = "Correo Electronico";
            // 
            // lbl_RSeguridad
            // 
            lbl_RSeguridad.AutoSize = true;
            lbl_RSeguridad.Font = new Font("Consolas", 9.75F, FontStyle.Bold);
            lbl_RSeguridad.Location = new Point(12, 139);
            lbl_RSeguridad.Name = "lbl_RSeguridad";
            lbl_RSeguridad.Size = new Size(168, 15);
            lbl_RSeguridad.TabIndex = 2;
            lbl_RSeguridad.Text = "Respuestas de Seguridad";
            lbl_RSeguridad.Visible = false;
            // 
            // tbox_Correo
            // 
            tbox_Correo.Location = new Point(271, 89);
            tbox_Correo.Name = "tbox_Correo";
            tbox_Correo.Size = new Size(246, 23);
            tbox_Correo.TabIndex = 3;
            // 
            // flp_PSeguridad
            // 
            flp_PSeguridad.FlowDirection = FlowDirection.TopDown;
            flp_PSeguridad.Location = new Point(12, 169);
            flp_PSeguridad.Name = "flp_PSeguridad";
            flp_PSeguridad.Size = new Size(776, 230);
            flp_PSeguridad.TabIndex = 4;
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(353, 118);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 23);
            btn_Enviar.TabIndex = 0;
            btn_Enviar.Text = "Confirmar";
            btn_Enviar.UseVisualStyleBackColor = true;
            btn_Enviar.Click += btn_Enviar_Click;
            // 
            // btn_EnviarCodigo
            // 
            btn_EnviarCodigo.Location = new Point(353, 415);
            btn_EnviarCodigo.Name = "btn_EnviarCodigo";
            btn_EnviarCodigo.Size = new Size(75, 23);
            btn_EnviarCodigo.TabIndex = 1;
            btn_EnviarCodigo.Text = "Enviar";
            btn_EnviarCodigo.UseVisualStyleBackColor = true;
            btn_EnviarCodigo.Visible = false;
            btn_EnviarCodigo.Click += btn_EnviarCodigo_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(706, 415);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 2;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // formRecuperarContrasena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Enviar);
            Controls.Add(flp_PSeguridad);
            Controls.Add(btn_EnviarCodigo);
            Controls.Add(tbox_Correo);
            Controls.Add(btn_Volver);
            Controls.Add(lbl_RSeguridad);
            Controls.Add(lbl_Correo);
            Controls.Add(lbl_Bienvenida);
            Name = "formRecuperarContrasena";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formRecuperar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Correo;
        private Label lbl_RSeguridad;
        private Label lbl_Bienvenida;
        private TextBox tbox_Correo;
        private FlowLayoutPanel flp_PSeguridad;
        private Button btn_Enviar;
        private Button btn_EnviarCodigo;
        private Button btn_Volver;
    }
}