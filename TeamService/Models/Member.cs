using System;
using System.Collections.Generic;
using System.Text;

namespace AsadCorp.TeamService.Models
{
    public class Member
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Member()
        {
        }

        public Member(Guid id) : this()
        {
            this.ID = id;
        }

        public Member(string firstName, string lastName, Guid id) : this(id)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public override string ToString()
        {
            return this.LastName;
        }
    }
}
