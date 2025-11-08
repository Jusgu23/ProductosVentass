using Infraestructura.Datos.Contexts;
using Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Mvc;
using VentasAplicaciones.Servicios;

using VentaDominio;
using VentasAplicaciones.Servicios;
using Infraestructura.Datos.Contexts;
using Infraestructura.Datos.Repositorios;


namespace Infraestructura.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaControllers : ControllerBase
    {

        //se crea servicio para venta
        VentaServicio CrearServicio()
        {
            VentaContext db = new VentaContext();
            VentaRepositorio ventaRepositorio = new VentaRepositorio(db);
            ProductoRepositorio productoRepositorio = new ProductoRepositorio(db);
            DetalleVentaRepositorio detalleVentaRepositorio = new DetalleVentaRepositorio(db);
            VentaServicio servicio = new VentaServicio(ventaRepositorio, productoRepositorio, detalleVentaRepositorio);
            return servicio;
        }

        // GET: api/<VentaControllers>
        [HttpGet]
        public ActionResult<List<Ventas>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<VentaControllers>/5
        [HttpGet("{id}")]
        public ActionResult<Ventas> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SelectId(id));
        }

        // POST api/<VentaControllers>
        [HttpPost]
        public ActionResult Post([FromBody] Ventas ventas)
        {
            var servicio = CrearServicio();
            servicio.Agregar(ventas);
            return Ok("Venta realizada correctamente");
        }

        // DELETE api/<VentaControllers>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Anular(id);
            return Ok("Venta anulada correctamente");
        }
    }
}
