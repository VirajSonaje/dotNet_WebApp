using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet_WebApp.Models;

namespace dotNet_WebApp.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}