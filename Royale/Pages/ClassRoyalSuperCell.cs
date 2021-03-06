using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

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
        public IWebElement GooglePlayButton => Driver.FindElement(By.CssSelector(".buttons.appstores .googleplay"));
        public IWebElement AppStoreButton => Driver.FindElement(By.CssSelector(".buttons.appstores .appstore"));

        public IWebElement AcceptCookiesButton => Driver.FindElement(By.CssSelector(".cc-btn.cc-dismiss"));
    }
}
