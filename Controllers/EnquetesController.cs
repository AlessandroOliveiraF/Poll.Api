using Microsoft.AspNetCore.Mvc;
using Poll.Api.Domain;
using Poll.Api.Services;

namespace Poll.Api.Controllers
{
    [ApiController]
    [Route("api/enquetes")]
    public class EnquetesController : ControllerBase
    {
        private readonly EnqueteService _enqueteService;

        public EnquetesController(EnqueteService enqueteService)
        {
            _enqueteService = enqueteService;
        }

        [HttpGet]
        public IEnumerable<Enquete>? Get()
        {
            try
            {
                return _enqueteService.ListarEnquetes();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Enquete> Get(int id)
        {
            try
            {
                return Ok(_enqueteService.BuscarEnquete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _enqueteService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Enquete enquete)
        {
            try
            {
                var success = _enqueteService.Add(enquete);
                return success ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Enquete enquete)
        {
            try
            {
                var success = _enqueteService.Update(id, enquete);
                return success ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}