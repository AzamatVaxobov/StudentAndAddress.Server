using Microsoft.AspNetCore.Mvc;
using StudentAndAddress.Service.DTOs;
using StudentAndAddress.Service.StudentService;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    
    [HttpPost]
    public ActionResult<long> PostStudent(StudentCreateDto studentCreateDto)
    {
        var studentId = _studentService.AddStudent(studentCreateDto);
        return CreatedAtAction(nameof(GetById), new { studentId }, studentId);
    }

    
    [HttpDelete("{studentId}")]
    public IActionResult DeleteStudent(long studentId)
    {
        _studentService.RemoveStudent(studentId);
        return NoContent();
    }

    [HttpGet]
    [ResponseCache(Duration = 20)]
    public ICollection<StudentDto> GetAllStudents()
    {
        var students = _studentService.GetAllStudents();
        return students;
    }

    
    [HttpGet("{studentId}")]
    public ActionResult<StudentDto> GetById(long studentId)
    {
        var student = _studentService.GetById(studentId);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

   
    [HttpPut]
    public IActionResult UpdateStudent(StudentDto studentDto)
    {
        _studentService.UpdateStudent(studentDto);
        return NoContent();
    }

    
    [HttpGet("{studentId}/address")]
    public ActionResult<StudentDto> GetStudentByIdWithAddress(long studentId)
    {
        var student = _studentService.GetByIdWithAddress(studentId);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

   
   
  
}
