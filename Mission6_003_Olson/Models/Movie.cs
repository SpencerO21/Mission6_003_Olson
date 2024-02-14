﻿using System.ComponentModel.DataAnnotations;

namespace Mission6_003_Olson.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
