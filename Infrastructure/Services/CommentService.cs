using System.Runtime;
using Domain.Entities;
using Infrastructure.DTOs.CommentDto;
using Infrastructure.DTOs.PostDto;
using Infrastructure.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CommentService(DataContext context) : ICommentService
{
    public async Task<int> AddCommentsAsync(CreateCommentDto dto)
    {
        var comment = new Comment
        {
            UserId = dto.UserId,
            PostId = dto.PostId,
            Text = dto.Text
        };

        context.Comments.Add(comment);
        return await context.SaveChangesAsync();
    }

    


    public async Task<int> DeleteCommentsAsync(int id)
    {
        var entity = await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if(entity is null)
        {
            return 0;
        }

        context.Comments.Remove(entity);
        return await context.SaveChangesAsync();
    

    }

    public async Task<ICollection<Comment>> GetCommentsAsync()
    {
        return await context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetCommentsByIdAsync(int id)
    {
        return await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<int> UpdateCommentsAsync(int id , UpdateCommentDto dto)
    {
        var entity = await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if(entity is null)
        {
            return 0;
        }

        entity.Text = dto.Text;

        return await context.SaveChangesAsync();
    }

}
