using Framework.Selenium;
using OpenQA.Selenium;

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
            Driver.wait.Until(drvr => Map.DeckBuilderInput.Displayed);
            return this;
        }

        public void AddCardsManualy() {
            Driver.wait.Until(WaitConditions.ElementIsDisplayed(Map.AddCardsManuallyLink)).Click();                
            Driver.wait.Until(WaitConditions.ElementDisplayed(Map.CopyDeckIcon));
        }


        public void CopySuggestedDeck() {
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
       public Element AddCardsManuallyLink => Driver.FindElement(By.XPath("//a[text()='add cards manually']"), "Add cards manually link");

       public Element CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"), "Copy deck icon");
      
       public Element DeckBuilderInput => Driver.FindElement(By.CssSelector(".deckBuilder__container"), "Deck builder input");
        
    }
}
