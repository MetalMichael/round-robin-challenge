using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelDeveloperScreen
{
    class Program
    {
        class Team
        {
            public Guid Id { get; private set; }

            public string Name { get; private set; }

            public Team(string name)
            {
                Id = Guid.NewGuid();
                Name = name;
            }
        }

        class Round
        {
            public int No { get; private set; }

            public Collection<Matchup> Matchups { get; private set; }

            public Round(int no)
            {
                No = no;
                Matchups = new Collection<Matchup>();
            }
        }

        class Matchup
        {
            public Team A { get; private set; }

            public Team B { get; private set; }

            public Matchup(Team a, Team b)
            {
                A = a;
                B = b;
            }
        }

        static void Main(string[] args)
        {
            var data = new Collection<Team>
            {
                new Team("Tom's Tyrants (1)"),
                new Team("Josh's Jollies (2)"),
                new Team("Ian's Instigators (3)"),
                new Team("Hench's Hydras (4)")
            };

            var tournament = new Collection<Round>(); // store your answer here.

            /* Task **
               ----
                Given a collection of Team objects, print matchups for a round 
                robin tournament. For simplicity's sake, you can assume that the
                number of teams is always even.
            */

            /* Example output **
               --------------
                Round 1
                Tom's Tyrants (1) vs. Josh's Jollies (2)
                Hench's Hydras (4) vs. Ian's Instigators (3)

                Round 2
                Tom's Tyrants (1) vs. Ian's Instigators (3)
                Josh's Jollies (2) vs. Hench's Hydras (4)

                Round 3
                Tom's Tyrants (1) vs. Hench's Hydras (4)
                Ian's Instigators (3) vs. Josh's Jollies (2)
            */

            // GL, HF!

            PrintMatchups(tournament);

            Console.WriteLine("[Enter] to close...");
            Console.ReadLine();
        }


        static void PrintMatchups(Collection<Round> tournament)
        {
            foreach (var round in tournament)
            {
                Console.WriteLine(string.Format("Round {0}", round.No));
                foreach (var matchup in round.Matchups)
                {
                    Console.WriteLine("{0} vs. {1}", matchup.A.Name, matchup.B.Name);
                }
                Console.WriteLine();
            }
        }
    }
}
