using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly MyDbContext _baglanti;

        public OrderController(MyDbContext context)
        {
            _baglanti = context;
        }


        public IActionResult Order()
        {
            //Ürünler
            List<Product> product = _baglanti.Products.Select(x => new Product { ProductID = x.ProductID, ProductName = x.ProductName }).ToList();
            ViewBag.products = product;

            //Modeller   
            List<Register> register = _baglanti.Registers.Select(x => new Register { RegisterID = x.RegisterID, NameSurname = x.NameSurname }).ToList();
            ViewBag.registers = register;

            var orderList = _baglanti.Orders.ToList();
            return View(orderList);
        }
     //   public IActionResult OrderList()
     //   {


     //       var orderList = _baglanti.Orders
     //.Join(_baglanti.Products,
     //    order => order.ProductID,
     //    product => product.ProductID,
     //    (order, product) => new { order, product })
     //.GroupJoin(_baglanti.Registers,
     //    or => or.order.RegisterID,
     //    register => register.RegisterID,
     //    (or, registers) => new
     //    {
     //        OrderID = or.order.OrderID,
     //        ProductName = or.product.ProductName,
     //        NameSurname = registers.FirstOrDefault().NameSurname // İlk eşleşen kaydın NameSurname değerini alır, yoksa null olur.
     //    })
     //.ToList();

     //       return View(orderList);

     //   }


    }
}
