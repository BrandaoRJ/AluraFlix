using AluraFlix.API.Data;
using AluraFlix.API.Models;
using AluraFlix.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraFlix.API.Controller
{
    [ApiController]
    public class VideoController : ControllerBase
    {
        [HttpGet("videos")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context, [FromQuery] string titulo)
        {
            IQueryable<Video> query = context.Videos.Include(x => x.Categoria);

            if (titulo != null)
            {
                query = query.Where(video => video.Titulo.ToLower().Contains(titulo.ToLower()));
            }

            return Ok(query.ToList());

        }

        [HttpGet]
        [Route("videos/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, int id)
        {
            var videos = await context.Videos.Include(x=>x.Categoria).FirstOrDefaultAsync(x => x.Id == id);
            return videos == null ? NotFound() : Ok(videos);
        }

        [HttpPost("videos")]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] CreateVideoViewModel video)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var _video = new Video
            {
                Titulo = video.Titulo,
                Descricao = video.Descricao,
                Url = video.Url,
                CategoriaId = video.CategoriaId ?? 1

            };

            try
            {
                await context.Videos.AddAsync(_video);
                await context.SaveChangesAsync();
                return Created($"videos/{video.Id}", video);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("videos/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] CreateVideoViewModel video, [FromRoute] int id)
        {
            var _video = await context.Videos.FirstOrDefaultAsync(x => x.Id == id);

            if (video == null)
                return NotFound();

            try
            {
                _video.Titulo = video.Titulo;
                _video.Descricao = video.Descricao;
                _video.Url = video.Url;

                context.Videos.Update(_video);
                await context.SaveChangesAsync();
                return Ok(_video);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("videos/{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var _video = await context.Videos.FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                context.Videos.Remove(_video);
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

