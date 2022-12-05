using Database2022.Models;
using Database2022.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Database2022
{
    public partial class MainPage : ContentPage
    {        
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ProductService service = new ProductService();
            List<Product> products = new List<Product>();

            for (int i = 0; i < 5; i++)            
                products.Add(new Product { ProductName = txtProductName.Text, ProductDetail = txtProductDetail.Text, ProductPrice = Convert.ToDouble(txtProductPrice.Text), ProductInStock = Convert.ToInt32(txtProductInStock.Text) });

            //service.Create(new Person { LastName = txtLastName.Text, FirstName = txtName.Text });

            service.CreateRange(products);
            
            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            ProductService service = new ProductService();
            lvProduct.ItemsSource= service.Get();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            ProductService service = new ProductService();            
            lvProduct.ItemsSource = service.GetByText(txtFilter.Text.Trim());
        }
    }
}