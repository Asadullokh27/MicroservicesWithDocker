using Clients.UI.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clients.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(AppDbContext appDbContext) : ControllerBase
    {

        private readonly AppDbContext _appDbContext = appDbContext;

        [HttpGet]
        public IEnumerable<Models.Client> Get()
        {
            return [.. _appDbContext.Clients];
        }

        [HttpGet("{id}")]
        public async Task<List<Models.Client>> Get(int id)
        {
            return [.. _appDbContext.Clients];
        }

        [HttpPost]
        public async Task<Models.Client> Post([FromBody] Models.Client product)
        {
            var result = await _appDbContext.Clients.AddAsync(product);

            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        [HttpPut("{id}")]
        public async Task<Models.Client> Put(int id, [FromBody] Models.Client product)
        {
            var pr = await _appDbContext.Clients.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            pr.Name = product.Name;
            pr.Surname = product.Surname;
            var result = _appDbContext.Clients.Update(pr).Entity;
            await _appDbContext.SaveChangesAsync();

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<Models.Client> Delete(int id)
        {
            var pr = await _appDbContext.Clients.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            var result = _appDbContext.Clients.Remove(pr).Entity;

            await _appDbContext.SaveChangesAsync();

            return result;
        }

    }
}
