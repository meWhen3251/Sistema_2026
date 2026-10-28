namespace Capa_Vista
{
    partial class formNuevoUsuario
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
            tbox_Nombre = new TextBox();
            tbox_Apellido = new TextBox();
            tbox_Correo = new TextBox();
            tbox_NombreUsuario = new TextBox();
            lbl_InfoPass = new Label();
            lbl_Nombre = new Label();
            lbl_Apellido = new Label();
            label5 = new Label();
            lbl_NombreUsuario = new Label();
            btn_Enviar = new Button();
            btn_Volver = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 14F, FontStyle.Bold);
            label1.Location = new Point(46, 9);
            label1.Name = "label1";
            label1.Size = new Size(310, 22);
            label1.TabIndex = 0;
            label1.Text = "Formulario de alta de usuarios";
            // 
            // tbox_Nombre
            // 
            tbox_Nombre.Location = new Point(76, 70);
            tbox_Nombre.MaxLength = 40;
            tbox_Nombre.Name = "tbox_Nombre";
            tbox_Nombre.Size = new Size(243, 23);
            tbox_Nombre.TabIndex = 1;
            // 
            // tbox_Apellido
            // 
            tbox_Apellido.Location = new Point(76, 114);
            tbox_Apellido.MaxLength = 40;
            tbox_Apellido.Name = "tbox_Apellido";
            tbox_Apellido.Size = new Size(243, 23);
            tbox_Apellido.TabIndex = 2;
            // 
            // tbox_Correo
            // 
            tbox_Correo.Location = new Point(76, 158);
            tbox_Correo.MaxLength = 50;
            tbox_Correo.Name = "tbox_Correo";
            tbox_Correo.Size = new Size(243, 23);
            tbox_Correo.TabIndex = 3;
            // 
            // tbox_NombreUsuario
            // 
            tbox_NombreUsuario.Location = new Point(76, 202);
            tbox_NombreUsuario.MaxLength = 50;
            tbox_NombreUsuario.Name = "tbox_NombreUsuario";
            tbox_NombreUsuario.Size = new Size(243, 23);
            tbox_NombreUsuario.TabIndex = 4;
            // 
            // lbl_InfoPass
            // 
            lbl_InfoPass.AutoSize = true;
            lbl_InfoPass.Location = new Point(56, 238);
            lbl_InfoPass.Name = "lbl_InfoPass";
            lbl_InfoPass.Size = new Size(290, 30);
            lbl_InfoPass.TabIndex = 5;
            lbl_InfoPass.Text = "La contraseña temporal se genera automáticamente y\r\nse envía al correo del usuario.";
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Font = new Font("Consolas", 9F);
            lbl_Nombre.Location = new Point(177, 53);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(49, 14);
            lbl_Nombre.TabIndex = 6;
            lbl_Nombre.Text = "Nombre";
            // 
            // lbl_Apellido
            // 
            lbl_Apellido.AutoSize = true;
            lbl_Apellido.Font = new Font("Consolas", 9F);
            lbl_Apellido.Location = new Point(170, 97);
            lbl_Apellido.Name = "lbl_Apellido";
            lbl_Apellido.Size = new Size(63, 14);
            lbl_Apellido.TabIndex = 7;
            lbl_Apellido.Text = "Apellido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Consolas", 9F);
            label5.Location = new Point(134, 141);
            label5.Name = "label5";
            label5.Size = new Size(133, 14);
            label5.TabIndex = 8;
            label5.Text = "Correo Electronico";
            // 
            // lbl_NombreUsuario
            // 
            lbl_NombreUsuario.AutoSize = true;
            lbl_NombreUsuario.Font = new Font("Consolas", 9F);
            lbl_NombreUsuario.Location = new Point(134, 185);
            lbl_NombreUsuario.Name = "lbl_NombreUsuario";
            lbl_NombreUsuario.Size = new Size(126, 14);
            lbl_NombreUsuario.TabIndex = 9;
            lbl_NombreUsuario.Text = "Nombre de usuario";
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(163, 288);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 23);
            btn_Enviar.TabIndex = 10;
            btn_Enviar.Text = "Registrar";
            btn_Enviar.UseVisualStyleBackColor = true;
            btn_Enviar.Click += btn_Enviar_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(322, 323);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 11;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // formNuevoUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 358);
            Controls.Add(btn_Volver);
            Controls.Add(btn_Enviar);
            Controls.Add(lbl_NombreUsuario);
            Controls.Add(label5);
            Controls.Add(lbl_Apellido);
            Controls.Add(lbl_Nombre);
            Controls.Add(lbl_InfoPass);
            Controls.Add(tbox_NombreUsuario);
            Controls.Add(tbox_Correo);
            Controls.Add(tbox_Apellido);
            Controls.Add(tbox_Nombre);
            Controls.Add(label1);
            Name = "formNuevoUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formNuevoUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbox_Nombre;
        private TextBox tbox_Apellido;
        private TextBox tbox_Correo;
        private TextBox tbox_NombreUsuario;
        private Label lbl_InfoPass;
        private Label lbl_Nombre;
        private Label lbl_Apellido;
        private Label label5;
        private Label lbl_NombreUsuario;
        private Button btn_Enviar;
        private Button btn_Volver;
    }
}