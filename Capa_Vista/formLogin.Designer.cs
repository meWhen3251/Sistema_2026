namespace Capa_Vista
{
    partial class formLogin
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
            lbl_Bievenida = new Label();
            lbl_Usuario = new Label();
            lbl_Contrasena = new Label();
            Llabel_Recuperar = new LinkLabel();
            tbox_Usuario = new TextBox();
            tbox_Contrasena = new TextBox();
            btn_Login = new Button();
            SuspendLayout();
            // 
            // lbl_Contrasena
            // 
            lbl_Contrasena.AutoSize = true;
            lbl_Contrasena.Font = new Font("Consolas", 9F);
            lbl_Contrasena.Location = new Point(304, 170);
            lbl_Contrasena.Name = "lbl_Contrasena";
            lbl_Contrasena.Size = new Size(77, 14);
            lbl_Contrasena.TabIndex = 13;
            lbl_Contrasena.Text = "Contraseña";
            // 
            // lbl_Usuario
            // 
            lbl_Usuario.AutoSize = true;
            lbl_Usuario.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Usuario.Location = new Point(284, 121);
            lbl_Usuario.Name = "lbl_Usuario";
            lbl_Usuario.Size = new Size(126, 14);
            lbl_Usuario.TabIndex = 12;
            lbl_Usuario.Text = "Nombre de Usuario";
            // 
            // Llabel_Recuperar
            // 
            Llabel_Recuperar.AutoSize = true;
            Llabel_Recuperar.Location = new Point(205, 271);
            Llabel_Recuperar.Name = "Llabel_Recuperar";
            Llabel_Recuperar.Size = new Size(282, 15);
            Llabel_Recuperar.TabIndex = 11;
            Llabel_Recuperar.TabStop = true;
            Llabel_Recuperar.Text = "Olvidaste tu contraseña? Click aqui para recuperarla.";
            Llabel_Recuperar.LinkClicked += Llabel_Recuperar_LinkClicked;
            // 
            // tbox_Contrasena
            // 
            tbox_Contrasena.Location = new Point(224, 187);
            tbox_Contrasena.Name = "tbox_Contrasena";
            tbox_Contrasena.Size = new Size(248, 23);
            tbox_Contrasena.TabIndex = 10;
            // 
            // tbox_Usuario
            // 
            tbox_Usuario.Location = new Point(224, 138);
            tbox_Usuario.Name = "tbox_Usuario";
            tbox_Usuario.Size = new Size(248, 23);
            tbox_Usuario.TabIndex = 9;
            // 
            // btn_Login
            // 
            btn_Login.Location = new Point(303, 229);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(86, 23);
            btn_Login.TabIndex = 8;
            btn_Login.Text = "Iniciar Sesion";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // lbl_Bienvenida
            // 
            lbl_Bievenida.AutoSize = true;
            lbl_Bievenida.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Bievenida.Location = new Point(161, 50);
            lbl_Bievenida.Name = "lbl_Bienvenida";
            lbl_Bievenida.Size = new Size(370, 24);
            lbl_Bievenida.TabIndex = 7;
            lbl_Bievenida.Text = "Login con usuario y contraseña";
            // 
            // formLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 407);
            Controls.Add(lbl_Contrasena);
            Controls.Add(lbl_Usuario);
            Controls.Add(Llabel_Recuperar);
            Controls.Add(tbox_Contrasena);
            Controls.Add(tbox_Usuario);
            Controls.Add(btn_Login);
            Controls.Add(lbl_Bievenida);
            Name = "formLogin";
            Text = "Form1";
            Load += formLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Bievenida;
        private Label lbl_Usuario;
        private Label lbl_Contrasena;
        private LinkLabel Llabel_Recuperar;
        private TextBox tbox_Usuario;
        private TextBox tbox_Contrasena;
        private Button btn_Login;
    }
}