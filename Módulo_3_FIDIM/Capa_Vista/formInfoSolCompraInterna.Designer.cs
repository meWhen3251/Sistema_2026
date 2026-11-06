namespace Capa_Vista
{
    partial class formInfoSolCompraInterna
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label7 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            button7 = new Button();
            button1 = new Button();
            button2 = new Button();
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
            label1.Size = new Size(657, 39);
            label1.TabIndex = 1;
            label1.Text = "Información de solicitud de compra interna";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(351, 272);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos generales";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 206);
            label6.Name = "label6";
            label6.Size = new Size(71, 22);
            label6.TabIndex = 2;
            label6.Text = "Estado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            label5.Location = new Point(14, 153);
            label5.Name = "label5";
            label5.Size = new Size(207, 18);
            label5.TabIndex = 2;
            label5.Text = "Fecha de emisión de solicitud:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            label4.Location = new Point(14, 60);
            label4.Name = "label4";
            label4.Size = new Size(139, 18);
            label4.TabIndex = 2;
            label4.Text = "Usuario solicitando:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            label3.Location = new Point(14, 91);
            label3.Name = "label3";
            label3.Size = new Size(73, 18);
            label3.TabIndex = 1;
            label3.Text = "Producto:";
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            label7.Location = new Point(14, 122);
            label7.Name = "label7";
            label7.Size = new Size(70, 18);
            label7.TabIndex = 3;
            label7.Text = "Cantidad:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(402, 51);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(551, 272);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Presupuestos para esta orden";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(539, 240);
            dataGridView1.TabIndex = 0;
            // 
            // button4
            // 
            button4.Location = new Point(12, 370);
            button4.Name = "button4";
            button4.Size = new Size(351, 35);
            button4.TabIndex = 9;
            button4.Text = "Ver detalles de Usuario";
            button4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(775, 435);
            button7.Name = "button7";
            button7.Size = new Size(178, 29);
            button7.TabIndex = 10;
            button7.Text = "Volver al menú anterior";
            button7.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(402, 329);
            button1.Name = "button1";
            button1.Size = new Size(216, 35);
            button1.TabIndex = 11;
            button1.Text = "Ver presupuesto seleccionado";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 329);
            button2.Name = "button2";
            button2.Size = new Size(351, 35);
            button2.TabIndex = 12;
            button2.Text = "Ver artículo";
            button2.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.BackColor = Color.ForestGreen;
            button6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(12, 411);
            button6.Name = "button6";
            button6.Size = new Size(351, 53);
            button6.TabIndex = 13;
            button6.Text = "Modificar estado de la solicitud";
            button6.UseVisualStyleBackColor = false;
            // 
            // formInfoSolCompraInterna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 476);
            Controls.Add(button6);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button7);
            Controls.Add(button4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "formInfoSolCompraInterna";
            Text = "formInfoSolCompraInterna";
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
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label2;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Button button4;
        private Button button7;
        private Button button1;
        private Button button2;
        private Button button6;
    }
}