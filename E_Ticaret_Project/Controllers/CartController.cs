﻿using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Ticaret_Project.Controllers
{
    public class CartController : Controller
    {
        private readonly MyDbContext _baglanti;
        public CartController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Index()
        {
            var cartsWithProducts = _baglanti.Carts.Include(cart => cart.ProductID).ToList();
            int userId = 8;

            return View(cartsWithProducts);
        }

        [HttpPost]
        public IActionResult AddToCart(int id, int quantity = 1)
        {
            try
            {
                
                Cart cart = new Cart { RegisterID = 8, ProductID = id, Piece = quantity }; 
               _baglanti.Carts.Add(cart);

                _baglanti.SaveChanges();

                return Ok(new { message = "Ürün sepete eklendi." });
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun şekilde hata mesajı döndürebilirsiniz
                return BadRequest(new { message = "Hata oluştu: " + ex.Message });
            }
        }

    }
}