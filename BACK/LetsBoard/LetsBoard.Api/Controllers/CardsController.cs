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
            return Ok(await _cardsService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Card card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _cardsService.CreateAsync(card));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Card card)
        {
            if (!ModelState.IsValid || id != card.Id)
                return BadRequest(ModelState);

            if(!await _cardsService.UpdateAsync(card))
                return NotFound();

            return Ok(card);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if(id == null)
                return BadRequest();

            var cards = await _cardsService.DeleteAsync(id);

            if (cards == null)
                return NotFound();

            return Ok(cards);
        }
    }
}
