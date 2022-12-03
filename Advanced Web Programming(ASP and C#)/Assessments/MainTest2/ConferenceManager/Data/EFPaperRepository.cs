using ConferenceManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceManager.Data
{
    public class EFPaperRepository: RepositoryBase<Paper>, IPaperRepository
    {
        public EFPaperRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public IEnumerable<Paper> GetAllPapersWithTopicDetails()
        {
            return _appDbContext.Papers
                .Include(p => p.Topic);
        }
    }
}
