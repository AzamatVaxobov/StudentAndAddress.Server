using StudentAndAddress.Service.DTOs;

namespace StudentAndAddress.Service.StudentService
{
    public interface IStudentService
    {
        long AddStudent(StudentCreateDto studentCreateDto);
        ICollection<StudentDto> GetAllStudents();
        void UpdateStudent(StudentDto studentDto);
        void RemoveStudent(long studentId);
        StudentDto GetById(long studentId);
        StudentDto GetByIdWithAddress(long studentId);
    }
}