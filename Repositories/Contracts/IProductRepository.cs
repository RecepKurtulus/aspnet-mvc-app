using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductRepository:IRepositoryBase<Product>
    //IProductRepository arabirimi var elimizde ve IRepositoryBase'i kalıtımla devralıyor
    {
        IQueryable<Product> GetAllProducts(bool trackChanges)=> FindAll(trackChanges);
        //Değişiklikleri izlemek için yazdık bu kodu
        Product? GetOneProduct(int id, bool trackChanges);
    }
}