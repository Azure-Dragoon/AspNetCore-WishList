using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Item> model = new List<Item>();

            foreach (Item item in _context.Items)
            {
                model.Add(item);
            }
            return View("Item", model);
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.Items.Remove(_context.Items.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
