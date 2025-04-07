namespace gastosResidenciais.Models
{
    // Representa uma transação (receita ou despesa) associada a uma pessoa
    public class Transacao
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int PessoaId { get; set; }
    }
}
