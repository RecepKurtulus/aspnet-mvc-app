using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
namespace Repositories;

    public class RepositoryContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        //Producları tutan ve productun sahip olduğu 3 alanı (id, name, price)'ı tabloya yansıytan bir yapı oluşutrduk
        public RepositoryContext(DbContextOptions <RepositoryContext> options)
        //RepositoryConetext olarak gelmeyen bir derleme isteği derlenemez. 
        :base(options)
        {
           //base(options) ile RepositoryConetext'i DbContext'e yansıtıyoruz.
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().
            HasData(
                new Product(){ProductId=1,ProductName="Kalem",ProductPrice=11},
                new Product(){ProductId=2,ProductName="Silgi",ProductPrice=10},
                new Product(){ProductId=3,ProductName="Defter",ProductPrice=30},
                new Product(){ProductId=4,ProductName="Kitap",ProductPrice=100},
                new Product(){ProductId=5,ProductName="Sözlük",ProductPrice=79}
                //Product tablosuna bakıcak eğer veri varsa dokumayacak, veri yoksa
                //bu verileri ekleyecek.
            );
        }
        //Model oluşurken araya girip OnModelCreating metodunu geçersiz kılıp bunu modelBuilden üzerinden çağırıcağımızı söylüyoruz
    
}
 