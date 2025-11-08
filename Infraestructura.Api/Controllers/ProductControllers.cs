using Microsoft.AspNetCore.Mvc;


using VentaDominio;
using VentasAplicaciones.Servicios;
using Infraestructura.Datos.Contexts;
using Infraestructura.Datos.Repositorios;
namespace Infraestructura.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        //funcion para crear servicios cada que se llame un metodo del controlador
        ProductoServicio CrearServicio()
        {
            VentaContext db = new VentaContext();
            ProductoRepositorio Productorepositorio = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(Productorepositorio);
            return servicio;
        }


        // GET: api/<Controller> traer todo 
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<Controller>/5 traer elemento por id 
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SelectId(id));
        }

        // POST api/<Controller> agregar elemento
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            servicio.Agregar(producto);
            return Ok("Se agergo correctamente");
        }

        // PUT api/<Controller>/5 editar elemento
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            producto.productoId = id;
            servicio.Editar(producto);
            return Ok("Se edito correctamente");
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Se elimino correctamente");
        }
    }
}
