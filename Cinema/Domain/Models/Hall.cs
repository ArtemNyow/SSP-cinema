using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Hall
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int RowsCount { get; set; }
        public int RowsVIPCount { get; set; }
        public int SeatsCountPreRow { get; set; }
        public int SeatsVIPCountPreRow { get; set; }
    }
}
