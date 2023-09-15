using EF.Entities;
using EF.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Logic
{
    public class CategoriesLogic : AbstractClassLogic
    {
        private DbSet<Categories> TableCategories => context.Categories;

        public IEnumerable<CategoriesDto> GetAll()
        {
            IEnumerable<Categories> categ = context.Categories.AsEnumerable();

            IEnumerable<CategoriesDto> cDTO = categ.Select(c => new CategoriesDto
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

        public void Add(CategoriesDto newCat)
        {
            context.Categories.Add(new Categories
            {
                //CategoryID = newCat.CategoryID,
                CategoryName = newCat.CategoryName,
                Description = newCat.Description
            });

            context.SaveChanges();
        }
    }
}
