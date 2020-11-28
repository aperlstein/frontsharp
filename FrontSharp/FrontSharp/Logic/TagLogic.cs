using FrontSharp.Interfaces;
using FrontSharp.Models;
using RestSharp;
using System.Collections.Generic;

namespace FrontSharp.Logic
{
    public class TagLogic : BaseLogic, ITagLogic
    {
        public TagLogic(FrontSharpClient client)
            : base(client)
        {
            _baseRoute = "tags";
        }

        /// <summary>
        /// Creates a new tag
        /// </summary>
        /// <param name="name">The name of the tag to be created</param>
        /// <returns>Created tag details</returns>
        public Tag Create(string name)
        {
            var request = base.BuildRequest(Method.POST);

            var obj = new { name = name };

            return _client.Execute<Tag>(request, obj);
        }

		/// <summary>
		/// Lists all the conversations tagged by a certain tag id.
		/// </summary>
		/// <param name="statusFilter">Limits results to only the statuses given or all results if no filters are provided</param>
		/// <param name="limit">The number of results to be retrieved (50 is the default, 100 is the max)</param>
		/// <returns>A list response of the tagged conversations</returns>
		public ListResultResponseBody<Conversation> List(string tagid, List<ConversationStatusFilter> statusFilter = null, int? limit = null) {
			var request = base.BuildRequest();
			request.Resource += "/{tag_id}/conversations";
			request.AddParameter("tag_id", tagid, ParameterType.UrlSegment);
			if (statusFilter != null && statusFilter.Count > 0) {
				foreach (var filter in statusFilter) {
					request.AddParameter("q[statuses][]", filter.ToString().ToLower(), ParameterType.QueryString);
				}
			}

			if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);

			return _client.Execute<ListResultResponseBody<Conversation>>(request);
		}
	}
}