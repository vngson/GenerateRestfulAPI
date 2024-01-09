using GenerateRestfulAPI.Data;
using GenerateRestfulAPI.Domain;
using GenerateRestfulAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GenerateRestfulAPI.Controllers
{
    //https://localhost:port/api/course
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly StudentDbContext studentDbContext;
        public CourseController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }
        [HttpGet]
        public IActionResult GetAll() {
            var course  = studentDbContext.courses.ToList();
            return Ok(course);
        }

        [HttpGet]
        [Route("id:Guid")]
        public IActionResult GetById(Guid id) {
            var course = studentDbContext.courses.FirstOrDefault(x => x.Id == id);
            if(course == null)
            {
                return NotFound();
            }
            var courseDTO = new CourseDTO();
            courseDTO.Id = course.Id;
            courseDTO.Name = course.Name;
            courseDTO.Description = course.Description;
            return Ok(courseDTO);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] AddCourseDTO dto)
        {
            var courseDomain = new Course() { 
                Name = dto.Name,
                Description = dto.Description
            };
            studentDbContext.courses.Add(courseDomain);
            studentDbContext.SaveChanges();

            var course_dto = new CourseDTO()
            {
                Id = courseDomain.Id,
                Name = courseDomain.Name,
                Description = courseDomain.Description
            };

            return CreatedAtAction(nameof(GetById), new { id = course_dto.Id }, course_dto);
        }
    }
}
