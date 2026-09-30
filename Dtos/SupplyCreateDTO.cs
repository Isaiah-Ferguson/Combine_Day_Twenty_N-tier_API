//What a client is allowed to SEND.
//This will no Id (our DB picks it anyway) and no StorageLocation (That is ours).
// Even if the client wants to set those properties they cannot because we dont have them

using System.ComponentModel.DataAnnotations;

namespace Combine_Day_Twenty_N_tier_API.Dtos
{
    public class SupplyCreateDTO
    {
        //Attributes are characteristics of our properties
        [Required(ErrorMessage = "Every supply needs a name.")]
        public string Name { get; set; }
        [Range(1, 10000, ErrorMessage = "Quantity must be from 0 to 10000")]
        public int Quantity { get;set; }
    }
}