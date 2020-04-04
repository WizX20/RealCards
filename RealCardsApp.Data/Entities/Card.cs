using System.Collections.Generic;

namespace RealCardsApp.Data.Entities
{
    public class Card : GameBase
    {
        public string ImageUrl { get; set; }
        public List<CardProperty> CardProperties { get; set; } = new List<CardProperty>();
        public List<CardType> CardTypes { get; set; } = new List<CardType>();
    }
}