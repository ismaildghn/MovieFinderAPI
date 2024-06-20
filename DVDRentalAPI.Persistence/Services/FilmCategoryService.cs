using DVDRentalAPI.Application.Abstractions.Services;
using DVDRentalAPI.Application.Repositories;
using DVDRentalAPI.Application.ViewModels;
using DVDRentalAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Persistence.Services
{
    public class FilmCategoryService : IFilmCategoryService
    {

        readonly IFilmReadRepository _filmReadRepository;
        readonly IFilmWriteRepository _filmWriteRepository;
        readonly IFilmCategoryReadRepository _filmCategoryReadRepository;
        readonly IFilmCategoryWriteRepository _filmCategoryWriteRepository;
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ICategoryWriteRepository _categoryWriteRepository;

        public FilmCategoryService(IFilmReadRepository filmReadRepository, IFilmWriteRepository filmWriteRepository, IFilmCategoryReadRepository filmCategoryReadRepository, IFilmCategoryWriteRepository filmCategoryWriteRepository, ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            _filmReadRepository = filmReadRepository;
            _filmWriteRepository = filmWriteRepository;
            _filmCategoryReadRepository = filmCategoryReadRepository;
            _filmCategoryWriteRepository = filmCategoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task AddFilmCategoryAsync(VM_Create_FilmCategory filmCategory)
        {
            Film _film = await _filmReadRepository.GetByIdAsync(filmCategory.FilmId);
            Category _category = await _categoryReadRepository.GetByIdAsync(filmCategory.CategoryId);

            if (_film != null && _category != null)
            {
                await _filmCategoryWriteRepository.AddAsync(new FilmCategory
                {
                    CategoryId = _category.Id,
                    FilmId = _film.Id,
                });
                await _filmCategoryWriteRepository.SaveAsync();
            }
            else
            {
                throw new Exception("Film or category not found");
            }


        }

        public async Task<List<Category>> GetCategoriesByFilmAsync(string filmId)
        {
            var categories = await _filmCategoryReadRepository.Table
                .Where(fc => fc.FilmId == Guid.Parse(filmId))
                .Select(fc => fc.Category)
                .ToListAsync();
            return categories;
        }

        public async Task<List<Film>> GetFilmsByCategoryAsync(string categoryId)
        {
            var films = await _filmCategoryReadRepository.Table
                .Where(fc => fc.CategoryId == Guid.Parse(categoryId))
                .Select(fc => fc.Film)
                .ToListAsync();
            return films;
        }
    }
}
