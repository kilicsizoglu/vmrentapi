using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using vmrentapi.Data;
using vmrentapi.Models;

namespace vmrentapi.Controllers
{
    public class DropletController : Controller
    {
        DropletManager dropletManager;
        private VMRentDbContext Context;

        public DropletController(VMRentDbContext context)
        {
            Context = context;
        }

        public async Task<IActionResult> GetAllDropletAsync([FromBody] Droplet droplet)
        {
            ApiKey? apiKey = Context.apiKeys.ToList().Where(x => x.Key == droplet.Key).FirstOrDefault();
            if (apiKey != null)
            {
                dropletManager = new DropletManager();
                var droplets = await dropletManager.GetAllDropletAsync();
                return Ok(droplets);
            }

            return Ok("reject");
        }

        public async Task<IActionResult> GetDropletAsync([FromBody] Droplet droplet)
        {
            ApiKey? apiKey = Context.apiKeys.ToList().Where(x => x.Key == droplet.Key).FirstOrDefault();
            if (apiKey != null)
            {
                dropletManager = new DropletManager();
                var droplet1 = await dropletManager.GetDropletAsync(droplet.Id) ;
                return Ok(droplet1);
            } 
            return Ok("reject");
        }

        public IActionResult CreateDroplet([FromBody] Droplet droplet)
        {
            ApiKey? apiKey = Context.apiKeys.ToList().Where(x => x.Key == droplet.Key).FirstOrDefault();
            if (apiKey != null)
            {
                dropletManager = new DropletManager();
                dropletManager.CreateDroplet(droplet.name, droplet.size, droplet.image);
                return Ok("ok");
            } 
            return Ok("reject");
        }

        public IActionResult DeleteDroplet([FromBody] Droplet droplet)
        {
            ApiKey? apiKey = Context.apiKeys.ToList().Where(x => x.Key == droplet.Key).FirstOrDefault();
            if (apiKey != null)
            {
                dropletManager = new DropletManager();
                dropletManager.DeleteDroplet(droplet.Id);
                return Ok("ok");
            } 
            return Ok("reject");
        }
    }
}
