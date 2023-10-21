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

    public async Task Login(User user)
    {
        throw new NotImplementedException();
    }

    public Task Register(User user)
    {
        throw new NotImplementedException();
    }

    public Task GetCurrentUser()
    {
        throw new NotImplementedException();
    }
}
