using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebChat.Models
{
    public class RegisterRequest
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public int phone { get; set; }
    }
}