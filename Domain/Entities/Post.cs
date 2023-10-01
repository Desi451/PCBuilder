using Domain.Common;

namespace Domain.Entities;

public class Post : AuditableEntity
{
    public Post() { }

    public Post(int id, string title, string content)
    {
        (Id,Title,Content) = (id,title,content);
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}
