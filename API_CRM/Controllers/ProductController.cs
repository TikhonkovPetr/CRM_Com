using API_CRM.DataBase;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API_CRM.Controllers
{
    public class ProductController : Controller
    {
        DB dbcontext = new DB();
        [HttpGet("Product")]
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return dbcontext.Products;
        }
        [HttpGet("ProductName/{Id}")]
        public async Task<string> GetProductName(Guid Id)
        {
            return dbcontext.Products.FirstOrDefault(p=>p.Id==Id).Name;
        }
        [HttpPost("Product")]
        public async void PostProduct([FromBody]Product product)
        {
            product.Id= Guid.NewGuid();
            dbcontext.Products.Add(product);
            dbcontext.SaveChanges();
        }
        [HttpGet("Product_IdCompany/{Id_Company}")]
        public async Task<IEnumerable<Product>> GetProduct_IdCompany(Guid Id_Company)
        {
            return dbcontext.Products.Where(p=>p.Id_Company==Id_Company);
        }
        [HttpPost("Product/{Id}/{Id_Company}/{Name}/{Cost}")]
        public async void PostProduct_OutCompany(Guid Id, Guid Id_Company, string Name, string Cost)
        {
            Product product = new Product() { Id = Id, Id_Company = Id_Company, Name = Name, cost = Cost };
            dbcontext.Products.Add(product);
            dbcontext.SaveChanges();
        }
        [HttpGet("Product/{Id}")]
        public async Task<Product> GetProduct(Guid Id)
        {
            return dbcontext.Products.FirstOrDefault(pro => pro.Id == Id);
        }
        [HttpPatch("Product_Patch/{Id}/{Id_Company}/{Name}/{cost}")]
        public async void UpdateProduct(Guid Id, Guid Id_Company, string Name, string cost)
        {
            dbcontext.Products.Update(new Product() { Id = Id, Id_Company = Id_Company, Name = Name, cost=cost});
            dbcontext.SaveChanges();
        }
        [HttpDelete("Product_Del/{Id}")]
        public async void DelProduct(Guid Id)
        {
            Product product = new Product() { Id = Id };
            dbcontext.Products.Attach(product);
            dbcontext.Products.Remove(product);
            dbcontext.SaveChanges();
        }
    }
}
