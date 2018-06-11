using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebProject.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        [Index]
        public string AuthorName { get; set; }

        public ICollection<Book> Books { get; set; }

        [Required]
        [StringLength(50)]
        public string AuthorEmail { get; set; }

        public ICollection<AuthorPublishers> AuthorPublishers { get; set; }

    }
}