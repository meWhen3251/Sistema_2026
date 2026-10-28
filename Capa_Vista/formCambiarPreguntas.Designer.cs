namespace Capa_Vista
{
    partial class formCambiarPreguntas
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
            lbl_Contrasena = new Label();
            tbox_Contrasena = new TextBox();
            flp_PreguntaSeg = new FlowLayoutPanel();
            btn_Guardar = new Button();
            btn_Volver = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lbl_Bienvenida
            // 
            lbl_Bienvenida.AutoSize = true;
            lbl_Bienvenida.Font = new Font("Consolas", 14F, FontStyle.Bold);
            lbl_Bienvenida.Location = new Point(110, 9);
            lbl_Bienvenida.Name = "lbl_Bienvenida";
            lbl_Bienvenida.Size = new Size(330, 22);
            lbl_Bienvenida.TabIndex = 0;
            lbl_Bienvenida.Text = "Fomulario de Cambio de Preguntas";
            // 
            // lbl_Contrasena
            // 
            lbl_Contrasena.AutoSize = true;
            lbl_Contrasena.Location = new Point(26, 51);
            lbl_Contrasena.Name = "lbl_Contrasena";
            lbl_Contrasena.Size = new Size(67, 15);
            lbl_Contrasena.TabIndex = 1;
            lbl_Contrasena.Text = "Contraseña";
            // 
            // tbox_Contrasena
            // 
            tbox_Contrasena.Location = new Point(12, 69);
            tbox_Contrasena.Name = "tbox_Contrasena";
            tbox_Contrasena.Size = new Size(100, 23);
            tbox_Contrasena.TabIndex = 2;
            tbox_Contrasena.UseSystemPasswordChar = true;
            // 
            // flp_PreguntaSeg
            // 
            flp_PreguntaSeg.Location = new Point(12, 98);
            flp_PreguntaSeg.Name = "flp_PreguntaSeg";
            flp_PreguntaSeg.Size = new Size(530, 230);
            flp_PreguntaSeg.TabIndex = 3;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Location = new Point(236, 352);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(75, 23);
            btn_Guardar.TabIndex = 0;
            btn_Guardar.Text = "Guardar";
            btn_Guardar.UseVisualStyleBackColor = true;
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(467, 352);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 1;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(154, 62);
            label1.Name = "label1";
            label1.Size = new Size(253, 30);
            label1.TabIndex = 4;
            label1.Text = "Para poder guardar los cambios, la contraseña \r\ndebe ser la correcta";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // formCambiarPreguntas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 387);
            Controls.Add(label1);
            Controls.Add(btn_Volver);
            Controls.Add(btn_Guardar);
            Controls.Add(flp_PreguntaSeg);
            Controls.Add(tbox_Contrasena);
            Controls.Add(lbl_Contrasena);
            Controls.Add(lbl_Bienvenida);
            Name = "formCambiarPreguntas";
            Text = "formCambiarPreguntas";
            Load += formCambiarPreguntas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Bienvenida;
        private Label lbl_Contrasena;
        private TextBox tbox_Contrasena;
        private FlowLayoutPanel flp_PreguntaSeg;
        private Button btn_Guardar;
        private Button btn_Volver;
        private Label label1;
    }
}