namespace ABM_Venta_de_Productos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }

        public Producto()
        {
            FechaCreacion = DateTime.Now;
        }

        public Producto(int id, string nombre, string categoria, decimal precio, int stock, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Stock = stock;
            Descripcion = descripcion;
            FechaCreacion = DateTime.Now;
        }
    }
}
