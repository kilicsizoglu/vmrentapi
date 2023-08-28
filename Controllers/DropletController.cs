using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using vmrentapi.Data;

namespace vmrentapi.Controllers
{
    public class DropletController : Controller
    {
        DropletManager dropletManager;
        public DropletController() 
        {
            dropletManager = new DropletManager();
        }

        public async Task<IActionResult> GetAllDropletAsync()
        {
            var droplets = await dropletManager.GetAllDropletAsync();
            return Ok(droplets);
        }

        public async Task<IActionResult> GetDropletAsync([FromBody] long id)
        {
            var droplet = await dropletManager.GetDropletAsync(id) ;
            return Ok(droplet);
        }

        public IActionResult CreateDroplet([FromBody] string name, [FromBody] string size, [FromBody] string image)
        {
            dropletManager.CreateDroplet(name, size, image);
            return Ok("ok");
        }

        public IActionResult DeleteDroplet([FromBody] long id)
        {
            dropletManager.DeleteDroplet(id);
            return Ok("ok");
        }
    }
}
