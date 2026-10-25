namespace Capa_Vista
{
    partial class formNuevaContrasena
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
            btn_Enviar = new Button();
            tbox_NuevaContra = new TextBox();
            lbl_NuevaContra = new Label();
            lbl_Bienvenida = new Label();
            btn_Volver = new Button();
            SuspendLayout();
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(198, 182);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 23);
            btn_Enviar.TabIndex = 3;
            btn_Enviar.Text = "Cambiar";
            btn_Enviar.UseVisualStyleBackColor = true;
            btn_Enviar.Click += btn_Enviar_Click;
            // 
            // tbox_NuevaContra
            // 
            tbox_NuevaContra.Location = new Point(79, 153);
            tbox_NuevaContra.Name = "tbox_NuevaContra";
            tbox_NuevaContra.Size = new Size(306, 23);
            tbox_NuevaContra.TabIndex = 2;
            // 
            // lbl_NuevaContra
            // 
            lbl_NuevaContra.AutoSize = true;
            lbl_NuevaContra.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_NuevaContra.Location = new Point(180, 136);
            lbl_NuevaContra.Name = "lbl_NuevaContra";
            lbl_NuevaContra.Size = new Size(119, 14);
            lbl_NuevaContra.TabIndex = 1;
            lbl_NuevaContra.Text = "Nueva contraseña";
            // 
            // lbl_Bienvenida
            // 
            lbl_Bienvenida.AutoSize = true;
            lbl_Bienvenida.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lbl_Bienvenida.Location = new Point(40, 50);
            lbl_Bienvenida.Name = "lbl_Bienvenida";
            lbl_Bienvenida.Size = new Size(418, 24);
            lbl_Bienvenida.TabIndex = 0;
            lbl_Bienvenida.Text = "Formulario para cambiar contraseña";
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(402, 201);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 4;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // formNuevaContrasena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 236);
            Controls.Add(btn_Volver);
            Controls.Add(btn_Enviar);
            Controls.Add(tbox_NuevaContra);
            Controls.Add(lbl_NuevaContra);
            Controls.Add(lbl_Bienvenida);
            Name = "formNuevaContrasena";
            Text = "formNuevaContrasena";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Enviar;
        private TextBox tbox_NuevaContra;
        private Label lbl_NuevaContra;
        private Label lbl_Bienvenida;
        private Button btn_Volver;
    }
}