using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//Bunu eklediğimiz için artık controller ve view yapılarını kullanabilceğiz boş bi web projesi olmasına rağmen 
builder.Services.AddDbContext<RepositoryContext>(options=>{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b=>b.MigrationsAssembly("StoreApp"));
    //DbContext'i yapılandırıcaz ve bu sayede veritabanını her istediğimiz middleware'da kullanıcaz.
});
var app = builder.Build();
app.UseStaticFiles();
//Statik dosyaları kullanmamızı sağlayan konfigrasyon.
app.UseRouting();
//Alttaki routing işlemini yapabilsin diye ekliyoruz bunu
app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
//Burada bir template belrliyoruz default olarak domain/home/index sayfasına yönlendiriyoruz




app.Run();
