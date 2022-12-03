

namespace ConferenceManager.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _appDbContext;
        private IPaperRepository _paper;
        private IPaperRepository _topic;

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IPaperRepository Paper
        {
            get
            {
                if (_paper == null)
                {
                    _paper = new EFPaperRepository(_appDbContext);
                }

                return _paper;
            }
        }

        public IPaperRepository Topic
        {
            get
            {
                if (_topic == null)
                {
                    _topic = new EFPaperRepository(_appDbContext);
                }

                return _topic;
            }
        }
    }
}
