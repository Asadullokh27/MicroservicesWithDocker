using Franchises.UI.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Franchises.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchiseController(AppDbContext appDbContext) : ControllerBase
    {

        private readonly AppDbContext _appDbContext = appDbContext;

        [HttpGet]
        public IEnumerable<Models.Franchise> Get()
        {
            return [.. _appDbContext.Franchises];
        }

        [HttpGet("{id}")]
        public async Task<List<Models.Franchise>> Get(int id)
        {
            return [.. _appDbContext.Franchises];
        }

        [HttpPost]
        public async Task<Models.Franchise> Post([FromBody] Models.Franchise product)
        {
            var result = await _appDbContext.Franchises.AddAsync(product);

            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        [HttpPut("{id}")]
        public async Task<Models.Franchise> Put(int id, [FromBody] Models.Franchise product)
        {
            var pr = await _appDbContext.Franchises.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            pr.Name = product.Name;
            pr.Location = product.Location;
            pr.Description = product.Description;
            var result = _appDbContext.Franchises.Update(pr).Entity;
            await _appDbContext.SaveChangesAsync();

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<Models.Franchise> Delete(int id)
        {
            var pr = await _appDbContext.Franchises.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            var result = _appDbContext.Franchises.Remove(pr).Entity;

            await _appDbContext.SaveChangesAsync();

            return result;
        }

    }
}
