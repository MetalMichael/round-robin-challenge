using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundRobin.Models
{
    public class Matchup
    {
        public Team A { get; private set; }
        public Team B { get; private set; }

        public Matchup(Team a, Team b)
        {
            A = a;
            B = b;
        }
    }
}
