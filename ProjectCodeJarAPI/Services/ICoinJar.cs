using ProjectCodeJarAPI.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCodeJarAPI.Services
{
    public interface ICoinJar
    {
        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();

        decimal TotalVolume { get; set; }
        decimal UsedVolume { get; set; }
        decimal CoinsTotalAmount { get; set; }

        
    }
}
