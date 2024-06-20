using DVDRentalAPI.Application.ViewModels;
using DVDRentalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Abstractions.Services
{
    public interface IFilmCategoryService
    {
        public Task AddFilmCategoryAsync(VM_Create_FilmCategory filmCategory);
        public Task<List<Film>> GetFilmsByCategoryAsync(string  categoryId);
        public Task<List<Category>> GetCategoriesByFilmAsync(string filmId);
    }
}
