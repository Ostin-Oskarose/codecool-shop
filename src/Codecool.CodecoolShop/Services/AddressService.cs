using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;
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

    public void UpdateUserId(FullBillingViewModel model, string userId)
    {
        model.BillingAddress.UserId = userId;
        model.ShippingAddress.UserId = userId;
    }


    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public BillingAddressModel FindBilling(string userId)
    {
        var bill = _dbContext.BillingAddressModels.FirstOrDefault(x=>x.UserId == userId);
        return bill;
    }    
    
    public ShippingAddressModel FindShipping(string userId)
    {
        var ship = _dbContext.ShippingAddressModels.FirstOrDefault(x => x.UserId == userId);
        return ship;
    }

}