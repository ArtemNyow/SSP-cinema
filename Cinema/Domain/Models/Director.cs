﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Director
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
