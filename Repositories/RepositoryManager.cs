using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        public RepositoryManager(IProductRepository productRepository,RepositoryContext context){
            _context=context;
            _productRepository = productRepository;
            
        }
        //Dependicy injection yaptık bile
        public IProductRepository Product => _productRepository;
        //Product'a erişilmek istenirse tanımladığımız alan üzerinden
        //ilgili yapı return edilicek.

        public void Save()
        {
            _context.SaveChanges(); //Veritabanına kayıt yapılır.
        }
    }
}