using UnityEngine;
using System.Collections;

public class SubtitleManager : MonoBehaviour {
	public GUISkin subtitleSkin;

	private static bool showingTelevisionSubtitle;
	private static string televisionSubtitle;
	private static Transform televisionSubtitleSource;
	private static float televisionVolume;

	private static bool showingTelephoneSubtitle;
	private static string telephoneSubtitle;
	private static Transform telephoneSubtitleSource;

	// Use this for initialization
	void Start () {
		showingTelephoneSubtitle = false;
		showingTelevisionSubtitle = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	private bool ShowingSubtitle() {
		return showingTelephoneSubtitle || showingTelevisionSubtitle;
	}

	void OnGUI() {
		if(ShowingSubtitle()) {
			// Telephone subtitles trump television subtitles
			if(showingTelephoneSubtitle) {
				float telephoneSoundRadius = 2.6f;
				float dstTelephone = Vector3.Distance(gameObject.transform.position, telephoneSubtitleSource.position);
				if(dstTelephone <= telephoneSoundRadius) {
					GUI.skin = subtitleSkin;
					GUI.Label(new Rect(10, Screen.height-160, Screen.width-20, 150), telephoneSubtitle);
					return;
				}
			}

			if(showingTelevisionSubtitle) {
				float televisionSoundRadius = televisionVolume * 12f;
				float dstTelevision = Vector3.Distance(gameObject.transform.position, televisionSubtitleSource.position);
				if(dstTelevision <= televisionSoundRadius) {
					GUI.skin = subtitleSkin;
					GUI.Label(new Rect(10, Screen.height-160, Screen.width-20, 150), televisionSubtitle);
				}
			}
		}
	}

	public static void ShowTelephoneSubtitle(string s, Transform source) {
		showingTelephoneSubtitle = true;
		telephoneSubtitle = s;
		telephoneSubtitleSource = source;
	}
	public static void StopTelephoneSubtitle() {
		showingTelephoneSubtitle = false;
	}

	public static void ShowTelevisionSubtitle(string s, Transform source, float volume) {
		showingTelevisionSubtitle = true;
		televisionSubtitle = s;
		televisionSubtitleSource = source;
		televisionVolume = volume;
	}
	public static void StopTelevisionSubtitle() {
		showingTelevisionSubtitle = false;
	}
}
