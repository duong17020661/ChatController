using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Models;

namespace WebChat.Repository
{
    public interface IUserService
    {
        AuthenticateResponse Login(LoginRequest model);

        AuthenticateResponse Register(RegisterRequest model);

        User Update(Guid id, User user);

    }
}
