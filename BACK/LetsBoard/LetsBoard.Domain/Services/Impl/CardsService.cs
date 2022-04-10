using LetsAuth.Models.Entities;
using LetsBoard.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace LetsAuth.Domain.Services.Impl
{
    public class CardsService : ICardsService
    {
        private readonly ICardsRepository _cardsRepository;

        public CardsService(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public async Task<IEnumerable<Card>> GetAll()
        {
            return await _cardsRepository.GetAll();
        }

        public async Task<Card> CreateAsync(Card card)
        {
            Validator.ValidateObject(card, new ValidationContext(card), true);

            return await _cardsRepository.CreateAsync(card);            
        }

        public async Task<bool> UpdateAsync(Card card)
        {
            Validator.ValidateObject(card, new ValidationContext(card), true);

            return await _cardsRepository.UpdateAsync(card);
        }

        public async Task<IEnumerable<Card>> DeleteAsync(Guid id)
        {
            var card = await _cardsRepository.GetAsync(id);

            if (card == null)
                return null;

            if (await _cardsRepository.DeleteAsync(card))
            {
                return await _cardsRepository.GetAll();
            }

            return null;
        }
    }
}
