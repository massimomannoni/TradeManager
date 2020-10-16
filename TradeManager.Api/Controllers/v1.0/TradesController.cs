using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradeManager.Api.Model.Requests;
using TradeManager.Service;
using TradeManager.Service.Models;
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
        public async Task<IEnumerable<string>> GetAsync()
        {
            // 
            ProductTradeService productTrade = new ProductTradeService(_context);

            await productTrade.Create(new ProductTrade(DateTime.Now, Guid.NewGuid(), "test", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()));

            return new string[] { "value1", "value2" };
      
        }

        // GET api/<TradeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TradeController>
        [HttpPost]
        public void Post([FromBody] CreateTradeRequest request)
        {
            try
            {

            }
            catch (Exception)
            {
                
            }
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
