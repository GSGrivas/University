namespace ContosoUniversity.Data
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private AppDbContext _appDbContext;
        private IStudentRepository _student;

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IStudentRepository Student
        {
            get
            {
                if (_student == null)
                {
                    _student = new EFStudentRepository(_appDbContext);
                }

                return _student;
            }
        }
    }
}
