namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        //Burada IQueryable<T> tipinde bir değer döndürür ve anlamı sorgulanabilirdir.
    }
}