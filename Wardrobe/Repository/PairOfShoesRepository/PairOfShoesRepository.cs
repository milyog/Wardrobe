using Microsoft.EntityFrameworkCore;
using Wardrobe.Data;
using Wardrobe.Models;

namespace Wardrobe.Services.PairOfShoesService
{
    public class PairOfShoesRepository : IPairOfShoesRepository
    {  
        private readonly DataContext _context;
        public PairOfShoesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PairOfShoes>> GetAllPairsOfShoes()
        {
            var pairsOfShoes = await _context.PairOfShoes.ToListAsync();
            return pairsOfShoes;
        }

        public async Task<PairOfShoes?> GetSinglePairOfShoes(int id)
        {
            var singlePairOfShoes = await _context.PairOfShoes.FirstOrDefaultAsync(c => c.Id == id);//FindAsync(id);

            if (singlePairOfShoes is null)
                return null;

            return singlePairOfShoes;
        } 

        public async Task<List<PairOfShoes>?> AddPairOfShoes(PairOfShoes shoes)
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

        public async Task<List<PairOfShoes>?> UpdatePairOfShoes(int id, PairOfShoes request)
        {
            var singlePairOfShoes = await _context.PairOfShoes.FindAsync(id);

            if (singlePairOfShoes is null)
                return null;

            singlePairOfShoes.Brand = request.Brand;
            singlePairOfShoes.Model = request.Model;
            singlePairOfShoes.Price = request.Price;
            singlePairOfShoes.Category = request.Category;
            singlePairOfShoes.Material = request.Material;   
            singlePairOfShoes.Color = request.Color;
            singlePairOfShoes.Size = request.Size;
            singlePairOfShoes.Description = request.Description;

            await _context.SaveChangesAsync();

            return await _context.PairOfShoes.ToListAsync();
        }

    }
}
