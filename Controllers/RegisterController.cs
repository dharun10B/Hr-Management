using Hr_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase // Use ControllerBase for API controllers
    {
        private readonly HrManageContext _context; // Corrected context type

        public RegisterController(HrManageContext context) // Injecting HrManage context
        {
            _context = context;
        }

        // Removed Index method since it's not typically used in API controllers

        [HttpPost]
        public async Task<ActionResult<RegisterModule>> PostEmployee(RegisterModule register)
        {
            if (register == null)
            {
                return BadRequest("Invalid registration data."); // Handle null input
            }

            // Add the new employee to the database
            _context.Register.Add(register); // Accessing DbSet<RegisterModule>
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = register.EmpId }, register);
        }

        // Example of a Get method to retrieve an employee by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterModule>> GetEmployee(int id)
        {
            var employee = await _context.Register.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
    }
}
