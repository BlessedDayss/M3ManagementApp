namespace WebApplication1.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebApplication1.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly M3ManagmentContext _context;

        public StudentController(M3ManagmentContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            return await _context.Student.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Student>> GetStudent(int Id)
        {
            var student = await _context.Student.FindAsync(Id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }
    }
    
}