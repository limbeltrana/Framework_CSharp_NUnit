using Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
