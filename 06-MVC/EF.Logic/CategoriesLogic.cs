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
        private DbSet<Categories> tableCategories => context.Categories;

        public IEnumerable<CategoriesDto> GetAll()
        //public List<CategoriesDto> GetAll()
        {
            IEnumerable<Categories> categ = context.Categories.AsEnumerable();
            IEnumerable<CategoriesDto> cDTO = categ.Select(c => new CategoriesDto
            //var CategoriesDto = context.Categories.Select(c => new CategoriesDto
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();
            return cDTO;
            //return CategoriesDto;
        }
        public async Task<List<CategoriesDto>> GetAllAsync()
        {
            return await tableCategories
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


        public Categories IdExist()
        {
            var numId = context.Categories
                .OrderByDescending(r => r.CategoryID)
                .FirstOrDefault();

            if (numId != null)
            {
                return numId;
            }
            else
            {
                throw new Exception("No se encontró ID para editar");
            }
        }

        public void UpdateLast(string name, string description)
        {
            var numId = IdExist();
            var updateCategory = context.Categories.Find(numId.CategoryID);
            updateCategory.CategoryName = name;
            updateCategory.Description = description;
            context.SaveChanges();
        }

        public void DeleteLast()
        {
            var numId = IdExist();
            context.Categories.Remove(numId);
            context.SaveChanges();
        }
    }
}
