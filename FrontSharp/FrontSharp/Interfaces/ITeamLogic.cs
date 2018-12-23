using FrontSharp.Models;
using FrontSharp.Requests;
using System.Collections.Generic;

namespace FrontSharp.Interfaces
{
    public interface ITeamLogic
    {
        ListResultResponseBody<Team> List();

		Tag CreateTag(string teamid, string name);
	}
}