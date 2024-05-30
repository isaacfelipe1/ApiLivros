using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLivros.Context;
using ApiLivros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiLivros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
       private readonly ApiLivrosBbContext _context;

        public LivrosController(ApiLivrosBbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livros>>> GetLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livros>> GetLivros(int id)
        {
            var livros = await _context.Livros.FindAsync(id);

            if (livros == null)
            {
                return NotFound();
            }

            return livros;
        }

        [HttpPost]
        public async Task<ActionResult<Livros>> CriarLivros(Livros livros)
        {
            _context.Livros.Add(livros);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLivros), new { id = livros.Id }, livros);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLivros(int id, Livros livros)
        {
            if (id != livros.Id)
            {
                return BadRequest();
            }
            _context.Entry(livros).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]    
        public async Task<IActionResult> DeletaLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return Ok(livro);   
        }
         private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }

    }
}