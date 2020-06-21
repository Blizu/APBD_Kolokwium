using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s16710_KolokwiumAPBD.Models
{
    public class EventOrganiser
    {
        public int IdEvent{ get; set; }
        public int IdOrganiser { get; set; }

        public Organiser Organiser { get; set; }

        public Event Event { get; set; }
    }
}
