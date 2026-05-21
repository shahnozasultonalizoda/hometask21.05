using Domain.Entities;
using Infrastructure.DTOs.PostDto;
using Infrastructure.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PostService(DataContext context) : IPostService
{
    public async Task<int> AddPostsAsync(CreatePostDto dto)
    {
        var post = new Post
        {
            UserId = dto.UserId,
            Content = dto.Content
        };

        await context.Posts.AddAsync(post);
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeletePostsAsync(int id)
    {
        var entity = await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if(entity is null)
        {
            return 0;
        }

        context.Posts.Remove(entity);
        return await context.SaveChangesAsync();
    }

    public async Task<List<LatestPostsDto>> GetLatestPostsAsync()
    {
        return await context.Posts
                        .OrderByDescending(p => p.CreatedAt)
                        .Take(5)
                        .Select(p => new LatestPostsDto
                        {
                            Content = p.Content,
                            CreatedAt = p.CreatedAt,
                            UserName = p.User.UserName
                        })
                        .ToListAsync();
    }


    public async Task<ICollection<Post>> GetPostsAsync()
    {
        return await context.Posts.ToListAsync();
    }

    public async Task<Post?> GetPostsByIdAsync(int id)
    {
        return await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<int> UpdatePostsAsync(int id , UpdatePostDto dto)
    {
        var entity = await context.Posts.FirstOrDefaultAsync(p => p.Id ==id);
        if(entity is null)
        {
            return 0;
        }

        entity.Content = dto.Content;

        return await context.SaveChangesAsync();
    }

}
