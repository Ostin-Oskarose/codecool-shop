using Codecool.CodecoolShop.Data;

namespace Codecool.CodecoolShop.Services;

public class CartService
{
    private readonly CodeCoolShopDBContext _dbContext;

    public CartService(CodeCoolShopDBContext dbContext)
    {
        _dbContext = dbContext;
    }
}