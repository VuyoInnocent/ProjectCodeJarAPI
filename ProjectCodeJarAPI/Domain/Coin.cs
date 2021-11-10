using ProjectCodeJarAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCodeJarAPI.Domain
{
    public class Coin :ICoin
    {
        [Key]
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
        
    }
}
