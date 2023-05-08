using Market.Context;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;

        MarketContext marketContext = new MarketContext();
        public ProductoController(ILogger<ProductoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Listar")]
        public List<Producto> Listar() => marketContext.Productos.ToList();

        [HttpPost(Name = "Save")]
        public dynamic Save(Producto producto)
        {
            producto.FechaCreacion = DateTime.Now;
            marketContext.Productos.Add(producto);
            marketContext.SaveChanges();
            return new
            {
                success = true,
                message = "El producto fue registrado exitosamente",
                result = producto,
            };
        }
        [HttpGet]
        [Route("Search")]
        public IActionResult Search(int presupuesto)
        {
            try
            {
                List<Producto> productos = marketContext.Productos.ToList();
                List<Producto> result = new List<Producto>();
                List<Producto> productosCategoriaUno = productos.Where(x => x.Tipo == (int)Test.Helpers.Enums.Categoria.CATEGORIA_UNO && x.Precio <= presupuesto).ToList();
                List<Producto> productosCategoriaDos = productos.Where(x => x.Tipo == (int)Test.Helpers.Enums.Categoria.CATEGORIA_DOS && x.Precio <= presupuesto).ToList();

                List<Tuple<Producto, Producto, int>> posibilidades = new List<Tuple<Producto, Producto, int>>();
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
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}