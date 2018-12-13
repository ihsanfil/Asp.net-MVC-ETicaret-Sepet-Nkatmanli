using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Entities
{
    public class Cart
    {
        List<CartLine> _lines = new List<CartLine>();

        public void AddToCart(Product product, int quantity)
        {
            CartLine cartLine = _lines.FirstOrDefault(c => c.Product.ProductID == product.ProductID); //sepette böyle bir eleman varmı
            if (cartLine==null)
            {
                _lines.Add(new CartLine {Product=product,Quantity=quantity}); //sepette yoksa ekle              
            }
            else
            {
                cartLine.Quantity += quantity; //varsa yeni gelen adeti üzerine ekle
            }
        }

        public void RemoveFromCart(Product product)
        {
            _lines.RemoveAll(p=>p.Product.ProductID==product.ProductID); //sepetten çıkarma işlemi
        }

        public decimal Total
        {
            get { return _lines.Sum(c => c.Product.UnitPrice * c.Quantity); } //toplam tutarı bulma
        }

        public void Clear()
        {
            _lines.Clear(); //Sepetin tamamını temizle
        }

        public List<CartLine> Lines
        {
            get { return _lines; } //ürünleri listele
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
