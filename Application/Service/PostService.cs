using Application.DTO.PostDTOs;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Service;

public class PostService : IPostService
{
    private readonly IPostRepository _repo;
    private readonly IMapper _mapper;
    public PostService(IPostRepository repo, IMapper mapper) 
    {
        _repo = repo;
        _mapper = mapper;
        AutoMapperConfig.Initialize();
    }

    public IEnumerable<PostDTO> GetAllPosts()
    {
        var posts = _repo.GetAll();
        return _mapper.Map<IEnumerable<PostDTO>>(posts);
    }

    public PostDTO GetPostById(int id)
    {
        var post = _repo.GetById(id);
        return _mapper.Map<PostDTO>(post);
    }

    public PostDTO AddPost(CreatePostDTO post)
    {
            var newPost = _mapper.Map<Post>(post);
            _repo.Add(newPost);
            return _mapper.Map<PostDTO>(newPost);
    }

    public void UpdatePost(UpdatePostDTO updatePost)
    {
        var res = _repo.GetById(updatePost.Id);
        var post = _mapper.Map(updatePost, res);
        _repo.Update(post);
    }

    public void DeletePost(int id)
    {
        var res = _repo.GetById(id);
        _repo.Delete(res);
    }
}
