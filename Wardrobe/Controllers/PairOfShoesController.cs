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
            var result = await _pairOfShoesService.GetAllPairsOfShoes();

            if (result.Count == 0)
                return NotFound("Ingen träff.");            // Nu finns resultatkontrollen i både service och controller. Kollar dessutom null.

            return Ok(result);
            // return await _pairOfShoesService.GetAllPairsOfShoes();
        }

        //[HttpGet] 
        //public async Task<ActionResult<List<PairOfShoes>?>> UpdatePairOfShoes(int id, PairOfShoes request)
        //{
        //    var singlePairOfShoes = pairsOfShoes.Find(x => x.Id == id);

        //    if (singlePairOfShoes is null)
        //        return null;

        //    singlePairOfShoes.Brand = request.Brand;
        //    singlePairOfShoes.Model = request.Model;
        //    singlePairOfShoes.Material = request.Material;
        //    singlePairOfShoes.Category = request.Category;
        //    singlePairOfShoes.Size = request.Size;
        //    singlePairOfShoes.Description = request.Description;

        //    return await _pairOfShoesService.UpdatePairOfShoes();  
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<PairOfShoes>> GetSinglePairOfShoes(int id)
        {
            var result = await _pairOfShoesService.GetSinglePairOfShoes(id);

            if (result is null)
                return NotFound("Ingen träff.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<PairOfShoes>>> AddPairOfShoes(PairOfShoes shoes)
        {
            var result = await _pairOfShoesService.AddPairOfShoes(shoes);

            return Ok(result);
        }

        // OBS! Uppdaterar just nu alla värden. Är det det du vill?
        [HttpPut("{id}")]
        public async Task<ActionResult<List<PairOfShoes>>> UpdatePairOfShoes(int id, PairOfShoes request)
        {
            var result = await _pairOfShoesService.UpdatePairOfShoes(id, request);

            if (result is null)
                return NotFound("Ingen träff.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PairOfShoes>>> DeletePairOfShoes(int id)
        {
            var result = await _pairOfShoesService.DeletePairOfShoes(id);

            if (result is null)
                return NotFound("Ingen träff.");

            return Ok(result);
        }
    }
}

