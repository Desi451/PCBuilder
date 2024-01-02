using Application.DTO.UserDTOs;
using Application.Interfaces;
using Application.Mappings;
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
        AutoMapperConfig.Initialize();
    }

    public async Task<bool> Login(LoginUserDTO user)
    {
        User res = new User();
        if (user.Login.Contains("@"))
            res.Email = user.Login;
        else
            res.Login = user.Login;
        
        res.Password = user.Password;

        return await _repository.GetByLoginMail(res);
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

    public async Task ChangeMailStatus(int id)
    {
        await _repository.ChangeMailStatus(id);
        await _saveData.Save();
    }
}
