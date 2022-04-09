using LetsAuth.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LetsBoard.Infra.Repositories
{
    public interface ICardsRepository:IBaseRepository<Card>
    {
        Task<IEnumerable<Card>> GetAll();
    }
}
