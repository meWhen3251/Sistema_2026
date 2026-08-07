namespace Sistema_de_Gestion_de_Usuario.Forms
{
    partial class FormNuevaContrasena
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
            tbox_NuevaContra = new TextBox();
            lbl_NuevaContra = new Label();
            lbl_FormNuevaContra = new Label();
            btn_Enviar = new Button();
            SuspendLayout();
            // 
            // tbox_NuevaContra
            // 
            tbox_NuevaContra.Location = new Point(110, 147);
            tbox_NuevaContra.Name = "tbox_NuevaContra";
            tbox_NuevaContra.Size = new Size(238, 23);
            tbox_NuevaContra.TabIndex = 0;
            // 
            // lbl_NuevaContra
            // 
            lbl_NuevaContra.AutoSize = true;
            lbl_NuevaContra.Location = new Point(178, 129);
            lbl_NuevaContra.Name = "lbl_NuevaContra";
            lbl_NuevaContra.Size = new Size(102, 15);
            lbl_NuevaContra.TabIndex = 2;
            lbl_NuevaContra.Text = "Nueva contraseña";
            // 
            // lbl_FormNuevaContra
            // 
            lbl_FormNuevaContra.AutoSize = true;
            lbl_FormNuevaContra.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lbl_FormNuevaContra.Location = new Point(12, 52);
            lbl_FormNuevaContra.Name = "lbl_FormNuevaContra";
            lbl_FormNuevaContra.Size = new Size(454, 24);
            lbl_FormNuevaContra.TabIndex = 3;
            lbl_FormNuevaContra.Text = "Formulario para cambiar la contraseña";
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(195, 176);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 23);
            btn_Enviar.TabIndex = 1;
            btn_Enviar.Text = "Enviar";
            btn_Enviar.UseVisualStyleBackColor = true;
            btn_Enviar.Click += btn_Enviar_Click_1;
            // 
            // FormNuevaContrasena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 265);
            Controls.Add(btn_Enviar);
            Controls.Add(lbl_FormNuevaContra);
            Controls.Add(lbl_NuevaContra);
            Controls.Add(tbox_NuevaContra);
            Name = "FormNuevaContrasena";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormNuevaContrasena";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbox_NuevaContra;
        private Label lbl_NuevaContra;
        private Label lbl_FormNuevaContra;
        private Button btn_Enviar;
    }
}