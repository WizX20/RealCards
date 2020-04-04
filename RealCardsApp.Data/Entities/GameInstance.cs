using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealCardsApp.Data.Entities
{
    public class GameInstance
    {
        [Required]
        public int Id { get; set; }

        public Game Game { get; set; }
        public Player ActivePlayer { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public int TurnCount { get; set; }
        public DateTime GameStartDateTime { get; set; }
        public DateTime? GameEndDateTime { get; set; }
    }
}