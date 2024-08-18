using Microsoft.EntityFrameworkCore;
using StudyCardsApi.Models;

namespace StudyCardsApi.Services
{
    public class CardService
    {
        private AppDbContext _context;
        public CardService(AppDbContext context) 
        {
            _context = context;
        }

        public Card GetRandomCardWithHighDifficulty()
        {
            return _context.Cards.OrderByDescending(r => r.Difficulty).OrderBy(r => EF.Functions.Random()).Take(1).AsSplitQuery().Single();
        }

        public void UpdateCardDifficulty(Card card)
        {
            var cardToUpdate = _context.Cards.Single(c => c.Id == card.Id);
            cardToUpdate.Difficulty = card.Difficulty > -1 ? card.Difficulty : 0;
            _context.SaveChanges();
        }

        public void CreateCart(Card card)
        {
            if(_context.Cards.Count() > 500)
            {
                throw new Exception("F*** U");
            }
            var newCard = new Card()
            {
                Answer = card.Answer,
                Difficulty = 10,
                Question = card.Question,
            };
            _context.Cards.Add(newCard);
            _context.SaveChanges();
        }
    }
}
