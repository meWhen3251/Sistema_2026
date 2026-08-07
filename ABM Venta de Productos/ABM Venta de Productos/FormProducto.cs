namespace ABM_Venta_de_Productos
{
    public partial class FormProducto : Form
    {
        private Producto producto;
        private bool esNuevo;

        public FormProducto(Producto productoExistente = null)
        {
            InitializeComponent();
            this.producto = productoExistente ?? new Producto();
            this.esNuevo = productoExistente == null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Text = esNuevo ? "Nuevo Producto" : "Editar Producto";
            this.Size = new System.Drawing.Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Cargar datos si es edición
            if (!esNuevo)
            {
                txtNombre.Text = producto.Nombre ?? string.Empty;
                txtCategoria.Text = producto.Categoria ?? string.Empty;
                txtPrecio.Text = producto.Precio.ToString("F2");
                txtStock.Text = producto.Stock.ToString();
                txtDescripcion.Text = producto.Descripcion ?? string.Empty;
            }
        }

        public Producto ObtenerProducto()
        {
            producto.Nombre = txtNombre.Text;
            producto.Categoria = txtCategoria.Text;
            producto.Precio = decimal.Parse(txtPrecio.Text);
            producto.Stock = int.Parse(txtStock.Text);
            producto.Descripcion = txtDescripcion.Text;
            return producto;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("La categoría es obligatoria", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoria.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio debe ser un número positivo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número positivo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            return true;
        }
    }
}
