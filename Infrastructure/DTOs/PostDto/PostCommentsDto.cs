using Domain.Entities;

namespace Infrastructure.DTOs.PostDto;

public class PostCommentsDto
{
    public string Content { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public List<Comment> Comments { get; set; } = [];
}
