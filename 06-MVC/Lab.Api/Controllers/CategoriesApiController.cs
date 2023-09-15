using EF.Logic;
using EF.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab.Api.Controllers
{
    public class CategoriesApiController : ApiController
    {
        private readonly CategoriesLogic logic = new CategoriesLogic();
        public CategoriesApiController()
        {
            logic = new CategoriesLogic();
        }

        //public IHttpActionResult GetAllEntities()
        //{
        //    try
        //    {
        //        List<CategoriesDto> catt = logic.GetAll().ToList();
        //        return Ok(catt);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        
        public IHttpActionResult Get()
        {
            try
            {
                List<CategoriesDto> catt = logic.GetAll().ToList();
                return Ok(catt);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //public IHttpActionResult GetById(int id)
        //{

        //}

        [HttpPost]
        public IHttpActionResult CreateCategory([FromBody] CategoriesDto cat)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                logic.Add(cat);
                return CreatedAtRoute("DefaultApi", new { id = cat.CategoryID }, cat);
            }
            catch (Exception ex)
            {
                return BadRequest("Excepción: " + ex);
            }
        }
        //public IHttpActionResult Put(int id, [FromBody] CategoryDto category)
        //{

        //}
        //public IHttpActionResult Delete(int id)
        //{
        //    logic.Delete(employeeId);
        //    return RedirectToAction("Index");
        //}
        // POST: api/categories
        //[HttpPost]
        //public IHttpActionResult CreateCategory(CategoriesDTO category)
        //{
        //    // Implementa la lógica para crear una nueva categoría
        //}

        //// PUT: api/categories/{id}
        //[HttpPut]
        //public IHttpActionResult UpdateCategory(int id, CategoriesDTO category)
        //{
        //    // Implementa la lógica para actualizar una categoría existente
        //}

        //// DELETE: api/categories/{id}
        //[HttpDelete]
        //public IHttpActionResult DeleteCategory(int id)
        //{
        //    // Implementa la lógica para eliminar una categoría por su ID
        //}
    }
}
