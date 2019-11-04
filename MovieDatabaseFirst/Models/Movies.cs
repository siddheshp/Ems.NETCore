using System;
using System.Collections.Generic;

namespace MovieDatabaseFirst.Models
{
    public partial class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Genre { get; set; }
        public int Rating { get; set; }
    }
}
