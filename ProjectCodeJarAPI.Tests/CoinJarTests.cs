using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectCodeJarAPI.Controllers.V1;
using ProjectCodeJarAPI.Domain;
using ProjectCodeJarAPI.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProjectCodeJarAPI.Tests
{
    public class CoinJarTests
    {
       // private readonly CoinJarController _coinJarController;
        CoinJar _coinJar;
        Coin _coin;

        public CoinJarTests()
        {
            _coinJar = new CoinJar();
            _coin = new Coin();
        }

        [Fact]
        public void GetTotalAmount_ReturnTotalAmountInDecimal()
        {
            //arrange

            var expected = 0m;
            //act
            var coinsTotal = _coinJar.GetTotalAmount();

            //assert
            Assert.Equal(expected, coinsTotal);
        }

        [Fact]
        public void AddCoin_CoinObject_ReturnVoid()
        {
            //arrange
            _coin = new Coin
            {
                Amount = 0.01m,
                Volume = 0.0146m
            };

            //act
            _coinJar.AddCoin(_coin);

           
        }

        [Fact]
        public void Reset_ReturnVoid()
        {
            //act
            _coinJar.Reset();

        }
    }
}
