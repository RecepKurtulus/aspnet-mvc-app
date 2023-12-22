namespace Repositories.Contracts
{
    public interface IRepositoryManager
    //Bu yapıyı implement eden herhangi bir class ilgili product
    //repository'i getirmek zorunda.
    {
        IProductRepository Product { get; }
        void Save(); //Veritabanına kaydetmek için kullanılır.

    }
}