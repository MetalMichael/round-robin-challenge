using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RoundRobin.Models;

namespace RoundRobin
{
    public class Program
    {
        /// <summary>
        /// Console output. Not very dynamic
        /// </summary>
        public static void Main(string[] args)
        {
            var teams = new Collection<Team>
            {
                new Team("Tom's Tyrants (1)"),
                new Team("Josh's Jollies (2)"),
                new Team("Ian's Instigators (3)"),
                new Team("Hench's Hydras (4)"),
                new Team("Michael's Mercenaries (5)")
            };

            var generator = new Generator(teams);
            generator.Run();
           
            PrintMatchups(generator.Rounds);

            Console.WriteLine("[Enter] to close...");
            Console.ReadLine();
        }

        private static void PrintMatchups(IEnumerable<Round> tournament)
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