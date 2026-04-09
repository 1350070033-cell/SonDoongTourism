using Microsoft.AspNetCore.Mvc;
using SonDoongTourism.Data; 
using SonDoongTourism.Models;

namespace SonDoongTourism.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Hàm để HIỆN THỊ trang Đăng ký
        public IActionResult Register()
        {
            return View();
        }

        // 1. XỬ LÝ ĐĂNG KÝ
[HttpPost]
public IActionResult Register(User user)
{
    // Mẹo giải vây: Gán chữ rỗng để Database không báo lỗi thiếu Email/FullName
    user.Email = user.Email ?? "";
    user.FullName = user.FullName ?? "";
    
    // Bỏ qua kiểm tra lỗi của 2 ô này vì trên giao diện không có
    ModelState.Remove("Email");
    ModelState.Remove("FullName");

    if (ModelState.IsValid)
    
    {

        // Kiểm tra xem tên tài khoản đã có ai tạo chưa
        var userExists = _context.Users.Any(u => u.Username == user.Username);
        if (userExists)
        {
            ViewBag.Error = "Tên tài khoản này đã tồn tại!";
            return View(user);
        }

        _context.Users.Add(user);
        _context.SaveChanges(); // Lần này chắc chắn 100% sẽ lưu được!
        return RedirectToAction("Login");
    }
    return View(user);
}

// 2. XỬ LÝ ĐĂNG NHẬP
[HttpPost]
public IActionResult Login(string Username, string Password)
{
    // Lục tìm trong CSDL xem có ai khớp cả Username VÀ Password không?
    var account = _context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);

    if (account != null)
    {
        // Nếu tìm thấy -> Đăng nhập chuẩn -> Cho vào trang chủ
        return RedirectToAction("Index", "Home");
    }
    else
    {
        // Nếu không thấy (sai pass hoặc sai tên) -> Trả về giao diện và báo lỗi
        ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác!";
        return View();
    }
}
// Hàm để HIỂN THỊ trang Đăng nhập
[HttpGet]
public IActionResult Login()
{
    return View();
}
    }
    
}