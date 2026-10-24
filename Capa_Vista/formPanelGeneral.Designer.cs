namespace Capa_Vista
{
    partial class formPanelGeneral
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
            btn_GestionUsuarios = new Button();
            btn_CambiarContra = new Button();
            lbl_Bienvenida = new Label();
            lbl_Rol = new Label();
            btn_CerrarSesion = new Button();
            SuspendLayout();
            // 
            // btn_CambiarContra
            // 
            btn_CambiarContra.Location = new Point(136, 126);
            btn_CambiarContra.Name = "btn_CambiarContra";
            btn_CambiarContra.Size = new Size(165, 38);
            btn_CambiarContra.TabIndex = 0;
            btn_CambiarContra.Text = "Cambiar contraseña";
            btn_CambiarContra.UseVisualStyleBackColor = true;
            btn_CambiarContra.Click += btn_CambiarContra_Click;
            // 
            // btn_GestionUsuarios
            // 
            btn_GestionUsuarios.Location = new Point(136, 187);
            btn_GestionUsuarios.Name = "btn_GestionUsuarios";
            btn_GestionUsuarios.Size = new Size(165, 38);
            btn_GestionUsuarios.TabIndex = 1;
            btn_GestionUsuarios.Text = "Panel de administrador";
            btn_GestionUsuarios.UseVisualStyleBackColor = true;
            btn_GestionUsuarios.Click += btn_GestionUsuarios_Click;
            // 
            // lbl_Bienvenida
            // 
            lbl_Bienvenida.AutoSize = true;
            lbl_Bienvenida.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lbl_Bienvenida.Location = new Point(136, 48);
            lbl_Bienvenida.Name = "lbl_Bienvenida";
            lbl_Bienvenida.Size = new Size(166, 24);
            lbl_Bienvenida.TabIndex = 2;
            lbl_Bienvenida.Text = "Panel General";
            // 
            // lbl_Rol
            // 
            lbl_Rol.AutoSize = true;
            lbl_Rol.Location = new Point(12, 309);
            lbl_Rol.Name = "lbl_Rol";
            lbl_Rol.Size = new Size(38, 15);
            lbl_Rol.TabIndex = 3;
            lbl_Rol.Text = "label2";
            // 
            // btn_CerrarSesion
            // 
            btn_CerrarSesion.Location = new Point(347, 284);
            btn_CerrarSesion.Name = "btn_CerrarSesion";
            btn_CerrarSesion.Size = new Size(75, 40);
            btn_CerrarSesion.TabIndex = 4;
            btn_CerrarSesion.Text = "Cerrar sesion";
            btn_CerrarSesion.UseVisualStyleBackColor = true;
            btn_CerrarSesion.Click += btn_CerrarSesion_Click;
            // 
            // formPanelGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 335);
            Controls.Add(btn_CerrarSesion);
            Controls.Add(lbl_Rol);
            Controls.Add(lbl_Bienvenida);
            Controls.Add(btn_GestionUsuarios);
            Controls.Add(btn_CambiarContra);
            Name = "formPanelGeneral";
            Text = "formPanelGeneral";
            Load += formPanelGeneral_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_GestionUsuarios;
        private Button btn_CambiarContra;
        private Label lbl_Bienvenida;
        private Label lbl_Rol;
        private Button btn_CerrarSesion;
    }
}