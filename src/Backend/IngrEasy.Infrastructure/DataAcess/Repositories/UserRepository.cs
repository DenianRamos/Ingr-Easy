using IngrEasy.Domain.Entities;
using IngrEasy.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace IngrEasy.Infrastructure.DataAcess.Repositories;

public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly IngrEasyDbContext _context;

    public UserRepository(IngrEasyDbContext context) => _context = context;

    public async Task Add(User user) =>  _context.Users.AddAsync(user);

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
       return await _context.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);   
    } 
    
    

    
}