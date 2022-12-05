using Database2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database2022.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService() => _context = App.GetContext();


        public bool Create(Product item)
        {
            try
            {
                //EntityFrameworkCore
                _context.Products.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public bool CreateRange(List<Product> items)
        {
            try
            {
                //EntityFrameworkCore
                _context.Products.AddRange(items);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Product> Get()
        {
            return _context.Products.ToList();
        }


        public List<Product> GetByText(string text)
        {
            return _context.Products.Where(x => x.ProductName.Contains(text) || x.ProductDetail.Contains(text)).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public bool UpdateProduct(Product product, int id)
        {
            try
            {
                var model = GetById(id);
                model.ProductName = product.ProductName;
                model.ProductDetail = product.ProductDetail;
                model.ProductPrice = product.ProductPrice;
                model.ProductInStock = product.ProductInStock;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                var model = GetById(id);
                _context.Remove(model);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
