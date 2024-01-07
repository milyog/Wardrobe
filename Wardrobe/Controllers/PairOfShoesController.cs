using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Reflection;
using Wardrobe.Models;
using Wardrobe.Services.PairOfShoesService;

namespace Wardrobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PairOfShoesController : ControllerBase
    {
        private readonly IPairOfShoesService _pairOfShoesService;

        public PairOfShoesController(IPairOfShoesService pairOfShoesService) 
        {
            this._pairOfShoesService = pairOfShoesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PairOfShoes>>> GetAllPairsOfShoes()
        {
            return _pairOfShoesService.GetAllPairsOfShoes();
        }

        //[HttpGet] Alternativt
        //[Route("{id}")] 
        [HttpGet("{id}")]
        public async Task<ActionResult<PairOfShoes>> GetSinglePairOfShoes(int id)
        {
            var result = _pairOfShoesService.GetSinglePairOfShoes(id);

            if (result is null)
                return NotFound("Ingen träff.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<PairOfShoes>>> AddPairOfShoes(PairOfShoes shoes)
        {
            var result = _pairOfShoesService.AddPairOfShoes(shoes);

            return Ok(result);
        }

        // OBS! Uppdaterar just nu alla värden. Är det det du vill?
        [HttpPut("{id}")]
        public async Task<ActionResult<List<PairOfShoes>>> UpdatePairOfShoes(int id, PairOfShoes request)
        {
            var result = _pairOfShoesService.UpdatePairOfShoes(id, request);

            if (result is null)
                return NotFound("Ingen träff.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PairOfShoes>>> DeletePairOfShoes(int id)
        {
            var result = _pairOfShoesService.DeletePairOfShoes(id);

            if (result is null) 
                return NotFound("Ingen träff.");

            return Ok(result);
        }
    }
}

