using UnityEngine;
using System.Collections.Generic;

public class TVProgram {
	private string[] texts;
	private Texture[] images;

	private int startTime;
	private int lengthInMinutes;

	public string Text {
		get {
			return texts[CurrentFrame(texts)];
		}
	}

	public Texture Image {
		get {
			return images[CurrentFrame(images)];
		}
	}

	private int CurrentFrame(System.Object[] array) {
		int elapsed = WorldClock.ElapsedMinutes - startTime;
		float prcntElapsed = (float)elapsed / (float)lengthInMinutes;
		if(prcntElapsed >= 1) 
			return array.Length-1;
		else
			return (int)(array.Length * prcntElapsed);
	}
	
	public TVProgram(ICollection<string> texts, ICollection<Texture> images, int lengthInMinutes) {
		this.texts = new string[texts.Count];
		int i = 0;
		foreach(string t in texts) {
			this.texts[i++] = t;
		}

		i = 0;
		this.images = new Texture[images.Count];
		foreach(Texture im in images) {
			this.images[i++] = im;
		}
		this.lengthInMinutes = lengthInMinutes;
	}

	public void Start() {
		startTime = WorldClock.ElapsedMinutes;
	}

	public bool Done {
		get {
			return startTime + lengthInMinutes < WorldClock.ElapsedMinutes;
		}
	}
}
