using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftServeTestTask.DAL.Database;

namespace SoftServeTestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly EducationalContext _context;

        public TestController(EducationalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Teachers
                .Include(t => t.Info)
                .Include(t => t.Contacts)
                .Include(t => t.Courses));
        }
    }
}
