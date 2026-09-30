using Combine_Day_Twenty_N_tier_API.Dtos;
using Combine_Day_Twenty_N_tier_API.Models;
using Combine_Day_Twenty_N_tier_API.Repositories;


// The SErvices is where the rules live and its where our DTOs and Models meet
// Controllers <- DTO -> Services <- Models -> Repository
namespace Combine_Day_Twenty_N_tier_API.Services
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _repository;

        public SupplyService(ISupplyRepository repository)
        {
            _repository = repository;
        }

        public List<SupplyReadDTO> GetAll()
        {
            //The list always comes back in alphabetical order
            //LINQ Select for every record in our Db we will do x to
            return _repository.GetAll()
            .OrderBy(s => s.Name)
            .Select(s => ToReadDTO(s)) // Turn every model into a DTO
            .ToList();
        }

        public SupplyReadDTO? GetById(int id)
        {
            Supply? supply = _repository.GetById(id);

            if(supply == null)
            {
                return null;
            }

            return ToReadDTO(supply);
        }

        // Rules: We Must have a name & you can't stock fewer than 0
        // Rules 2 No 2 Supplies can have the same
        public SupplyReadDTO? Create(SupplyCreateDTO dto)
        {
            //We do not need this anymore this is being handled within the DTO itself
            // if (supply.Quantity <= 0 || string.IsNullOrWhiteSpace(supply.Name))
            // {
            //     return null;
            // }

            bool exists = _repository.GetAll().Any(s => s.Name.ToLower() == dto.Name.ToLower());

            //If a name already exists within our DB we will return null
            if (exists)
            {
                return null;
            }

            //DTO -> Model

            Supply supply = new Supply();

            supply.Name = dto.Name;
            supply.Quantity = dto.Quantity;
            supply.StorageLocation = "Recieving Bay"; //everything new starts here

            //We are creating a new Supply variable and storing our added supply.
            Supply created = _repository.Add(supply);

            return ToReadDTO(created);
        }

        //Rules: You must take at least 1, and never more than what we have.
        public bool Withdraw(int id, int amount)
        {
            Supply? exsisting = _repository.GetById(id);

            if(exsisting == null ||amount > exsisting.Quantity || amount <= 0)
            {
                return false;
            }

            exsisting.Quantity -= amount;
            _repository.Update(exsisting);
            return true;
        }

        public void Delete(int id)
        {
            Supply? supply = _repository.GetById(id);

            //If it is not null we will delete it
            if (supply != null)
            {
                _repository.Delete(supply);
            }
        }
        
        //Our Helper Method that takes in our Supply Model and outputs our DTO
        private static SupplyReadDTO ToReadDTO(Supply supply)
        {
            SupplyReadDTO outputDTO = new SupplyReadDTO();
            outputDTO.Id = supply.Id;
            outputDTO.Name = supply.Name;
            outputDTO.Quantity = supply.Quantity;

            return outputDTO;
        }
    }
}