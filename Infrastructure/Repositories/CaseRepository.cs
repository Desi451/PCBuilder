using Application.Service.Common;
using Domain.Entities.Components.Case;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CaseRepository : ICaseRepository
{
    private AppDbContext _context;

    public CaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Case box)
    {
        box.IsDeleted = false;
        box.Created = DateTime.Now;
        await _context.AddAsync(box);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        res.IsDeleted = true;
    }

    public async Task<List<Case>> GetCases()
    {
        try
        {
            return await _context.Cases
            .Where(x => x.IsDeleted == false)
            .ToListAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task<Case> GetById(int id)
    {
        var res = await _context.Cases.
            FirstOrDefaultAsync(c => c.Id == id);
        return res == null ?
            throw new AppException("No case with this id") : res;
    }

    public async Task Update(Case box)
    {
        Case oldBox = await GetById(box.Id);
        Helper.CopyProperties(box, oldBox);
        oldBox.LastModified = DateTime.Now;
    }
}
