using Combine_Day_Twenty_N_tier_API.Models;

namespace Combine_Day_Twenty_N_tier_API.Repositories
{
    public interface ISupplyRepository
    {
        List<Supply> GetAll();
        Supply? GetById(int id);
        Supply Add(Supply supply);
        void Update(Supply supply);
        void Delete(Supply supply);
    }
}