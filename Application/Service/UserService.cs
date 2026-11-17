using Application.DTO.UserDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;

namespace Application.Service;

public class UserService : IUserService
{
    private IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly ISaveData _saveData;

    public UserService(IMapper mapper,
        IUserRepository repository, ISaveData saveData)
    {
        _repository = repository;
        _mapper = mapper;
        _saveData = saveData;
    }

    public async Task<List<UserDTO>> GetAll()
    {
        var res = await _repository.GetUsers();
        return _mapper.Map<List<UserDTO>>(res);
    }

    public async Task<UserDTO> GetById(int id)
    {
        try
        {
            var res = await _repository.GetById(id);
            res.Password = "";
            return _mapper.Map<UserDTO>(res);
        }
        catch
        {
            throw;
        }
    }

    public async Task<UserDTO> Add(AddUserDTO user)
    {
        var res = _mapper.Map<User>(user);
        await _repository.Add(res);
        await _saveData.Save();
        return _mapper.Map<UserDTO>(res);
    }

    public async Task Update(UserDTO updateUser)
    {
        try
        {
            var res = _mapper.Map<User>(updateUser);
            await _repository.Update(res, updateUser.Id);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
        await _saveData.Save();
    }
}
