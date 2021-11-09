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
        //CoinJar properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }
        decimal TotalVolume { get; set; }
        decimal UsedVolume { get; set; }
        decimal CoinsTotalAmount { get; set; }

        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();
    }
}
