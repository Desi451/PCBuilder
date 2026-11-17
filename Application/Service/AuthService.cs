using Application.DTO.Computer;
using Application.DTO.UserDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;

namespace Application.Service;

public class AuthService : IAuthService
{
    private IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly ISaveData _saveData;

    public AuthService(IMapper mapper,
        IUserRepository repository, ISaveData saveData)
    {
        _repository = repository;
        _mapper = mapper;
        _saveData = saveData;
    }

    public async Task<UserDTO> Login(LoginUserDTO user)
    {
        User res = new User();
        if (user.Login.Contains("@"))
            res.Email = user.Login;
        else
            res.Login = user.Login;
        
        res.Password = user.Password;
        var data = await _repository.GetByLoginMail(res);
        return _mapper.Map<UserDTO>(data);
    }

    public async Task Register(AddUserDTO user)
    {
        await _repository.Add(_mapper.Map<User>(user));
        await _saveData.Save();
    }

    public Task GetCurrentUser()
    {
        throw new NotImplementedException();
    }

    //public async Task ChangeMailStatus(int id)
    //{
    //    await _repository.ChangeMailStatus(id);
    //    await _saveData.Save();
    //}

    public async Task Edit(AddUserDTO user, int id)
    {
        await _repository.Update(_mapper.Map<User>(user), id);
        await _saveData.Save();
    }
}
