using Application.DTO.BrandDTOs;
using Application.DTO.Components.Case_Size;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface ICaseService
{
    public Task<List<CaseDTO>> GetAll();
    public Task<CaseDTO> GetById(int id);
    public Task<CaseDTO> Add(CaseDTO box);
    public Task Update(CaseDTO upBox);
    public Task Delete(int id);
}
