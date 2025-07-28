using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguroController : ControllerBase
    {
        private readonly SeguroService _seguroService;

        public SeguroController(SeguroService seguroService)
        {
            _seguroService = seguroService;
        }

        [HttpPost]
        public async Task<ActionResult<SeguroDto>> CriarSeguro([FromBody] CriarSeguroRequest request)
        {
            try
            {
                var seguro = await _seguroService.CriarSeguroAsync(request);
                return CreatedAtAction(nameof(ObterSeguro), new { id = seguro.Id }, seguro);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeguroDto>> ObterSeguro(Guid id)
        {
            var seguro = await _seguroService.ObterSeguroPorIdAsync(id);
            
            if (seguro == null)
            {
                return NotFound();
            }

            return Ok(seguro);
        }

        [HttpGet("relatorio/medias")]
        public async Task<ActionResult<RelatorioMediasDto>> ObterRelatorioMedias()
        {
            var relatorio = await _seguroService.ObterRelatorioMediasAsync();
            return Ok(relatorio);
        }
    }
}

