using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.Data
{
    public class EFStudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public EFStudentRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        //public IEnumerable<Student> GetAllStudentsAsce(string sortBy, string searchString)
        //{
        //    return _appDbContext.Students
        //            .OrderBy(s => EF.Property<object>(s, sortBy))
        //            .Where(s => s.LastName.Contains(searchString) ||
        //                        s.FirstName.Contains(searchString));
        //}

        //public IEnumerable<Student> GetAllStudentsDesc(string sortBy, string searchString)
        //{
        //    return _appDbContext.Students
        //            .OrderByDescending(s => EF.Property<object>(s, sortBy))
        //            .Where(s => s.LastName.Contains(searchString) ||
        //                        s.FirstName.Contains(searchString));
        //}

        public Student GetStudentWithEnrollmentDetails(int id)
        {
            return _appDbContext.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefault(s => s.StudentID == id);
        }
    }
}
