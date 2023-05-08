using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VShop.Web.Models;
using VShop.Web.Roles;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Controllers
{
    [Authorize(Roles = Role.Admin)]
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
            var token = await GetToken();
            var result = await _productService.GetAll(token);

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var token = await GetToken();
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(token), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel model)
        {
            var token = await GetToken();
            if (ModelState.IsValid)
            {
                var result = await _productService.Create(model, token);
                if (result is not null)
                    return RedirectToAction(nameof(Index));
            }
            else
                ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(token), "Id", "Name");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var token = await GetToken();
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(token), "Id", "Name");

            var result = await _productService.GetById(id, token);
            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductViewModel model)
        {
            var token = await GetToken();
            if (ModelState.IsValid)
            {
                var result = await _productService.Update(model, token);
                if (result is not null)
                    return RedirectToAction(nameof(Index));
            }
            else
                ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(token), "Id", "Name");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var token = await GetToken();
            var result = await _productService.GetById(id, token);
            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            var token = await GetToken();
            var result = await _productService.Delete(id, token);
            if (!result)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }

        private async Task<string?> GetToken()
        {
            return await HttpContext.GetTokenAsync("access_token");
        }
    }
}