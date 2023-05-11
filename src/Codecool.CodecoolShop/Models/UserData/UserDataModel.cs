using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models.UserData
{
    public class UserDataModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string PhoneNumber { get; set; }
        public BillingAddressModel BillingAddress { get; set; }
        public ShippingAddressModel ShippingAddress { get; set; }
    }
}
