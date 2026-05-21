using Domain.Entities;
using Infrastructure.DTOs.UserDto;
using Infrastructure.Interface;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserService(DataContext context) : IUserService
{
    public async Task<int> AddUsersAsync(CreateUserDto dto)
    {
        var user = new User
        {
            UserName = dto.Username,
            Email = dto.Email,
            Bio = dto.Bio
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<int> DeleteUsersAsync(int id)
    {
         var entity = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
         if(entity == null)
        {
            return 0;
        }

        context.Remove(entity);
        return await context.SaveChangesAsync();
    }

    public async Task<ICollection<User>> GetUsersAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User?> GetUsersByIdAsync(int id)
    {
         return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        
    }

    public async Task<int> UpdateUsersAsync(int id , UpdateUserDto dto)
    {
        var entity = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
         if(entity == null)
        {
            return 0;
        }

        entity.UserName = dto.Username;
        entity.Email = dto.Email;
        entity.Bio = dto.Email;

        return await context.SaveChangesAsync();
    }

}
