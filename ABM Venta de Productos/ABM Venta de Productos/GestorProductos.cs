namespace ABM_Venta_de_Productos
{
    public class GestorProductos
    {
        private List<Producto> productos;
        private int proximoId = 1;

        public GestorProductos()
        {
            productos = new List<Producto>();
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            productos.Add(new Producto(proximoId++, "Laptop ASUS VivoBook", "Computadoras", 45000, 15, "Laptop 14\" Intel Core i5, 8GB RAM, 512GB SSD"));
            productos.Add(new Producto(proximoId++, "Monitor LG 24\"", "Monitores", 12000, 30, "Monitor Full HD 60Hz IPS"));
            productos.Add(new Producto(proximoId++, "Teclado Mecánico RGB", "Periféricos", 5500, 50, "Teclado mecánico switches azules"));
            productos.Add(new Producto(proximoId++, "Mouse Logitech MX", "Periféricos", 3200, 40, "Mouse inalámbrico de precisión"));
            productos.Add(new Producto(proximoId++, "SSD Samsung 1TB", "Almacenamiento", 8000, 25, "SSD NVMe M.2 velocidad 7000MB/s"));
        }

        public List<Producto> ObtenerTodos()
        {
            return new List<Producto>(productos);
        }

        public Producto? ObtenerPorId(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Producto producto)
        {
            producto.Id = proximoId++;
            producto.FechaCreacion = DateTime.Now;
            productos.Add(producto);
        }

        public bool Actualizar(Producto producto)
        {
            var productoExistente = ObtenerPorId(producto.Id);
            if (productoExistente != null)
            {
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Categoria = producto.Categoria;
                productoExistente.Precio = producto.Precio;
                productoExistente.Stock = producto.Stock;
                productoExistente.Descripcion = producto.Descripcion;
                return true;
            }
            return false;
        }

        public bool Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null)
            {
                productos.Remove(producto);
                return true;
            }
            return false;
        }

        public List<Producto> Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return ObtenerTodos();

            var terminoLower = termino.ToLower();
            return productos.Where(p =>
                p.Nombre.ToLower().Contains(terminoLower) ||
                p.Categoria.ToLower().Contains(terminoLower) ||
                p.Descripcion.ToLower().Contains(terminoLower)
            ).ToList();
        }

        public List<Producto> FiltrarPorCategoria(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria))
                return ObtenerTodos();

            return productos.Where(p => p.Categoria == categoria).ToList();
        }

        public List<string> ObtenerCategorias()
        {
            return productos.Select(p => p.Categoria).Distinct().ToList();
        }
    }
}
