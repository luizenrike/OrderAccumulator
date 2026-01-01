using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAccumulator.Models.DTOs;
using OrderAccumulator.Models.Records;
using OrderAccumulator.Services.Interfaces;

namespace OrderAccumulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAccumulatorController : ControllerBase
    {
        private readonly IOrderAccumulatorService _orderAccumulatorService;

        public OrderAccumulatorController(IOrderAccumulatorService orderAccumulatorService)
        {
            _orderAccumulatorService = orderAccumulatorService;
        }

        /// <summary>
        /// Recebe uma ordem e tenta processar avaliando a exposição financeira do ativo.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     {
        ///        "ativo": "PETR4",
        ///        "lado": "C",
        ///        "quantidade": 100,
        ///        "preco": 32.50
        ///     }
        ///     
        /// ****************************
        /// 
        /// Exemplo de resposta:
        ///
        ///     {
        ///        "sucesso": true|false,
        ///        "exposicao_atual": 12345.67,
        ///        "msg": "Processada com sucesso | Exposicao financeira atingida",  
        ///     }
        /// </remarks>
        /// <response code="200">Ordem processada com sucesso.</response>
        /// <response code="400">Dados inválidos enviados na requisição ou falha ao inserir nova ordem.</response>
        [HttpPost("new-order")]
        [ProducesResponseType(typeof(OrderResponseRec), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OrderResponseRec), StatusCodes.Status400BadRequest)]
        public ActionResult<OrderResponseRec> ProcessNewOrder([FromBody]OrderRequestDTO request)
        {
            var orderResponse =  _orderAccumulatorService.ProcessNewOrder(request);

            if (!orderResponse.sucesso)
              return BadRequest(orderResponse);

            return Ok(orderResponse);
        }
    }
}
