using OrderAccumulator.Models.Enumerators;

namespace OrderAccumulator.Models.DTOs
{
    public record OrderRequestDTO
    (
        string ativo,
        char lado,
        int quantidade,
        decimal preco
    );
}
