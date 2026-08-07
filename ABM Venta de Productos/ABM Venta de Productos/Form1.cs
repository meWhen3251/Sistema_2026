namespace ABM_Venta_de_Productos
{
    public partial class Form1 : Form
    {
        private GestorProductos gestor;
        private FormProducto? formProducto;
        private bool cargandoDatos = false;

        public Form1()
        {
            InitializeComponent();
            gestor = new GestorProductos();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConfigurarDataGridView();
            CargarCategorias();
            CargarProductos();
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add("Id", "ID");
            dgvProductos.Columns.Add("Nombre", "Nombre");
            dgvProductos.Columns.Add("Categoria", "Categoría");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Stock", "Stock");
            dgvProductos.Columns.Add("Descripcion", "Descripción");

            dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void CargarCategorias()
        {
            cargandoDatos = true;
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas las categorías");
            var categorias = gestor.ObtenerCategorias();
            foreach (var categoria in categorias)
            {
                cmbCategoria.Items.Add(categoria);
            }
            cmbCategoria.SelectedIndex = 0;
            cargandoDatos = false;
        }

        private void CargarProductos()
        {
            dgvProductos.Rows.Clear();
            var productos = gestor.ObtenerTodos();
            foreach (var producto in productos)
            {
                AgregarFilaAlGrid(producto);
            }
        }

        private void AgregarFilaAlGrid(Producto producto)
        {
            dgvProductos.Rows.Add(
                producto.Id,
                producto.Nombre,
                producto.Categoria,
                producto.Precio,
                producto.Stock,
                producto.Descripcion
            );
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            formProducto = new FormProducto();
            if (formProducto.ShowDialog() == DialogResult.OK)
            {
                var nuevoProducto = formProducto.ObtenerProducto();
                gestor.Agregar(nuevoProducto);
                CargarProductos();
                CargarCategorias();
                MessageBox.Show("Producto agregado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cellValue = dgvProductos.SelectedRows[0].Cells["Id"].Value;
                if (cellValue == null || !int.TryParse(cellValue.ToString(), out int id))
                {
                    MessageBox.Show("Error al obtener el ID del producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var producto = gestor.ObtenerPorId(id);
                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                formProducto = new FormProducto(producto);
                if (formProducto.ShowDialog() == DialogResult.OK)
                {
                    var productoActualizado = formProducto.ObtenerProducto();
                    if (gestor.Actualizar(productoActualizado))
                    {
                        CargarProductos();
                        CargarCategorias();
                        MessageBox.Show("Producto actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cellValue = dgvProductos.SelectedRows[0].Cells["Id"].Value;
                if (cellValue == null || !int.TryParse(cellValue.ToString(), out int id))
                {
                    MessageBox.Show("Error al obtener el ID del producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var resultado = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (gestor.Eliminar(id))
                    {
                        CargarProductos();
                        CargarCategorias();
                        MessageBox.Show("Producto eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarProductos();
            MessageBox.Show("Listado actualizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!cargandoDatos)
            {
                FiltrarProductos();
            }
        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargandoDatos)
            {
                FiltrarProductos();
            }
        }

        private void FiltrarProductos()
        {
            dgvProductos.Rows.Clear();
            var termino = txtBuscar.Text;
            var productos = gestor.Buscar(termino);

            if (cmbCategoria.SelectedIndex > 0)
            {
                var categoria = cmbCategoria.SelectedItem?.ToString();
                if (categoria != null)
                {
                    productos = productos.Where(p => p.Categoria == categoria).ToList();
                }
            }

            foreach (var producto in productos)
            {
                AgregarFilaAlGrid(producto);
            }
        }
    }
}
