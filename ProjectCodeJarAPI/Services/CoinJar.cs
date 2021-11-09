using ProjectCodeJarAPI.Data;
using ProjectCodeJarAPI.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCodeJarAPI.Services
{
    public class CoinJar : ICoinJar
    {
        private readonly DataContext _dataContext;

        public int Id { get; set; }
        public decimal TotalVolume { get; set; }
        public decimal UsedVolume { get; set; }
        public decimal CoinsTotalAmount { get; set; }
        

        public CoinJar(DataContext dataContext)
        {
            _dataContext = dataContext;

            TotalVolume = 42m;
            UsedVolume = 0m;
            CoinsTotalAmount = 0.00m;
        }
        public CoinJar()
        {
        }

        public void AddCoin(ICoin coin)
        {
            //if (coin is null)
            //    Console.WriteLine();

            var CoinJarList = GetCoinJarList();
            if (!CoinJarList.Any())
            {
                var addCoinJar = new CoinJar { TotalVolume = 42m,
                                               UsedVolume = coin.Volume, 
                                               CoinsTotalAmount = coin.Amount };

                TotalVolume = addCoinJar.TotalVolume;

                _dataContext.CoinJar.Add(addCoinJar);
            }
            else
            {
                var coinJarResult = _dataContext.CoinJar.SingleOrDefault(x => x.TotalVolume == 42m);
                TotalVolume = coinJarResult.TotalVolume;
                coinJarResult.UsedVolume += coin.Volume;
                coinJarResult.CoinsTotalAmount += coin.Amount;
            }
            if (coin != null && coin.Volume < TotalVolume)
            { 
                //casting ICoin
                _dataContext.Coin.Add((Coin)coin);
            }

            _dataContext.SaveChanges();

        }

        public decimal GetTotalAmount()
        {
            return _dataContext.CoinJar.SingleOrDefault(x => x.TotalVolume == 42m).CoinsTotalAmount;
        }

        public void Reset()
        {
            var coinJarResult = _dataContext.CoinJar.SingleOrDefault(x => x.TotalVolume == 42m);
            coinJarResult.CoinsTotalAmount = 0.00m;
            coinJarResult.UsedVolume = 0m;

            _dataContext.SaveChanges();
        }

        public List<CoinJar> GetCoinJarList()
        {
            return _dataContext.CoinJar.ToList(); 
        }
    }
}
