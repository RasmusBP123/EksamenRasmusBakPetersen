using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EksamenRasmusBakPetersen.Models;
using EksamenRasmusBakPetersen.Services;
using Microsoft.AspNetCore.Mvc;

namespace EksamenRasmusBakPetersen.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var itemsFromRepo = _repo.GetAll();
            var items = Mapper.Map<IEnumerable<ItemDTO>>(itemsFromRepo);

            return View(items);
        }
    }
}