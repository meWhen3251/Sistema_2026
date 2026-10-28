namespace Capa_Vista
{
    partial class formModificarDatos
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
            lbl_Usuario = new Label();
            lbl_Nombre = new Label();
            lbl_Apellido = new Label();
            lbl_Correo = new Label();
            tbox_Nombre = new TextBox();
            tbox_Apellido = new TextBox();
            tbox_Correo = new TextBox();
            btn_Modificar = new Button();
            btn_Volver = new Button();
            tbox_Usuario = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(382, 48);
            label1.TabIndex = 0;
            label1.Text = "Formulario de edicion de datos \r\nde usuario";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Usuario
            // 
            lbl_Usuario.AutoSize = true;
            lbl_Usuario.Location = new Point(101, 77);
            lbl_Usuario.Name = "lbl_Usuario";
            lbl_Usuario.Size = new Size(180, 15);
            lbl_Usuario.TabIndex = 1;
            lbl_Usuario.Text = "Nombre de Usuario (no editable)";
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Location = new Point(163, 121);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(51, 15);
            lbl_Nombre.TabIndex = 2;
            lbl_Nombre.Text = "Nombre";
            // 
            // lbl_Apellido
            // 
            lbl_Apellido.AutoSize = true;
            lbl_Apellido.Location = new Point(163, 165);
            lbl_Apellido.Name = "lbl_Apellido";
            lbl_Apellido.Size = new Size(51, 15);
            lbl_Apellido.TabIndex = 3;
            lbl_Apellido.Text = "Apellido";
            // 
            // lbl_Correo
            // 
            lbl_Correo.AutoSize = true;
            lbl_Correo.Location = new Point(163, 216);
            lbl_Correo.Name = "lbl_Correo";
            lbl_Correo.Size = new Size(43, 15);
            lbl_Correo.TabIndex = 4;
            lbl_Correo.Text = "Correo";
            // 
            // tbox_Nombre
            // 
            tbox_Nombre.Location = new Point(89, 139);
            tbox_Nombre.Name = "tbox_Nombre";
            tbox_Nombre.Size = new Size(202, 23);
            tbox_Nombre.TabIndex = 5;
            // 
            // tbox_Apellido
            // 
            tbox_Apellido.Location = new Point(89, 183);
            tbox_Apellido.Name = "tbox_Apellido";
            tbox_Apellido.Size = new Size(202, 23);
            tbox_Apellido.TabIndex = 6;
            // 
            // tbox_Correo
            // 
            tbox_Correo.Location = new Point(89, 234);
            tbox_Correo.Name = "tbox_Correo";
            tbox_Correo.Size = new Size(202, 23);
            tbox_Correo.TabIndex = 7;
            // 
            // btn_Modificar
            // 
            btn_Modificar.Location = new Point(155, 263);
            btn_Modificar.Name = "btn_Modificar";
            btn_Modificar.Size = new Size(75, 23);
            btn_Modificar.TabIndex = 8;
            btn_Modificar.Text = "Modificar";
            btn_Modificar.UseVisualStyleBackColor = true;
            btn_Modificar.Click += btn_Modificar_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(311, 311);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(75, 23);
            btn_Volver.TabIndex = 9;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // tbox_Usuario
            // 
            tbox_Usuario.Location = new Point(89, 95);
            tbox_Usuario.Name = "tbox_Usuario";
            tbox_Usuario.ReadOnly = true;
            tbox_Usuario.Size = new Size(202, 23);
            tbox_Usuario.TabIndex = 10;
            tbox_Usuario.TabStop = false;
            // 
            // formModificarDatos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 346);
            Controls.Add(tbox_Usuario);
            Controls.Add(btn_Volver);
            Controls.Add(btn_Modificar);
            Controls.Add(tbox_Correo);
            Controls.Add(tbox_Apellido);
            Controls.Add(tbox_Nombre);
            Controls.Add(lbl_Correo);
            Controls.Add(lbl_Apellido);
            Controls.Add(lbl_Nombre);
            Controls.Add(lbl_Usuario);
            Controls.Add(label1);
            Name = "formModificarDatos";
            Text = "formModificarDatos";
            Load += formModificarDatos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lbl_Usuario;
        private Label lbl_Nombre;
        private Label lbl_Apellido;
        private Label lbl_Correo;
        private TextBox tbox_Nombre;
        private TextBox tbox_Apellido;
        private TextBox tbox_Correo;
        private Button btn_Modificar;
        private Button btn_Volver;
        private TextBox tbox_Usuario;
    }
}