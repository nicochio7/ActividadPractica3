using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica01.Dominio;
using Practica01.Servicios;

namespace Practica02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _factura;
        public FacturaController(FacturaService factura)
        {
            _factura = factura;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                if (_factura.GetFacturas() != null && _factura.GetFacturas().Count > 0)
                {
                    return Ok(_factura.GetFacturas());
                }
                return BadRequest();

            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Ok(_factura.getByID(id));
                }
                return BadRequest();

            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public IActionResult Save(Facturas fp)
        {
            try
            {
                if (fp != null)
                {
                    _factura.Save(fp);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        // PUT api/<ServiciosController>/5
        [HttpPut()]
        public IActionResult Put(int id)
        {
            try
            {
                if (id != null)
                {
                    _factura.Update(id);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }
        


        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteId(int id)
        {
            try
            {
                if (id > 0)
                {
                    _factura.deleteId(id);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }
       




    }
}
