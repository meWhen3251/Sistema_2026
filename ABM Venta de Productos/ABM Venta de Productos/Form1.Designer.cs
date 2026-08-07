namespace ABM_Venta_de_Productos
{
    partial class Form1
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
            panelBusqueda = new Panel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblFiltro = new Label();
            cmbCategoria = new ComboBox();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            dgvProductos = new DataGridView();
            panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // panelBusqueda
            // 
            panelBusqueda.BackColor = Color.White;
            panelBusqueda.BorderStyle = BorderStyle.FixedSingle;
            panelBusqueda.Controls.Add(lblBuscar);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(lblFiltro);
            panelBusqueda.Controls.Add(cmbCategoria);
            panelBusqueda.Controls.Add(btnNuevo);
            panelBusqueda.Controls.Add(btnEditar);
            panelBusqueda.Controls.Add(btnEliminar);
            panelBusqueda.Controls.Add(btnActualizar);
            panelBusqueda.Dock = DockStyle.Top;
            panelBusqueda.Location = new Point(0, 0);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Padding = new Padding(10);
            panelBusqueda.Size = new Size(1200, 80);
            panelBusqueda.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.Font = new Font("Segoe UI", 10F);
            lblBuscar.Location = new Point(10, 10);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(60, 25);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.Location = new Point(80, 10);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 25);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            // 
            // lblFiltro
            // 
            lblFiltro.Font = new Font("Segoe UI", 10F);
            lblFiltro.Location = new Point(400, 10);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(80, 25);
            lblFiltro.TabIndex = 2;
            lblFiltro.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Font = new Font("Segoe UI", 10F);
            cmbCategoria.Location = new Point(490, 10);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(200, 25);
            cmbCategoria.TabIndex = 3;
            cmbCategoria.SelectedIndexChanged += CmbCategoria_SelectedIndexChanged;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.Green;
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(10, 45);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 30);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "➕ Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += BtnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Blue;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(120, 45);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 30);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "✏️ Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += BtnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(230, 45);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.Orange;
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(340, 45);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 30);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "🔄 Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += BtnActualizar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.FixedSingle;
            dgvProductos.ColumnHeadersHeight = 35;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Font = new Font("Segoe UI", 10F);
            dgvProductos.Location = new Point(0, 80);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowTemplate.Height = 30;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(1200, 620);
            dgvProductos.TabIndex = 0;
            dgvProductos.ReadOnly = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1200, 700);
            Controls.Add(dgvProductos);
            Controls.Add(panelBusqueda);
            Name = "Form1";
            Text = "ABM - Venta de Productos";
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtBuscar;
        private ComboBox cmbCategoria;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnActualizar;
        private DataGridView dgvProductos;
        private Panel panelBusqueda;
        private Label lblBuscar;
        private Label lblFiltro;
    }
}
