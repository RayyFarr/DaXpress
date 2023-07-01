using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DaXpress.Data;
using DaXpress.Models;

namespace DaXpress.Controllers
{
    public class MyCartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyCart
        public async Task<IActionResult> Index()
        {
            var cart = _context.Cart.Where(x => x.UserName == User.Identity.Name);
            return cart == null ? View(cart) : Problem("Entity set 'ApplicationDbContext.Product'  is null.");
        }



        // GET: MyCart/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cart = _context.Cart.First(x => x.Id == id);
            if (cart != null)
            {
                cart.ProductNames = null;
                cart.counts = null;
            }
            await _context.SaveChangesAsync();
            return View(_context.Cart);
        }

        // POST: MyCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cart == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cart'  is null.");
            }
            var cart = await _context.Cart.FindAsync(id);
            if (cart != null)
            {
                _context.Cart.Remove(cart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return (_context.Cart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
