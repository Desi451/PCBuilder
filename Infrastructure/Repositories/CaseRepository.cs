using Application.Service.Common;
using Domain.Entities.Components.Case;
using Domain.Interfaces.Repository.Components;
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
        await _context.AddAsync(box);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        res.IsDeleted = true;
    }

    public async Task<List<Case>> GetCases()
    {
        return await _context.Cases.AsNoTracking().ToListAsync();
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
        oldBox.Name = box.Name;
        oldBox.Model = box.Model;
        oldBox.Height = box.Height;
        oldBox.Width = box.Width;
        oldBox.Deepth = box.Deepth;
        oldBox.Description = box.Description;
        oldBox.CaseSize = box.CaseSize;
        oldBox.SeriesId = box.SeriesId;
    }
}
