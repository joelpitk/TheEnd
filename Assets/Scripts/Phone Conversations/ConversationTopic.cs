using UnityEngine;
using System.Collections;

public class ConversationTopic {
	// How many minutes in world time can pass before this conversation is invalid
	public int MinutesValid {
		get; set;
	}

	// Has the player already heard this topic
	public bool HasBeenDiscussed {
		get; set;
	}

	public string Content {
		get; set;
	}

	public ConversationTopic() {
		MinutesValid = 0;
		Content = "";
	}

	public ConversationTopic(int minutesValid, string content) {
		MinutesValid = minutesValid;
		Content = content;
		HasBeenDiscussed = false;
	}
}
