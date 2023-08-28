using DigitalOcean.API;
using DigitalOcean.API.Models.Requests;

namespace vmrentapi.Data
{
    

    public class DropletManager
    {

        public DigitalOceanClient client;

        public DropletManager()
        {
            client = new DigitalOceanClient("");
        }

        public void CreateDroplet(String Name, String Size, String Image)
        {
            var request = new DigitalOcean.API.Models.Requests.Droplet
            {
                Name = Name,
                Size = Size,
                Image = Image
            };

            client.Droplets.Create(request);
        }

        public void DeleteDroplet(long id)
        {
            client.Droplets.Delete(id);
        }

        public async Task<DigitalOcean.API.Models.Responses.Droplet> GetDropletAsync(long id)
        {
            return await client.Droplets.Get(id);
        }

        public async Task<IReadOnlyList<DigitalOcean.API.Models.Responses.Droplet>> GetAllDropletAsync()
        {
            return await client.Droplets.GetAll();
        }

    }
}
