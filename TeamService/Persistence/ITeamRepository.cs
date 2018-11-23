using System;
using System.Collections.Generic;
using System.Text;
using AsadCorp.TeamService.Models;

namespace AsadCorp.TeamService.Persistence
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        void AddTeam(Team team);
        Team Get(Guid id);
        Team Delete(Guid id);
        Team Add(Team team);
        Team Update(Team team);
    }
}
