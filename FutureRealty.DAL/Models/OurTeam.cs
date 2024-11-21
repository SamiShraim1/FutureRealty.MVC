using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureRealty.DAL.Models
{
    public class OurTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Info { get; set; }
        public string ImageName { get; set; }
        public string? FacebookLink { get; set; }
        public string? linkedinLink { get; set; }
        public string? TwitterLink { get; set; }

    }
}
