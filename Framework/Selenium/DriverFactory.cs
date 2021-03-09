using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Selenium
{
    public static class DriverFactory
    {
        public static IWebDriver Build(string browserName) {
            FW.Log.Info($"Browser: {browserName}");
            //switch (browserName)
            //{
            //    case "chrome":
            //        return new ChromeDriver();

            //    case "firefox":
            //        return new FirefoxDriver();

            //    default:
            //        throw new ArgumentException($"{browserName} not supported");
            //} 
            return browserName switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                _ => throw new ArgumentException($"{browserName} not supported"),
            };
        }
    }
}
