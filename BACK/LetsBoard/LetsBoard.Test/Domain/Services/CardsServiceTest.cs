using FluentAssertions;
using LetsAuth.Domain.Services.Impl;
using LetsAuth.Models.Entities;
using LetsBoard.Infra.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsBoard.Test.Domain.Services
{
    [TestClass]
    public class CardsServiceTest
    {
        private readonly CardsService _subject;
        private readonly Mock<ICardsRepository> _cardsRepositoryMock = new Mock<ICardsRepository>();

        public CardsServiceTest()
        {
            _subject = new CardsService(_cardsRepositoryMock.Object);
        }

        [TestMethod]
        public async Task CreateAsync_HappyDay_ReturnCard()
        {
            var card = new Card
            {
                Content = "conteudo",
                Title = "titulo",
                List = "lista"
            };

            _cardsRepositoryMock.Setup(x => x.CreateAsync(card))
                .ReturnsAsync(card);

            var (cardResult,errorMessage) = await _subject.CreateAsync(card);

            cardResult.Should().BeEquivalentTo(new Card
            {
                Title = card.Title,
                List = card.List,
                Content = card.Content,
                Id = It.IsAny<Guid>(),
            });

            errorMessage.Should().BeEmpty();
        }

        [TestMethod]
        public async Task CreateAsync_RepositoryError_ReturnNullCard()
        {
            var card = new Card
            {
                Content = "conteudo",
                Title = "titulo",
                List = "lista"
            };

            _cardsRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Card>()))
                .Throws(new Exception("Erro no repositório"));

            var (cardResult, errorMessage) = await _subject.CreateAsync(card);

            cardResult.Should().BeNull();

            errorMessage.Should().BeEquivalentTo("Erro no repositório");
        }

        [TestMethod]
        public async Task UpdateAsync_HappyDay_ReturnTrue()
        {
            var card = new Card
            {
                Content = "conteudo",
                Title = "titulo",
                List = "lista"
            };

            _cardsRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Card>()))
                .ReturnsAsync(true);

            var (result, errorMessage) = await _subject.UpdateAsync(card);

            result.Should().Be(true);

            errorMessage.Should().BeEmpty();
        }

        [TestMethod]
        public async Task UpdateAsync_InvalidCard_ReturnFalse()
        {
            var card = new Card();            

            var (result, errorMessage) = await _subject.UpdateAsync(card);

            result.Should().Be(false);

            errorMessage.Should().NotBeEmpty();
        }

        [TestMethod]
        public async Task DeleteAsync_HappyDay_ReturnList()
        {
            _cardsRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Card());

            _cardsRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<Card>()))
                .ReturnsAsync(true);

            _cardsRepositoryMock.Setup(x => x.GetAll())
                .ReturnsAsync(new List<Card>());

            var (result, errorMessage) = await _subject.DeleteAsync(Guid.NewGuid());

            result.Should().NotBeNull();

            errorMessage.Should().BeEmpty();
        }
    }
}
