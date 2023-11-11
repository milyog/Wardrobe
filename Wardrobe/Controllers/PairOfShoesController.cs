using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Reflection;
using Wardrobe.Models;

namespace Wardrobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PairOfShoesController : ControllerBase
    {
        private static List<PairOfShoes> pairsOfShoes = new List<PairOfShoes>
            {
                new PairOfShoes
                {
                    Id = 1,
                    Brand = "Crockett & Jones",
                    Model = "Boston",
                    Material ="Suede",
                    Category = "Loafer",
                    Size = "7",
                    Description = "Mörkbrun loafer med lädersula.",
                    TimesUsed = new List<WearCounter>() { new WearCounter(1), new WearCounter(2) }
                },
                   new PairOfShoes
                {
                    Id = 2,
                    Brand = "New Balance",
                    Model = "880 v. 13",
                    Material ="Synthetic",
                    Category = "Running shoe",
                    Size = "9",
                    Description = "Neutral mörkblå löparsko med god dämpning.",
                    TimesUsed = new List<WearCounter>() { new WearCounter(1), new WearCounter(2) }
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<PairOfShoes>>> GetAllPairsOfShoes()
        {
            return Ok(pairsOfShoes);
        }

        //[HttpGet] Alternativt
        //[Route("{id}")] 
        [HttpGet("{id}")]
        public async Task<ActionResult<PairOfShoes>> GetSinglePairOfShoes(int id)
        {
            var singlePairOfShoes = pairsOfShoes.Find(x => x.Id == id);

            if (singlePairOfShoes is null) 
                return NotFound("Ingen träff.");

            return Ok(singlePairOfShoes);
        }

        [HttpPost]
        public async Task<ActionResult<List<PairOfShoes>>> AddPairOfShoes(PairOfShoes shoes)
        {
            pairsOfShoes.Add(shoes);
            return Ok(pairsOfShoes);
        }

        // OBS! Uppdaterar just nu alla värden. Är det det du vill?
        [HttpPut("{id}")]
        public async Task<ActionResult<List<PairOfShoes>>> UpdatePairOfShoes(int id, PairOfShoes request)
        {
            var singlePairOfShoes = pairsOfShoes.Find(x => x.Id == id);

            if (singlePairOfShoes is null)
                return NotFound("Ingen träff.");

            singlePairOfShoes.Brand= request.Brand;
            singlePairOfShoes.Model = request.Model;
            singlePairOfShoes.Material= request.Material;
            singlePairOfShoes.Category= request.Category;
            singlePairOfShoes.Size= request.Size;
            singlePairOfShoes.Description= request.Description;
            singlePairOfShoes.TimesUsed= request.TimesUsed;

            return Ok(singlePairOfShoes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PairOfShoes>>> DeletePairOfShoes(int id)
        {
            var singlePairOfShoes = pairsOfShoes.Find(x => x.Id == id);

            if (singlePairOfShoes is null)
                return NotFound("Ingen träff.");

            pairsOfShoes.Remove(singlePairOfShoes);

            return Ok(pairsOfShoes);
        }
    }
}

