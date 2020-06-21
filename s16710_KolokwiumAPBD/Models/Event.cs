using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s16710_KolokwiumAPBD.Models
{
    public class Event
    {
        public int IdEvent { get; set; }
        public String Name { get; set; }

        public DateTime StartDate{ get; set; }

        public DateTime EndDate{ get; set; }

        public IList<ArtistEvent> ArtistEvents { get; set; }
        public IList<EventOrganiser> EventOrganisers { get; set; }

    }
}
