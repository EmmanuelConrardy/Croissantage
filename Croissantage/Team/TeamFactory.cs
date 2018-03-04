using System;
using System.Collections.Generic;

namespace Croissantage
{
    public class TeamFactory
    {
        private List<Team> teams = new List<Team>();

        public TeamFactory()
        {
            teams.Add(new RedTeam());
            //green, blue, ...
        }

       
        public Team CreateTeam(string teamName)
        {
            return teams.Find(t => t.Name == teamName);
        }
    }
}
