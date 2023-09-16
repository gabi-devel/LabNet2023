using EF.Logic;
using EF.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // GET: api/CategoriesApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<CategoriesDto> catt = logic.GetAll().ToList();
                return Ok(catt);
            }
            catch (Exception ex)
            {
                return BadRequest("Excepción: " + ex);
            }
        }

        // GET: api/CategoriesApi/{id}
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var category = logic.GetCategory(id);
                if (category != null)
                {
                    return Ok(category);
                }
                else return BadRequest("No se encontró ese ID.");
            }
            catch (Exception ex)
            {
                return BadRequest("Excepción: " + ex);
            }
        }

        // POST: api/CategoriesApi
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

        // PUT: api/CategoriesApi/{id}
        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, [FromBody] CategoriesDto cat)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var existCategory = logic.GetCategory(id);
                if (existCategory == null)
                {
                    return NotFound();
                }
                existCategory.CategoryName = cat.CategoryName;
                existCategory.Description = cat.Description;

                logic.Update(existCategory);
                return Ok(existCategory);
            }
            catch (Exception ex)
            {
                return BadRequest("Excepción: " + ex);
            }
        }

        // DELETE: api/CategoriesApi/{id}
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            try
            {
                var existCategory = logic.GetCategory(id);

                if (existCategory != null)
                {
                    logic.Delete(existCategory);
                    return StatusCode(HttpStatusCode.Accepted);
                }
                else return BadRequest("No se ha encontrado esa categoría para eliminar.");
            }
            catch (Exception ex)
            {
                return BadRequest("Excepción: " + ex);
            }
        }
    }
}
