using UnityEngine;
using System.Collections;

public interface IConversation {
	string NameOfTalker {
		get;
	}
	bool ConversationDone {
		get;
	}

	string GetResponse();
	bool OpenLine();
}
