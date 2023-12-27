using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        //Burada IQueryable<T> tipinde bir değer döndürür ve anlamı sorgulanabilirdir.
        T? FindByCondition(Expression<Func<T,bool>> expression,bool trackChanges);
        //Bir T ifadesi döneceksin null olabilir bu t ifadesi sorguya göre kayıt döndürecek
        //Ve trackChanges ile değişiklikleri takip edebiliriz.
    }
}