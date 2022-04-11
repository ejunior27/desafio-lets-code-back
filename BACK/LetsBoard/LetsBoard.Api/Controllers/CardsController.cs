using LetsAuth.Domain.Services;
using LetsAuth.Models.Entities;
using LetsBoard.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LetsAuthApi.Controllers
{
    [Authorize]    
    [Route("{controller}")]
    public class CardsController : ControllerBase
    {
        private readonly ICardsService _cardsService;
        public CardsController(ICardsService cardsService)
        {
            _cardsService = cardsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cardList = await _cardsService.GetAll();

            if(cardList == null)
                return BadRequest();

            return Ok(cardList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Card card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (cardCreated, errorMessage) = await _cardsService.CreateAsync(card);

            if(cardCreated == null)
                return BadRequest(errorMessage);

            return Ok(cardCreated);
        }

        [Log]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Card card)
        {
            if (!ModelState.IsValid || id != card.Id)
                return BadRequest(ModelState);

            var (result, errorMessage) = await _cardsService.UpdateAsync(card);

            if (!result)
                return NotFound(errorMessage);

            return Ok(result);
        }

        [Log]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if(id == null)
                return BadRequest();

            var (cards, errorMessage) = await _cardsService.DeleteAsync(id);

            if (cards == null)
                return NotFound(errorMessage);

            return Ok(cards);
        }
    }
}
