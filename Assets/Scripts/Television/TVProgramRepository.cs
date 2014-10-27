using UnityEngine;
using System.Collections.Generic;

public class TVProgramRepository : MonoBehaviour {
	public Texture testcard;
	public Texture[] newsFrames;

	private static Dictionary<string, TVProgram> programs;

	void Awake() {
		programs = new Dictionary<string, TVProgram>();

		List<string> texts = new List<string>();
		List<Texture> t = new List<Texture>();

		t.AddRange(newsFrames);
		texts.Add ("The situation does indeed look very bad.");
		texts.Add ("We will keep you posted on new developments as soon as they arrive.");
		texts.Add ("However, our analysts currently say this may very well be the end of the World as we know it.");
		programs.Add("News", new TVProgram(texts, t, 30));

		t.Clear();
		t.Add(testcard);
		texts.Clear();
		programs.Add("Testcard", new TVProgram(texts, t, 60));
	}

	public static TVProgram GetProgram(string name) {
		TVProgram p;
		if(programs.TryGetValue(name, out p)) {
			return p;
		}

		return null;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
