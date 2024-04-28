﻿namespace Domain.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; } = new();
    }
}
