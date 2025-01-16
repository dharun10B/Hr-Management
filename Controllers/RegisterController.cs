using Hr_Management.Models; // Ensure this namespace matches your project structure
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hr_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly HrManageContext _context; // Use your actual DbContext class

        public RegisterController(HrManageContext context) // Injecting your DbContext
        {
            _context = context;
        }

        // GET: api/Register
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterModule>>> GetEmployees()
        {
            return await _context.Register.ToListAsync(); // Fetch all registered users
        }

        // GET: api/Register/5
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

        // POST: api/Register
        [HttpPost]
        public async Task<ActionResult<RegisterModule>> PostEmployee(RegisterModule register)
        {
            if (register == null)
            {
                return BadRequest("Invalid registration data."); // Handle null input
            }

            // Optionally set default values here if needed
            _context.Register.Add(register); // Add new employee to the database
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = register.EmpId }, register);
        }

        //// PUT: api/Register/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEmployee(int id, RegisterModule register)
        //{
        //    if (id != register.EmpId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(register).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw; // Rethrow the exception if not a concurrency issue
        //        }
        //    }

        //    return NoContent();
        //}

        //// DELETE: api/Register/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(int id)
        //{
        //    var employee = await _context.Register.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Register.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //// DELETE: api/Register
        //[HttpDelete]
        //public async Task<IActionResult> DeleteAllEmployees()
        //{
        //    var employees = await _context.Register.ToListAsync();
        //    if (employees.Count == 0)
        //    {
        //        return NotFound("No employees found to delete.");
        //    }

        //    _context.Register.RemoveRange(employees);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Register.Any(e => e.EmpId == id); // Check if employee exists by ID
        //}
    }
}
