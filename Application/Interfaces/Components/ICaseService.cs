using Application.DTO.Components.Case;
using Application.DTO.Components.Case_Size;

namespace Application.Interfaces.Components;

public interface ICaseService
{
    public Task<List<CaseDTO>> GetAll();
    public Task<CaseDTO> GetById(int id);
    public Task<CaseDTO> Add(AddCaseDTO box);
    public Task Update(CaseDTO upBox);
    public Task Delete(int id);
}
