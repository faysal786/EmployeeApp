using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        private readonly DataContext _datacontext;
        public ValuesController(DataContext dataContext){
            _datacontext = dataContext;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _datacontext.Values.ToListAsync();
            return Ok(values);
            //return new string[] { "value1", "value2" };
        }
        
        [AllowAnonymous]
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _datacontext.Values.FirstOrDefaultAsync( x=> x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
