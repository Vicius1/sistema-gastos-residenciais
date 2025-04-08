using Microsoft.AspNetCore.Mvc;
using gastosResidenciais.Models;

namespace gastosResidenciais.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PessoaController(AppDbContext context)
        {
            _context = context;
        }

        // Retorna a lista de todas as pessoas cadastradas
        [HttpGet]
        public ActionResult<List<Pessoa>> GetPessoas()
        {
            return _context.Pessoas.ToList();
        }

        // Cadastra uma nova pessoa no sistema
        [HttpPost]
        public ActionResult<Pessoa> PostPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPessoas), new { id = pessoa.Id }, pessoa);
        }

        // Deleta uma pessoa e todas as suas transações associadas
        [HttpDelete("{id}")]
        public IActionResult DeletePessoa(int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa == null)
                return NotFound("Pessoa não encontrada.");

            var transacoes = _context.Transacoes.Where(t => t.PessoaId == id).ToList();
            _context.Transacoes.RemoveRange(transacoes);

            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
