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

        public CategoriesDto GetCategory(int id)
        {
            var categ = TableCategories.FirstOrDefault(c => c.CategoryID == id);

            if (categ != null)
            {
                var categoryDto = new CategoriesDto
                {
                    CategoryID = categ.CategoryID,
                    CategoryName = categ.CategoryName,
                    Description = categ.Description
                };

                return categoryDto;
            }
            else return null;
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

        public void Update(CategoriesDto cat)
        {
            var existCategory = TableCategories.FirstOrDefault(c => c.CategoryID == cat.CategoryID);

            if (existCategory != null)
            {
                existCategory.CategoryName = cat.CategoryName;
                existCategory.Description = cat.Description;

                context.SaveChanges();
            }
            else throw new Exception("Esa categoría no fue encontrada");
        }

        public void Delete(CategoriesDto cat)
        {
            var existCategory = TableCategories.FirstOrDefault(c => c.CategoryID == cat.CategoryID);

            if (existCategory != null)
            {
                TableCategories.Remove(existCategory);
                context.SaveChanges();
            }
            else throw new Exception("No existe esa categoría");
        }
    }
}
