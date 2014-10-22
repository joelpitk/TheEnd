using UnityEngine;
using System.Collections.Generic;

public class MotherConversation : IConversation {
	private Queue<ConversationTopic> topicQueue;

	private float startTime;
	private ConversationTopic currentTopic;

	public MotherConversation() {
		topicQueue = new Queue<ConversationTopic>();

		topicQueue.Enqueue(new ConversationTopic(10, "Oh honey, thank god for calling me!", 10));
		topicQueue.Enqueue(new ConversationTopic(20, "Second call!!", 10));
	}

	public string NameOfTalker {
		get {
			return "Mom";
		}
	}

	public bool ConversationDone {
		get {
			return startTime + currentTopic.LengthInSeconds < WorldClock.ElapsedRealSeconds;
		}
	}

	public bool OpenLine() {
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
				currentTopic = t;
				startTime = WorldClock.ElapsedRealSeconds;
				return true;
			}
		}

		return false;
	}

	public string GetResponse() {
		if(currentTopic != null) {
			return currentTopic.Content;
		}
		else {
			return "";
		}
	}
}
