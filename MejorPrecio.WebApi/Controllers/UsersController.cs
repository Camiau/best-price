using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MejorPrecio.Common;
using MejorPrecio.Api;

namespace MejorPrecio.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        [HttpPost("login")]
        public IActionResult Post([FromBody]LoginModel mod1)
        {
            LoginModel logModel = new LoginModel();
            logModel.Email = mod1.Email;
            //chekeo sí el usuario es correcto
            UsersApi usersApi = new UsersApi();
            var res = usersApi.Login(mod1);
            return this.Json(res);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}