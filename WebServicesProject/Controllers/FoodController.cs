using FoodProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace WebServicesProject.Controllers
{
    public class FoodController : ApiController
    {

        // GET api/Food
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<Food> foods = new List<Food>();
            FoodDAOMSSQL foodDao = new FoodDAOMSSQL();
            foods = foodDao.GetAllFoods();
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK,foods);
            return msg;

        }

        // GET api/Food/5
        [HttpGet]
        public HttpResponseMessage Get([FromUri] int id) 
        {
            FoodDAOMSSQL foodDao = new FoodDAOMSSQL();
           Food food = foodDao.GetfoodById(id);
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK, food);
            return msg;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Food f)
        {
            FoodDAOMSSQL foodDao = new FoodDAOMSSQL();
            if (f == null)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            else
            {
                foodDao.AddFood(f);
                return Request.CreateResponse(HttpStatusCode.Created, f);
            }

        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage Put(int id, Food f)
        {
            FoodDAOMSSQL foodDao = new FoodDAOMSSQL();
            if (f == null)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            else
            {
                foodDao.UpdateFood(id, f);
                return Request.CreateResponse(HttpStatusCode.OK, f);
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            FoodDAOMSSQL foodDao = new FoodDAOMSSQL();
            if (id == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            else
            {
                foodDao.DeleteFood(id);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
        }

        [Route("api/food/ByName/{name}")]
        [HttpGet]
        public HttpResponseMessage GetByName(string name)
        {
            FoodDAOMSSQL foodDao = new FoodDAOMSSQL();
            List<Food> foods = foodDao.GetByFoodName(name);
            if (foods.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }

        [Route("api/food/BiggerThan/{calories}")]
        [HttpGet]
        public HttpResponseMessage BiggerThan(int calories)
        {
            FoodDAOMSSQL foodDao = new FoodDAOMSSQL();
            List<Food> foods = foodDao.GetFoodBiggerthanCal(calories);
            if (foods.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }

        //Search api/food/search
        [Route("api/food/search")]
        [HttpGet]
        public HttpResponseMessage Search(string name = "", int maxcal = 0, int mincal = 0, string ingridients = "", int grade = 0)
        {
            FoodDAOMSSQL foodDao = new FoodDAOMSSQL();
            List<Food> foods = foodDao.GetByFilter(name, maxcal, mincal, ingridients, grade);
            if (foods.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }
    }
}
