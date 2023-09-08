using EF.Entities;
using EF.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF.Logic
{
    public class CategoriesLogic : AbstractClassLogic, IABMLogic<CategoriesDto>
    {
        public List<CategoriesDto> GetAll()
        {
            var CategoriesDto = context.Categories.Select(c => new CategoriesDto
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();
            return CategoriesDto;
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


        public void Update(Categories elementUpdate)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(CategoriesDto elementAdd)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoriesDto elementUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
