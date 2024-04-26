﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Session
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int HallID { get; set; }
        public DateTime DateTime { get; set; }
        public int VipPrice { get; set; }
        public int TicketPrice { get; set; }
    }
}
