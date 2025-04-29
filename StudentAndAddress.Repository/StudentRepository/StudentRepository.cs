using Microsoft.EntityFrameworkCore;
using StudentAndAddress.DataAccess;
using StudentAndAddress.DataAccess.Entities;

namespace StudentAndAddress.Repository.StudentRepository
{

    public class StudentRepository : IStudentRepository
    {
        private readonly MainContext _context;
        public StudentRepository(MainContext context)
        {
            _context = context;
        }
        public void DeleteStudent(long studentId)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new Exception($" Student with {studentId} not found ");
            }
            _context.Students.Remove(student);
            _context.SaveChanges();

        }

        public ICollection<Student> SelectAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(long studentId)
        {
            var student = _context.Students.FirstOrDefault(student => student.Id == studentId);
            if (student == null)
            {
                throw new Exception($"Student with {studentId} not found ");
            }

            return student;
        }

        public Student GetByIdWithAddress(long studentId)
        {
            var student = _context.Students
                .Include(s => s.Address)
                .FirstOrDefault(student => student.Id == studentId);
            if (student == null) 
            {
                throw new Exception($"Student with {studentId} not found ");
            }

            return student;
        }

        public long InsertStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return student.Id;

        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = _context.Students.Include(s => s.Address).FirstOrDefault(student => student.Id == student.Id); 
            if (existingStudent == null)
            {
                throw new Exception($"Student with {student.Id} not found ");
            }

            existingStudent.Firstname = student.Firstname;  
            existingStudent.Lastname = student.Lastname;  

        }

    }
}
