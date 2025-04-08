using Microsoft.AspNetCore.Mvc;
using gastosResidenciais.Models;

namespace gastosResidenciais.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class TotalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TotalController(AppDbContext context)
        {
            _context = context;
        }

        // Lista totais de todas as pessoas + o total geral
        [HttpGet]
        public ActionResult<object> ListarTotaisPorPessoaComGeral()
        {
            var pessoas = _context.Pessoas.ToList();
            var resultado = new List<object>();

            decimal totalReceitasGeral = 0;
            decimal totalDespesasGeral = 0;

            foreach (var pessoa in pessoas)
            {
                var transacoes = _context.Transacoes.Where(t => t.PessoaId == pessoa.Id).ToList();

                var receitas = transacoes
                    .Where(t => t.Tipo.ToLower() == "receita")
                    .Sum(t => t.Valor);

                var despesas = transacoes
                    .Where(t => t.Tipo.ToLower() == "despesa")
                    .Sum(t => t.Valor);

                totalReceitasGeral += receitas;
                totalDespesasGeral += despesas;

                resultado.Add(new
                {
                    Pessoa = pessoa.Nome,
                    TotalReceitas = receitas,
                    TotalDespesas = despesas,
                    Saldo = receitas - despesas
                });
            }

            var totalGeral = new
            {
                TotalReceitas = totalReceitasGeral,
                TotalDespesas = totalDespesasGeral,
                SaldoGeral = totalReceitasGeral - totalDespesasGeral
            };

            return Ok(new
            {
                Pessoas = resultado,
                TotalGeral = totalGeral
            });
        }

    }
}
