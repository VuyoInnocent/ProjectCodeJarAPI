using Microsoft.AspNetCore.Mvc;
using ProjectCodeJarAPI.Contracts;
using ProjectCodeJarAPI.Domain;
using ProjectCodeJarAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCodeJarAPI.Controllers.V1
{
    public class CoinJarController : Controller
    {
        private readonly ICoinJar _coinJar;

        public CoinJarController(ICoinJar coinJar)
        {
            _coinJar = coinJar;
        }
        
        [HttpPost(ApiRoutes.CoinJar.AddCoin)]
        public IActionResult AddCoin([FromBody] Coin coin)
        {
            var addCoin = new Coin { Volume = coin.Volume, Amount = coin.Amount };
            _coinJar.AddCoin(addCoin);


            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.CoinJar.AddCoin + "/" + addCoin.Volume.ToString();
            //Shows how user can rtetrive volume data using this Url
            return Created(locationUri, addCoin);
        }

        [HttpGet(ApiRoutes.CoinJar.GetTotalAmout)]
        public IActionResult GetTotalAmount()
        {
            var totalAmount = _coinJar.GetTotalAmount();

            if (totalAmount != 0.00m)
            {
                return Ok();
            }

           return NotFound();
        }

        [HttpPut(ApiRoutes.CoinJar.Reset)]
        public IActionResult ResetCount()
        {
            _coinJar.Reset();

            return Ok();
           
        }

        //[HttpDelete(ApiRoutes.CoinJar.Reset)]
        //public IActionResult ResetCount2()
        //{
        //    _coinJar.Reset();

        //    return Ok();

        //}
    }
}
