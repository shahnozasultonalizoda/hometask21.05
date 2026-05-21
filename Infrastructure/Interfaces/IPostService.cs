using Domain.Entities;
using Infrastructure.DTOs.PostDto;

namespace Infrastructure.Interfaces;

public interface IPostService
{
    public Task<ICollection<Post>> GetPostsAsync();
    public Task<Post?> GetPostsByIdAsync(int id);
    public Task<int> AddPostsAsync(CreatePostDto dto);
    public Task<int> UpdatePostsAsync(int id , UpdatePostDto dto);
    public Task<int> DeletePostsAsync(int id);
    Task<List<LatestPostsDto>> GetLatestPostsAsync();
}
