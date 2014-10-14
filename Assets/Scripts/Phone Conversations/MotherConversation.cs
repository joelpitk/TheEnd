using UnityEngine;
using System.Collections.Generic;

public class MotherConversation : IConversation {
	private Queue<ConversationTopic> topicQueue;

	private float startTime;
	private float currentTopicLengthInSeconds;
	private ConversationTopic currentTopic;

	public MotherConversation() {
		topicQueue = new Queue<ConversationTopic>();

		topicQueue.Enqueue(new ConversationTopic(10, "First time you called me, love you!"));
		topicQueue.Enqueue(new ConversationTopic(20, "Second call!!"));
	}

	public string NameOfTalker {
		get {
			return "Mom";
		}
	}

	public bool ConversationDone {
		get {
			return startTime + currentTopicLengthInSeconds < WorldClock.ElapsedRealSeconds;
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
				// A retarded way to figure out how long to show a subtitle
				currentTopicLengthInSeconds = Mathf.Clamp(currentTopic.Content.Length / 5f, 3f, 20f);
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
