﻿using BusinessLogic.Interfaces;
using System.Web.Http;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.Controllers
{
    public class DataController : ApiController
    {
        IRepository<Data> _dataContext;

        public DataController()
        {
        }

        [Authorize]
        [HttpGet]
        [Route("api/data")]
        public IHttpActionResult Get()
        {
            return Ok(_dataContext.GetAll());
        }

       // [Authorize]
        public IHttpActionResult Get(int id)
        {
            return Ok(_dataContext.FindBy(d => d.Id == id));
        }
    }
}