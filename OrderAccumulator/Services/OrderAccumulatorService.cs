using OrderAccumulator.Models.Domain;
using OrderAccumulator.Models.DTOs;
using OrderAccumulator.Models.Enumerators;
using OrderAccumulator.Models.Records;
using OrderAccumulator.Services.Interfaces;
using OrderAccumulator.Utils;
using OrderAccumulator.Utils.Exceptions;

namespace OrderAccumulator.Services
{
    public class OrderAccumulatorService : IOrderAccumulatorService
    {
        private readonly Dictionary<string, Asset> _hshAssets; // hash de ativos <nome_ativo, ativo>

        public OrderAccumulatorService() 
        {
            _hshAssets = new Dictionary<string, Asset>();

            BuildAsset("PETR4");
            BuildAsset("VALE3");
            BuildAsset("VIIA4");
        }

        ///********************************************************************
        ///
        ///           Nome: ProcessNewOrder
        /// Funcionalidade: Processa uma requisição de nova ordem
        /// 
        ///********************************************************************
        public OrderResponseRec ProcessNewOrder(OrderRequestDTO request)
        {
            try
            {
                var req = MapOrderRequest(request);

                if (!_hshAssets.TryGetValue(req.assetName, out var asset))
                    return new OrderResponseRec(false, 0m, TextMessage.GetText(TextMessage.MsgCode.MsgInvalidAsset, req.assetName));

                var success = asset.TryApplyOrder(req);

                var msgCode = success ? TextMessage.MsgCode.MsgSuccess : TextMessage.MsgCode.MsgMaxExposure;

                return new OrderResponseRec(success, asset.Exposure, TextMessage.GetText(msgCode, req.assetName));
            }
            catch (Exception ex)
            {
                return new OrderResponseRec(false, 0m, ex.Message);
            }
        }

        ///********************************************************************
        ///
        ///           Nome: MapOrderRequest
        /// Funcionalidade: Mapeia um OrderRequestDTO para OrderRequestRec
        /// 
        ///********************************************************************
        private OrderRequestRec MapOrderRequest(OrderRequestDTO request)
        {
            var side = request.lado switch
            {
                'C' => OrderSideEnum.Buy,
                'V' => OrderSideEnum.Sell,
                _ => throw new InvalidOrderSideException(request.lado) 
            };
            return new OrderRequestRec(request.ativo.ToUpper(), side, request.quantidade, request.preco);
        }

        ///********************************************************************
        ///
        ///           Nome: BuildAsset
        /// Funcionalidade: Constroi ativo e adiciona na hash
        /// 
        ///********************************************************************
        private Asset BuildAsset(string AssetName)
        {
            var Asset = new Asset(AssetName);
            _hshAssets.Add(AssetName, Asset);
            return Asset;
        }
    }
}
