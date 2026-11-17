using Application.DTO.UserDTOs;
using Application.Interfaces;
using Application.Service.Common;
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
    private readonly ICurrentUser _currentUser;

    public UserService(IMapper mapper,
        IUserRepository repository, ISaveData saveData, ICurrentUser currentUser)
    {
        _currentUser = currentUser;
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
        if (id == _currentUser.Id)
        {
            throw new AppException("You cannot delete your own account.");
        }

        await _repository.Delete(id);
        await _saveData.Save();
    }
}
