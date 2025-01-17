using Hr_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hr_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly HrManageContext _context;

        public AttendanceController(HrManageContext context)
        {
            _context = context;
        }

        // GET: api/attendance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceModule>>> GetAttendances()
        {
            return await _context.Attendances.ToListAsync(); // Fetch all attendance records
        }

        // GET: api/attendance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceModule>> GetAttendance(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return attendance;
        }

        // POST: api/attendance
        [HttpPost]
        public async Task<IActionResult> CreateAttendance([FromBody] AttendanceModule attendance)
        {
            // Validate input
            if (attendance == null || attendance.EmployeeId <= 0 || attendance.Date == default)
            {
                return BadRequest(new { message = "EmployeeId and Date are required." });
            }

            attendance.CalculateShortFall();

            // Add the attendance record to the database
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttendance), new { id = attendance.Id }, attendance);
        }
    }
}