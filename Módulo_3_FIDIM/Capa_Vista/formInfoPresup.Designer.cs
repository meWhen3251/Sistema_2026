namespace Capa_Vista
{
    partial class formInfoPresup
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
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            button2 = new Button();
            button4 = new Button();
            button3 = new Button();
            button7 = new Button();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            button6 = new Button();
            button5 = new Button();
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
            label1.Size = new Size(446, 39);
            label1.TabIndex = 2;
            label1.Text = "Información del presupuesto";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 52);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(320, 228);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos generales";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 25);
            label6.Name = "label6";
            label6.Size = new Size(26, 18);
            label6.TabIndex = 4;
            label6.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 81);
            label3.Name = "label3";
            label3.Size = new Size(139, 18);
            label3.TabIndex = 1;
            label3.Text = "Usuario solicitando:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 54);
            label2.Name = "label2";
            label2.Size = new Size(81, 18);
            label2.TabIndex = 0;
            label2.Text = "Proveedor:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 184);
            label4.Name = "label4";
            label4.Size = new Size(71, 22);
            label4.TabIndex = 5;
            label4.Text = "Estado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            label5.Location = new Point(6, 142);
            label5.Name = "label5";
            label5.Size = new Size(202, 18);
            label5.TabIndex = 6;
            label5.Text = "Fecha de emisión de presup.:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 113);
            label7.Name = "label7";
            label7.Size = new Size(143, 18);
            label7.TabIndex = 7;
            label7.Text = "Solicitud de compra:";
            // 
            // button2
            // 
            button2.Location = new Point(12, 287);
            button2.Name = "button2";
            button2.Size = new Size(106, 76);
            button2.TabIndex = 5;
            button2.Text = "Ver solicitud original";
            button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(141, 328);
            button4.Name = "button4";
            button4.Size = new Size(191, 35);
            button4.TabIndex = 8;
            button4.Text = "Ver detalles de Usuario";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(141, 287);
            button3.Name = "button3";
            button3.Size = new Size(191, 35);
            button3.TabIndex = 7;
            button3.Text = "Ver detalles de Proveedor";
            button3.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(610, 393);
            button7.Name = "button7";
            button7.Size = new Size(178, 29);
            button7.TabIndex = 11;
            button7.Text = "Volver al menú anterior";
            button7.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(360, 52);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(428, 228);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle del presupuesto";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(416, 196);
            dataGridView1.TabIndex = 0;
            // 
            // button6
            // 
            button6.BackColor = Color.ForestGreen;
            button6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(12, 369);
            button6.Name = "button6";
            button6.Size = new Size(320, 53);
            button6.TabIndex = 14;
            button6.Text = "Aprobar presupuesto";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.Location = new Point(360, 287);
            button5.Name = "button5";
            button5.Size = new Size(105, 76);
            button5.TabIndex = 15;
            button5.Text = "Ver artículo";
            button5.UseVisualStyleBackColor = true;
            // 
            // formInfoPresup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 434);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(groupBox2);
            Controls.Add(button7);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "formInfoPresup";
            Text = "formInfoPresup";
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
        private Label label6;
        private Label label3;
        private Label label2;
        private Label label7;
        private Label label4;
        private Label label5;
        private Button button2;
        private Button button4;
        private Button button3;
        private Button button7;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Button button6;
        private Button button5;
    }
}