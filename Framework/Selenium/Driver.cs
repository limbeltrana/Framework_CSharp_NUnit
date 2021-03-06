﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        public static Wait wait;

        public static void Init() {
            _driver = new ChromeDriver();
            wait = new Wait(10);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

        public static string Title => Current.Title;

        public static void GoToPage(string url) {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }
            Debug.WriteLine(url);
            Current.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElement(By by) {
            return Current.FindElement(by);
        }


        public static IList<IWebElement> FindElements(By by) {
            return Current.FindElements(by);
        }

         
    }
}
