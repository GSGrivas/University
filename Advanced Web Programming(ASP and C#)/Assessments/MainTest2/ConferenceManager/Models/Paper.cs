using System;
using System.ComponentModel.DataAnnotations;

namespace ConferenceManager.Models
{
    public class Paper
    {
        [Display(Name = "ID")]
        public int PaperId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string PaperTitle { get; set; }

        [Required]
        [Display(Name = "Abstract")]
        public string PaperAbstract { get; set; }


        [Display(Name = "Author")]
        public string PaperAuthor { get; set; }

 
        [Display(Name = "Submission date")]
        public DateTime PaperDateSubmitted { get; set; }

        [Required]
        [Display(Name = "Topic")]
        public int TopicId { get; set; }


        //Navigation properties
        public Topic Topic { get; set; }
    }
}
