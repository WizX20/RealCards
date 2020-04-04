using System.Collections.Generic;

namespace RealCardsApp.Data.Entities
{
    public class Deck : GameBase
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public List<Card> DiscardedCards { get; set; } = new List<Card>();
        public bool ShuffleOnGameStart { get; set; }
        public bool ShuffleOnDeckMerge { get; set; }
        public bool HasDiscardPile { get; set; }
        public bool ShuffleDiscardPile { get; set; }
    }
}