namespace Capa_Vista
{
    partial class formInfoOC
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(522, 39);
            label1.TabIndex = 0;
            label1.Text = "Información de Orden de Compra";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(303, 246);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos generales";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            label2.Location = new Point(14, 32);
            label2.Name = "label2";
            label2.Size = new Size(26, 18);
            label2.TabIndex = 0;
            label2.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            label3.Location = new Point(14, 67);
            label3.Name = "label3";
            label3.Size = new Size(81, 18);
            label3.TabIndex = 1;
            label3.Text = "Proveedor:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            label4.Location = new Point(14, 105);
            label4.Name = "label4";
            label4.Size = new Size(139, 18);
            label4.TabIndex = 2;
            label4.Text = "Usuario solicitando:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            label5.Location = new Point(14, 141);
            label5.Name = "label5";
            label5.Size = new Size(184, 18);
            label5.TabIndex = 2;
            label5.Text = "Fecha de emisión de O.C.:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 192);
            label6.Name = "label6";
            label6.Size = new Size(71, 22);
            label6.TabIndex = 2;
            label6.Text = "Estado:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(360, 51);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(428, 246);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle de la Orden";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(416, 214);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(610, 409);
            button1.Name = "button1";
            button1.Size = new Size(178, 29);
            button1.TabIndex = 3;
            button1.Text = "Volver al menú anterior";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 303);
            button2.Name = "button2";
            button2.Size = new Size(106, 76);
            button2.TabIndex = 4;
            button2.Text = "Ver solicitud original";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(124, 303);
            button3.Name = "button3";
            button3.Size = new Size(191, 35);
            button3.TabIndex = 5;
            button3.Text = "Ver detalles de proveedor";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(124, 344);
            button4.Name = "button4";
            button4.Size = new Size(191, 35);
            button4.TabIndex = 6;
            button4.Text = "Ver detalles de Usuario";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(360, 303);
            button5.Name = "button5";
            button5.Size = new Size(105, 76);
            button5.TabIndex = 7;
            button5.Text = "Ver artículo";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.BackColor = Color.ForestGreen;
            button6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(12, 385);
            button6.Name = "button6";
            button6.Size = new Size(303, 53);
            button6.TabIndex = 8;
            button6.Text = "Modificar estado de orden";
            button6.UseVisualStyleBackColor = false;
            // 
            // formInfoOC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "formInfoOC";
            Text = "formInfoOC";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}