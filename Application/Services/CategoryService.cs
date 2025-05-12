using Application.Contract;
using Application.Dtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return _categoryRepository.GetAll()
                .ProjectToType<CategoryDTO>()
                .ToList();
        }

        public CategoryDTO GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
                throw new KeyNotFoundException("Category not found.");
            return category.Adapt<CategoryDTO>();
        }
    }
}
