using Core.Entities;
using Core.Services;

namespace Core.Interfaces
{
    public interface ICalculoSeguroService
    {
        CalculoSeguroResult Calcular(Veiculo veiculo);
    }
}

