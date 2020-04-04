using System.Collections.Generic;

namespace RealCardsApp.Data.Entities
{
    public class Game : GameBase
    {
        public string Description { get; set; }
        public List<Deck> Decks { get; set; } = new List<Deck>();
    }
}