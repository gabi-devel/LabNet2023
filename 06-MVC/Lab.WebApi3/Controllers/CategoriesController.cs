using EF.Logic;
using EF.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly CategoriesLogic logic = new CategoriesLogic();
        public CategoriesController()
        {
            logic = new CategoriesLogic();
        }
        // GET: api/Categories
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

        // GET: api/Categories/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
        }
    }
}
