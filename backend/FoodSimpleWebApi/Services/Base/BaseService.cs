using FoodSimpleWebApi.Data;

namespace FoodSimpleWebApi.Services.Base;

public abstract class BaseService
{
    private protected readonly FoodSimpleDbContext _context;

    public BaseService(FoodSimpleDbContext context)
    {
        _context = context;
    }
}