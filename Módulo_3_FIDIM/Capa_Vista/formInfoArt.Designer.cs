namespace Capa_Vista
{
    partial class formInfoArt
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
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            lsb_almacenado = new ListBox();
            groupBox3 = new GroupBox();
            listBox1 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            label6 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(361, 39);
            label1.TabIndex = 0;
            label1.Text = "Información de artículo";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(14, 63);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(259, 189);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos generales";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 109);
            label5.Name = "label5";
            label5.Size = new Size(91, 18);
            label5.TabIndex = 3;
            label5.Text = "Descripción:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 128);
            label4.Location = new Point(6, 142);
            label4.Name = "label4";
            label4.Size = new Size(97, 25);
            label4.TabIndex = 2;
            label4.Text = "Cantidad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 80);
            label3.Name = "label3";
            label3.Size = new Size(76, 18);
            label3.TabIndex = 1;
            label3.Text = "Categoría:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 53);
            label2.Name = "label2";
            label2.Size = new Size(66, 18);
            label2.TabIndex = 0;
            label2.Text = "Nombre:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lsb_almacenado);
            groupBox2.Location = new Point(14, 307);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(259, 189);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ubicaciones almacenado";
            // 
            // lsb_almacenado
            // 
            lsb_almacenado.FormattingEnabled = true;
            lsb_almacenado.Items.AddRange(new object[] { "Estante C4 - Lomas", "Estante G2/G3/G4 - Esteban Echeverría" });
            lsb_almacenado.Location = new Point(7, 29);
            lsb_almacenado.Margin = new Padding(3, 4, 3, 4);
            lsb_almacenado.Name = "lsb_almacenado";
            lsb_almacenado.Size = new Size(245, 144);
            lsb_almacenado.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(listBox1);
            groupBox3.Location = new Point(539, 63);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(361, 189);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Proveedores del artículo";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(7, 29);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(332, 144);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(539, 260);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(112, 31);
            button1.TabIndex = 4;
            button1.Text = "Ver proveedor";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(280, 63);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(103, 51);
            button2.TabIndex = 5;
            button2.Text = "Modificar información";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackColor = Color.IndianRed;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.Menu;
            button3.Location = new Point(14, 260);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(144, 39);
            button3.TabIndex = 6;
            button3.Text = "Eliminar artículo";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(280, 183);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(200, 69);
            button4.TabIndex = 7;
            button4.Text = "Solicitar reaprovisionamiento";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(739, 465);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(163, 31);
            button5.TabIndex = 8;
            button5.Text = "Volver al menú anterior";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(280, 307);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(103, 49);
            button6.TabIndex = 9;
            button6.Text = "Ver ubicación";
            button6.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 24);
            label6.Name = "label6";
            label6.Size = new Size(26, 18);
            label6.TabIndex = 4;
            label6.Text = "ID:";
            // 
            // formInfoArt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 509);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "formInfoArt";
            Text = "formInfoArt";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private ListBox lsb_almacenado;
        private Label label5;
        private GroupBox groupBox3;
        private ListBox listBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label6;
    }
}