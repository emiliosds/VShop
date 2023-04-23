﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(
            IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            var result = await _productService.GetAll();

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.Create(model);
                if (result is not null)
                    return RedirectToAction(nameof(Index));
            }
            else
                ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "Id", "Name");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "Id", "Name");

            var result = await _productService.GetById(id);
            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.Update(model);
                if (result is not null)
                    return RedirectToAction(nameof(Index));
            }
            else
                ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "Id", "Name");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _productService.GetById(id);
            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            var result = await _productService.Delete(id);
            if (!result)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }
    }
}