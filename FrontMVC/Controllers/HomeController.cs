using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontMVC.Models;
using FrontMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiProxyExtension _proxy;

        public HomeController(ApiProxyExtension proxy) 
        {
            _proxy = proxy;
        }

        //TJEK DEN
        public IActionResult Index()
        {
            var items = _proxy.GetAllItems().Result;
            return View(items);
        }

        [HttpGet]
        public IActionResult CreateItem()
        {
            return View();
        }

        public async Task<IActionResult> CreateItem([FromBody] ItemForCreationDTO itemToCreate)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (itemToCreate == null) return BadRequest();

            var itemSuccess = await _proxy.LoadItemToApi(itemToCreate);

            if (itemSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(itemToCreate);
            }
        }
    }
}