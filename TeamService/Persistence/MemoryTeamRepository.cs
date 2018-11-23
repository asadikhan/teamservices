using System;
using System.Collections.Generic;
using System.Text;
using AsadCorp.TeamService.Models;
using System.Linq;

namespace AsadCorp.TeamService.Persistence
{
    public class MemoryTeamRepository : ITeamRepository
    {
        protected static ICollection<Team> teams;

        public MemoryTeamRepository()
        {
            if (teams == null)
            {
                teams = new List<Team>();
            }
        }

        public MemoryTeamRepository(ICollection<Team> t)
        {
            teams = t;
        }

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }

        public Team Get(Guid id)
        {
            return teams.FirstOrDefault(t => t.ID == id);
        }

        public Team Delete(Guid id)
        {
            var q = teams.Where(t => t.ID == id);
            Team team = null;

            if (q.Count() > 0)
            {
                team = q.First();
                teams.Remove(team);
            }

            return team;
        }

        public Team Add(Team team)
        {
            teams.Add(team);
            return team;
        }

        public Team Update(Team t)
        {
            Team team = this.Delete(t.ID);

            if (team != null)
            {
                team = this.Add(t);
            }

            return team;
        }
    }
}
