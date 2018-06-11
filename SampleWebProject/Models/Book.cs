using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleWebProject.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Book Title")]
        [Index]
        public string BookTitle { get; set; }

        [Required]
        [StringLength(25)]
        [Index(IsUnique = true)]
        public string ISBN { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="Published Date")]
        public DateTimeOffset PublishedDate { get; set; }

        public Author Author { get; set; }

        public Publisher Publisher { get; set; }


    }
}