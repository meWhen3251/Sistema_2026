namespace Capa_Vista
{
    partial class formPanelAdmin
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
            dgv_ListaUsuarios = new DataGridView();
            lbl_Bienvenida = new Label();
            lbl_ListaUsuarios = new Label();
            btn_ConfigSistema = new Button();
            btn_AjustePreguntas = new Button();
            btn_AjusteRoles = new Button();
            btn_AjusteUserSelect = new Button();
            btn_Volver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_ListaUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgv_ListaUsuarios
            // 
            dgv_ListaUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ListaUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ListaUsuarios.Location = new Point(31, 60);
            dgv_ListaUsuarios.MultiSelect = false;
            dgv_ListaUsuarios.Name = "dgv_ListaUsuarios";
            dgv_ListaUsuarios.ReadOnly = true;
            dgv_ListaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ListaUsuarios.Size = new Size(737, 237);
            dgv_ListaUsuarios.TabIndex = 0;
            // 
            // lbl_Bienvenida
            // 
            lbl_Bienvenida.AutoSize = true;
            lbl_Bienvenida.Font = new Font("Consolas", 14F, FontStyle.Bold);
            lbl_Bienvenida.Location = new Point(276, 9);
            lbl_Bienvenida.Name = "lbl_Bienvenida";
            lbl_Bienvenida.Size = new Size(220, 22);
            lbl_Bienvenida.TabIndex = 1;
            lbl_Bienvenida.Text = "Menu de Administrador";
            // 
            // lbl_ListaUsuarios
            // 
            lbl_ListaUsuarios.AutoSize = true;
            lbl_ListaUsuarios.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ListaUsuarios.Location = new Point(31, 39);
            lbl_ListaUsuarios.Name = "lbl_ListaUsuarios";
            lbl_ListaUsuarios.Size = new Size(144, 18);
            lbl_ListaUsuarios.TabIndex = 2;
            lbl_ListaUsuarios.Text = "Lista de Usuarios";
            // 
            // btn_ConfigSistema
            // 
            btn_ConfigSistema.Location = new Point(604, 317);
            btn_ConfigSistema.Name = "btn_ConfigSistema";
            btn_ConfigSistema.Size = new Size(113, 41);
            btn_ConfigSistema.TabIndex = 7;
            btn_ConfigSistema.Text = "Configuraciones del sistema";
            btn_ConfigSistema.UseVisualStyleBackColor = true;
            // 
            // btn_AjustePreguntas
            // 
            btn_AjustePreguntas.Location = new Point(427, 317);
            btn_AjustePreguntas.Name = "btn_AjustePreguntas";
            btn_AjustePreguntas.Size = new Size(113, 41);
            btn_AjustePreguntas.TabIndex = 5;
            btn_AjustePreguntas.Text = "Ajuste de Preguntas";
            btn_AjustePreguntas.UseVisualStyleBackColor = true;
            btn_AjustePreguntas.Click += btn_AjustePreguntas_Click;
            // 
            // btn_AjusteRoles
            // 
            btn_AjusteRoles.Location = new Point(252, 317);
            btn_AjusteRoles.Name = "btn_AjusteRoles";
            btn_AjusteRoles.Size = new Size(113, 41);
            btn_AjusteRoles.TabIndex = 4;
            btn_AjusteRoles.Text = "Ajuste de Roles";
            btn_AjusteRoles.UseVisualStyleBackColor = true;
            btn_AjusteRoles.Click += btn_AjusteRoles_Click;
            // 
            // btn_AjusteUserSelect
            // 
            btn_AjusteUserSelect.Location = new Point(54, 317);
            btn_AjusteUserSelect.Name = "btn_AjusteUserSelect";
            btn_AjusteUserSelect.Size = new Size(121, 41);
            btn_AjusteUserSelect.TabIndex = 3;
            btn_AjusteUserSelect.Text = "Ajustes de Usuario Seleccionado";
            btn_AjusteUserSelect.UseVisualStyleBackColor = true;
            btn_AjusteUserSelect.Click += btn_AjusteUserSelect_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(670, 389);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(118, 42);
            btn_Volver.TabIndex = 8;
            btn_Volver.Text = "Volver al panel general";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // formPanelAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 445);
            Controls.Add(btn_Volver);
            Controls.Add(btn_ConfigSistema);
            Controls.Add(btn_AjustePreguntas);
            Controls.Add(btn_AjusteRoles);
            Controls.Add(btn_AjusteUserSelect);
            Controls.Add(lbl_ListaUsuarios);
            Controls.Add(lbl_Bienvenida);
            Controls.Add(dgv_ListaUsuarios);
            Name = "formPanelAdmin";
            Text = "FormPanelAdmin";
            Load += formPanelAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_ListaUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_ListaUsuarios;
        private Label lbl_Bienvenida;
        private Label lbl_ListaUsuarios;
        private Button btn_ConfigSistema;
        private Button btn_AjustePreguntas;
        private Button btn_AjusteRoles;
        private Button btn_AjusteUserSelect;
        private Button btn_Volver;
    }
}