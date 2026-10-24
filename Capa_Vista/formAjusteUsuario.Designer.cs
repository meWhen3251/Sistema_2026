namespace Capa_Vista
{
    partial class formAjusteUsuario
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
            lbox_Roles = new ListBox();
            lbox_Familias = new ListBox();
            lbox_Permisos = new ListBox();
            lbox_PSRespondidas = new ListBox();
            btn_AgregarRol = new Button();
            btn_QuitarRol = new Button();
            btn_AgregarFamilia = new Button();
            btn_QuitarFamilia = new Button();
            btn_AgregarPermiso = new Button();
            btn_QuitarPermiso = new Button();
            groupBox1 = new GroupBox();
            flp_InformacionUsuario = new FlowLayoutPanel();
            btn_SolicitarNuevaPass = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            lbl_TiempoUltimaPass = new Label();
            btn_Volver = new Button();
            lbl_NombreUsuario = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lbox_Roles
            // 
            lbox_Roles.FormattingEnabled = true;
            lbox_Roles.ItemHeight = 15;
            lbox_Roles.Location = new Point(12, 74);
            lbox_Roles.Name = "lbox_Roles";
            lbox_Roles.Size = new Size(120, 94);
            lbox_Roles.TabIndex = 0;
            // 
            // lbox_Familias
            // 
            lbox_Familias.FormattingEnabled = true;
            lbox_Familias.ItemHeight = 15;
            lbox_Familias.Location = new Point(12, 207);
            lbox_Familias.Name = "lbox_Familias";
            lbox_Familias.Size = new Size(120, 94);
            lbox_Familias.TabIndex = 1;
            // 
            // lbox_Permisos
            // 
            lbox_Permisos.FormattingEnabled = true;
            lbox_Permisos.ItemHeight = 15;
            lbox_Permisos.Location = new Point(12, 344);
            lbox_Permisos.Name = "lbox_Permisos";
            lbox_Permisos.Size = new Size(120, 94);
            lbox_Permisos.TabIndex = 2;
            // 
            // lbox_PSRespondidas
            // 
            lbox_PSRespondidas.FormattingEnabled = true;
            lbox_PSRespondidas.ItemHeight = 15;
            lbox_PSRespondidas.Location = new Point(12, 466);
            lbox_PSRespondidas.Name = "lbox_PSRespondidas";
            lbox_PSRespondidas.Size = new Size(149, 154);
            lbox_PSRespondidas.TabIndex = 3;
            // 
            // btn_AgregarRol
            // 
            btn_AgregarRol.Location = new Point(138, 74);
            btn_AgregarRol.Name = "btn_AgregarRol";
            btn_AgregarRol.Size = new Size(127, 44);
            btn_AgregarRol.TabIndex = 4;
            btn_AgregarRol.Text = "Agregar rol...";
            btn_AgregarRol.UseVisualStyleBackColor = true;
            btn_AgregarRol.Click += btn_AgregarRol_Click;
            // 
            // btn_QuitarRol
            // 
            btn_QuitarRol.Location = new Point(138, 124);
            btn_QuitarRol.Name = "btn_QuitarRol";
            btn_QuitarRol.Size = new Size(127, 44);
            btn_QuitarRol.TabIndex = 5;
            btn_QuitarRol.Text = "Quitar rol seleccionado...";
            btn_QuitarRol.UseVisualStyleBackColor = true;
            btn_QuitarRol.Click += btn_QuitarRol_Click;
            // 
            // btn_AgregarFamilia
            // 
            btn_AgregarFamilia.Location = new Point(138, 207);
            btn_AgregarFamilia.Name = "btn_AgregarFamilia";
            btn_AgregarFamilia.Size = new Size(127, 44);
            btn_AgregarFamilia.TabIndex = 6;
            btn_AgregarFamilia.Text = "Agregar a familia...";
            btn_AgregarFamilia.UseVisualStyleBackColor = true;
            btn_AgregarFamilia.Click += btn_AgregarFamilia_Click;
            // 
            // btn_QuitarFamilia
            // 
            btn_QuitarFamilia.Location = new Point(138, 257);
            btn_QuitarFamilia.Name = "btn_QuitarFamilia";
            btn_QuitarFamilia.Size = new Size(127, 44);
            btn_QuitarFamilia.TabIndex = 7;
            btn_QuitarFamilia.Text = "Quitar de familia seleccionada...";
            btn_QuitarFamilia.UseVisualStyleBackColor = true;
            btn_QuitarFamilia.Click += btn_QuitarFamilia_Click;
            // 
            // btn_AgregarPermiso
            // 
            btn_AgregarPermiso.Location = new Point(138, 344);
            btn_AgregarPermiso.Name = "btn_AgregarPermiso";
            btn_AgregarPermiso.Size = new Size(127, 44);
            btn_AgregarPermiso.TabIndex = 8;
            btn_AgregarPermiso.Text = "Agregar permiso...";
            btn_AgregarPermiso.UseVisualStyleBackColor = true;
            btn_AgregarPermiso.Click += btn_AgregarPermiso_Click;
            // 
            // btn_QuitarPermiso
            // 
            btn_QuitarPermiso.Location = new Point(138, 390);
            btn_QuitarPermiso.Name = "btn_QuitarPermiso";
            btn_QuitarPermiso.Size = new Size(127, 44);
            btn_QuitarPermiso.TabIndex = 9;
            btn_QuitarPermiso.Text = "Quitar permiso seleccionado...";
            btn_QuitarPermiso.UseVisualStyleBackColor = true;
            btn_QuitarPermiso.Click += btn_QuitarPermiso_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flp_InformacionUsuario);
            groupBox1.Location = new Point(391, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(349, 352);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informacion personal";
            // 
            // flp_InformacionUsuario
            // 
            flp_InformacionUsuario.FlowDirection = FlowDirection.TopDown;
            flp_InformacionUsuario.Location = new Point(6, 22);
            flp_InformacionUsuario.Name = "flp_InformacionUsuario";
            flp_InformacionUsuario.Size = new Size(337, 324);
            flp_InformacionUsuario.TabIndex = 0;
            // 
            // btn_SolicitarNuevaPass
            // 
            btn_SolicitarNuevaPass.Location = new Point(448, 571);
            btn_SolicitarNuevaPass.Name = "btn_SolicitarNuevaPass";
            btn_SolicitarNuevaPass.Size = new Size(245, 49);
            btn_SolicitarNuevaPass.TabIndex = 11;
            btn_SolicitarNuevaPass.Text = "Solicitar nuevo cambio de contraseña";
            btn_SolicitarNuevaPass.UseVisualStyleBackColor = true;
            btn_SolicitarNuevaPass.Click += btn_SolicitarNuevaPass_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 51);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 12;
            label1.Text = "Roles";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 189);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 13;
            label2.Text = "Familias";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 326);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 14;
            label3.Text = "Permisos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 448);
            label5.Name = "label5";
            label5.Size = new Size(127, 15);
            label5.TabIndex = 16;
            label5.Text = "Preguntas respondidas";
            // 
            // lbl_TiempoUltimaPass
            // 
            lbl_TiempoUltimaPass.AutoSize = true;
            lbl_TiempoUltimaPass.Location = new Point(448, 551);
            lbl_TiempoUltimaPass.Name = "lbl_TiempoUltimaPass";
            lbl_TiempoUltimaPass.Size = new Size(245, 15);
            lbl_TiempoUltimaPass.TabIndex = 17;
            lbl_TiempoUltimaPass.Text = "Último cambio de contraseña: Hace (tiempo)";
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(713, 599);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 18;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // lbl_NombreUsuario
            // 
            lbl_NombreUsuario.AutoSize = true;
            lbl_NombreUsuario.Location = new Point(9, 9);
            lbl_NombreUsuario.Name = "lbl_NombreUsuario";
            lbl_NombreUsuario.Size = new Size(101, 15);
            lbl_NombreUsuario.TabIndex = 19;
            lbl_NombreUsuario.Text = "Usuario: (Usuario)";
            // 
            // formAjusteUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 632);
            Controls.Add(lbl_NombreUsuario);
            Controls.Add(btn_Volver);
            Controls.Add(lbl_TiempoUltimaPass);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_SolicitarNuevaPass);
            Controls.Add(groupBox1);
            Controls.Add(btn_QuitarPermiso);
            Controls.Add(btn_AgregarPermiso);
            Controls.Add(btn_QuitarFamilia);
            Controls.Add(btn_AgregarFamilia);
            Controls.Add(btn_QuitarRol);
            Controls.Add(btn_AgregarRol);
            Controls.Add(lbox_PSRespondidas);
            Controls.Add(lbox_Permisos);
            Controls.Add(lbox_Familias);
            Controls.Add(lbox_Roles);
            Name = "formAjusteUsuario";
            Text = "FormAjusteUsuario";
            Load += formAjusteUsuario_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbox_Roles;
        private ListBox lbox_Familias;
        private ListBox lbox_Permisos;
        private ListBox lbox_PSRespondidas;
        private Button btn_AgregarRol;
        private Button btn_QuitarRol;
        private Button btn_AgregarFamilia;
        private Button btn_QuitarFamilia;
        private Button btn_AgregarPermiso;
        private Button btn_QuitarPermiso;
        private GroupBox groupBox1;
        private Button btn_SolicitarNuevaPass;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label lbl_TiempoUltimaPass;
        private Button btn_Volver;
        private Label lbl_NombreUsuario;
        private FlowLayoutPanel flp_InformacionUsuario;
    }
}