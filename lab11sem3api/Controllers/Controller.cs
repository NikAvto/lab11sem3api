using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;

namespace lab11sem3api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTerritories>>> GetEmployees()
        {
            return await _context.EmployeeTerritories.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTerritories>> GetEmployee(int id)
        {
            var employee = await _context.EmployeeTerritories.FindAsync(id);
            if (employee == null) 
            {
                return NotFound();
            }
            return employee;
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeTerritories>> PostEmployee(EmployeeTerritories employee)
        {
            _context.EmployeeTerritories.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeID }, employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeTerritories employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified; 
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else 
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.EmployeeTerritories.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.EmployeeTerritories.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool EmployeeExists(int id)
        {
            return _context.EmployeeTerritories.Any(e => e.EmployeeID == id);
        }
    }
}
