using Application.DTO.Components.Drive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Components;

public interface IHddService
{
    public Task<List<HddDTO>> GetAll();
    public Task<HddDTO> GetById(int id);
    public Task<HddDTO> Add(AddHddDTO ssd);
    public Task Update(HddDTO ssd);
    public Task Delete(int id);
}
