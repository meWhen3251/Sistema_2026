namespace ABM_Venta_de_Productos
{
    partial class FormProducto
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Label Nombre
            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new System.Drawing.Point(15, 20);
            lblNombre.Size = new System.Drawing.Size(100, 25);
            lblNombre.Font = new Font("Segoe UI", 10);
            lblNombre.AutoSize = false;

            txtNombre = new TextBox();
            txtNombre.Location = new System.Drawing.Point(120, 20);
            txtNombre.Size = new System.Drawing.Size(350, 25);
            txtNombre.Font = new Font("Segoe UI", 10);

            // Label Categoría
            Label lblCategoria = new Label();
            lblCategoria.Text = "Categoría:";
            lblCategoria.Location = new System.Drawing.Point(15, 60);
            lblCategoria.Size = new System.Drawing.Size(100, 25);
            lblCategoria.Font = new Font("Segoe UI", 10);
            lblCategoria.AutoSize = false;

            txtCategoria = new TextBox();
            txtCategoria.Location = new System.Drawing.Point(120, 60);
            txtCategoria.Size = new System.Drawing.Size(350, 25);
            txtCategoria.Font = new Font("Segoe UI", 10);

            // Label Precio
            Label lblPrecio = new Label();
            lblPrecio.Text = "Precio:";
            lblPrecio.Location = new System.Drawing.Point(15, 100);
            lblPrecio.Size = new System.Drawing.Size(100, 25);
            lblPrecio.Font = new Font("Segoe UI", 10);
            lblPrecio.AutoSize = false;

            txtPrecio = new TextBox();
            txtPrecio.Location = new System.Drawing.Point(120, 100);
            txtPrecio.Size = new System.Drawing.Size(350, 25);
            txtPrecio.Font = new Font("Segoe UI", 10);
            txtPrecio.Text = "0.00";

            // Label Stock
            Label lblStock = new Label();
            lblStock.Text = "Stock:";
            lblStock.Location = new System.Drawing.Point(15, 140);
            lblStock.Size = new System.Drawing.Size(100, 25);
            lblStock.Font = new Font("Segoe UI", 10);
            lblStock.AutoSize = false;

            txtStock = new TextBox();
            txtStock.Location = new System.Drawing.Point(120, 140);
            txtStock.Size = new System.Drawing.Size(350, 25);
            txtStock.Font = new Font("Segoe UI", 10);
            txtStock.Text = "0";

            // Label Descripción
            Label lblDescripcion = new Label();
            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Location = new System.Drawing.Point(15, 180);
            lblDescripcion.Size = new System.Drawing.Size(100, 25);
            lblDescripcion.Font = new Font("Segoe UI", 10);
            lblDescripcion.AutoSize = false;

            txtDescripcion = new TextBox();
            txtDescripcion.Location = new System.Drawing.Point(120, 180);
            txtDescripcion.Size = new System.Drawing.Size(350, 80);
            txtDescripcion.Font = new Font("Segoe UI", 10);
            txtDescripcion.Multiline = true;
            txtDescripcion.ScrollBars = ScrollBars.Vertical;

            // Button Guardar
            BtnGuardar = new Button();
            BtnGuardar.Text = "Guardar";
            BtnGuardar.Location = new System.Drawing.Point(120, 280);
            BtnGuardar.Size = new System.Drawing.Size(100, 35);
            BtnGuardar.BackColor = System.Drawing.Color.Green;
            BtnGuardar.ForeColor = System.Drawing.Color.White;
            BtnGuardar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BtnGuardar.Cursor = Cursors.Hand;
            BtnGuardar.Click += BtnGuardar_Click;

            // Button Cancelar
            BtnCancelar = new Button();
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.Location = new System.Drawing.Point(230, 280);
            BtnCancelar.Size = new System.Drawing.Size(100, 35);
            BtnCancelar.BackColor = System.Drawing.Color.Gray;
            BtnCancelar.ForeColor = System.Drawing.Color.White;
            BtnCancelar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BtnCancelar.Cursor = Cursors.Hand;
            BtnCancelar.Click += BtnCancelar_Click;

            // Agregar controles
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblCategoria);
            this.Controls.Add(txtCategoria);
            this.Controls.Add(lblPrecio);
            this.Controls.Add(txtPrecio);
            this.Controls.Add(lblStock);
            this.Controls.Add(txtStock);
            this.Controls.Add(lblDescripcion);
            this.Controls.Add(txtDescripcion);
            this.Controls.Add(BtnGuardar);
            this.Controls.Add(BtnCancelar);
        }

        private TextBox txtNombre;
        private TextBox txtCategoria;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private TextBox txtDescripcion;
        private Button BtnGuardar;
        private Button BtnCancelar;
    }
}
