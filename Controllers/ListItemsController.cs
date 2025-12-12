using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeAList.Data;
using MakeAList.Models;

namespace MakeAList.Controllers
{
    [Authorize]
    public class ListItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int listId)
        {
            return View(new ListItem { UserListId = listId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListItem item)
        {
            if (ModelState.IsValid)
            {
                _context.ListItems.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "UserLists", new { id = item.UserListId });
            }

            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.ListItems.FindAsync(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ListItem item)
        {
            if (ModelState.IsValid)
            {
                _context.ListItems.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "UserLists", new { id = item.UserListId });
            }
            return View(item);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ListItems.FindAsync(id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.ListItems.FindAsync(id);
            int listId = item.UserListId;
            _context.ListItems.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "UserLists", new { id = listId });
        }
    }
}
