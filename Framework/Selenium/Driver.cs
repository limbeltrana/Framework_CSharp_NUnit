using OpenQA.Selenium;
using System;
using System.IO;

namespace Framework.Selenium
{
  public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        public static Wait wait;

        public static Window window;

        public static void Init() {
           
            _driver = DriverFactory.Build(FW.Config.Driver.Browser);
            wait = new Wait(10);
            window = new Window();
            window.Maximize();
        }

        public static void TakeScreenshot(string imageName) {
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFileName = Path.Combine(FW.CurrentTestDirectory.FullName, imageName);
            ss.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
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
