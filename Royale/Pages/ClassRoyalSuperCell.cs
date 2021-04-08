using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
  public class ClassRoyalSuperCell
    {

        public readonly ClassRoyalSuperCellMap Map;

        public ClassRoyalSuperCell()
        {
            Map = new ClassRoyalSuperCellMap();
        }

        public ClassRoyalSuperCell Goto() {
            
            return this;
        }

        public void OpenAppStore()
        {
            Map.AcceptCookiesButton.Click();
            Driver.wait.Until(drvr => Map.AppStoreButton.Displayed);
            Map.AppStoreButton.Click();
        }

     
        public void OpenGooglePlay()
        {
            Map.AcceptCookiesButton.Click();
            Driver.wait.Until(drvr => Map.GooglePlayButton.Displayed);
            Map.GooglePlayButton.Click();
        }

        public void AcceptCookies()
        {
            Map.AcceptCookiesButton.Click();
            Driver.wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
        }
    }

    public class ClassRoyalSuperCellMap {
        public Element GooglePlayButton => Driver.FindElement(By.CssSelector(".buttons.appstores .googleplay"), "Google Play button");
        public Element AppStoreButton => Driver.FindElement(By.CssSelector(".buttons.appstores .appstore"), "App Store button");

        public Element AcceptCookiesButton => Driver.FindElement(By.CssSelector(".cc-btn.cc-dismiss"), "Accept cookies button");
    }
}
