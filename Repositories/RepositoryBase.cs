using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    //Abstract kullanmamızın sebebi bu classı alanlar newlenebilsin bu class newlenemesin
    where T:class, new()
    //T Referans tipli ve newlenebilir olsun.
    {
        protected readonly RepositoryContext _context;
        //RepositoryConetext ifadesini çağırıyoruz
        //Protected olarak tanımlamamızın sebebi diğer classlarda da kullanmak istiyoruz.
        protected RepositoryBase(RepositoryContext context){
            _context=context;
        
        }
        //Constractor injection yapmış olduk
        
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges 
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();
                //Bütün kayıtları getiren bir tanım yazdık.
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
            //Değişiklikler izlenicek demek.
                ?_context.Set<T>().Where(expression).SingleOrDefault(expression)
                //Contextte git ilgili tipe set ol. Ve bir adet kaydın dönmesini sağla.
                :_context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault(expression);
                //Değişiklikler izlenmicekse AsNoTracking ile takip etmemesini söylüyoruz.
        }
    }
}
