namespace Capa_Vista
{
    partial class formConfiguraciones
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
            label1 = new Label();
            chk_MinContra = new CheckBox();
            chk_CantPreguntas = new CheckBox();
            chk_MayusMinus = new CheckBox();
            chk_NumCaracteres = new CheckBox();
            chk_CaracteresEsp = new CheckBox();
            chk_2FA = new CheckBox();
            chk_RepetirContra = new CheckBox();
            chk_DatosPersonales = new CheckBox();
            btn_Guardar = new Button();
            btn_Volver = new Button();
            nud_CantPreguntas = new NumericUpDown();
            nud_CantMinContra = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nud_CantPreguntas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_CantMinContra).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 14F, FontStyle.Bold);
            label1.Location = new Point(229, 9);
            label1.Name = "label1";
            label1.Size = new Size(310, 44);
            label1.TabIndex = 0;
            label1.Text = "Formulario de Configuraciones \r\ndel sistema";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chk_MinContra
            // 
            chk_MinContra.AutoSize = true;
            chk_MinContra.Font = new Font("Consolas", 10F);
            chk_MinContra.Location = new Point(12, 87);
            chk_MinContra.Name = "chk_MinContra";
            chk_MinContra.Size = new Size(435, 21);
            chk_MinContra.TabIndex = 1;
            chk_MinContra.Text = "Verificación de mínimo de caracteres en contraseña.";
            chk_MinContra.UseVisualStyleBackColor = true;
            chk_MinContra.CheckedChanged += chk_MinContra_CheckedChanged;
            // 
            // chk_CantPreguntas
            // 
            chk_CantPreguntas.AutoSize = true;
            chk_CantPreguntas.Font = new Font("Consolas", 10F);
            chk_CantPreguntas.Location = new Point(12, 114);
            chk_CantPreguntas.Name = "chk_CantPreguntas";
            chk_CantPreguntas.Size = new Size(411, 21);
            chk_CantPreguntas.TabIndex = 2;
            chk_CantPreguntas.Text = "Cantidad de preguntas a responder por el usuario";
            chk_CantPreguntas.UseVisualStyleBackColor = true;
            chk_CantPreguntas.CheckedChanged += chk_CantPreguntas_CheckedChanged;
            // 
            // chk_MayusMinus
            // 
            chk_MayusMinus.AutoSize = true;
            chk_MayusMinus.Font = new Font("Consolas", 10F);
            chk_MayusMinus.Location = new Point(12, 141);
            chk_MayusMinus.Name = "chk_MayusMinus";
            chk_MayusMinus.Size = new Size(451, 21);
            chk_MayusMinus.TabIndex = 3;
            chk_MayusMinus.Text = "Obligacion de combinación de mayúsculas y minúsculas.";
            chk_MayusMinus.UseVisualStyleBackColor = true;
            // 
            // chk_NumCaracteres
            // 
            chk_NumCaracteres.AutoSize = true;
            chk_NumCaracteres.Font = new Font("Consolas", 10F);
            chk_NumCaracteres.Location = new Point(12, 168);
            chk_NumCaracteres.Name = "chk_NumCaracteres";
            chk_NumCaracteres.Size = new Size(395, 21);
            chk_NumCaracteres.TabIndex = 4;
            chk_NumCaracteres.Text = "Obligacion de combinacion de números y letras.";
            chk_NumCaracteres.UseVisualStyleBackColor = true;
            // 
            // chk_CaracteresEsp
            // 
            chk_CaracteresEsp.AutoSize = true;
            chk_CaracteresEsp.Font = new Font("Consolas", 10F);
            chk_CaracteresEsp.Location = new Point(12, 195);
            chk_CaracteresEsp.Name = "chk_CaracteresEsp";
            chk_CaracteresEsp.Size = new Size(499, 21);
            chk_CaracteresEsp.TabIndex = 5;
            chk_CaracteresEsp.Text = "Obligacion de combinacion de al menos un carácter especial.";
            chk_CaracteresEsp.UseVisualStyleBackColor = true;
            // 
            // chk_2FA
            // 
            chk_2FA.AutoSize = true;
            chk_2FA.Font = new Font("Consolas", 10F);
            chk_2FA.Location = new Point(12, 222);
            chk_2FA.Name = "chk_2FA";
            chk_2FA.Size = new Size(547, 21);
            chk_2FA.TabIndex = 6;
            chk_2FA.Text = "Obligar la autenticación en 2FA utilizando el correo del usuario.";
            chk_2FA.UseVisualStyleBackColor = true;
            // 
            // chk_RepetirContra
            // 
            chk_RepetirContra.AutoSize = true;
            chk_RepetirContra.Font = new Font("Consolas", 10F);
            chk_RepetirContra.Location = new Point(12, 249);
            chk_RepetirContra.Name = "chk_RepetirContra";
            chk_RepetirContra.Size = new Size(403, 21);
            chk_RepetirContra.TabIndex = 7;
            chk_RepetirContra.Text = "No se permitirá repetir contraseñas anteriores.";
            chk_RepetirContra.UseVisualStyleBackColor = true;
            // 
            // chk_DatosPersonales
            // 
            chk_DatosPersonales.AutoSize = true;
            chk_DatosPersonales.Font = new Font("Consolas", 10F);
            chk_DatosPersonales.Location = new Point(12, 276);
            chk_DatosPersonales.Name = "chk_DatosPersonales";
            chk_DatosPersonales.Size = new Size(691, 21);
            chk_DatosPersonales.TabIndex = 8;
            chk_DatosPersonales.Text = "Verificar no contener datos personales registrados al momento del alta del sistema.";
            chk_DatosPersonales.UseVisualStyleBackColor = true;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Location = new Point(363, 314);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(75, 23);
            btn_Guardar.TabIndex = 9;
            btn_Guardar.Text = "Guardar";
            btn_Guardar.UseVisualStyleBackColor = true;
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(713, 314);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 10;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // nud_CantPreguntas
            // 
            nud_CantPreguntas.Location = new Point(429, 112);
            nud_CantPreguntas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_CantPreguntas.Name = "nud_CantPreguntas";
            nud_CantPreguntas.Size = new Size(120, 23);
            nud_CantPreguntas.TabIndex = 11;
            nud_CantPreguntas.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // nud_CantMinContra
            // 
            nud_CantMinContra.Location = new Point(439, 87);
            nud_CantMinContra.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            nud_CantMinContra.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            nud_CantMinContra.Name = "nud_CantMinContra";
            nud_CantMinContra.Size = new Size(120, 23);
            nud_CantMinContra.TabIndex = 12;
            nud_CantMinContra.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // formConfiguraciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 352);
            Controls.Add(nud_CantMinContra);
            Controls.Add(nud_CantPreguntas);
            Controls.Add(btn_Volver);
            Controls.Add(btn_Guardar);
            Controls.Add(chk_DatosPersonales);
            Controls.Add(chk_RepetirContra);
            Controls.Add(chk_2FA);
            Controls.Add(chk_CaracteresEsp);
            Controls.Add(chk_NumCaracteres);
            Controls.Add(chk_MayusMinus);
            Controls.Add(chk_CantPreguntas);
            Controls.Add(chk_MinContra);
            Controls.Add(label1);
            Name = "formConfiguraciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formConfiguraciones";
            FormClosing += formConfiguraciones_FormClosing;
            Load += formConfiguraciones_Load;
            ((System.ComponentModel.ISupportInitialize)nud_CantPreguntas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_CantMinContra).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox chk_MinContra;
        private CheckBox chk_CantPreguntas;
        private CheckBox chk_MayusMinus;
        private CheckBox chk_NumCaracteres;
        private CheckBox chk_CaracteresEsp;
        private CheckBox chk_2FA;
        private CheckBox chk_RepetirContra;
        private CheckBox chk_DatosPersonales;
        private Button btn_Guardar;
        private Button btn_Volver;
        private NumericUpDown nud_CantPreguntas;
        private NumericUpDown nud_CantMinContra;
    }
}