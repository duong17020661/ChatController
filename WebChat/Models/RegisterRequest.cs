using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebChat.Models
{
    /// <summary>
    /// Model dữ liệu đăng ký gửi từ Client lên
    /// </summary>
    public class RegisterRequest
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string repassword { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
    }
}