using Application.DTOs;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class SeguroService
    {
        private readonly ISeguroRepository _seguroRepository;
        private readonly ICalculoSeguroService _calculoSeguroService;

        public SeguroService(ISeguroRepository seguroRepository, ICalculoSeguroService calculoSeguroService)
        {
            _seguroRepository = seguroRepository;
            _calculoSeguroService = calculoSeguroService;
        }

        public async Task<SeguroDto> CriarSeguroAsync(CriarSeguroRequest request)
        {
            var veiculo = new Veiculo
            {
                Id = Guid.NewGuid(),
                Valor = request.Veiculo.Valor,
                MarcaModelo = request.Veiculo.MarcaModelo
            };

            var segurado = new Segurado
            {
                Id = Guid.NewGuid(),
                Nome = request.Segurado.Nome,
                CPF = request.Segurado.CPF,
                Idade = request.Segurado.Idade
            };

            var calculoResult = _calculoSeguroService.Calcular(veiculo);

            var seguro = new Seguro
            {
                Id = Guid.NewGuid(),
                Veiculo = veiculo,
                Segurado = segurado,
                TaxaRisco = calculoResult.TaxaRisco,
                PremioRisco = calculoResult.PremioRisco,
                PremioPuro = calculoResult.PremioPuro,
                PremioComercial = calculoResult.PremioComercial,
                ValorSeguro = calculoResult.ValorSeguro,
                DataCalculo = DateTime.UtcNow
            };

            var seguroSalvo = await _seguroRepository.AdicionarAsync(seguro);

            return MapearSeguroParaDto(seguroSalvo);
        }

        public async Task<SeguroDto> ObterSeguroPorIdAsync(Guid id)
        {
            var seguro = await _seguroRepository.ObterPorIdAsync(id);
            return seguro != null ? MapearSeguroParaDto(seguro) : null;
        }

        public async Task<RelatorioMediasDto> ObterRelatorioMediasAsync()
        {
            var seguros = await _seguroRepository.ObterTodosAsync();
            var listaSeguros = seguros.ToList();

            if (!listaSeguros.Any())
            {
                return new RelatorioMediasDto
                {
                    TotalSeguros = 0
                };
            }

            return new RelatorioMediasDto
            {
                MediaValorVeiculo = listaSeguros.Average(s => s.Veiculo.Valor),
                MediaTaxaRisco = listaSeguros.Average(s => s.TaxaRisco),
                MediaPremioRisco = listaSeguros.Average(s => s.PremioRisco),
                MediaPremioPuro = listaSeguros.Average(s => s.PremioPuro),
                MediaPremioComercial = listaSeguros.Average(s => s.PremioComercial),
                MediaValorSeguro = listaSeguros.Average(s => s.ValorSeguro),
                TotalSeguros = listaSeguros.Count
            };
        }

        private SeguroDto MapearSeguroParaDto(Seguro seguro)
        {
            return new SeguroDto
            {
                Id = seguro.Id,
                Veiculo = new VeiculoDto
                {
                    Id = seguro.Veiculo.Id,
                    Valor = seguro.Veiculo.Valor,
                    MarcaModelo = seguro.Veiculo.MarcaModelo
                },
                Segurado = new SeguradoDto
                {
                    Id = seguro.Segurado.Id,
                    Nome = seguro.Segurado.Nome,
                    CPF = seguro.Segurado.CPF,
                    Idade = seguro.Segurado.Idade
                },
                TaxaRisco = seguro.TaxaRisco,
                PremioRisco = seguro.PremioRisco,
                PremioPuro = seguro.PremioPuro,
                PremioComercial = seguro.PremioComercial,
                ValorSeguro = seguro.ValorSeguro,
                DataCalculo = seguro.DataCalculo
            };
        }
    }
}

