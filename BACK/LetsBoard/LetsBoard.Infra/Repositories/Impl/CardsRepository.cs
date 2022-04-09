using LetsAuth.Infra.Context;
using LetsAuth.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LetsBoard.Infra.Repositories.Impl
{
    public class CardsRepository : BaseRepository<Card>, ICardsRepository
    {
        public CardsRepository(LetsBoardContext context)
            : base(context) { }
        public async Task<IEnumerable<Card>> GetAll()
        {
            return await _context.Cards.ToListAsync();
        }
    }
}
