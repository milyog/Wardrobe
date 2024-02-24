using Wardrobe.Models;

namespace Wardrobe.Services.PairOfShoesService
{
    public interface IPairOfShoesService
    {
        Task<List<PairOfShoes>> GetAllPairsOfShoes();
        Task<PairOfShoes?> GetSinglePairOfShoes(int id);
        Task<List<PairOfShoes>?> AddPairOfShoes(PairOfShoes shoes);
        Task<List<PairOfShoes>?> UpdatePairOfShoes(int id, PairOfShoes request);
        Task<List<PairOfShoes>?> DeletePairOfShoes(int id);

    }
}
