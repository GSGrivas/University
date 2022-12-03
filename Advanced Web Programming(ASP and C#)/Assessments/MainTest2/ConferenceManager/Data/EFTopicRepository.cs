using ConferenceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceManager.Data
{
    public class EFTopicRepository: RepositoryBase<Topic>, ITopicRepository
    {
        public EFTopicRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
