using OrderAccumulator.Models.Enumerators;
using OrderAccumulator.Models.Records;
using OrderAccumulator.Utils;
using System.Threading;

namespace OrderAccumulator.Models.Domain
{
    ///********************************************************************
    ///
    ///           Nome: Asset.cs
    /// Funcionalidade: Representa o estado de um Ativo
    /// 
    ///********************************************************************
    public class Asset
    {
        private const decimal MaxExposure = 1_000_000m;
        private readonly object _criticalSession = new object();

        public string Name { get; private set; }
        public decimal Exposure { get; private set; }

        public Asset(string Name) 
        { 
            this.Name = Name.ToUpper();
            this.Exposure = 0m;
        }

        ///********************************************************************
        ///
        ///           Nome: TryApplyOrder
        /// Funcionalidade: Tenta efetivar uma nova ordem
        /// 
        ///********************************************************************
        public bool TryApplyOrder(OrderRequestRec request)
        {
            // Pelo fato do Controller em ASP NET ser um ambiente multi-threading,
            // Estou colocando uma sessão crítica, para evitar problemas de concorrência
            // evitando que múltiplos usuários acessem um ativo de forma simultânea, gerando erros nos valores
            lock (_criticalSession)
            {
                var newOrderValue = request.price * request.qtd;

                if (request.side == OrderSideEnum.Sell)
                    newOrderValue = -newOrderValue;

                var newExposure = this.Exposure + newOrderValue;

                if (Math.Abs(newExposure) > MaxExposure)
                    return false;

                this.Exposure = newExposure;
                return true;
            }
        }
    }
}
