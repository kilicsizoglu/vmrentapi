using Microsoft.AspNetCore.Mvc;
using vmrentapi.Data;
using vmrentapi.Models;

namespace vmrentapi.Controllers
{
    public class llsController : Controller
    {
        private VMRentDbContext Context;
        public llsController(VMRentDbContext dbContext)
        {
            Context = dbContext;
        }

        public IActionResult Login([FromBody] LoginResponse response)
        {
            User? user = Context.users.ToList().Where(x => x.name == response.user.name && x.password == response.user.password).FirstOrDefault();
            if (user == null)
            {
                return Ok("reject");
            }
            else
            {
                if (user.Id == null) {}
                ApiKey apiKey = new ApiKey
                {
                    Id =  Guid.NewGuid(),
                    UserId = user.Id,
                    Key = Guid.NewGuid()
                };
                Context.apiKeys.Add(apiKey);
            }
        }
        
        public IActionResult Logout([FromBody] Guid key)
        {
            ApiKey? apiKey = Context.apiKeys.ToList().Where(x => x.Key == key).FirstOrDefault();
            if (apiKey != null)
            {
                Context.apiKeys.Remove(apiKey);
            }

            return Ok("ok");
        }
        
        public IActionResult SingUp([FromBody] LoginResponse response)
        {
            Context.users.Add(response.user);
            return Ok("ok");
        }
        
    }
}