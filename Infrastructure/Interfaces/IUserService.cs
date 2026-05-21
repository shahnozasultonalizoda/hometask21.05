using Domain.Entities;
using Infrastructure.DTOs.UserDto;

namespace Infrastructure.Interface;

public interface IUserService
{
    public Task<ICollection<User>> GetUsersAsync();
    public Task<User?> GetUsersByIdAsync(int id);
    public Task<int> AddUsersAsync(CreateUserDto dto);
    public Task<int> UpdateUsersAsync(int id , UpdateUserDto dto);
    public Task<int> DeleteUsersAsync(int id);
}
