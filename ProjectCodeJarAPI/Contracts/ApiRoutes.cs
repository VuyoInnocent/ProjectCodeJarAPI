using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCodeJarAPI.Contracts
{
    //Create versioning of our API
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class CoinJar
        {
            public const string AddCoin = Base + "/coins/addCoin";
            public const string GetTotalAmout = Base + "/coins/coinsTotal";
            public const string Reset = Base + "/coins/resetCoins";
        }
    }
}
