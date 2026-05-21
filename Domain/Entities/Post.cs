using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Post
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    [Required]
    [MaxLength(500)]
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public User User { get; set; } = null!;
    public List<Comment> Comments { get; set; } = [];

}
