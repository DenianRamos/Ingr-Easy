using IngrEasy.Domain.Repositories;

namespace IngrEasy.Infrastructure.DataAcess;

public class UnitOfWork : IUnitOfWork
{
    private readonly IngrEasyDbContext _context;

    public UnitOfWork(IngrEasyDbContext context) => _context = context;


    public async Task Commit() => await _context.SaveChangesAsync();
}