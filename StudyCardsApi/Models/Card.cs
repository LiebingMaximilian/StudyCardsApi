using System.ComponentModel.DataAnnotations.Schema;

namespace StudyCardsApi.Models
{
    public class Card
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public int Difficulty { get; set; }
    }
}