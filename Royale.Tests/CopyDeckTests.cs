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

        [TearDown, Category("copydeck")]
        //after each test
        public void AfterEach()
        {
            Driver.Current.Quit();
        }


        [Test,Category("copydeck")]
        public void User_can_copy_the_deck() {

            WrapPages.DeckBuilder.GoTo().AddCardsManualy();
            WrapPages.DeckBuilder.CopySuggestedDeck();
            WrapPages.CopyDeck.Yes();
            Assert.That(WrapPages.CopyDeck.Map.CopiedMessage.Displayed);
        }

        [Test,Category("copydeck")]
        public void User_opens_app_store() {
            WrapPages.DeckBuilder.GoTo().AddCardsManualy();
            WrapPages.DeckBuilder.CopySuggestedDeck();
            WrapPages.CopyDeck.No().GoToClassRoyalSuperCellPage("App Store").OpenAppStore();
            //WrapPages.CopyDeck.No().OpenAppStore();
            Assert.That(Driver.Title,Is.EqualTo("‎Clash Royale on the App Store"));
        }

        [Test, Category("copydeck")]
        public void User_opens_google_play() {
            WrapPages.DeckBuilder.GoTo().AddCardsManualy();
            WrapPages.DeckBuilder.CopySuggestedDeck();
            WrapPages.CopyDeck.No().GoToClassRoyalSuperCellPage("Google Play").OpenGooglePlay();
            //WrapPages.CopyDeck.No().OpenGooglePlay();
            Assert.AreEqual("Clash Royale - Apps on Google Play", Driver.Title);
        }
    }
}
