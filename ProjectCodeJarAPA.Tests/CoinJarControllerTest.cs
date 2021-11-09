using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using ProjectCodeJarAPI.Controllers.V1;
using WebAPI.Models;

namespace ProjectCodeJarAPI.Tests
{
    [TestClass]
    public class CoinJarControllerTest
    {
        [TestMethod]
        public void AddCoin_CoinOnjectTwoDecimalNumumbers_ReturnVoid()
        {
            var controller = new CoinJarController();


            //Arrange
            Coin coin = new Coin();
            CoinJar coinJar = new CoinJar();
            var ammout = 0.01m;
            var expectedVolume = 0.0146m;

            //Act
            var actual = coin.GetCoinByAmount(ammout);
            coinJar.AddCoin(actual);

            //Assert
            Assert.AreEqual(expectedVolume, actual.Volume);

        }
        [TestMethod]
        public void GetTotalAmount_NoParameters_ReturndecimalTotal()
        {

            CoinJar coinJar = new CoinJar();
            var expectedTotal = 0.01m;

            var actual = coinJar.GetTotalAmount();

            Assert.AreEqual(expectedTotal, actual);

        }
        [TestMethod]
        public void Reset_NoParameters_ReturnVoid()
        {
            ProjectCodeJarAPI.Services.CoinJar coinJar = new ProjectCodeJarAPI.Services.CoinJar();
            var totalAmmout = coinJar.CoinsTotalAmount;

            coinJar.Reset();

            Assert.IsTrue(totalAmmout == 0.00m);

        }
    }
}
