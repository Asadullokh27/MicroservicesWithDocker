using Employees.UI.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(AppDbContext appDbContext) : ControllerBase
    {

        private readonly AppDbContext _appDbContext = appDbContext;

        [HttpGet]
        public IEnumerable<Models.Employee> Get()
        {
            return [.. _appDbContext.Employees];
        }

        [HttpGet("{id}")]
        public async Task<List<Models.Employee>> Get(int id)
        {
            return [.. _appDbContext.Employees];
        }

        [HttpPost]
        public async Task<Models.Employee> Post([FromBody] Models.Employee product)
        {
            var result = await _appDbContext.Employees.AddAsync(product);

            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        [HttpPut("{id}")]
        public async Task<Models.Employee> Put(int id, [FromBody] Models.Employee product)
        {
            var pr = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            pr.Name = product.Name;
            pr.Surname = product.Surname;
            pr.Age = product.Age;
            var result = _appDbContext.Employees.Update(pr).Entity;
            await _appDbContext.SaveChangesAsync();

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<Models.Employee> Delete(int id)
        {
            var pr = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            var result = _appDbContext.Employees.Remove(pr).Entity;

            await _appDbContext.SaveChangesAsync();

            return result;
        }

    }
}
