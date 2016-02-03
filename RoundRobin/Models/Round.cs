using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundRobin.Models
{
    public class Round
    {
        public int No { get; private set; }
        public Collection<Matchup> Matchups { get; private set; }

        public Round(int no)
        {
            No = no;
            Matchups = new Collection<Matchup>();
        }
    }
}