using ConferenceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceManager.Data
{
    public interface IPaperRepository: IRepositoryBase<Paper>
    {
        IEnumerable<Paper> GetAllPapersWithTopicDetails();
    }
}
