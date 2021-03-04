using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Royale.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Tests
{
    public class CopyDeckTests
    {
        [SetUp]
        //Setup before each test method
        public void BeforeEach()
        {
            Driver.Init();
            WrapPages.Init();
            Driver.Current.Manage().Window.Maximize();
            Driver.GoToPage("https://statsroyale.com");
        }

        [TearDown]
        //after each test
        public void AfterEach()
        {
            Driver.Current.Quit();
        }


        [Test]
        public void User_can_copy_the_deck() {

            //var wait = new WebDriverWait(Driver.Current, TimeSpan.FromSeconds(10));
            //Driver.FindElement(By.CssSelector("[href='/deckbuilder']")).Click();
            WrapPages.DeckBuilder.GoTo();

            //Driver.FindElement(By.XPath("//a[text()='add cards manually']")).Click();
            WrapPages.DeckBuilder.AddCardsManualy();

            Driver.wait.Until(drvr => WrapPages.DeckBuilder.Map.CopyDeckIcon.Displayed);
            //Driver.FindElement(By.CssSelector(".copyButton")).Click();
            WrapPages.DeckBuilder.CopySuggestedDeck();

            Driver.FindElement(By.Id("button-open")).Click();
            Driver.wait.Until(drvr => WrapPages.CopyDeck.Map.CopiedMessage.Displayed);
            WrapPages.CopyDeck.Yes();
            //var copyMessage = Driver.FindElement(By.CssSelector(".notes.active"));
            Assert.That(WrapPages.CopyDeck.Map.CopiedMessage.Displayed);
            ;

        }
    }
}
