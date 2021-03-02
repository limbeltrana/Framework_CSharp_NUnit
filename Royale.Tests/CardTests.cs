using Framework.Models;
using Framework.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        //Setup before each test method
        public void BeforeEach()
        { 
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://statsroyale.com";
        }

        [TearDown]
        //after each test
        public void AfterEach(){
            driver.Quit();
        }

        [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {
            var cardsPage = new CardsPage(driver);
            var iceSpirit =  cardsPage.GoTo().GetCardByName("Ice Spirit");
            Assert.That(iceSpirit.Displayed);
        }

        [Test]
        public void Ice_Spirit_headers_are_correct_on_Card_Details_Page()
        {
            new CardsPage(driver).GoTo().GetCardByName("Ice Spirit").Click();
            var cardDetails = new CardDetailsPage(driver);

            var (category, arena) = cardDetails.GetCardCategory();
            var cardName = cardDetails.Map.CardName.Text;
            var cardRarity = cardDetails.Map.CardRarity.Text;

            Assert.AreEqual("Ice Spirit",cardName);
            Assert.AreEqual("Troop", category);
            Assert.AreEqual("Arena 8", arena);
            Assert.AreEqual("Common",cardRarity);
            //Assert.Pass();
        }

        static string[] cardNames = { "Ice Spirit", "Mirror" };

        [Test, Category("cards")]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        //[TestCase("Ice Spirit")] se reemplaza por testCaseSource
        //[TestCase("Mirror")]
        public void Card_headers_are_correct_on_Card_Details_Page(string cardName)
        {
            new CardsPage(driver).GoTo().GetCardByName(cardName).Click();
            var cardDetails = new CardDetailsPage(driver);

            Card cardOnPage = cardDetails.GetBaseCard();
            var card = new InMemoryCardServices().GetCardByName(cardName);

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
            //Assert.Pass();
        }
    }
}