using DVDRentalAPI.Application.Abstractions.Services;
using DVDRentalAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        readonly IAuthService _authService;
        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
           Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);

            return new RefreshTokenLoginCommandResponse { Token = token };
        }
    }
}
