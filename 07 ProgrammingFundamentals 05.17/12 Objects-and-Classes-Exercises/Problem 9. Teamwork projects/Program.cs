using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TeamworkProjectsList
{
    class Team
    {
        public string ImeNaEkip { get; set; }
        public string Syzdatel { get; set; }
        public List<string> Uchastnici { get; set; }

        public Team()
        {
            Uchastnici = new List<string>();
        }
    }

    class TeamworkProjectList
    {
        static void Main(string[] args)
        {
            int teamsNumber = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            CreatingTeams(teamsNumber, teams);
            UsersJoiningTeams(teams);
            PrintingTeams(teams);
        }

        private static void CreatingTeams(int teamsNumber, List<Team> teams)
        {
            for (int i = 0; i < teamsNumber; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string creator = input[0];
                string teamName = input[1];

                if (teams.Any(x => x.ImeNaEkip == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                else if (teams.Any(x => x.Syzdatel == creator))
                {
                    Console.WriteLine("{0} cannot create another team!", creator);
                    continue;
                }
                else
                {
                    Team nastoyashtEkip = new Team();
                    nastoyashtEkip.Syzdatel = creator;
                    nastoyashtEkip.ImeNaEkip = teamName;

                    teams.Add(nastoyashtEkip);
                    Console.WriteLine("Team {0} has been created by {1}!", teamName, creator);
                }
            }
        }

        private static void UsersJoiningTeams(List<Team> teams)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end of assignment") break;

                string[] inputArgs = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string userToJoin = inputArgs[0];
                string teamToJoin = inputArgs[1];

                if (teams.All(x => x.ImeNaEkip != teamToJoin))
                {
                    Console.WriteLine("Team {0} does not exist!", teamToJoin);
                    continue;
                }

                if (teams.Any(x => x.Uchastnici.Contains(userToJoin)) || teams.Any(x => x.Syzdatel == userToJoin))
                {
                    Console.WriteLine("Member {0} cannot join team {1}!", userToJoin, teamToJoin);
                    continue;
                }

                int teamToJoinIndex = teams.FindIndex(x => x.ImeNaEkip == teamToJoin);
                teams[teamToJoinIndex].Uchastnici.Add(userToJoin);
            }
        }

        private static void PrintingTeams(List<Team> teams)
        {
            teams = teams.OrderByDescending(x => x.Uchastnici.Count).ThenBy(x => x.ImeNaEkip).ToList();

            foreach (Team currentTeam in teams)
            {
                if (currentTeam.Uchastnici.Count != 0)
                {
                    Console.WriteLine("{0}", currentTeam.ImeNaEkip);
                    Console.WriteLine("- {0}", currentTeam.Syzdatel);
                    foreach (string currentUser in currentTeam.Uchastnici.OrderBy(x => x))
                        Console.WriteLine("-- {0}", currentUser);
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (Team currentTeam in teams.OrderBy(x => x.ImeNaEkip))
            {
                if (currentTeam.Uchastnici.Count == 0)
                    Console.WriteLine("{0}", currentTeam.ImeNaEkip);
            }
        }
    }
}