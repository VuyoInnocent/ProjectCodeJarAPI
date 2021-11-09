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
            var CoinJarList = GetCoinJarObjectList();
            if (CoinJarList.Count == 0)
            {
                var addCodeJar = new CoinJar { TotalVolume = 42m, UsedVolume = coin.Volume, CoinsTotalAmount = coin.Amount };
                TotalVolume = addCodeJar.TotalVolume;
                _dataContext.CoinJar.Add(addCodeJar);
            }
            else
            {
                var coinJarResult = _dataContext.CoinJar.SingleOrDefault(x => x.TotalVolume == 42m);
                TotalVolume = coinJarResult.TotalVolume;
                coinJarResult.UsedVolume += coin.Volume;
                coinJarResult.CoinsTotalAmount += coin.Amount;

                #region trialsCode
                //TotalVolume = CoinJarList.FirstOrDefault().TotalVolume ;
                //UsedVolume = CoinJarList.FirstOrDefault().UsedVolume += coin.Volume;
                //CoinsTotalAmount = CoinJarList.FirstOrDefault().CoinsTotalAmount += coin.Amount;
                //var updateCoinJar = new CoinJar {UsedVolume = UsedVolume, CoinsTotalAmount = CoinsTotalAmount };
                //_dataContext.CoinJar.Update(updateCoinJar);
                //_dataContext.SaveChanges();


                //foreach (var coinJar in CoinJarList)
                //{
                //    coinJar.CoinsTotalAmount += coin.Amount;
                //    coinJar.UsedVolune += coin.Volume;

                //    _dataContext.SaveChanges();
                //}

                #endregion

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
           
            var coinJarResult = _dataContext.CoinJar.SingleOrDefault(x => x.TotalVolume == 42m);

            CoinsTotalAmount = coinJarResult.CoinsTotalAmount;

            #region Trial an error
            ////decimal coinsAmount = 0.00m;
            //// var CoinJarList = _dataContext.CoinJar.ToList();
            //var CoinJarList = GetCoinJarObjectList();
            //if (CoinJarList != null)
            //{
            //    foreach (var coinJar in CoinJarList)
            //    {
            //        coinsAmount += coinJar.CoinsTotalAmount;
            //    }
            //}
            ////else
            ////{
            ////    Console.WriteLine($"No Coins in the jar :- {coinsAmount}");
            ////}
            #endregion

            return CoinsTotalAmount;
        }

        public void Reset()
        {
            var coinJarResult = _dataContext.CoinJar.SingleOrDefault(x => x.TotalVolume == 42m);
            coinJarResult.CoinsTotalAmount = 0.00m;
            coinJarResult.UsedVolume = 0m;

            _dataContext.SaveChanges();

            #region Old Logic
            // var CoinJarList = _dataContext.CoinJar.ToList();
            //foreach (var coinJar in coinJarList)
            //{
            //    _dataContext.Coin.Remove(coinJar);
            //}
            //var CoinJarList = GetCoinJarObjectList();
            //foreach (var coinjar in CoinJarList)
            //{
            //    coinjar.CoinsTotalAmount = 0.00m;
            //    coinjar.UsedVolume = 0m;
            //    _dataContext.CoinJar.Update(coinjar);
            //    _dataContext.SaveChanges();
            //}
            #endregion

        }

        public List<CoinJar> GetCoinJarObjectList()
        {
            return _dataContext.CoinJar.ToList(); 
        }
        //public CoinJar GetCoinJarObject()
        //{
        //    return _dataContext.CoinJar.SingleOrDefault(x => x.TotalVolume == 42m);
        //}
    }
}
