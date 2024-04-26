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
        public int RowsVipCount { get; set; }
        public int SeatsCountPerRow { get; set; }
        public int SeatsVipCountPerRow { get; set; }
    }
}
