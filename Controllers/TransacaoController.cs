using Microsoft.AspNetCore.Mvc;
using gastosResidenciais.Models;

namespace gastosResidenciais.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransacaoController(AppDbContext context)
        {
            _context = context;
        }

        // Retorna todas as transações cadastradas
        [HttpGet]
        public ActionResult<List<Transacao>> ListarTransacoes()
        {
            return _context.Transacoes.ToList();
        }

        // Cadastra uma nova transação
        [HttpPost]
        public ActionResult<Transacao> CadastrarTransacao([FromBody] Transacao transacao)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == transacao.PessoaId);
            if (pessoa == null)
                return BadRequest("Pessoa não encontrada.");

            if (pessoa.Idade < 18 && transacao.Tipo?.ToLower() == "receita")
                return BadRequest("Menores de idade só podem cadastrar despesas.");

            if (transacao.Valor <= 0)
                return BadRequest("Valor da transação deve ser positivo.");

            _context.Transacoes.Add(transacao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ListarTransacoes), new { id = transacao.Id }, transacao);
        }
    }
}
