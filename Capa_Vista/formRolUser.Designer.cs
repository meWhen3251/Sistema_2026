namespace Capa_Vista
{
    partial class formRolUser
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
            dgv_TablasRoles = new DataGridView();
            btn_AgregarRol = new Button();
            btn_Volver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_TablasRoles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(266, 15);
            label1.TabIndex = 0;
            label1.Text = "Seleccionar el rol que se quiere agregar al usuario";
            // 
            // dgv_TablasRoles
            // 
            dgv_TablasRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_TablasRoles.Location = new Point(12, 27);
            dgv_TablasRoles.Name = "dgv_TablasRoles";
            dgv_TablasRoles.Size = new Size(488, 140);
            dgv_TablasRoles.TabIndex = 1;
            dgv_TablasRoles.CellClick += dgv_TablasRoles_CellClick;
            // 
            // btn_AgregarRol
            // 
            btn_AgregarRol.Location = new Point(12, 173);
            btn_AgregarRol.Name = "btn_AgregarRol";
            btn_AgregarRol.Size = new Size(121, 54);
            btn_AgregarRol.TabIndex = 2;
            btn_AgregarRol.Text = "Agregar rol (nombre de rol)";
            btn_AgregarRol.UseVisualStyleBackColor = true;
            btn_AgregarRol.Click += btn_AgregarRol_Click;
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
            // formRolUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 234);
            Controls.Add(btn_Volver);
            Controls.Add(btn_AgregarRol);
            Controls.Add(dgv_TablasRoles);
            Controls.Add(label1);
            Name = "formRolUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRolUser";
            Load += formRolUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_TablasRoles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgv_TablasRoles;
        private Button btn_AgregarRol;
        private Button btn_Volver;
    }
}