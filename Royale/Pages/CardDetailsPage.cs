﻿using Framework.Models;
using Framework.Selenium;
using OpenQA.Selenium;
using System.Linq;

namespace Royale.Pages
{
    public class CardDetailsPage : PageBase
    {
        public readonly CardDetailsMap Map;
        public CardDetailsPage()
        {
            Map = new CardDetailsMap();
        }

        public (string category, string arena) GetCardCategory() {
            var categories = Map.CardCategory.Text.Split(",");
            return (categories[0].Trim(), categories[1].Trim());
        }

        public Card GetBaseCard() {

            var (category, arena) = GetCardCategory();
            return new Card {
                Name = Map.CardName.Text,
                Rarity = Map.CardRarity.Text.Split('\n').Last(),
                Type = category,
                Arena = arena
            };
        }
    }

    public class CardDetailsMap 
    {
   
        public IWebElement CardName => Driver.FindElement(By.CssSelector("[class*='card__cardName']"));
        public IWebElement CardCategory => Driver.FindElement(By.ClassName("card__rarity"));
        public IWebElement CardRarity => Driver.FindElement(By.CssSelector(".card__common"));


    }
}
