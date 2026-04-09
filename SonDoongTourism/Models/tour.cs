using System.ComponentModel.DataAnnotations;

namespace SonDoongTourism.Models
{
    public class Tour
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập tên tour")]
        [Display(Name = "Tên Tour")]
        public string? Name { get; set; }
        
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
        
        [Display(Name = "Giá (VNĐ)")]
        public decimal Price { get; set; }
        
        [Display(Name = "Thời gian (Ngày)")]
        public int DurationDays { get; set; }
        
        [Display(Name = "Đường dẫn ảnh")]
        public string? ImageUrl { get; set; }
    }
}