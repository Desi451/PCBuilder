using Domain.Entities;

namespace Domain.Interfaces.Repository;

public interface IPostRepository
{
    IEnumerable<Post> GetAll();
    Post GetById(int id);
    Post Add(Post post);
    void Update(Post post);
    void Delete(Post post);
}
