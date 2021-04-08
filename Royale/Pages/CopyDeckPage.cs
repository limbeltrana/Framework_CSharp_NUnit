using Framework.Selenium;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

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
            //Driver.wait.Until(drvr => Map.GooglePlayButton.Displayed);
            Driver.wait.Until(ExpectedConditions.ElementIsVisible(Map.GooglePlayButton.FoundBy));
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
            //Driver.wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
            Driver.wait.Until(WaitConditions.ElementNotDisplayed(Map.AcceptCookiesButton));
        }
    }

    public class CopyDeckPageMap
    {

        public Element YesButton => Driver.FindElement(By.Id("button-open"), "Yes button");

        public Element CopiedMessage => Driver.FindElement(By.CssSelector(".notes.active"),"Copied message");

        public Element NoButton => Driver.FindElement(By.Id("not-installed"), "No button");

        public Element GooglePlayButton => Driver.FindElement(By.XPath("//a[text()='Google Play']"), "Google play button");

        public Element PlatformButton(string platform) {
            return Driver.FindElement(By.XPath($"//a[text()='{platform}']"), $"{platform} button" );
        }

        public Element AcceptCookiesButton => Driver.FindElement(By.CssSelector(".cc-btn.cc-dismiss"), "Accept Cookies button");


    }
}
