using Application.DTO.UserDTOs;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Domain.Interfaces.Query;

namespace Application.Service;

public class UserService : IUserService
{
    private IUserQuery _query;
    private readonly IMapper _mapper;

    public UserService(IUserQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
        AutoMapperConfig.Initialize();
    }

    public List<UserDTO> GetAll()
    {
        var res = _query.GetUsers();
        return _mapper.Map<List<UserDTO>>(res);
    }

    public UserDTO GetById(int id)
    {
        throw new NotImplementedException();
    }

    public UserDTO Add(ManageUserDTO post)
    {
        throw new NotImplementedException();
    }

    public void Update(ManageUserDTO updatePost)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
