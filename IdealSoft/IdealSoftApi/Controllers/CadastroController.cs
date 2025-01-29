using IdealSoftApi;
using IdealSoftApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/[controller]")]
public class CadastrosController : ControllerBase
{

    private readonly BancoContext _context;

    public CadastrosController(BancoContext context)
    {
        _context = context;

    }


    private static List<Cadastro> _cadastros = new List<Cadastro>();

    [HttpGet]
    public IActionResult GetAll()
    {
        var cadastros = _context.Cadastros.ToList(); // Lista os cadastros ja feitos
        return Ok(cadastros);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Cadastro cadastro)
    {
        if (cadastro == null)
        {
            return BadRequest("Dados inválidos.");
        }

        await _context.Cadastros.AddAsync(cadastro);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAll), new { id = cadastro.Id }, cadastro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Cadastro cadastro)
    {
        if (cadastro == null)
        {
            return BadRequest("Dados inválidos.");
        }

        var existing = await _context.Cadastros.FindAsync(id);
        if (existing == null)
        {
            return NotFound("Cadastro não encontrado.");
        }

        existing.Nome = cadastro.Nome;
        existing.Sobrenome = cadastro.Sobrenome;
        existing.Telefone = cadastro.Telefone;

        await _context.SaveChangesAsync();

        return Ok(existing); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cadastro = await _context.Cadastros.FindAsync(id);
        if (cadastro == null)
        {
            return NotFound("Cadastro não encontrado.");
        }

        _context.Cadastros.Remove(cadastro);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}


