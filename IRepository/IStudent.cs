using students_api.models;

namespace students_api.IRepository
{
    public interface IStudent
    {
        public Task<Student> deleteById(int id);
        public Task<Student> getById(int id);
        public Task<Student> updateById(Student student, int id);
        public Task<IEnumerable<Student>> GetStudents();
    }
}
