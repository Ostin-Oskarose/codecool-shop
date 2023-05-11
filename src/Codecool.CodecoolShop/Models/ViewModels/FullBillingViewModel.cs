using Codecool.CodecoolShop.Models.UserData;

namespace Codecool.CodecoolShop.Models.ViewModels;

public class FullBillingViewModel
{
    public BillingAddressModel BillingAddress { get; set; }
    public ShippingAddressModel ShippingAddress { get; set; }
}