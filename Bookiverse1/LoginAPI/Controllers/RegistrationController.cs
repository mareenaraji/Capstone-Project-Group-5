using LoginAPI.Data;
using LoginAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly DbContextClass _context;

        public RegistrationController(DbContextClass context)
        {
            _context = context;
        }


        //get

        [HttpGet]

        public async Task<ActionResult> GetAdminUsers()
        {
            return Ok(await _context.Registration.ToListAsync());
        }

        //post:

        [HttpPost]
        public async Task<ActionResult> RegisterUser ([FromBody] Registration model)
        {           
            _context.Registration.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult<Registration>> put([FromBody] Registration model, int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            _context.Registration.Update(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var result = _context.Registration.Find(id);
            _context.Registration.Remove(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }



        ////post:

        //[HttpPost("user")]
        //public async Task<IActionResult> RegisterUser ([FromBody] Registration model)
        //{
        //    model.Role = "User";
        //    _context.Registration.Add(model);
        //    await _context.SaveChangesAsync();
        //    return Ok(model);
        //}

        ////post

        //[HttpPost("admin")]
        //public async Task<IActionResult> RegisterAdmin([FromBody] Registration model)
        //{
        //    model.Role="Admin";

        //    _context.Registration.Add(model);
        //    await _context.SaveChangesAsync();
        //    return Ok(model);
        //}

    }
}
