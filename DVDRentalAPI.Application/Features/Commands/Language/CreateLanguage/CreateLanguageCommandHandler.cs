using DVDRentalAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Language.CreateLanguage
{
    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommandRequest, CreateLanguageCommandResponse>
    {
        readonly ILanguageWriteRepository _languageWriteRepository;

        public CreateLanguageCommandHandler(ILanguageWriteRepository languageWriteRepository)
        {
            _languageWriteRepository = languageWriteRepository;
        }

        public async Task<CreateLanguageCommandResponse> Handle(CreateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            await _languageWriteRepository.AddAsync(new()
            {
                Name = request.Name,           
            });
            await _languageWriteRepository.SaveAsync();
            return new();
        }
    }
}
