namespace WebApplication1.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebApplication1.Models;

    [Route("rest/student")]
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
            return await _context.Students.ToListAsync();
        }

    }
    
}