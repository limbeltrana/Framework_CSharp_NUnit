using Framework;
using Framework.Models;
using Framework.Selenium;
using Framework.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;
using Royale.Tests.Base;
using System.Collections.Generic;

namespace Royale.Tests
{
    public class CardTests : TestBase
    {
        static IList<Card> apiCards = new ApiCardService().GetAllCards();

        [Test, Category("cards")]
        [TestCaseSource ("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_is_on_Cards_Page(Card card)
        {
            var cardOnPage =  WrapPages.Cards.GoTo().GetCardByName(card.Name);
            Assert.That(cardOnPage.Displayed);
        }

          
        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        //[TestCase("Ice Spirit")] se reemplaza por testCaseSource
        //[TestCase("Mirror")]
        public void Card_headers_are_correct_on_Card_Details_Page(Card card)
        {
            WrapPages.Cards.GoTo().GetCardByName(card.Name).Click();

            Card cardOnPage = WrapPages.CardDetails.GetBaseCard();

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
            //Assert.Pass();
        }
    }
}