using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s16710_KolokwiumAPBD.Models
{
    public class Artist
    {
        public int IdArtist { get; set; }
        public String NickName { get; set; }

        public IList<ArtistEvent> ArtistEvents { get; set; }
    }
}
