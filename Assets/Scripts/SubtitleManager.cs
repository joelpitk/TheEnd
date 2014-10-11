using UnityEngine;
using System.Collections;

public class SubtitleManager : MonoBehaviour {
	public GUISkin subtitleSkin;

	private static bool showingSubtitle;
	private static float timeToShowSubtitle;

	private static string subtitle;
	private static Transform subtitleSource;
	private static float subtitleRadius;

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
			float dst = Vector3.Distance(gameObject.transform.position, subtitleSource.position);
			if(dst <= subtitleRadius) {
				GUI.skin = subtitleSkin;
				GUI.Label(new Rect(10, Screen.height-160, Screen.width-20, 150), subtitle);
			}
		}
	}

	public static void ShowSubtitle(string s, float timeToShow, Transform source, float radius) {
		showingSubtitle = true;
		subtitle = s;
		timeToShowSubtitle = timeToShow;
		subtitleSource = source;
		subtitleRadius = radius;
	}
}
