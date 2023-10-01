using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private static readonly ISet<Post> _posts = new HashSet<Post>()
    {
        new Post(1,"tytul","content"),
        new Post(2,"tytul2","content2"),
        new Post(3,"tytul3","content3")
    };

    public Post Add(Post post)
    {
        post.Id = _posts.Count() + 1;
        post.Created = DateTime.Now;
        _posts.Add(post);
        return post;
    }

    public void Delete(Post post)
    {
        _posts.Remove(post);

    }

    public IEnumerable<Post> GetAll()
    {
        return _posts;
    }

    public Post GetById(int id)
    {
        return _posts.SingleOrDefault(x => x.Id == id);
    }

    public void Update(Post post)
    {
        post.LastModified = DateTime.Now;
    }
}
