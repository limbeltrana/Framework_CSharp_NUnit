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
            FW.Log.Info("Browser: Chrome");
            _driver = new ChromeDriver();
            wait = new Wait(10);
        }

        public static void Quit() {
            FW.Log.Info("Close browser");
            Current.Quit();
            Current.Dispose();
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

        public static string Title => Current.Title;

        public static void GoToPage(string url) {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }
            FW.Log.Info(url);
            Current.Navigate().GoToUrl(url);
        }

        public static Element FindElement(By by, string elementName) {
            return new Element(Current.FindElement(by), elementName)
            {
                FoundBy = by
            };
        }


        public static Elements FindElements(By by) {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
           
        }

         
    }
}
