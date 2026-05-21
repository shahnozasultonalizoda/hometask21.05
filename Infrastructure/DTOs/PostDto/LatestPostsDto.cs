namespace Infrastructure.DTOs.PostDto;

public class LatestPostsDto
{
    public string Content { get; set; } =null!;
    public DateTime CreatedAt { get; set; }
    public string UserName { get; set; } = null!;
}
