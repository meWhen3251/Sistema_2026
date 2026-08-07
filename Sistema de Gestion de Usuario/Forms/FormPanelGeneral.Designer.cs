namespace Sistema_de_Gestion_de_Usuario.Forms
{
    partial class FormPanelGeneral
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lbl_Bienvenida = new Label();
            lbl_Rol = new Label();
            btn_CambiarContra = new Button();
            btn_GestionUsuarios = new Button();
            btn_CerrarSesion = new Button();
            SuspendLayout();
            // 
            // lbl_Bienvenida
            // 
            lbl_Bienvenida.AutoSize = true;
            lbl_Bienvenida.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lbl_Bienvenida.Location = new Point(170, 23);
            lbl_Bienvenida.Name = "lbl_Bienvenida";
            lbl_Bienvenida.Size = new Size(166, 24);
            lbl_Bienvenida.TabIndex = 0;
            lbl_Bienvenida.Text = "Panel General";
            lbl_Bienvenida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Rol
            // 
            lbl_Rol.AutoSize = true;
            lbl_Rol.Font = new Font("Consolas", 9.75F);
            lbl_Rol.Location = new Point(200, 80);
            lbl_Rol.Name = "lbl_Rol";
            lbl_Rol.Size = new Size(0, 15);
            lbl_Rol.TabIndex = 1;
            // 
            // btn_CambiarContra
            // 
            btn_CambiarContra.Location = new Point(170, 154);
            btn_CambiarContra.Name = "btn_CambiarContra";
            btn_CambiarContra.Size = new Size(180, 35);
            btn_CambiarContra.TabIndex = 0;
            btn_CambiarContra.Text = "Cambiar contraseña";
            btn_CambiarContra.UseVisualStyleBackColor = true;
            btn_CambiarContra.Click += btn_CambiarContra_Click;
            // 
            // btn_GestionUsuarios
            // 
            btn_GestionUsuarios.Location = new Point(170, 204);
            btn_GestionUsuarios.Name = "btn_GestionUsuarios";
            btn_GestionUsuarios.Size = new Size(180, 35);
            btn_GestionUsuarios.TabIndex = 1;
            btn_GestionUsuarios.Text = "Gestión de usuarios";
            btn_GestionUsuarios.UseVisualStyleBackColor = true;
            btn_GestionUsuarios.Visible = false;
            btn_GestionUsuarios.Click += btn_GestionUsuarios_Click;
            // 
            // btn_CerrarSesion
            // 
            btn_CerrarSesion.Location = new Point(466, 398);
            btn_CerrarSesion.Name = "btn_CerrarSesion";
            btn_CerrarSesion.Size = new Size(75, 40);
            btn_CerrarSesion.TabIndex = 2;
            btn_CerrarSesion.Text = "Cerrar sesion";
            btn_CerrarSesion.UseVisualStyleBackColor = true;
            btn_CerrarSesion.Click += btn_CerrarSesion_Click;
            // 
            // FormPanelGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 450);
            Controls.Add(btn_CerrarSesion);
            Controls.Add(lbl_Bienvenida);
            Controls.Add(lbl_Rol);
            Controls.Add(btn_CambiarContra);
            Controls.Add(btn_GestionUsuarios);
            Name = "FormPanelGeneral";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel General";
            Load += FormPanelGeneral_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lbl_Bienvenida;
        private Label lbl_Rol;
        private Button btn_CambiarContra;
        private Button btn_GestionUsuarios;
        private Button btn_CerrarSesion;
    }
}