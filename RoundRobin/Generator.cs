using System.Collections.Generic;
using System.Linq;
using RoundRobin.Models;

namespace RoundRobin
{
    public class Generator
    {
        private readonly ICollection<Team> _teams;

        /// <summary>
        /// Round Results
        /// </summary>
        public ICollection<Round> Rounds { get; private set; } 

        public Generator(ICollection<Team> teams)
        {
            _teams = teams;
            Rounds = new List<Round>();
        }


        /// <summary>
        /// Generate the Rounds
        /// </summary>
        public void Run()
        {
            // Odd teams
            if (_teams.Count % 2 != 0)
                _teams.Add(new Team("", true));

            // Number of teams. Always even
            var totalTeams = _teams.Count;

            // Number of round.
            var rounds = totalTeams - 1;
            // Initial Team positions. Teams other than 0 are then rotated clockwise.
            // Think of it as a grid, teams always play their opposite.
            // E.g
            // 0 1 2 3   =>   0 4 1 2   =>  0 5 4 1  =>  etc.
            // 4 5 6 7        5 6 7 3       6 7 3 2
            var roundTeams = _teams.ToArray();

            for (var r = 0; r < rounds; r++) {
                // Don't need to do anything first round
                if (r != 0) {
                    var newPositions = new Team[totalTeams];
                    for (var rt = 0; rt < totalTeams; rt++) {
                        var team = roundTeams[rt];
                        var newIndex = rt;
                        // First team stays where it is
                        if (rt != 0) {
                            // Move top row along right
                            if (rt < totalTeams / 2 - 1)
                                newIndex++;
                            // Top right corner to bottom right
                            else if (rt == totalTeams / 2 - 1)
                                newIndex = totalTeams - 1;
                            // Move bottom row along left
                            else if (rt > totalTeams / 2)
                                newIndex--;
                            // Move bottom left to 2nd position
                            else
                                newIndex = 1;
                        }
                        // Place team in position
                        newPositions[newIndex] = team;
                    }
                    // Update Round Teams
                    roundTeams = newPositions;
                }

                // Create Round
                var round = new Round(r + 1);
                for (var rm = 0; rm < totalTeams / 2; rm++) {
                    var teamA = roundTeams[rm];
                    var teamB = roundTeams[rm + totalTeams / 2];

                    // Ghost (rest round)
                    if (teamA.Ghost || teamB.Ghost)
                        continue;

                    var match = new Matchup(teamA, teamB);
                    round.Matchups.Add(match);
                }
                Rounds.Add(round);
            }
        }
    }
}