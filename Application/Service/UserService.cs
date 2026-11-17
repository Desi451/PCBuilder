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
        var res = await _repository.GetById(id);
        return _mapper.Map<UserDTO>(res);
    }

    public async Task<UserDTO> Add(AddUserDTO user)
    {
        var res = await _repository.Create(_mapper.Map<User>(user), user.Password);
        return _mapper.Map<UserDTO>(res);
    }

    public async Task Update(UserDTO updateUser)
    {
        await _repository.UpdateProfile(updateUser.Id, updateUser.Login, updateUser.Email, null, null);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
        await _saveData.Save();
    }
}
