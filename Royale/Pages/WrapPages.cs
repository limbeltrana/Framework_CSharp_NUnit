using System;


namespace Royale.Pages
{
  public class WrapPages
    {
        [ThreadStatic]
        public static CardsPage Cards;

        [ThreadStatic]
        public static CardDetailsPage CardDetails;

        [ThreadStatic]
        public static DeckBuilderPage DeckBuilder;

        [ThreadStatic]
        public static CopyDeckPage CopyDeck;

        [ThreadStatic]
        public static ClassRoyalSuperCell SuperCell;

        public static void Init() {
            Cards = new CardsPage();
            CardDetails = new CardDetailsPage();
            DeckBuilder = new DeckBuilderPage();
            CopyDeck = new CopyDeckPage();
            SuperCell = new ClassRoyalSuperCell();
        }
    }
}
