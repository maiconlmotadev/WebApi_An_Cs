using System;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    public class ProductApiController : Controller
    {
        private readonly IProduct IProduct;

        public ProductApiController(IProduct IProduct)
        {
            this.IProduct = IProduct;
        }

        [HttpGet("/api/ListProducts")]
        public async Task<JsonResult> ListProducts()
        {
            return Json(await this.IProduct.List());
        }

        [HttpPost("/api/AddProduct")]
        public async Task AddProduct([FromBody] Product product)
        {
            await Task.FromResult(this.IProduct.Add(product));
        }
    }

    
    
}

