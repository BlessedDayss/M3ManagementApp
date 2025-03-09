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

        [HttpGet("Name")]
        public async Task<ActionResult<Student>> GetStudentByName(string Name) {
            var student = await _context.Student.FirstOrDefaultAsync(s => s.Name == Name);

            if (student == null) {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetStudent", new { Id = student.Id}, student);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutStudent(int Id, Student student)
        {
            if (Id != student.Id)
            {
                return BadRequest();
            }
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Id))
                {
                    return NotFound();
                } else 
                {
                   throw;
                }
            }
            return NoContent();
        }

        // [HttpDelete("Id")]

        private bool StudentExists(int Id) 
        {
            return _context.Student.Any(s => s.Id == Id);
        }
    }
    
}