using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleWebProject.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Publisher Name")]
        [Index]
        public string PublisherName { get; set; }

        public ICollection<Book> BooksPublished { get; set; }

        public ICollection<AuthorPublishers> AuthorPublishers { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name ="Publisher Address")]
        [MaxLength(200,ErrorMessage ="You cannot enter an address that is longer than 200 characters")]
        [MinLength(20, ErrorMessage ="Your cannot enter an address shorter than 20 characters")]
        public string Address { get; set; }

    }
}