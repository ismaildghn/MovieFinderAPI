using DVDRentalAPI.Application.Abstractions.Services;
using DVDRentalAPI.Application.Abstractions.Token;
using DVDRentalAPI.Application.DTOs;
using DVDRentalAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if(user == null)
            {
                user = await _userManager.FindByNameAsync(usernameOrEmail);
            }
            if(user == null)
            {
                throw new Exception("Kullanıcı Adı Veya Şifre Hatalı");
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if(result.Succeeded)
            {
                Token token =  _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 20);
                return token;
            }
            else
            {
                throw new Exception("Kimlik Doğrulama Hatası");
            }
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if(user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15, user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 10);
                return token;
            }
            else
            {
                throw new Exception("Kullanıcı Adı Veya Şifre Hatalı");
            }
        }
    }
}
