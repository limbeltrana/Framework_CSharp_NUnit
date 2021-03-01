using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Pages
{
   public abstract class PageBase
    {
        public readonly HeaderNav headerNav;
        public PageBase(IWebDriver driver)
        {
            headerNav = new HeaderNav(driver);
        }


    }
}
