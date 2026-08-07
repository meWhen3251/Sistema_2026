namespace Sistema_de_Gestion_de_Usuario
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbox_Usuario = new TextBox();
            tbox_Contrasena = new TextBox();
            btn_Login = new Button();
            lbl_Welcome = new Label();
            lbl_Contrasena = new Label();
            lbl_Usuario = new Label();
            Llabel_Recuperar = new LinkLabel();
            SuspendLayout();
            // 
            // tbox_Usuario
            // 
            tbox_Usuario.Font = new Font("Consolas", 9.75F);
            tbox_Usuario.Location = new Point(289, 143);
            tbox_Usuario.Name = "tbox_Usuario";
            tbox_Usuario.Size = new Size(230, 23);
            tbox_Usuario.TabIndex = 0;
            // 
            // tbox_Contrasena
            // 
            tbox_Contrasena.Location = new Point(289, 205);
            tbox_Contrasena.Name = "tbox_Contrasena";
            tbox_Contrasena.Size = new Size(230, 23);
            tbox_Contrasena.TabIndex = 1;
            // 
            // btn_Login
            // 
            btn_Login.Location = new Point(366, 244);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(75, 23);
            btn_Login.TabIndex = 2;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // lbl_Welcome
            // 
            lbl_Welcome.AutoSize = true;
            lbl_Welcome.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Welcome.Location = new Point(220, 31);
            lbl_Welcome.Name = "lbl_Welcome";
            lbl_Welcome.Size = new Size(370, 24);
            lbl_Welcome.TabIndex = 4;
            lbl_Welcome.Text = "Login con Usuario y Contraseña\r\n";
            // 
            // lbl_Contrasena
            // 
            lbl_Contrasena.AutoSize = true;
            lbl_Contrasena.Font = new Font("Consolas", 9.75F);
            lbl_Contrasena.Location = new Point(366, 187);
            lbl_Contrasena.Name = "lbl_Contrasena";
            lbl_Contrasena.Size = new Size(77, 15);
            lbl_Contrasena.TabIndex = 5;
            lbl_Contrasena.Text = "Contraseña";
            // 
            // lbl_Usuario
            // 
            lbl_Usuario.AutoSize = true;
            lbl_Usuario.Font = new Font("Consolas", 9.75F);
            lbl_Usuario.Location = new Point(377, 125);
            lbl_Usuario.Name = "lbl_Usuario";
            lbl_Usuario.Size = new Size(56, 15);
            lbl_Usuario.TabIndex = 6;
            lbl_Usuario.Text = "Usuario\r\n";
            // 
            // Llabel_Recuperar
            // 
            Llabel_Recuperar.AutoSize = true;
            Llabel_Recuperar.Location = new Point(265, 279);
            Llabel_Recuperar.Name = "Llabel_Recuperar";
            Llabel_Recuperar.Size = new Size(282, 15);
            Llabel_Recuperar.TabIndex = 3;
            Llabel_Recuperar.TabStop = true;
            Llabel_Recuperar.Text = "Olvidaste tu contraseña? Click aqui para recuperarla.";
            Llabel_Recuperar.LinkClicked += Llabel_Recuperar_LinkClicked;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Llabel_Recuperar);
            Controls.Add(lbl_Usuario);
            Controls.Add(lbl_Contrasena);
            Controls.Add(lbl_Welcome);
            Controls.Add(btn_Login);
            Controls.Add(tbox_Contrasena);
            Controls.Add(tbox_Usuario);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbox_Usuario;
        private TextBox tbox_Contrasena;
        private Button btn_Login;
        private Label lbl_Welcome;
        private Label lbl_Contrasena;
        private Label lbl_Usuario;
        private LinkLabel Llabel_Recuperar;
    }
}
