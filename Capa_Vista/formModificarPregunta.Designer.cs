namespace Capa_Vista
{
    partial class formModificarPregunta
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
            lbl_PSelect = new Label();
            lbl_PModificada = new Label();
            tbox_PreguntaSelect = new TextBox();
            tbox_PreguntaModificada = new TextBox();
            button1 = new Button();
            button2 = new Button();
            lbl_Bienvenida = new Label();
            SuspendLayout();
            // 
            // lbl_PSelect
            // 
            lbl_PSelect.AutoSize = true;
            lbl_PSelect.Location = new Point(12, 46);
            lbl_PSelect.Name = "lbl_PSelect";
            lbl_PSelect.Size = new Size(102, 15);
            lbl_PSelect.TabIndex = 0;
            lbl_PSelect.Text = "Pregunta anterior:";
            // 
            // lbl_PModificada
            // 
            lbl_PModificada.AutoSize = true;
            lbl_PModificada.Location = new Point(21, 85);
            lbl_PModificada.Name = "lbl_PModificada";
            lbl_PModificada.Size = new Size(93, 15);
            lbl_PModificada.TabIndex = 1;
            lbl_PModificada.Text = "Pregunta nueva:";
            // 
            // tbox_PreguntaSelect
            // 
            tbox_PreguntaSelect.Location = new Point(120, 46);
            tbox_PreguntaSelect.Name = "tbox_PreguntaSelect";
            tbox_PreguntaSelect.ReadOnly = true;
            tbox_PreguntaSelect.Size = new Size(199, 23);
            tbox_PreguntaSelect.TabIndex = 2;
            // 
            // tbox_PreguntaModificada
            // 
            tbox_PreguntaModificada.Location = new Point(120, 77);
            tbox_PreguntaModificada.Name = "tbox_PreguntaModificada";
            tbox_PreguntaModificada.Size = new Size(199, 23);
            tbox_PreguntaModificada.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(120, 115);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(257, 115);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // lbl_Bienvenida
            // 
            lbl_Bienvenida.AutoSize = true;
            lbl_Bienvenida.Location = new Point(48, 9);
            lbl_Bienvenida.Name = "lbl_Bienvenida";
            lbl_Bienvenida.Size = new Size(221, 15);
            lbl_Bienvenida.TabIndex = 6;
            lbl_Bienvenida.Text = "Formulario de Modificacion de Pregunta";
            // 
            // formModificarPregunta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 156);
            Controls.Add(lbl_Bienvenida);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tbox_PreguntaModificada);
            Controls.Add(tbox_PreguntaSelect);
            Controls.Add(lbl_PModificada);
            Controls.Add(lbl_PSelect);
            Name = "formModificarPregunta";
            Text = "formModificarPregunta";
            Load += formModificarPregunta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_PSelect;
        private Label lbl_PModificada;
        private TextBox tbox_PreguntaSelect;
        private TextBox tbox_PreguntaModificada;
        private Button button1;
        private Button button2;
        private Label lbl_Bienvenida;
    }
}