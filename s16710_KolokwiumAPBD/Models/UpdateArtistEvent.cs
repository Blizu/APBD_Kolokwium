using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s16710_KolokwiumAPBD.Models
{
    public class UpdateArtistEvent
    {

        public int IdArtist { get; set; }
        public int IdEvent { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}
