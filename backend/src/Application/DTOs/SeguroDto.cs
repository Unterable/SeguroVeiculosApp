namespace Application.DTOs
{
    public class SeguroDto
    {
        public Guid Id { get; set; }
        public VeiculoDto Veiculo { get; set; }
        public SeguradoDto Segurado { get; set; }
        public decimal TaxaRisco { get; set; }
        public decimal PremioRisco { get; set; }
        public decimal PremioPuro { get; set; }
        public decimal PremioComercial { get; set; }
        public decimal ValorSeguro { get; set; }
        public DateTime DataCalculo { get; set; }
    }

    public class VeiculoDto
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public string MarcaModelo { get; set; }
    }

    public class SeguradoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
    }

    public class CriarSeguroRequest
    {
        public VeiculoDto Veiculo { get; set; }
        public SeguradoDto Segurado { get; set; }
    }

    public class RelatorioMediasDto
    {
        public decimal MediaValorVeiculo { get; set; }
        public decimal MediaTaxaRisco { get; set; }
        public decimal MediaPremioRisco { get; set; }
        public decimal MediaPremioPuro { get; set; }
        public decimal MediaPremioComercial { get; set; }
        public decimal MediaValorSeguro { get; set; }
        public int TotalSeguros { get; set; }
    }
}

