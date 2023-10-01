using Application.DTO.PostDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService service)
    {
        _postService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var posts = _postService.GetAllPosts();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var post = _postService.GetPostById(id);
        return Ok(post);
    }

    [HttpPost("add")]
    public IActionResult Create(CreatePostDTO newPost)
    {
        var post = _postService.AddPost(newPost);
        return Ok(post);
    }

    [HttpPut("update")]
    public IActionResult Update(UpdatePostDTO newPost)
    {
        _postService.UpdatePost(newPost);
        return Ok();
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        _postService.DeletePost(id);
        return NoContent();
    }
}
