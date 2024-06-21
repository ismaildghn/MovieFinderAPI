using DVDRentalAPI.Application.DTOs;
using DVDRentalAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
