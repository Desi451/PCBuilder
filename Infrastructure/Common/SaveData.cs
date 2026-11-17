using Application.Service.Common;
using Domain.Interfaces.Common;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;

public class SaveData : ISaveData
{
    private const int UniqueIndexViolation = 2601;
    private const int UniqueConstraintViolation = 2627;

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
        catch (DbUpdateException exception) when (IsUniqueViolation(exception))
        {
            throw new ConflictException("The operation would create a duplicate record.");
        }
    }

    private static bool IsUniqueViolation(DbUpdateException exception)
    {
        return exception.InnerException is SqlException sqlException
            && (sqlException.Number == UniqueIndexViolation || sqlException.Number == UniqueConstraintViolation);
    }
}
