using AluraFlix.API.Data;
using AluraFlix.API.Models;
using AluraFlix.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AluraFlix.API.Controller
{
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet("categorias")]
        
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var categorias = await context.Categorias.ToListAsync();
            return Ok(categorias);
        }

        [HttpGet]
        [Route("categorias/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, int id)
        {
            var categorias = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            return categorias == null ? NotFound() : Ok(categorias);
        }

        [HttpGet("categorias/{id:int}/videos")]
        public async Task<IActionResult> GetVideosByCategoriaId([FromServices] AppDbContext context, int id)
        {
            var videos = await context.Videos.Where(x => x.CategoriaId == id).Include(x => x.Categoria).ToListAsync();
            return Ok(videos);
        }

        [HttpPost("categorias")]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] CreateCategoriaViewModel categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var _categoria = new Categoria
            {
                Titulo = categoria.Titulo,
                Cor = categoria.Cor,
            };
            try
            {
                await context.Categorias.AddAsync(_categoria);
                await context.SaveChangesAsync();
                return Created($"categorias/{categoria.Id}", categoria);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("categorias/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] CreateCategoriaViewModel categoria, [FromRoute] int id)
        {
            var _categoria = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
                return NotFound();

            try
            {
                _categoria.Titulo = categoria.Titulo;
                _categoria.Cor = categoria.Cor;

                context.Categorias.Update(_categoria);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("categoria/{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var _categoria = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Categorias.Remove(_categoria);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
