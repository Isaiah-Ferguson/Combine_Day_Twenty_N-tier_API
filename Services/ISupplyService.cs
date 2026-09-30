using Combine_Day_Twenty_N_tier_API.Dtos;
using Combine_Day_Twenty_N_tier_API.Models;

namespace Combine_Day_Twenty_N_tier_API.Services
{
    public interface ISupplyService
    {
        List<SupplyReadDTO> GetAll();

        SupplyReadDTO? GetById(int id);
        SupplyReadDTO Create(SupplyCreateDTO supply);

        bool Withdraw(int id, int ammount); //false if there isn't enough

        void Delete(int id);
    }
}