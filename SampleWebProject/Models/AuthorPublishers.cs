using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebProject.Models
{
    public class AuthorPublishers
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public Publisher Publisher { get; set; }

        public int PublisherId { get; set; }

    }
}