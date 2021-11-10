using ProjectCodeJarAPI.Data;
using ProjectCodeJarAPI.Domain;
using ProjectCodeJarAPI.Interfaces;

namespace ProjectCodeJarAPI.Repositories
{
    public class CoinRepository : Repository<Coin>, ICoinRepository
    {

        public CoinRepository(DataContext dataContext) : base(dataContext)
        {
        }
       
    }
}
