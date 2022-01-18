using System.Collections.Generic;

namespace CompositeAndIteratorAndProxyDP
{
    #region Composite DP Classes
    
    interface ILeague
    {
        string Name { get; set; }
        void Create(string name);
    }

    public class Team : ILeague
    {
        public string Name { get; set; }

        public Team(string name)
        {
            Create(name);
        }

        public void Create(string name)
        {
            Name = name;
        }
    }

    public class Division : ILeague
    {
        public string Name { get; set; }
        public List<Team> Teams { get; }

        public Division(string name)
        {
            Create(name);
            Teams = new List<Team>();
        }

        public void Create(string name)
        {
            Name = name;
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }
    }

    public class League : ILeague
    {
        public string Name { get; set; }
        public List<Division> Divisions { get; }

        public League(string name)
        {
            Create(name);
            Divisions = new List<Division>();
        }

        public void Create(string name)
        {
            Name = name;
        }

        public void AddDivision(Division division)
        {
            Divisions.Add(division);
        }
    }

    public class ListLeague : List<League>
    {
        public ListLeague()
        {
            League l;
            Division d;

            Add(l = new League("League A"));
            
            l.AddDivision(d = new Division("Division A"));
            d.AddTeam(new Team("Team I"));
            d.AddTeam(new Team("Team II"));
            d.AddTeam(new Team("Team III"));
            d.AddTeam(new Team("Team IV"));
            d.AddTeam(new Team("Team V"));
            
            l.AddDivision(d = new Division("Division B"));
            d.AddTeam(new Team("Team Blue"));
            d.AddTeam(new Team("Team Red"));
            d.AddTeam(new Team("Team Yellow"));
            d.AddTeam(new Team("Team Green"));
            d.AddTeam(new Team("Team Orange"));
            
            l.AddDivision(d = new Division("Division C"));
            d.AddTeam(new Team("Team East"));
            d.AddTeam(new Team("Team West"));
            d.AddTeam(new Team("Team North"));
            d.AddTeam(new Team("Team South"));

            Add(l = new League("League B"));
            
            l.AddDivision(d = new Division("Division A"));
            d.AddTeam(new Team("Team 1"));
            d.AddTeam(new Team("Team 2"));
            d.AddTeam(new Team("Team 3"));
            d.AddTeam(new Team("Team 4"));
            d.AddTeam(new Team("Team 5"));
            
            l.AddDivision(d = new Division("Division B"));
            d.AddTeam(new Team("Team Diamond"));
            d.AddTeam(new Team("Team Heart"));
            d.AddTeam(new Team("Team Club"));
            d.AddTeam(new Team("Team Spade"));
            
            l.AddDivision(d = new Division("Division C"));
            d.AddTeam(new Team("Team Alpha"));
            d.AddTeam(new Team("Team Beta"));
            d.AddTeam(new Team("Team Gamma"));
            d.AddTeam(new Team("Team Delta"));
            d.AddTeam(new Team("Team Epsilon"));
        }
    }
    #endregion
}