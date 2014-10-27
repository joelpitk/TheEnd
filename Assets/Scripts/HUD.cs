using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	private Texture2D crosshair;

	// Use this for initialization
	void Start () {
		crosshair = new Texture2D(2, 2);
		for(int y = 0; y < 2; y++) {
			for(int x = 0; x < 2; x++) {
				crosshair.SetPixel(x, y, Color.green);
			}
		}

		crosshair.Apply();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) / 2, crosshair.width, crosshair.height), crosshair);

		DrawTestGUI();
	}

	void DrawTestGUI() {
		GUI.Label(new Rect(10, 10, 300, 30), "Current time: " + WorldClock.Hour + ":" + WorldClock.Minute);
		GUI.Label(new Rect(10, 40, 300, 30), "Power: " + WorldStatus.Electricity);
		GUI.Label(new Rect(10, 70, 300, 30), "Water: " + WorldStatus.Water);

		GUI.Label(new Rect(10, 120, 300, 30), "Hunger: " + PlayerStatus.Hunger);
		GUI.Label(new Rect(10, 150, 300, 30), "Thirst: " + PlayerStatus.Thirst.CurrentThirst);
		GUI.Label(new Rect(10, 180, 300, 30), "Sanity: " + PlayerStatus.Sanity);
		GUI.Label(new Rect(10, 210, 300, 30), "Energy: " + PlayerStatus.Energy);
		GUI.Label(new Rect(10, 240, 300, 30), "Drunkness: " + PlayerStatus.Drunkness);
		GUI.Label(new Rect(10, 270, 300, 30), "Sips had: " + PlayerStatus.Thirst.SipsDrunk);
	}
}