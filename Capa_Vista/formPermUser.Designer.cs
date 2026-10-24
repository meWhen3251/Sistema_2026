namespace Capa_Vista
{
    partial class formPermUser
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
            dgv_TablaPermisos = new DataGridView();
            btn_AgregarPermiso = new Button();
            btn_Volver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_TablaPermisos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(295, 15);
            label1.TabIndex = 0;
            label1.Text = "Seleccionar el permiso que se quiere agregar al usuario";
            // 
            // dgv_TablaPermisos
            // 
            dgv_TablaPermisos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_TablaPermisos.Location = new Point(12, 27);
            dgv_TablaPermisos.Name = "dgv_TablaPermisos";
            dgv_TablaPermisos.Size = new Size(488, 140);
            dgv_TablaPermisos.TabIndex = 1;
            dgv_TablaPermisos.CellClick += dgv_TablaPermisos_CellClick;
            // 
            // btn_AgregarPermiso
            // 
            btn_AgregarPermiso.Location = new Point(12, 173);
            btn_AgregarPermiso.Name = "btn_AgregarPermiso";
            btn_AgregarPermiso.Size = new Size(139, 54);
            btn_AgregarPermiso.TabIndex = 2;
            btn_AgregarPermiso.Text = "Agregar permiso \"(nombre de permiso)\"";
            btn_AgregarPermiso.UseVisualStyleBackColor = true;
            btn_AgregarPermiso.Click += btn_AgregarPermiso_Click;
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
            // formPermUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 234);
            Controls.Add(btn_Volver);
            Controls.Add(btn_AgregarPermiso);
            Controls.Add(dgv_TablaPermisos);
            Controls.Add(label1);
            Name = "formPermUser";
            Text = "formPermUser";
            Load += formPermUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_TablaPermisos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgv_TablaPermisos;
        private Button btn_AgregarPermiso;
        private Button btn_Volver;
    }
}