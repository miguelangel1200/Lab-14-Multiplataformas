using Database2022.Models;
using Database2022.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Database2022.ViewModels
{
    public class ViewModelProduct : BaseViewModel
    {
        private string color;
        public string Color
        {
            get { return this.color; }
            set { SetValue(ref this.color, value); }
        }


        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value); }
        }


        private string productname;
        public string ProductName
        {
            get { return productname; }
            set { SetValue(ref this.productname, value); }
        }
        private string productdetail;
        public string ProductDetail
        {
            get { return productdetail; }
            set { SetValue(ref this.productdetail, value); }
        }

        private double productprice;
        public double ProductPrice
        {
            get { return productprice; }
            set { SetValue(ref this.productprice, value); }
        }

        private int productinstock;
        public int ProductInStock
        {
            get { return productinstock; }
            set { SetValue(ref this.productinstock, value); }
        }

        private int idProduct;
        public int IdProduct
        {
            get { return idProduct; }
            set { SetValue(ref this.idProduct, value); }
        }

        private List<Product> products;
        public List<Product> Products
        {
            get { return this.products; }
            set { SetValue(ref this.products, value); }
        }

        private Product product;
        public Product Product
        {
            get { return this.product; }
            set { SetValue(ref this.product, value); }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectOneCommand { get; set; }
        public ViewModelProduct()
        {
            ProductService service = new ProductService();
            Products = service.Get();

            SearchCommand = new Command(() =>
            {
                ProductService service = new ProductService();
                Products = service.Get();
            });

            InsertCommand = new Command(() =>
            {
                ProductService service = new ProductService();
                if (IdProduct != 0)
                {
                    Console.WriteLine(IdProduct);
                    service.UpdateProduct(new Product { ProductName = ProductName, ProductDetail = ProductDetail, ProductPrice = ProductPrice, ProductInStock = ProductInStock, ProductId = IdProduct }, IdProduct);

                    ProductName = "";
                    ProductDetail = "";
                    ProductPrice = 0;
                    ProductInStock = 0;
                    IdProduct = 0;
                }
                else
                {
                    int newProductId = service.Get().Count + 1;
                    service.Create(new Product { ProductName = ProductName, ProductDetail = ProductDetail, ProductPrice = ProductPrice, ProductInStock = ProductInStock, ProductId = IdProduct });
                    ProductName = "";
                    ProductDetail = "";
                    ProductPrice = 0;
                    ProductInStock = 0;
                    Console.WriteLine("Error al insertar");
                }
                Products = service.Get();
            });

            SelectOneCommand = new Command<int>(execute: (int parameter) =>
            {
                ProductService service = new ProductService();
                int ide = parameter;
                Product = service.GetById(ide);
                ProductName = Product.ProductName;
                ProductDetail = Product.ProductDetail;
                ProductPrice = Product.ProductPrice;
                ProductInStock = Product.ProductInStock;
                IdProduct = Product.ProductId;
                Console.WriteLine(IdProduct);
            });

            DeleteCommand = new Command<int>(execute: (int parameter) =>
            {
                ProductService service = new ProductService();
                int ide = parameter;
                service.DeleteProduct(ide);
                Products = service.Get();
            });
        }


    }
}