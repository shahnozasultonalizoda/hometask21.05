using Domain.Entities;
using Infrastructure.DTOs.CommentDto;
using Infrastructure.DTOs.PostDto;

namespace Infrastructure.Interfaces;

public interface ICommentService
{
    public Task<ICollection<Comment>> GetCommentsAsync();
    public Task<Comment?> GetCommentsByIdAsync(int id);
    public Task<int> AddCommentsAsync(CreateCommentDto dto);
    public Task<int> UpdateCommentsAsync(int id , UpdateCommentDto dto);
    public Task<int> DeleteCommentsAsync(int id);

}
