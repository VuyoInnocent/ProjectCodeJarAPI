using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCodeJarAPI.Interfaces
{
    public interface ICoinJar
    {
        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();
    }
}
