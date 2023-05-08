using Market.Context;

namespace Market.Logic
{
    public class ProductoLogic
    {
        MarketContext marketContext = new MarketContext();

        public void GuardarProducto(Producto producto)
        {
            producto.FechaCreacion = DateTime.Now;
            marketContext.Productos.Add(producto);
            marketContext.SaveChanges();
        }

        public List<Producto> GetAll() => marketContext.Productos.ToList();

        public List<Producto> BuscarPorPresupuesto(int presupuesto)
        {
            List<Producto> result = new();
            List<Producto> productos = marketContext.Productos.ToList();
            List<Producto> productosCategoriaUno = productos.Where(x => x.Tipo == (int)Test.Helpers.Enums.Categoria.CATEGORIA_UNO && x.Precio <= presupuesto).ToList();
            List<Producto> productosCategoriaDos = productos.Where(x => x.Tipo == (int)Test.Helpers.Enums.Categoria.CATEGORIA_DOS && x.Precio <= presupuesto).ToList();

            List<Tuple<Producto, Producto, int>> posibilidades = new();
            foreach (Producto productoCategoriaUno in productosCategoriaUno)
            {
                foreach (Producto productoCategoriaDos in productosCategoriaDos)
                {
                    int precioTotal = productoCategoriaUno.Precio + productoCategoriaDos.Precio;
                    if (precioTotal <= presupuesto)
                        posibilidades.Add(Tuple.Create(productoCategoriaUno, productoCategoriaDos, precioTotal));
                }
            }
            if (posibilidades.Any())
            {
                Tuple<Producto, Producto, int> resultado = posibilidades.OrderByDescending(x => x.Item3).First();
                result.Add(resultado.Item1);
                result.Add(resultado.Item2);
            }
            return result;
        }
    }
}
