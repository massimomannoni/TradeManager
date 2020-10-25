using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradeManager.Service.Infrastructure.Database;
using TradeManager.Service.Trades.CreateTrade;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradeManager.Api.Controllers
{
    [Route(ApiBase.Trades)]
    [ApiController]
    public class TradesController : ControllerBase
    {
        private readonly UpsLightContext _context;

        public TradesController(UpsLightContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get trades
        /// </summary>
        [Route("")]
        [HttpGet]
        public string GetAsync()
        {

            return "value";
        }

        // GET api/<TradeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] Model.Requests.CreateTradeRequest request)
        {
            
               
            ProductTradeService productTrade = new ProductTradeService(_context);

            Guid id = await productTrade.Create(new CreateTradeRequest(request.Date, request.ProductId, request.Details, request.SchemaId, request.TradeId, request.ProductId));
            
    
            return Created(string.Empty, id);
        }

        // PUT api/<TradeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TradeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
