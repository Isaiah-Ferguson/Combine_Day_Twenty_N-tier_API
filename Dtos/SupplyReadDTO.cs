//This is what our Client will Get Back
//The Model Minus StorageLocation
namespace Combine_Day_Twenty_N_tier_API.Dtos
{
    public class SupplyReadDTO
    {
        public int Id { get;set; }
        public string Name { get;set; } = string.Empty;
        public int Quantity { get;set; }
    }
}