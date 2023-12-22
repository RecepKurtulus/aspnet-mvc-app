using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Repositories;
using Repositories.Contracts;



namespace StoreApp.Controllers
{
    public class ProductController:Controller
    {
        private readonly IRepositoryManager _manager;
        //Sadece okunabilir bir IRepositoryManager dosyası oluşturduk.
        public ProductController(IRepositoryManager manager){
            _manager=manager;
        
        }
        //Buna dependicy enjection patterni diyoruz 
        //Bunu da Program.cs dosyasında yaptığımız bağlantı sayesinde başarıyoruz.
        public IActionResult Index(){
            var model=_manager.Product.GetAllProducts(false).ToList();
            return View("Index",model);
            
        }
        public IActionResult Get(int id){
            
            //var product=_context.Products.First(p=>p.ProductId.Equals(id));
            //Productun için gir eğer domainin sonu ile id değeri eşleşiyosa 
			//onu döndür
			//mesela domain/Product/Get/1 dedik buradaki 1 id değeri oluyor
            throw new NotImplementedException();
        }
    }
}