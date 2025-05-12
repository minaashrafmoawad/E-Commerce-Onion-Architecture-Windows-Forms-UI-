using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryById(int id);
    }
}
