using StudentAndAddress.DataAccess.Entities;

namespace StudentAndAddress.Repository.StudentRepository
{
    public interface IStudentRepository
    {
        long InsertStudent(Student student);
        ICollection<Student> SelectAll();
        void UpdateStudent(Student student);
        void DeleteStudent(long studentId);
        Student GetById(long studentId);
        Student GetByIdWithAddress(long studentId);

    }
}