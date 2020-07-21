

using System;

namespace WebChat.Models
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public string Token { get; set; }

        /// <summary>
        /// Dữ liệu trả về Client để xác thực
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.firstName;
            LastName = user.lastName;
            Username = user.username;
            Avatar = user.avatar;
            Token = token;
        }
    }
}