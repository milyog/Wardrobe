using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Reflection;
using Wardrobe.Models;
using Wardrobe.Repository.UsageLogRepository;
using Wardrobe.Services.PairOfShoesService;

namespace Wardrobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PairOfShoesController : ControllerBase
    {
        private readonly IPairOfShoesRepository _pairOfShoesRepository;
        private readonly IUsageLogRepository _usageLogRepository;

        public PairOfShoesController(IPairOfShoesRepository pairOfShoesRepository, IUsageLogRepository usageLogRepository) 
        {
            this._pairOfShoesRepository = pairOfShoesRepository;
            this._usageLogRepository = usageLogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PairOfShoes>>> GetAllPairsOfShoes()
        {
            var result = await _pairOfShoesRepository.GetAllPairsOfShoes();

            if (result.Count == 0)
                return NotFound("Ingen träff.");            // Nu finns resultatkontrollen i både service och controller. Kollar dessutom null.

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PairOfShoes>> GetSinglePairOfShoes(int id)
        {
            var result = await _pairOfShoesRepository.GetSinglePairOfShoes(id);

            if (result is null)
                return NotFound("Ingen träff.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<PairOfShoes>>> AddPairOfShoes([FromForm] PairOfShoes shoes)
        {
            var result = await _pairOfShoesRepository.AddPairOfShoes(shoes);

            return Ok(result);
        }

        // OBS! Uppdaterar just nu alla värden. Är det det du vill?
        [HttpPut("{id}")]
        public async Task<ActionResult<List<PairOfShoes>>> UpdatePairOfShoes(int id,[FromForm] PairOfShoes request)
        {
            var result = await _pairOfShoesRepository.UpdatePairOfShoes(id, request);

            if (result is null)
                return NotFound("Ingen träff.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PairOfShoes>>> DeletePairOfShoes(int id)
        {
            var result = await _pairOfShoesRepository.DeletePairOfShoes(id);

            if (result is null)
                return NotFound("Ingen träff.");

            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> AddUsageLog(int id, UsageLog usageLog)
        {
            await _usageLogRepository.AddUsageLog(id, usageLog);

            return Ok("Användning uppdaterad.");
        }
    }
}

