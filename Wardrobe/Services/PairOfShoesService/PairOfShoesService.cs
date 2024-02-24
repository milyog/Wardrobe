using Microsoft.EntityFrameworkCore;
using Wardrobe.Data;
using Wardrobe.Models;

namespace Wardrobe.Services.PairOfShoesService
{
    public class PairOfShoesService : IPairOfShoesService
    {   /*
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
                    //TimesUsed = new List<WearCounter>() { new WearCounter(1), new WearCounter(2) }
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
                    //TimesUsed = new List<WearCounter>() { new WearCounter(1), new WearCounter(2) }
                }
            };*/

        private readonly DataContext _context;
        public PairOfShoesService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PairOfShoes>> AddPairOfShoes(PairOfShoes shoes)
        {
            _context.PairOfShoes.Add(shoes);
            _context.SaveChanges();

            return await _context.PairOfShoes.ToListAsync();
        }

        public async Task<List<PairOfShoes>?> DeletePairOfShoes(int id)
        {
            var singlePairOfShoes = await _context.PairOfShoes.FindAsync(id);

            if (singlePairOfShoes is null)
                return null;

            _context.PairOfShoes.Remove(singlePairOfShoes);
            await _context.SaveChangesAsync();

            return await _context.PairOfShoes.ToListAsync();
        }

        public async Task<List<PairOfShoes>> GetAllPairsOfShoes()
        {
            var pairsOfShoes = await _context.PairOfShoes.ToListAsync();
            return pairsOfShoes;
        }

        public async Task<PairOfShoes>? GetSinglePairOfShoes(int id)
        {
            var singlePairOfShoes = await _context.PairOfShoes.FindAsync(id);

            if (singlePairOfShoes is null)
                return null;

            return singlePairOfShoes;
        }

        public async Task<List<PairOfShoes>?> UpdatePairOfShoes(int id, PairOfShoes request)
        {
            var singlePairOfShoes = await _context.PairOfShoes.FindAsync(id);

            if (singlePairOfShoes is null)
                return null;

            singlePairOfShoes.Brand = request.Brand;
            singlePairOfShoes.Model = request.Model;
            singlePairOfShoes.Material = request.Material;
            singlePairOfShoes.Category = request.Category;
            singlePairOfShoes.Size = request.Size;
            singlePairOfShoes.Description = request.Description;

            await _context.SaveChangesAsync();

            return await _context.PairOfShoes.ToListAsync();
        }


    }
}
