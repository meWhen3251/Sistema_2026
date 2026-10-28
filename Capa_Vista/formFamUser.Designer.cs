namespace Capa_Vista
{
    partial class formFamUser
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
            dgv_TablaFamilia = new DataGridView();
            btn_AgregarFamilia = new Button();
            btn_Volver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_TablaFamilia).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(302, 15);
            label1.TabIndex = 0;
            label1.Text = "Seleccionar la familia la cual se quiere agregar al usuario";
            // 
            // dgv_TablaFamilia
            // 
            dgv_TablaFamilia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_TablaFamilia.Location = new Point(12, 27);
            dgv_TablaFamilia.Name = "dgv_TablaFamilia";
            dgv_TablaFamilia.Size = new Size(488, 140);
            dgv_TablaFamilia.TabIndex = 1;
            dgv_TablaFamilia.CellClick += dgv_TablaFamilia_CellClick;
            // 
            // btn_AgregarFamilia
            // 
            btn_AgregarFamilia.Location = new Point(12, 173);
            btn_AgregarFamilia.Name = "btn_AgregarFamilia";
            btn_AgregarFamilia.Size = new Size(121, 54);
            btn_AgregarFamilia.TabIndex = 2;
            btn_AgregarFamilia.Text = "Agregar a familia (nombre de familia)";
            btn_AgregarFamilia.UseVisualStyleBackColor = true;
            btn_AgregarFamilia.Click += btn_AgregarFamilia_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(361, 181);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(139, 38);
            btn_Volver.TabIndex = 3;
            btn_Volver.Text = "Volver a menú anterior";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // formFamUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 234);
            Controls.Add(btn_Volver);
            Controls.Add(btn_AgregarFamilia);
            Controls.Add(dgv_TablaFamilia);
            Controls.Add(label1);
            Name = "formFamUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormFamUser";
            Load += formFamUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_TablaFamilia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgv_TablaFamilia;
        private Button btn_AgregarFamilia;
        private Button btn_Volver;
    }
}