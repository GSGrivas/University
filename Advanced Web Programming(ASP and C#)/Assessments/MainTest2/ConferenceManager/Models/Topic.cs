using System.Collections.Generic;

namespace ConferenceManager.Models
{
    public class Topic
    {
        public int TopicId { get; set; }

        public string TopicName { get; set; }

        //Navigation properties
        public ICollection<Paper> Papers { get; set; }
    }
}
