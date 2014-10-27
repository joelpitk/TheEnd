using UnityEngine;
using System.Collections.Generic;

public class TVChannel {
	private Queue<TVProgram> programs;

	public TVProgram CurrentProgram {
		get {
			while(programs.Count > 0 && programs.Peek().Done) {
				programs.Dequeue();
			}

			if(programs.Count > 0) {
				return programs.Peek();
			}

			return null;
		}
	}

	public TVChannel() {
		programs = new Queue<TVProgram>();

		programs.Enqueue(TVProgramRepository.GetProgram("News"));
	}
}
