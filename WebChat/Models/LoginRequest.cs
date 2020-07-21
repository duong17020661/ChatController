using System.ComponentModel.DataAnnotations;

namespace WebChat.Models
{   
    /// <summary>
    /// Model dữ liệu đăng nhập Client gửi lên
    /// </summary>
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}