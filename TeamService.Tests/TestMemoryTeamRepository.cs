using AsadCorp.TeamService.Persistence;
using AsadCorp.TeamService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsadCorp.TeamService
{
    public class TestMemoryTeamRepository : MemoryTeamRepository
    {
        public TestMemoryTeamRepository() : base(CreateInitialFake())
        {

        }

        private static ICollection<Team> CreateInitialFake()
        {
            var teams = new List<Team>();
            teams.Add(new Team("one"));
            teams.Add(new Team("two"));

            return teams;
        }
    }
}
