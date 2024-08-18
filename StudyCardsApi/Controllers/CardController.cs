using Microsoft.AspNetCore.Mvc;
using StudyCardsApi.Models;
using StudyCardsApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudyCardsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly CardService _cardService;

        public CardController(AppDbContext context, CardService cardService)
        {
            _context = context;
            _cardService = cardService;
        }


        [HttpGet("question")]
        public ActionResult Get()
        {
            try
            {
                return Ok(_cardService.GetRandomCardWithHighDifficulty());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // POST api/<CardController>
        [HttpPost("question")]
        public ActionResult Post([FromBody] Card card)
        {
            try
            {
                _cardService.CreateCart(card);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // Patch api/<CardController>
        [HttpPatch("question")]
        public ActionResult Patch([FromBody] Card card)
        {
            try
            {
                _cardService.UpdateCardDifficulty(card);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // GET api/<CardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
