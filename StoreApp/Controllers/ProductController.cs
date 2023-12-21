using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Repositories;



namespace StoreApp.Controllers
{
    public class ProductController:Controller
    {
        private readonly RepositoryContext _context;
        //Sadece okunabilir bir RepositoryContext dosyası oluşturduk.
        public ProductController(RepositoryContext context){
            _context=context;
        
        }
        //Buna dependicy enjection patterni diyoruz 
        //Bunu da Program.cs dosyasında yaptığımız bağlantı sayesinde başarıyoruz.
        public IActionResult Index(){
            var model=_context.Products.ToList();
            return View("Index",model);
            
        }
        public IActionResult Get(int id){
            
            var product=_context.Products.First(p=>p.ProductId.Equals(id));
            //Productun için gir eğer domainin sonu ile id değeri eşleşiyosa 
			//onu döndür
			//mesela domain/Product/Get/1 dedik buradaki 1 id değeri oluyor
            return View(product);
        }
    }
}