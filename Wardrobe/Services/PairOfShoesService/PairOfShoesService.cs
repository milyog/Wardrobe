using Wardrobe.Models;

namespace Wardrobe.Services.PairOfShoesService
{
    public class PairOfShoesService : IPairOfShoesService
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
        public List<PairOfShoes> AddPairOfShoes(PairOfShoes shoes)
        {
            pairsOfShoes.Add(shoes);
            return pairsOfShoes;
        }

        public List<PairOfShoes>? DeletePairOfShoes(int id)
        {
            var singlePairOfShoes = pairsOfShoes.Find(x => x.Id == id);

            if (singlePairOfShoes is null)
                return null;

            pairsOfShoes.Remove(singlePairOfShoes);

            return pairsOfShoes;
        }

        public List<PairOfShoes> GetAllPairsOfShoes()
        {
            return pairsOfShoes;
        }

        public PairOfShoes? GetSinglePairOfShoes(int id)
        {
            var singlePairOfShoes = pairsOfShoes.Find(x => x.Id == id);

            if (singlePairOfShoes is null)
                return null;

            return singlePairOfShoes;
        }

        public List<PairOfShoes>? UpdatePairOfShoes(int id, PairOfShoes request)
        {
            var singlePairOfShoes = pairsOfShoes.Find(x => x.Id == id);

            if (singlePairOfShoes is null)
                return null;

            singlePairOfShoes.Brand = request.Brand;
            singlePairOfShoes.Model = request.Model;
            singlePairOfShoes.Material = request.Material;
            singlePairOfShoes.Category = request.Category;
            singlePairOfShoes.Size = request.Size;
            singlePairOfShoes.Description = request.Description;
            singlePairOfShoes.TimesUsed = request.TimesUsed;

            return pairsOfShoes; 
        }
    }
}
