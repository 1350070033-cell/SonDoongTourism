using Microsoft.EntityFrameworkCore;
using SonDoongTourism.Data;
using System;
using System.Linq;

namespace SonDoongTourism.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Kiểm tra xem Database đã có Tour nào chưa. Nếu có rồi thì bỏ qua.
                if (context.Tours.Any())
                {
                    return; 
                }

                // Nếu chưa có, tiến hành thêm 3 Tour mẫu tuyệt đẹp
                context.Tours.AddRange(
                    new Tour
                    {
                        Name = "Thám Hiểm Sơn Đoòng - Hang Động Lớn Nhất Thế Giới",
                        Description = "Hành trình thám hiểm đỉnh cao 4 ngày 3 đêm, băng rừng nguyên sinh, lội suối ngầm và cắm trại ngay bên trong lòng hang động kỳ vĩ nhất hành tinh.",
                        Price = 72000000,
                        DurationDays = 4,
                        ImageUrl = "/img/sondoong.jpg"
                    },
                    new Tour
                    {
                        Name = "Khám Phá Hang Én - Kiệt Tác Thiên Nhiên",
                        Description = "Trải nghiệm 2 ngày 1 đêm băng qua bản Đoòng của người Macoong, cắm trại tại bãi cát tuyệt đẹp dưới vòm hang khổng lồ có hàng vạn chim én sinh sống.",
                        Price = 7600000,
                        DurationDays = 2,
                        ImageUrl = "/img/image_pkr1639446571.jpg"
                    },
                    new Tour
                    {
                        Name = "Chinh Phục và Khai Phá Hệ Thống Hang Tú Làn",
                        Description = "Hành trình 3 ngày 2 đêm bơi xuyên qua các dòng sông ngầm, ngắm nhìn những khối thạch nhũ tráng lệ và hòa mình vào thiên nhiên hoang sơ của Quảng Bình.",
                        Price = 15000000,
                        DurationDays = 3,
                        ImageUrl = "/img/tulang.jpg"
                    }
                );
                
                // Lưu vào Database
                context.SaveChanges();
            }
        }
    }
}