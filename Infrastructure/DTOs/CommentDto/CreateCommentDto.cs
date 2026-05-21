using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.CommentDto;

public class CreateCommentDto
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    [Required]
    [MaxLength(300)]
    public string Text { get; set; } = null!;
}
