using EF.Logic;
using EF.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IHttpActionResult GetAllEntities()
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
    }
}