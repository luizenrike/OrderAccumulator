using OrderAccumulator.Models.DTOs;
using OrderAccumulator.Models.Records;

namespace OrderAccumulator.Services.Interfaces
{
    public interface IOrderAccumulatorService
    {
        OrderResponseRec ProcessNewOrder(OrderRequestDTO request);
    }
}
