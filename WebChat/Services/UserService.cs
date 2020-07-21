using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using WebChat.Data;
using WebChat.Helpers;
using WebChat.Models;
using WebChat.Repository;

namespace WebChat.Services
{

    public class UserService : IUserService
    { 
        private readonly AppSettings _appSettings;
        private readonly DataContext _context;

        public UserService(IOptions<AppSettings> appSettings, DataContext dataContext)
        {
            _context = dataContext;
            _appSettings = appSettings.Value;
        }
        // Băm String thành dạng MD5
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// Hàm xác thực đăng nhập
        /// </summary>
        /// <param name="model">Dữ liệu đăng nhập từ Client</param>
        /// <returns></returns>
        public AuthenticateResponse Login(LoginRequest model)
        {
            var user = _context.Users.FirstOrDefault(x => x.username == model.Username && x.password == CreateMD5(model.Password));

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        /// <summary>
        /// Hàm xác thực đăng ký
        /// </summary>
        /// <param name="model">Dữ liệu đăng ký từ Client</param>
        /// <returns></returns>
        public AuthenticateResponse Register(RegisterRequest model)
        {
            // Xử lý một số lỗi khi đăng ký
            if (string.IsNullOrWhiteSpace(model.password))
                throw new AppException("Bạn phải nhập mật khẩu !");
            if (string.IsNullOrWhiteSpace(model.username))
                throw new AppException("Bạn phải nhập tên đăng nhập !");
            if (string.IsNullOrWhiteSpace(model.email))
                throw new AppException("Bạn phải nhập email !");
            if (string.IsNullOrWhiteSpace(model.repassword))
                throw new AppException("Bạn phải nhập mật khẩu !");
            if (model.password != model.repassword)
                throw new AppException("Mật khẩu chưa trùng khớp !");
            if (_context.Users.Any(x => x.email == model.email))
                throw new AppException("Email " + model.email + " da ton tai");
            if (_context.Users.Any(x => x.username == model.username))
                throw new AppException("Email " + model.username + " da ton tai");
            // Tạo một đối tượng mới để thêm vào CSDK
            var user = new User
            {
                Id = new Guid(),
                username = model.username,
                password = CreateMD5(model.password),
                firstName = model.firstName,
                lastName = model.lastName,
                avatar = "",
                email = model.email,
                phone = model.phone,
                lastMessage = "",
                status = false,
                newMessage = 0,
                lastSeen = new DateTime(),
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        /// <summary>
        /// Tạo token xác thực đăng nhập và dùng để kết nối với Stringee
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string generateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var name = user.firstName + " " + user.lastName;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.Id.ToString()),
                new Claim("name", name.ToString()),
                new Claim("avatar", user.avatar.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _appSettings.Issuer,
                audience: _appSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
