using Market.Context;
using Market.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        ProductoLogic productoLogic = new();

        [HttpGet(Name = "Listar")]
        public List<Producto> Listar() => productoLogic.GetAll();

        [HttpPost(Name = "Save")]
        public dynamic Save(Producto producto)
        {
            try
            {
                productoLogic.GuardarProducto(producto);
                return new
                {
                    success = true,
                    message = "El producto fue registrado exitosamente",
                    result = producto,
                };
            }
            catch (Exception)
            {
                return new
                {
                    success = false,
                    message = "Error al guardar el producto",
                    result = producto,
                };
            }
            
        }
        [HttpGet]
        [Route("Search")]
        public IActionResult Search(int presupuesto)
        {
            try
            {
                List<Producto> resultado = productoLogic.BuscarPorPresupuesto(presupuesto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}