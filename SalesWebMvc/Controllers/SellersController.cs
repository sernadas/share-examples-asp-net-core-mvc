using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            List<Seller> sellers = _sellerService.FindAll();

            return View(sellers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // this is the way to identify this method as a post method 
        [ValidateAntiForgeryToken] // to avoid attacks of session capture
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        } 
    }


}