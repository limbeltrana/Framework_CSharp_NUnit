using Framework.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Royale.Pages
{
    public class CopyDeckPage
    {
        public readonly CopyDeckPageMap Map;
        public CopyDeckPage()
        {
            Map = new CopyDeckPageMap();
        }

        public CopyDeckPage Yes()
        {
            AcceptCookies();
            Map.YesButton.Click();
            Driver.wait.Until(drvr => Map.CopiedMessage.Displayed);
            return this;
        }

        public CopyDeckPage No() {
            AcceptCookies();
            Map.NoButton.Click();
            //AcceptCookies();
            Driver.wait.Until(drvr => Map.GooglePlayButton.Displayed);
            return this;
        }

        public ClassRoyalSuperCell GoToClassRoyalSuperCellPage(string platform) {
            Map.PlatformButton(platform).Click();
            return new ClassRoyalSuperCell();
        }

        //public void OpenGooglePlay() {
        //    Map.GooglePlayButton.Click();
        //}

        public void AcceptCookies() {
            Map.AcceptCookiesButton.Click();
            Driver.wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
        }
    }

    public class CopyDeckPageMap
    {

        public IWebElement YesButton => Driver.FindElement(By.Id("button-open"));

        public IWebElement CopiedMessage => Driver.FindElement(By.CssSelector(".notes.active"));

        public IWebElement NoButton => Driver.FindElement(By.Id("not-installed"));

        //public IWebElement AppStoreButton => Driver.FindElement(By.CssSelector("[class*='os-ios']"));

        public IWebElement GooglePlayButton => Driver.FindElement(By.XPath("//a[text()='Google Play']"));

        public IWebElement PlatformButton(string platform) {
            return Driver.FindElement(By.XPath($"//a[text()='{platform}']"));
        }

        public IWebElement AcceptCookiesButton => Driver.FindElement(By.CssSelector(".cc-btn.cc-dismiss"));


    }
}
