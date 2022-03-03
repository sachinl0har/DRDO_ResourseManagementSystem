using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DRDO_ResourseManagementSystem.Data;
using DRDO_ResourseManagementSystem.Models;
using DRDO_ResourseManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace DRDO_ResourseManagementSystem.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room.ToListAsync());
        }

        // GET: Dashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.RoomID == id);
            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.ID == id);
            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel.Book = book;
            bookViewModel.Room = room;
            if (room == null)
            {
                return NotFound();
            }

            return View(bookViewModel);
        }

        public async Task<IActionResult> DisplayBookings()
        {
            // var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            var book = await _context.Book.ToListAsync();
            return View(book);
        }

        public async Task<IActionResult> Book(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.RoomID = id;
            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.ID == id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(int? id, [Bind("RoomID,UserName,UserEmail,IsBook,BookFor,EndTime,IsFullDay,ColorStatus,BookingDateTime")] Book book)
        {
            book.RoomID = (int)id;
            book.IsFullDay = false;
            book.ColorStatus = "Red";
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}
