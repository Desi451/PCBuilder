using Application.DTO.PostDTOs;

namespace Application.Interfaces;

public interface IPostService
{
    public IEnumerable<PostDTO> GetAllPosts();
    public PostDTO GetPostById(int id);
    public PostDTO AddPost(CreatePostDTO post);
    public void UpdatePost(UpdatePostDTO updatePost);
    public void DeletePost(int id);
}
