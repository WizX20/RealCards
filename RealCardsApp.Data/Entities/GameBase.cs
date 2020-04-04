using System.ComponentModel.DataAnnotations;

namespace RealCardsApp.Data.Entities
{
    public abstract class GameBase
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}