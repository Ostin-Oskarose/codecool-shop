using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models.UserData;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Services;

public class AddressService
{
    private readonly CodeCoolShopDBContext _dbContext;

    public AddressService(CodeCoolShopDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(object address)
    {
        switch (address)
        {
            case BillingAddressModel billingAddressModel:
                _dbContext.BillingAddressModels.Add(billingAddressModel);
                break;
            case ShippingAddressModel shippingAddressModel:
                _dbContext.ShippingAddressModels.Add(shippingAddressModel);
                break;
            _: ;
        }

        Save();
    }   
    
    public void Save()
    {
        _dbContext.SaveChanges();
    }
}