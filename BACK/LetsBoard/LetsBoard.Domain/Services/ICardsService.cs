using LetsAuth.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsAuth.Domain.Services
{
    public interface ICardsService
    {
        Task<(Card, string)> CreateAsync(Card card);
        Task<(IEnumerable<Card>, string)> DeleteAsync(Guid id);
        Task<IEnumerable<Card>> GetAll();
        Task<(bool, string)> UpdateAsync(Card card);
    }
}
