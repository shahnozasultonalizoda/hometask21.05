using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; } = null!;
    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [MaxLength(200)]
    public string Bio { get; set; } = null!;
    public List<Post> Posts { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
}
