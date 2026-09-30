namespace Combine_Day_Twenty_N_tier_API.Models
{
    public class Supply
    {
        //When creating an entity we always need a unique identifer
        public int Id {get; set;}
        public string Name {get;set;} = string.Empty;
        public int Quantity {get; set;}
        //StorageLocation is Internal Only. The Client never see's it.
        public string StorageLocation {get;set;} = string.Empty;
    }
}