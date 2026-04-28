using EvieWizardingWorld.Models;
using EvieWizardingWorld.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvieWizardingWorld.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly TeachersService _teachersService;

        public TeachersController(TeachersService teachersService)
        {
            _teachersService = teachersService;
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be a positive number.");
            }
           
            var teacher = _teachersService.GetTeacherById(id);

            if (teacher == null)
            {
                return NotFound($"No teacher found with Id {id}.");
            }

            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult AddTeacher([FromBody] Teacher newTeacher)
        {
            if (string.IsNullOrEmpty(newTeacher.Name))
            {
                return BadRequest("Teacher must have a name.");
            }

            var teacher = _teachersService.AddTeacher(newTeacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be a positive number.");
            }

            bool deleted = _teachersService.DeleteTeacher(id);

            if (!deleted)
            {
                return NotFound($"No teacher found with Id {id}.");
            }

            return NoContent();
        }
    }
}
    

