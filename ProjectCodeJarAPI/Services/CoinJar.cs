using ProjectCodeJarAPI.Data;
using ProjectCodeJarAPI.Domain;
using ProjectCodeJarAPI.Interfaces;
using System;

namespace ProjectCodeJarAPI.Services
{
    public class CoinJar : ICoinJar
    {
        private readonly ICoinRepository _coinRepository;

        public CoinJar(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public void AddCoin(ICoin coin)
        {
            decimal usedVolume = 0;
            decimal totalVolume = 42m;

            if (coin == null)
                throw new ArgumentNullException("Coin required.");

            var newCoin = new Coin
            {
                Amount = coin.Amount,
                Volume = coin.Volume
            };

            var coinsInJar = _coinRepository.GetAll();

            foreach (var coins in coinsInJar)
            {
                usedVolume += coins.Volume;
            }

            if (newCoin.Volume < totalVolume && usedVolume < totalVolume)
            {
                _coinRepository.SaveAsync(newCoin);
            }
            

            //if (_dataContext.CoinJarTotals.SingleOrDefault(x => x.TotalVolume == 42m) is null || _dataContext is null)
            //{
            //    var _coinJarTotals = new CoinJarTotals
            //    {
            //        TotalVolume = 42m,
            //        UsedVolume = coin.Volume,
            //        CoinsTotalAmount = coin.Amount
            //    };

            //    _coinJarTotals.TotalVolume = addCoinJar.TotalVolume;

            //    //_dataContext.CoinJarTotals.Add(addCoinJar);
            //}
            //else
            //{
            //    var coinJarResult = _dataContext.CoinJarTotals.SingleOrDefault(x => x.TotalVolume == 42m);
            //    _coinJarTotals.TotalVolume = coinJarResult.TotalVolume;
            //    coinJarResult.UsedVolume += coin.Volume;
            //    coinJarResult.CoinsTotalAmount += coin.Amount;
            //}
            //if (coin != null && coin.Volume < TotalVolume)
            //{ 
            //    //casting ICoin
            //    _dataContext.Coin.Add((Coin)coin);
            //}
            //_dataContext.SaveChanges();
        }

        public decimal GetTotalAmount()
        {
            decimal totalAmount = 0;

            var coins = _coinRepository.GetAll();

            foreach (var coin in coins)
            {
                totalAmount += coin.Amount;
            }

            return totalAmount;



            //if (_dataContext is null)
            //    return 0m;

            //if (_dataContext.CoinJarTotals.SingleOrDefault(x => x.TotalVolume == 42m) is null)
            //    return 0m;

            //return _dataContext.CoinJarTotals.SingleOrDefault(x => x.TotalVolume == 42m).CoinsTotalAmount;
        }

        public void Reset()
        {
            
                _coinRepository.DeleteAsync();
            
            


            //var coinJarResult = _dataContext.CoinJarTotals.SingleOrDefault(x => x.TotalVolume == 42m);
            //coinJarResult.CoinsTotalAmount = 0.00m;
            //coinJarResult.UsedVolume = 0m;

            //_dataContext.SaveChanges();
        }

        //public List<CoinJar> GetCoinJarList()
        //{
        //    return _dataContext.CoinJarTotals.ToList(); 
        //}
    }
}
