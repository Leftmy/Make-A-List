using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeAList.Data;
using MakeAList.Models;

namespace MakeAList.Controllers
{
    [Authorize]
    public class UserListsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserListsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var lists = await _context.UserLists
                .Where(l => l.UserId == userId)
                .ToListAsync();

            return View(lists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserList list)
        {
            if (ModelState.IsValid)
            {
                list.UserId = _userManager.GetUserId(User);

                _context.UserLists.Add(list);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(list);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var list = await _context.UserLists.FindAsync(id);

            if (list == null || list.UserId != _userManager.GetUserId(User))
                return NotFound();

            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserList list)
        {
            if (ModelState.IsValid)
            {
                _context.Update(list);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(list);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var list = await _context.UserLists.FindAsync(id);

            if (list == null || list.UserId != _userManager.GetUserId(User))
                return NotFound();

            return View(list);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var list = await _context.UserLists.FindAsync(id);
            _context.UserLists.Remove(list);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var list = await _context.UserLists
                .Include(l => l.Items)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (list == null || list.UserId != _userManager.GetUserId(User))
                return NotFound();

            return View(list);
        }
    }
}
