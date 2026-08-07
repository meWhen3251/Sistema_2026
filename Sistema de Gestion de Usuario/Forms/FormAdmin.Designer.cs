namespace Sistema_de_Gestion_de_Usuario.Forms
{
    partial class FormAdmin
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
            btn_Registrar = new Button();
            tbox_Usuario = new TextBox();
            tbox_Email = new TextBox();
            lbl_Welcome = new Label();
            lbl_Usuario = new Label();
            lbl_Email = new Label();
            btn_PSAñadir = new Button();
            tbox_PSAnadir = new TextBox();
            lbl_IntPreguntas = new Label();
            lbl_Pregunta = new Label();
            lbl_IntRegistro = new Label();
            cbox_PS = new ComboBox();
            tbox_PSSeleccionado = new TextBox();
            btn_PSModificar = new Button();
            btn_PSDesactivar = new Button();
            label1 = new Label();
            tbox_Apellido = new TextBox();
            tbox_Nombre = new TextBox();
            lbl_Nombre = new Label();
            lbl_Apellido = new Label();
            cbox_RolNuevo = new ComboBox();
            lbl_RolNuevo = new Label();
            cbox_UserSeleccionado = new ComboBox();
            lbl_UserSelected = new Label();
            lbl_CambioRoles = new Label();
            btn_CambiarRol = new Button();
            btn_Volver = new Button();
            SuspendLayout();
            // 
            // btn_Registrar
            // 
            btn_Registrar.Location = new Point(123, 323);
            btn_Registrar.Name = "btn_Registrar";
            btn_Registrar.Size = new Size(75, 23);
            btn_Registrar.TabIndex = 4;
            btn_Registrar.Text = "Registrar";
            btn_Registrar.UseVisualStyleBackColor = true;
            btn_Registrar.Click += btn_Registrar_Click;
            // 
            // tbox_Usuario
            // 
            tbox_Usuario.Location = new Point(12, 247);
            tbox_Usuario.Name = "tbox_Usuario";
            tbox_Usuario.Size = new Size(295, 23);
            tbox_Usuario.TabIndex = 2;
            // 
            // tbox_Email
            // 
            tbox_Email.Location = new Point(12, 294);
            tbox_Email.Name = "tbox_Email";
            tbox_Email.Size = new Size(295, 23);
            tbox_Email.TabIndex = 3;
            // 
            // lbl_Welcome
            // 
            lbl_Welcome.AutoSize = true;
            lbl_Welcome.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Welcome.Location = new Point(372, 9);
            lbl_Welcome.Name = "lbl_Welcome";
            lbl_Welcome.Size = new Size(274, 24);
            lbl_Welcome.TabIndex = 4;
            lbl_Welcome.Text = "Panel de Administrador";
            lbl_Welcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Usuario
            // 
            lbl_Usuario.AutoSize = true;
            lbl_Usuario.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Usuario.Location = new Point(135, 229);
            lbl_Usuario.Name = "lbl_Usuario";
            lbl_Usuario.Size = new Size(56, 15);
            lbl_Usuario.TabIndex = 5;
            lbl_Usuario.Text = "Usuario";
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.Font = new Font("Consolas", 9.75F);
            lbl_Email.Location = new Point(96, 276);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(133, 15);
            lbl_Email.TabIndex = 6;
            lbl_Email.Text = "Correo Electronico";
            // 
            // btn_PSAñadir
            // 
            btn_PSAñadir.Location = new Point(470, 180);
            btn_PSAñadir.Name = "btn_PSAñadir";
            btn_PSAñadir.Size = new Size(63, 23);
            btn_PSAñadir.TabIndex = 9;
            btn_PSAñadir.Text = "Añadir";
            btn_PSAñadir.UseVisualStyleBackColor = true;
            btn_PSAñadir.Click += btn_PSAñadir_Click;
            // 
            // tbox_PSAnadir
            // 
            tbox_PSAnadir.Location = new Point(372, 151);
            tbox_PSAnadir.Name = "tbox_PSAnadir";
            tbox_PSAnadir.Size = new Size(251, 23);
            tbox_PSAnadir.TabIndex = 8;
            // 
            // lbl_IntPreguntas
            // 
            lbl_IntPreguntas.AutoSize = true;
            lbl_IntPreguntas.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IntPreguntas.Location = new Point(389, 95);
            lbl_IntPreguntas.Name = "lbl_IntPreguntas";
            lbl_IntPreguntas.Size = new Size(207, 19);
            lbl_IntPreguntas.TabIndex = 9;
            lbl_IntPreguntas.Text = "Preguntas de Seguridad";
            // 
            // lbl_Pregunta
            // 
            lbl_Pregunta.AutoSize = true;
            lbl_Pregunta.Font = new Font("Consolas", 9.75F);
            lbl_Pregunta.Location = new Point(470, 133);
            lbl_Pregunta.Name = "lbl_Pregunta";
            lbl_Pregunta.Size = new Size(63, 15);
            lbl_Pregunta.TabIndex = 10;
            lbl_Pregunta.Text = "Pregunta";
            // 
            // lbl_IntRegistro
            // 
            lbl_IntRegistro.AutoSize = true;
            lbl_IntRegistro.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IntRegistro.Location = new Point(70, 95);
            lbl_IntRegistro.Name = "lbl_IntRegistro";
            lbl_IntRegistro.Size = new Size(189, 19);
            lbl_IntRegistro.TabIndex = 11;
            lbl_IntRegistro.Text = "Registro de Usuarios";
            // 
            // cbox_PS
            // 
            cbox_PS.FormattingEnabled = true;
            cbox_PS.Location = new Point(372, 247);
            cbox_PS.Name = "cbox_PS";
            cbox_PS.Size = new Size(251, 23);
            cbox_PS.TabIndex = 10;
            cbox_PS.SelectedIndexChanged += cbox_PS_SelectedIndexChanged;
            // 
            // tbox_PSSeleccionado
            // 
            tbox_PSSeleccionado.Location = new Point(372, 276);
            tbox_PSSeleccionado.Name = "tbox_PSSeleccionado";
            tbox_PSSeleccionado.Size = new Size(251, 23);
            tbox_PSSeleccionado.TabIndex = 11;
            tbox_PSSeleccionado.Visible = false;
            // 
            // btn_PSModificar
            // 
            btn_PSModificar.Location = new Point(413, 305);
            btn_PSModificar.Name = "btn_PSModificar";
            btn_PSModificar.Size = new Size(75, 23);
            btn_PSModificar.TabIndex = 12;
            btn_PSModificar.Text = "Modificar";
            btn_PSModificar.UseVisualStyleBackColor = true;
            btn_PSModificar.Visible = false;
            btn_PSModificar.Click += btn_PSModificar_Click;
            // 
            // btn_PSDesactivar
            // 
            btn_PSDesactivar.Location = new Point(503, 305);
            btn_PSDesactivar.Name = "btn_PSDesactivar";
            btn_PSDesactivar.Size = new Size(75, 23);
            btn_PSDesactivar.TabIndex = 13;
            btn_PSDesactivar.Text = "Desactivar";
            btn_PSDesactivar.UseVisualStyleBackColor = true;
            btn_PSDesactivar.Visible = false;
            btn_PSDesactivar.Click += btn_PSDesactivar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 9.75F);
            label1.Location = new Point(428, 229);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 17;
            label1.Text = "Ajustes de Pregunta";
            // 
            // tbox_Apellido
            // 
            tbox_Apellido.Location = new Point(12, 196);
            tbox_Apellido.Name = "tbox_Apellido";
            tbox_Apellido.Size = new Size(295, 23);
            tbox_Apellido.TabIndex = 1;
            // 
            // tbox_Nombre
            // 
            tbox_Nombre.Location = new Point(12, 151);
            tbox_Nombre.Name = "tbox_Nombre";
            tbox_Nombre.Size = new Size(295, 23);
            tbox_Nombre.TabIndex = 0;
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Font = new Font("Consolas", 9.75F);
            lbl_Nombre.Location = new Point(142, 133);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(49, 15);
            lbl_Nombre.TabIndex = 23;
            lbl_Nombre.Text = "Nombre";
            // 
            // lbl_Apellido
            // 
            lbl_Apellido.AutoSize = true;
            lbl_Apellido.Font = new Font("Consolas", 9.75F);
            lbl_Apellido.Location = new Point(135, 178);
            lbl_Apellido.Name = "lbl_Apellido";
            lbl_Apellido.Size = new Size(63, 15);
            lbl_Apellido.TabIndex = 24;
            lbl_Apellido.Text = "Apellido";
            // 
            // cbox_RolNuevo
            // 
            cbox_RolNuevo.Enabled = false;
            cbox_RolNuevo.FormattingEnabled = true;
            cbox_RolNuevo.Location = new Point(25, 483);
            cbox_RolNuevo.Name = "cbox_RolNuevo";
            cbox_RolNuevo.Size = new Size(142, 23);
            cbox_RolNuevo.TabIndex = 6;
            cbox_RolNuevo.SelectedIndexChanged += cbox_RolNuevo_SelectedIndexChanged;
            // 
            // lbl_RolNuevo
            // 
            lbl_RolNuevo.AutoSize = true;
            lbl_RolNuevo.Font = new Font("Consolas", 9.75F);
            lbl_RolNuevo.Location = new Point(63, 465);
            lbl_RolNuevo.Name = "lbl_RolNuevo";
            lbl_RolNuevo.Size = new Size(70, 15);
            lbl_RolNuevo.TabIndex = 26;
            lbl_RolNuevo.Text = "Rol nuevo";
            // 
            // cbox_UserSeleccionado
            // 
            cbox_UserSeleccionado.FormattingEnabled = true;
            cbox_UserSeleccionado.Location = new Point(25, 439);
            cbox_UserSeleccionado.Name = "cbox_UserSeleccionado";
            cbox_UserSeleccionado.Size = new Size(142, 23);
            cbox_UserSeleccionado.TabIndex = 5;
            cbox_UserSeleccionado.SelectedIndexChanged += cbox_UserSeleccionado_SelectedIndexChanged;
            // 
            // lbl_UserSelected
            // 
            lbl_UserSelected.AutoSize = true;
            lbl_UserSelected.Location = new Point(35, 421);
            lbl_UserSelected.Name = "lbl_UserSelected";
            lbl_UserSelected.Size = new Size(119, 15);
            lbl_UserSelected.TabIndex = 28;
            lbl_UserSelected.Text = "Usuario seleccionado";
            // 
            // lbl_CambioRoles
            // 
            lbl_CambioRoles.AutoSize = true;
            lbl_CambioRoles.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lbl_CambioRoles.Location = new Point(35, 391);
            lbl_CambioRoles.Name = "lbl_CambioRoles";
            lbl_CambioRoles.Size = new Size(126, 19);
            lbl_CambioRoles.TabIndex = 29;
            lbl_CambioRoles.Text = "Agregar roles";
            // 
            // btn_CambiarRol
            // 
            btn_CambiarRol.Enabled = false;
            btn_CambiarRol.Location = new Point(63, 512);
            btn_CambiarRol.Name = "btn_CambiarRol";
            btn_CambiarRol.Size = new Size(79, 23);
            btn_CambiarRol.TabIndex = 7;
            btn_CambiarRol.Text = "Agregar";
            btn_CambiarRol.UseVisualStyleBackColor = true;
            btn_CambiarRol.Click += btn_CambiarRol_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(906, 606);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 14;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 639);
            Controls.Add(btn_Volver);
            Controls.Add(btn_CambiarRol);
            Controls.Add(lbl_CambioRoles);
            Controls.Add(lbl_UserSelected);
            Controls.Add(cbox_UserSeleccionado);
            Controls.Add(lbl_RolNuevo);
            Controls.Add(cbox_RolNuevo);
            Controls.Add(lbl_Apellido);
            Controls.Add(lbl_Nombre);
            Controls.Add(tbox_Nombre);
            Controls.Add(tbox_Apellido);
            Controls.Add(label1);
            Controls.Add(btn_PSDesactivar);
            Controls.Add(btn_PSModificar);
            Controls.Add(tbox_PSSeleccionado);
            Controls.Add(cbox_PS);
            Controls.Add(lbl_IntRegistro);
            Controls.Add(lbl_Pregunta);
            Controls.Add(lbl_IntPreguntas);
            Controls.Add(tbox_PSAnadir);
            Controls.Add(btn_PSAñadir);
            Controls.Add(lbl_Email);
            Controls.Add(lbl_Usuario);
            Controls.Add(lbl_Welcome);
            Controls.Add(tbox_Email);
            Controls.Add(tbox_Usuario);
            Controls.Add(btn_Registrar);
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel de Administrador";
            Load += FormAdmin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_Registrar;
        private TextBox tbox_Usuario;
        private TextBox tbox_Email;
        private Label lbl_Welcome;
        private Label lbl_Usuario;
        private Label lbl_Email;
        private Button btn_PSAñadir;
        private TextBox tbox_PSAnadir;
        private Label lbl_IntPreguntas;
        private Label lbl_Pregunta;
        private Label lbl_IntRegistro;
        private ComboBox cbox_PS;
        private TextBox tbox_PSSeleccionado;
        private Button btn_PSModificar;
        private Button btn_PSDesactivar;
        private Label label1;
        private TextBox tbox_Apellido;
        private TextBox tbox_Nombre;
        private Label lbl_Nombre;
        private Label lbl_Apellido;
        private ComboBox cbox_RolNuevo;
        private Label lbl_RolNuevo;
        private ComboBox cbox_UserSeleccionado;
        private Label lbl_UserSelected;
        private Label lbl_CambioRoles;
        private Button btn_CambiarRol;
        private Button btn_Volver;
    }
}