using DVDRentalAPI.Application.Repositories;
using MediatR;
using C = DVDRentalAPI.Domain.Entities;
namespace DVDRentalAPI.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly ICategoryReadRepository _categoryReadRepository;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            C.Category category = await _categoryReadRepository.GetByIdAsync(request.Id);

            category.Name = request.Name;
            category.UpdatedDate = DateTime.UtcNow;
            await _categoryWriteRepository.SaveAsync();
            
            return new();
        }
    }
}
