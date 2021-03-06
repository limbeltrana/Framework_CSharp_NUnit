using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Pages
{
    public class DeckBuilderPage:PageBase
    {
        public readonly DeckBuilderPageMap Map;

        public DeckBuilderPage()
        {
            Map = new DeckBuilderPageMap();
        }

        public DeckBuilderPage GoTo()
        {
            headerNav.Map.DeckBuilderLink.Click();
            Driver.wait.Until(drvr => Map.AddCardsManuallyLink.Displayed);
            return this;
        }

        public void AddCardsManualy() {
            Map.AddCardsManuallyLink.Click();
            Driver.wait.Until(drvr => Map.CopyDeckIcon.Displayed);
        }


        public void CopySuggestedDeck() {
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
        //public IWebElement AddCardsManuallyLink => Driver.FindElement(By.CssSelector("[href='/deckbuilder']"));
        public IWebElement AddCardsManuallyLink => Driver.FindElement(By.CssSelector("[class='deckBuilderInput__separator']" +
            "+[class='ui__blueLink ui__link']"));

        // public IWebElement CopyDeckIcon => Driver.FindElement(By.XPath("//a[text()='add cards manually']"));
        public IWebElement CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"));
        
    }
}
