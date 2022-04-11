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

        public async Task<(Card, string)> CreateAsync(Card card)
        {
            try
            {
                Validator.ValidateObject(card, new ValidationContext(card), true);

                var cardCreated = await _cardsRepository.CreateAsync(card);

                return (cardCreated, "");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }                      
        }

        public async Task<(bool, string)> UpdateAsync(Card card)
        {
            try
            {
                Validator.ValidateObject(card, new ValidationContext(card), true);

                var result = await _cardsRepository.UpdateAsync(card);

                return (result, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(IEnumerable<Card>, string)> DeleteAsync(Guid id)
        {
            try
            {
                var card = await _cardsRepository.GetAsync(id);

                if (card == null)
                    return (null, "Card não encontrado") ;

                if (await _cardsRepository.DeleteAsync(card))
                {
                    return (await _cardsRepository.GetAll(), "");
                }

                return (null, "Erro ao deletar");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
