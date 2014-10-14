using UnityEngine;
using System.Collections.Generic;

public class TVChannel {
	private Queue<TVProgram> programs;

	public TVProgram CurrentProgram {
		get {
			while(programs.Peek().Done) {
				programs.Dequeue();
			}

			return programs.Peek();
		}
	}

	public TVChannel() {
		programs = new Queue<TVProgram>();

		List<string> texts = new List<string>();
		List<Texture> t = new List<Texture>();

		texts.Add("Hello");
		texts.Add("I love you");
		texts.Add("Won't you tell me your name");
		programs.Enqueue(new TVProgram(texts, t, 15));

		texts.Clear();
		texts.Add("NOTHING TO SEE HERE");
		programs.Enqueue(new TVProgram(texts, t, 2020202));
	}
}
