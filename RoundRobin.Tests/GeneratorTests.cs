using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundRobin.Models;

namespace RoundRobin.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        /// <summary>
        /// This may take serveral minutes to run
        /// </summary>
        [TestMethod]
        public void Generator_Tests()
        {
            var r = new Random();
            // Test 10 random samples
            for (var x = 0; x < 10; x++)
            {
                // Between 3 and 200 teams
                var noTeams = r.Next(3, 200);

                var teams = new Collection<Team>();
                for (var t = 0; t < noTeams; t++)
                {
                    var teamName = string.Format(RandomString() + " ({0})", t);
                    teams.Add(new Team(teamName));
                }

                var generator = new Generator(teams);
                generator.Run();

                var results = generator.Rounds;

                CheckResults(teams, results);
            }
        }

        /// <summary>
        /// Check the results match the rules for round robin.
        /// 
        /// 1. Each team plays every other team.
        /// 2. Each team does not play any other team more than once.
        /// </summary>
        private static void CheckResults(ICollection<Team> teams, IEnumerable<Round> rounds)
        {
            Debug.WriteLine(teams.Count);
            var matchups = rounds.SelectMany(r => r.Matchups).ToList();

            // This could all be one LINQ statement. I tried it, but it was nearly impossible to read/debug.
            // Apparently too much LINQ is a bad thing :(
            foreach (var team1 in teams.Where(t => !t.Ghost))
            {
                foreach (var team2 in teams.Where(t => t != team1 && !t.Ghost))
                {
                    var matchesBetweenTwoTeams =
                        matchups.Where(m => (m.A.Equals(team1) && m.B.Equals(team2)
                                             || m.A.Equals(team2) && m.B.Equals(team1)));
                    Assert.AreEqual(1, matchesBetweenTwoTeams.Count());
                }
            }
        }

        /// <summary>
        /// Get a random string for a team name
        /// </summary>
        private static string RandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}