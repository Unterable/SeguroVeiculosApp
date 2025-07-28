namespace Core.Entities
{
    public class Seguro
    {
        public Guid Id { get; set; }
        public Veiculo Veiculo { get; set; }
        public Segurado Segurado { get; set; }
        public decimal TaxaRisco { get; set; }
        public decimal PremioRisco { get; set; }
        public decimal PremioPuro { get; set; }
        public decimal PremioComercial { get; set; }
        public decimal ValorSeguro { get; set; }
        public DateTime DataCalculo { get; set; }
    }
}

