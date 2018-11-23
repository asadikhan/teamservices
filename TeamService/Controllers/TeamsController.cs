using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AsadCorp.TeamService.Models;
using AsadCorp.TeamService.Persistence;
using System.Threading.Tasks;

namespace AsadCorp.TeamService.Controllers
{
    public class TeamsController : Controller
    {
        ITeamRepository repository;

        public TeamsController(ITeamRepository repo)
        {
            repository = repo;
        }

        [HttpGet] 
        // public IEnumerable<Team> GetAllTeams()
        public virtual IActionResult GetAllTeams()
        {
            // return new Team[] { new Team("One"), new Team("Two") };
            return this.Ok(repository.GetTeams());
        }

        [HttpPost]
        public virtual IActionResult CreateTeam([FromBody]Team newTeam)
        {
            repository.Add(newTeam);

            //TODO: add test that asserts result is a 201 pointing to URL of the created team.
            //TODO: teams need IDs
            //TODO: return created at route to point to team details			
            return this.Created($"/teams/{newTeam.ID}", newTeam);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeam(Guid id)
        {
            Team team = repository.Get(id);

            if (team != null) // I HATE NULLS, MUST FIXERATE THIS.			  
            {
                return this.Ok(team);
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpPut("{id}")]
        public virtual IActionResult UpdateTeam([FromBody]Team team, Guid id)
        {
            team.ID = id;

            if (repository.Update(team) == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(team);
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult DeleteTeam(Guid id)
        {
            Team team = repository.Delete(id);

            if (team == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(team.ID);
            }
        }


    }
}
