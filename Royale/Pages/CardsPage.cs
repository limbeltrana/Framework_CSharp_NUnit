using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Pages
{
    public class CardsPage : PageBase

    {
        public readonly CardsPageMap Map;

        public CardsPage() 
        {
            Map = new CardsPageMap();
        }


        public CardsPage GoTo() {
            headerNav.GoToCardsPage();
            return this;
        }

        public Element GetCardByName(string cardName) {
            if (cardName.Contains(" "))
            {
                cardName = cardName.Replace(" ", "+");
            }

            return Map.Card(cardName); 
        }
    }

    public class CardsPageMap
    {

        //public IWebElement IceSpiritCard => _driver.FindElement(By.CssSelector("a[href *= 'Ice+Spirit']"));
        public Element Card(string name) => Driver.FindElement(By.CssSelector($"a[href *= '{name}']"), $"Card {name}");
    }
}
