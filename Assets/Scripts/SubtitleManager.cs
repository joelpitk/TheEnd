using UnityEngine;
using System.Collections;

public class SubtitleManager : MonoBehaviour {
	public GUISkin subtitleSkin;

	private static bool showingSubtitle;
	private static float timeToShowSubtitle;

	private static string subtitle;

	// Use this for initialization
	void Start () {
		showingSubtitle = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(showingSubtitle) {
			timeToShowSubtitle -= Time.deltaTime;
			showingSubtitle = timeToShowSubtitle > 0f;
		}
	}

	void OnGUI() {
		if(showingSubtitle) {
			GUI.skin = subtitleSkin;
			GUI.Label(new Rect(10, Screen.height-160, Screen.width-20, 150), subtitle);
		}
	}

	public static void ShowSubtitle(string s) {
		float time = s.Length / 5;
		time = Mathf.Clamp(timeToShowSubtitle, 2, 15);
		ShowSubtitle(s, time);
	}

	public static void ShowSubtitle(string s, float timeToShow) {
		showingSubtitle = true;
		subtitle = s;
		timeToShowSubtitle = timeToShow;
	}
}
