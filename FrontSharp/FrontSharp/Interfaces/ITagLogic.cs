using FrontSharp.Models;
using System.Collections.Generic;

namespace FrontSharp.Interfaces
{
    public interface ITagLogic
    {
        Tag Create(string name);
		ListResultResponseBody<Conversation> List(string tagid, List<ConversationStatusFilter> statusFilter = null, int? limit = null);
	}
}