namespace Capa_Vista
{
    partial class formAjusteRol
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
            dgv_Roles = new DataGridView();
            label1 = new Label();
            btn_ModificarRol = new Button();
            btn_AgregarRol = new Button();
            btn_EliminarRol = new Button();
            btn_Volver = new Button();
            tbox_RolSeleccionado = new TextBox();
            tbox_RolModificado = new TextBox();
            btn_ActualizarRol = new Button();
            label2 = new Label();
            label3 = new Label();
            tbox_NuevoRol = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv_Roles).BeginInit();
            SuspendLayout();
            // 
            // dgv_Roles
            // 
            dgv_Roles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Roles.Location = new Point(12, 49);
            dgv_Roles.Name = "dgv_Roles";
            dgv_Roles.Size = new Size(776, 222);
            dgv_Roles.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(337, 9);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 1;
            label1.Text = "Ajustes de Roles";
            // 
            // btn_ModificarRol
            // 
            btn_ModificarRol.Location = new Point(626, 302);
            btn_ModificarRol.Name = "btn_ModificarRol";
            btn_ModificarRol.Size = new Size(162, 38);
            btn_ModificarRol.TabIndex = 2;
            btn_ModificarRol.Text = "Modificar Rol Seleccionado";
            btn_ModificarRol.UseVisualStyleBackColor = true;
            btn_ModificarRol.Click += btn_ModificarRol_Click;
            // 
            // btn_AgregarRol
            // 
            btn_AgregarRol.Location = new Point(396, 346);
            btn_AgregarRol.Name = "btn_AgregarRol";
            btn_AgregarRol.Size = new Size(162, 38);
            btn_AgregarRol.TabIndex = 3;
            btn_AgregarRol.Text = "Agregar nuevo rol";
            btn_AgregarRol.UseVisualStyleBackColor = true;
            btn_AgregarRol.Click += btn_AgregarRol_Click;
            // 
            // btn_EliminarRol
            // 
            btn_EliminarRol.Location = new Point(12, 346);
            btn_EliminarRol.Name = "btn_EliminarRol";
            btn_EliminarRol.Size = new Size(162, 38);
            btn_EliminarRol.TabIndex = 4;
            btn_EliminarRol.Text = "Eliminar rol seleccionado";
            btn_EliminarRol.UseVisualStyleBackColor = true;
            btn_EliminarRol.Click += btn_EliminarRol_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(713, 367);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 5;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // tbox_RolSeleccionado
            // 
            tbox_RolSeleccionado.Location = new Point(117, 288);
            tbox_RolSeleccionado.Name = "tbox_RolSeleccionado";
            tbox_RolSeleccionado.ReadOnly = true;
            tbox_RolSeleccionado.Size = new Size(162, 23);
            tbox_RolSeleccionado.TabIndex = 6;
            // 
            // tbox_RolModificado
            // 
            tbox_RolModificado.Location = new Point(117, 320);
            tbox_RolModificado.Name = "tbox_RolModificado";
            tbox_RolModificado.Size = new Size(162, 23);
            tbox_RolModificado.TabIndex = 7;
            // 
            // btn_ActualizarRol
            // 
            btn_ActualizarRol.Location = new Point(192, 346);
            btn_ActualizarRol.Name = "btn_ActualizarRol";
            btn_ActualizarRol.Size = new Size(162, 38);
            btn_ActualizarRol.TabIndex = 8;
            btn_ActualizarRol.Text = "Actualizar Rol";
            btn_ActualizarRol.UseVisualStyleBackColor = true;
            btn_ActualizarRol.Click += btn_ActualizarRol_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 291);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 9;
            label2.Text = "Rol seleccionado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 323);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 10;
            label3.Text = "Rol modificado:";
            // 
            // tbox_NuevoRol
            // 
            tbox_NuevoRol.Location = new Point(396, 317);
            tbox_NuevoRol.Name = "tbox_NuevoRol";
            tbox_NuevoRol.Size = new Size(162, 23);
            tbox_NuevoRol.TabIndex = 11;
            // 
            // formAjusteRol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 401);
            Controls.Add(tbox_NuevoRol);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btn_ActualizarRol);
            Controls.Add(tbox_RolModificado);
            Controls.Add(tbox_RolSeleccionado);
            Controls.Add(btn_Volver);
            Controls.Add(btn_EliminarRol);
            Controls.Add(btn_AgregarRol);
            Controls.Add(btn_ModificarRol);
            Controls.Add(label1);
            Controls.Add(dgv_Roles);
            Name = "formAjusteRol";
            Text = "FormAjusteRol";
            Load += formAjusteRol_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Roles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_Roles;
        private Label label1;
        private Button btn_ModificarRol;
        private Button btn_AgregarRol;
        private Button btn_EliminarRol;
        private Button btn_Volver;
        private TextBox tbox_RolSeleccionado;
        private TextBox tbox_RolModificado;
        private Button btn_ActualizarRol;
        private Label label2;
        private Label label3;
        private TextBox tbox_NuevoRol;
    }
}