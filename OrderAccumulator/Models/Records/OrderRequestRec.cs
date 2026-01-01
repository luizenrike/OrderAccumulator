using OrderAccumulator.Models.Enumerators;

namespace OrderAccumulator.Models.Records
{
    public record OrderRequestRec
    (
       string assetName,
       OrderSideEnum side,
       int qtd,
       decimal price
    );
}
