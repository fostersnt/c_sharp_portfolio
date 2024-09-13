using CustomLibrary.interfaces;
using CustomLibrary.models;
using Microsoft.EntityFrameworkCore;
using students_api.data;
using students_api.Mapper;
using students_api.models;

namespace students_api.repository
{
    public class StudentRepository : IDatabaseCRUD<Student>
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public StudentRepository(ApplicationDBContext applicationDBContext)
        {
            this._applicationDBContext = applicationDBContext;
        }
        public async Task<Student> DeleteRecord(int id)
        {
            return null;
        }

        public Task<List<Student>> GetAllAsync()
        {
            try
            {
                var students = _applicationDBContext.students.ToListAsync();

                return students;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<Student> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateRecord(int id, Student record)
        {
            throw new NotImplementedException();
        }
    }
}
