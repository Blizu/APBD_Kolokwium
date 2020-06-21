using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s16710_KolokwiumAPBD.Models
{
    public class Organiser
    {
        public int idOrganiser { get; set; }
        public String Name { get; set; }

        public IList<EventOrganiser> EventOrganisers { get; set; }
    }
}
