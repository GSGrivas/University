using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCollection.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [StringLength(100),
        DisplayName("Book Title"),
        Required(ErrorMessage = "Enter a book title")]
        public string BookTitle { get; set; }

        [DisplayName("Book Author")
        ,Required(ErrorMessage = "Enter a book Author")]
        public string BookAuthor { get; set; }

        [DisplayName("Book ISBN"),
        RegularExpression("^(?:ISBN(?:-1[03])?:?\\ )?(?=[0-9X]{10}$|(?=(?:[0-9]+[-\\ ]){3})[-\\ 0-9X]{13}$|97[89][0-9]{10}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)(?:97[89][-\\ ]?)?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9X]$",
        ErrorMessage = "Please enter a valid ISBN")]
        public string BookISBN { get; set; }

        public bool? BookIsRead { get; set; }
    }
}
