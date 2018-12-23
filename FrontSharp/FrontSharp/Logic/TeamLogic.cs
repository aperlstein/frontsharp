using FrontSharp.Interfaces;
using FrontSharp.Models;
using FrontSharp.Requests;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace FrontSharp.Logic
{
    public class TeamLogic : BaseLogic, ITeamLogic
    {
        public TeamLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "teams";
        }

		/// <summary>
		/// Lists all teammates
		/// </summary>
		/// <returns>A list response of the resulting teammates</returns>
		public ListResultResponseBody<Team> List() {
			var request = base.BuildRequest();
			return _client.Execute<ListResultResponseBody<Team>>(request);
		}

		/// <summary>
		/// Creates a new team tag
		/// </summary>
		/// <param name="name">The name of the tag to be created</param>
		/// <returns>Created tag details</returns>
		public Tag CreateTag(string teamid, string name) {
			var request = base.BuildRequest(Method.POST);
			request.Resource += "/{team_id}/tags";
			request.AddParameter("team_id", teamid, ParameterType.UrlSegment);
			var obj = new { name = name };

			return _client.Execute<Tag>(request, obj);
		}
	}
}