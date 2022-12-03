using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class EFCourseRepository: RepositoryBase<Course>, ICourseRepository
    {
        public EFCourseRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
