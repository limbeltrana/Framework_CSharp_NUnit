using Framework.Models;
using System;

namespace Framework.Services
{
  public class InMemoryCardServices : ICardService
    {
        public Card GetCardByName(string cardName)
        {
            switch (cardName)
            {
                case "Ice Spirit":
                    return new IceSpiritCard();

                case "Mirror":
                    return new MirrorCard();
                default:
                    throw new ArgumentException("Card is not available: " + cardName);
            }
        }
    }
}
