﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role {  get; set; }  
        
    }
}
