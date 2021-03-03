using Framework.Models;
using Framework.Selenium;
using Framework.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;

namespace Royale.Tests
{
    public class CardTests
    {

        [SetUp]
        //Setup before each test method
        public void BeforeEach()
        {
            Driver.Init();
            WrapPages.Init();
            Driver.Current.Manage().Window.Maximize();
            Driver.GoToPage("https://statsroyale.com");
        }

        [TearDown]
        //after each test
        public void AfterEach(){
            Driver.Current.Quit();
        }

        [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {
            var iceSpirit =  WrapPages.Cards.GoTo().GetCardByName("Ice Spirit");
            Assert.That(iceSpirit.Displayed);
        }


        static string[] cardNames = { "Ice Spirit", "Mirror" };

        [Test, Category("cards")]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        //[TestCase("Ice Spirit")] se reemplaza por testCaseSource
        //[TestCase("Mirror")]
        public void Card_headers_are_correct_on_Card_Details_Page(string cardName)
        {
            WrapPages.Cards.GoTo().GetCardByName(cardName).Click();

            Card cardOnPage = WrapPages.CardDetails.GetBaseCard();
            var card = new InMemoryCardServices().GetCardByName(cardName);

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
            //Assert.Pass();
        }
    }
}