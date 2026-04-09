using System.ComponentModel.DataAnnotations;

namespace SonDoongTourism.Models
{
    public class User
    {
        [Key] // Đánh dấu đây là cột ID tự động tăng
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Bạn có thể thêm các trường khác nếu muốn
        public string? Email { get; set; }
        public string? FullName { get; set; }
    }
}