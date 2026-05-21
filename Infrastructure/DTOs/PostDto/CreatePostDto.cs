namespace Infrastructure.DTOs.PostDto;

public class CreatePostDto
{
    public int UserId { get; set; }
    public string Content { get; set; } = null!;
}
