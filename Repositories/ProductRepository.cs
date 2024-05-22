using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddProduct(Product product)
        {
            product.IsActive = 1;
            int result = 0;
            db.Products.Add(product);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            var model = db.Products.Where(e => e.Id == id).FirstOrDefault();

            if (model != null)
            {
                model.IsActive = 0;
                result = db.SaveChanges();

            }
            return result;
        }

        public int EditProduct(Product product)
        {
            int result = 0;
            var model = db.Products.Where(p => p.Id == product.Id).FirstOrDefault();
            if (model != null)
            {
                model.Name = product.Name;
                model.Description = product.Description;
                model.Price = product.Price;
                model.Stock = product.Stock;
                model.IsActive = 1;
                result = db.SaveChanges();
            }
            return result;
        }

        public Product GetProductById(int id)
        {
            return db.Products.Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            var model = (from products in db.Products
                         where products.IsActive == 1
                         select products).ToList();
            return model;
        }
    }
}
