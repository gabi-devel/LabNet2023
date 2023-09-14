using EF.Entities;
using EF.Logic.DTOs;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Logic
{
    public class CategoriesLogic : AbstractClassLogic
    {
        private DbSet<Categories> TableCategories => context.Categories;

        public List<CategoriesDto> GetAll()
        {
            List<Categories> categ = context.Categories.ToList();

            List<CategoriesDto> cDTO = categ.Select(c => new CategoriesDto
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();

            return cDTO;
        }
        public async Task<List<CategoriesDto>> GetAllAsync()
        {
            return await TableCategories
                .Select(c => new CategoriesDto
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .ToListAsync();
        }

        public void Add(Categories newCat)
        {
            context.Categories.Add(newCat);

            context.SaveChanges();
        }
    }
}
