using Framework.Selenium;
using NUnit.Framework;
using Royale.Pages;
using Royale.Tests.Base;

namespace Royale.Tests
{
    public class CopyDeckTests : TestBase
    {
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
            Assert.That(Driver.Title,Is.EqualTo("‎Clash Royale on the App Store"));
        }

        [Test, Category("copydeck")]
        public void User_opens_google_play() {
            WrapPages.DeckBuilder.GoTo().AddCardsManualy();
            WrapPages.DeckBuilder.CopySuggestedDeck();
            WrapPages.CopyDeck.No().GoToClassRoyalSuperCellPage("Google Play").OpenGooglePlay();
            Assert.AreEqual("Clash Royale - Apps on Google Play", Driver.Title);
        }
    }
}
