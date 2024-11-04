using Core.Entities;

namespace Infrastructure.Services
{
    public interface IProductServices
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        string Create(Product product);
        string Update(Product product);
        void Delete(int id);



    }
}
