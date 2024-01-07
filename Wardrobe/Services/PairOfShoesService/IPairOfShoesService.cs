using Wardrobe.Models;

namespace Wardrobe.Services.PairOfShoesService
{
    public interface IPairOfShoesService
    {
        List<PairOfShoes> GetAllPairsOfShoes();
        PairOfShoes? GetSinglePairOfShoes(int id);
        List<PairOfShoes> AddPairOfShoes(PairOfShoes shoes);
        List<PairOfShoes>? UpdatePairOfShoes(int id, PairOfShoes request);
        List<PairOfShoes>? DeletePairOfShoes(int id);

    }
}
