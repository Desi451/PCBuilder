using Application.DTO.UserDTOs;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Query;
using Domain.Interfaces.Repository;

namespace Application.Service;

public class UserService : IUserService
{
    private readonly IUserQuery _query;
    private IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserQuery query, IMapper mapper,
        IUserRepository repository)
    {
        _query = query;
        _repository = repository;
        _mapper = mapper;
        AutoMapperConfig.Initialize();
    }

    public async Task<List<UserDTO>> GetAll()
    {
        var res = await _query.GetUsers();
        return _mapper.Map<List<UserDTO>>(res);
    }

    public async Task<UserDTO> GetById(int id)
    {
        try
        {
            var res = await _query.GetById(id);
            return _mapper.Map<UserDTO>(res);
        } 
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<UserDTO> Add(AddUserDTO user)
    {
        var res = _mapper.Map<User>(user);
        await _repository.Add(res);
        await _repository.Save();
        return _mapper.Map<UserDTO>(res);
    }

    public async Task Update(UserDTO updateUser)
    {
        try
        {
            var res = _mapper.Map<User>(updateUser);
            await _repository.Update(res);
            await _repository.Save();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
        await _repository.Save();
    }

    public async Task CheckMail(int id)
    {
        await _repository.ConfirmMail(id);
        await _repository.Save();
    }
}
