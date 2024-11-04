namespace IngrEasy.Domain.Repositories;

public interface IUnitOfWork
{
    public Task Commit();
}