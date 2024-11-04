

using Core.Entities;
using Infrastructure.Data; 
//using Microsoft.AspNetCore.Http.HttpResults;

namespace Infrastructure.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;
        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public string Create(Product product)
        {

            if (product != null && (_context.Products.Any(p => p.Name == product.Name)) == false)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return "ok";
            }
            else return "Invalid Creation";
        }

       

        public Product GetProductById(int id)
        {

            var product=_context.Products.Find(id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
           var products= _context.Products;
            return products;
        }

        public string Update(Product product)
        {
            var p = GetProductById(product.Id);
            if (p != null)
            {
                p.Name = product.Name;
                _context.Update(p);
                _context.SaveChanges();
                return "updated";
            }
            else return "invalid";
        }
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();

            }

        }
    }
}
