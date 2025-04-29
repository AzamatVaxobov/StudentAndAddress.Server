using StudentAndAddress.DataAccess.Entities;
using StudentAndAddress.Repository.StudentRepository;
using StudentAndAddress.Service.DTOs;

namespace StudentAndAddress.Service.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public long AddStudent(StudentCreateDto studentCreateDto)
        {
            var student = new Student()
            {
                Firstname = studentCreateDto.Firstname,
                Lastname = studentCreateDto.Lastname,
            };

            return _studentRepository.InsertStudent(student);
        }

        public void RemoveStudent(long studentId)
        {
            _studentRepository.DeleteStudent(studentId);
        }

        public ICollection<StudentDto> GetAllStudents()
        {
            var students = _studentRepository.SelectAll();
            return students.Select(student => new StudentDto
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Address = null,
            }).ToList();
        }

        public StudentDto GetById(long studentId)
        {
            var student = _studentRepository.GetById(studentId);
            if (student == null) return null;
            return new StudentDto
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Address = null
            };
        }

        public StudentDto GetByIdWithAddress(long studentId)
        {
            var student = _studentRepository.GetByIdWithAddress(studentId);
            if (student == null) return null;

            var studentDto = new StudentDto
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname
            };
            if (student.Address != null)
            {
                studentDto.Address = new AddressDto
                {
                    Id = student.Address.Id,
                    City = student.Address.City,
                    Street = student.Address.Street,
                    StudentId = student.Address.StudentId,
                };
            }

            return studentDto;
        }

        public void UpdateStudent(StudentDto studentDto)
        {
            var student = new Student
            {
                Id = studentDto.Id,
                Firstname = studentDto.Firstname,
                Lastname = studentDto.Lastname,
            };

            _studentRepository.UpdateStudent(student);
        }
    }
}
