using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonDoongTourism.Data;
using SonDoongTourism.Models;
using System.Threading.Tasks;

namespace SonDoongTourism.Controllers
{
    public class TourController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TourController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách Tour
        public async Task<IActionResult> Index()
        {
            var tours = await _context.Tours.ToListAsync();
            return View(tours);
        }

        // Hiển thị chi tiết 1 Tour và Form đặt tour
        public async Task<IActionResult> Details(int id)
        {
            var tour = await _context.Tours.FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null) return NotFound();

            ViewBag.Tour = tour; // Truyền dữ liệu tour sang View
            return View(new Booking { TourId = tour.Id });
        }

        // Xử lý khi khách hàng bấm nút "Đặt Tour"
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(Booking booking)
        {
            booking.Id = 0;
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction("Success");
            }
            
            // Nếu form có lỗi, quay lại trang chi tiết
            var tour = await _context.Tours.FindAsync(booking.TourId);
            ViewBag.Tour = tour;
            return View("Details", booking);
        }

        // Trang thông báo đặt thành công
        public IActionResult Success()
        {
            return View();
        }
    }
}