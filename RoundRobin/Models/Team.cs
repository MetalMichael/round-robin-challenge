using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundRobin.Models
{
    public class Team
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Ghost { get; private set; }
        public Team(string name, bool ghost = false)
        {
            Id = Guid.NewGuid();
            Name = name;
            Ghost = ghost;
        }
    }
}
