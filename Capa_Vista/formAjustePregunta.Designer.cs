namespace Capa_Vista
{
    partial class formAjustePregunta
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
            label2 = new Label();
            label3 = new Label();
            dgv_PreguntasS = new DataGridView();
            tbox_PreguntaAnterior = new TextBox();
            tbox_NuevaPregunta = new TextBox();
            btn_HabilitarPregunta = new Button();
            btn_AgregarPregunta = new Button();
            btn_ModificarPregunta = new Button();
            btn_ActualizarPregunta = new Button();
            tbox_PreguntaNueva = new TextBox();
            btn_Volver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_PreguntasS).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(339, 9);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 0;
            label1.Text = "Ajustes de preguntas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 367);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 1;
            label2.Text = "Pregunta anterior:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 396);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 2;
            label3.Text = "Pregunta nueva:";
            // 
            // dgv_PreguntasS
            // 
            dgv_PreguntasS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_PreguntasS.Location = new Point(12, 40);
            dgv_PreguntasS.Name = "dgv_PreguntasS";
            dgv_PreguntasS.Size = new Size(776, 244);
            dgv_PreguntasS.TabIndex = 3;
            // 
            // tbox_PreguntaAnterior
            // 
            tbox_PreguntaAnterior.Location = new Point(120, 367);
            tbox_PreguntaAnterior.Name = "tbox_PreguntaAnterior";
            tbox_PreguntaAnterior.ReadOnly = true;
            tbox_PreguntaAnterior.Size = new Size(211, 23);
            tbox_PreguntaAnterior.TabIndex = 4;
            // 
            // tbox_NuevaPregunta
            // 
            tbox_NuevaPregunta.Location = new Point(120, 396);
            tbox_NuevaPregunta.Name = "tbox_NuevaPregunta";
            tbox_NuevaPregunta.Size = new Size(211, 23);
            tbox_NuevaPregunta.TabIndex = 5;
            // 
            // btn_HabilitarPregunta
            // 
            btn_HabilitarPregunta.Location = new Point(184, 291);
            btn_HabilitarPregunta.Name = "btn_HabilitarPregunta";
            btn_HabilitarPregunta.Size = new Size(147, 38);
            btn_HabilitarPregunta.TabIndex = 6;
            btn_HabilitarPregunta.Text = "Habilitar / Deshabilitar pregunta";
            btn_HabilitarPregunta.UseVisualStyleBackColor = true;
            btn_HabilitarPregunta.Click += btn_HabilitarPregunta_Click;
            // 
            // btn_AgregarPregunta
            // 
            btn_AgregarPregunta.Location = new Point(608, 344);
            btn_AgregarPregunta.Name = "btn_AgregarPregunta";
            btn_AgregarPregunta.Size = new Size(147, 38);
            btn_AgregarPregunta.TabIndex = 7;
            btn_AgregarPregunta.Text = "Agregar nueva pregunta";
            btn_AgregarPregunta.UseVisualStyleBackColor = true;
            btn_AgregarPregunta.Click += btn_AgregarPregunta_Click;
            // 
            // btn_ModificarPregunta
            // 
            btn_ModificarPregunta.Location = new Point(12, 291);
            btn_ModificarPregunta.Name = "btn_ModificarPregunta";
            btn_ModificarPregunta.Size = new Size(157, 38);
            btn_ModificarPregunta.TabIndex = 8;
            btn_ModificarPregunta.Text = "Modificar pregunta seleccionada";
            btn_ModificarPregunta.UseVisualStyleBackColor = true;
            btn_ModificarPregunta.Click += btn_ModificarPregunta_Click;
            // 
            // btn_ActualizarPregunta
            // 
            btn_ActualizarPregunta.Location = new Point(339, 396);
            btn_ActualizarPregunta.Name = "btn_ActualizarPregunta";
            btn_ActualizarPregunta.Size = new Size(157, 23);
            btn_ActualizarPregunta.TabIndex = 9;
            btn_ActualizarPregunta.Text = "Actualizar pregunta";
            btn_ActualizarPregunta.UseVisualStyleBackColor = true;
            btn_ActualizarPregunta.Click += btn_ActualizarPregunta_Click;
            // 
            // tbox_PreguntaNueva
            // 
            tbox_PreguntaNueva.Location = new Point(576, 315);
            tbox_PreguntaNueva.Name = "tbox_PreguntaNueva";
            tbox_PreguntaNueva.Size = new Size(212, 23);
            tbox_PreguntaNueva.TabIndex = 10;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(713, 415);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 11;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // formAjustePregunta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Volver);
            Controls.Add(tbox_PreguntaNueva);
            Controls.Add(btn_ActualizarPregunta);
            Controls.Add(btn_ModificarPregunta);
            Controls.Add(btn_AgregarPregunta);
            Controls.Add(btn_HabilitarPregunta);
            Controls.Add(tbox_NuevaPregunta);
            Controls.Add(tbox_PreguntaAnterior);
            Controls.Add(dgv_PreguntasS);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "formAjustePregunta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAjustePregunta";
            Load += formAjustePregunta_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_PreguntasS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgv_PreguntasS;
        private TextBox tbox_PreguntaAnterior;
        private TextBox tbox_NuevaPregunta;
        private Button btn_HabilitarPregunta;
        private Button btn_AgregarPregunta;
        private Button btn_ModificarPregunta;
        private Button btn_ActualizarPregunta;
        private TextBox tbox_PreguntaNueva;
        private Button btn_Volver;
    }
}