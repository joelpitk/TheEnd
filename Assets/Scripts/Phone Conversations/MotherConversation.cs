using UnityEngine;
using System.Collections.Generic;

public class MotherConversation : IConversation {
	private Queue<ConversationTopic> topicQueue;

	public MotherConversation() {
		topicQueue = new Queue<ConversationTopic>();

		topicQueue.Enqueue(new ConversationTopic(10, "First time you called me, love you!"));
		topicQueue.Enqueue(new ConversationTopic(20, "Second call!!"));
	}

	public string GetNameOfTalker() {
		return "Mom";
	}

	public string GetResponse() {
		int time = WorldClock.ElapsedMinutes;

		// Remove topics that are too old
		bool b = topicQueue.Count > 0;
		while(b) {
			ConversationTopic t = topicQueue.Peek();
			if(t.MinutesValid < time) {
				topicQueue.Dequeue();
				b = topicQueue.Count > 0;
			}
			else {
				b = false;
			}
		}

		// If there's still topics to talk about
		if(topicQueue.Count > 0) {
			ConversationTopic t = topicQueue.Peek();
			if(!t.HasBeenDiscussed) {
				t.HasBeenDiscussed = true;
				return t.Content;
			}
		}

		// No more valid topics or current topic has already been discussed. No answer at this time!
		return "";
	}
}
