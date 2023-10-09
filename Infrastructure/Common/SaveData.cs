using Domain.Interfaces.Common;
using Infrastructure.Context;

namespace Infrastructure.Common;

public class SaveData : ISaveData
{
    private readonly AppDbContext _context;

    public SaveData(AppDbContext context)
    {
        _context = context;
    }

    public async Task Save()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }
}
