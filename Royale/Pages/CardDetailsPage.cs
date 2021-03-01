using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Pages
{
    public class CardDetailsPage : PageBase
    {
        public readonly CardDetailsMap Map;
        public CardDetailsPage(IWebDriver driver):base(driver)
        {
            Map = new CardDetailsMap(driver);
        }

        public (string category, string arena) GetCardCategory() {
            var categories = Map.CardCategory.Text.Split(",");
            return (categories[0].Trim(), categories[1].Trim());
        }
    }

    public class CardDetailsMap 
    {
        IWebDriver _driver;

        public CardDetailsMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement CardName => _driver.FindElement(By.CssSelector("[class*='card__cardName']"));
        public IWebElement CardCategory => _driver.FindElement(By.ClassName("card__rarity"));
        public IWebElement CardRarity => _driver.FindElement(By.CssSelector(".card__common"));


    }
}
