using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Football_Team_Generator
{
    class Program
    {
        static void Main()
        {
            var teams = new List<FootballTeam>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    var inputArgs = input.Split(';');
                    var command = inputArgs[0];

                    string teamName;
                    string playerName;

                    FootballTeam team = null;
                    Player player = null;

                    switch (command)
                    {
                        case "Team":
                            teamName = inputArgs[1];
                            team = new FootballTeam(teamName);

                            teams.Add(team);
                            break;

                        case "Add":
                            teamName = inputArgs[1];
                            team = teams.FirstOrDefault(t => t.Name == teamName);
                            if (team == null)
                            {
                                throw new Exception($"Team {teamName} does not exist.");
                            }

                            playerName = inputArgs[2];
                            var endurance = int.Parse(inputArgs[3]);
                            var spirit = int.Parse(inputArgs[4]);
                            var dribble = int.Parse(inputArgs[5]);
                            var passing = int.Parse(inputArgs[6]);
                            var shooting = int.Parse(inputArgs[7]);

                            var stats = new Stats(endurance, spirit, dribble, passing, shooting);
                            player = new Player(playerName, stats);

                            team.AddPlayer(player);
                            break;

                        case "Remove":
                            teamName = inputArgs[1];
                            playerName = inputArgs[2];

                            team = teams.FirstOrDefault(t => t.Name == teamName);
                            if (team == null)
                            {
                                throw new Exception($"Team {teamName} does not exist.");
                            }

                            player = team.Team.FirstOrDefault(p => p.Name == playerName);
                            if (player == null)
                            {
                                throw new Exception($"Player {playerName} is not in {teamName} team.");
                            }

                            team.Team.Remove(player);
                            break;

                        case "Rating":
                            teamName = inputArgs[1];
                            team = teams.FirstOrDefault(t => t.Name == teamName);
                            if (team == null)
                            {
                                throw new Exception($"Team {teamName} does not exist.");
                            }

                            Console.WriteLine(team);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}