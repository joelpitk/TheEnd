using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	private Texture2D crosshair;

	// Use this for initialization
	void Start () {
		crosshair = new Texture2D(2, 2);
		for(int y = 0; y < 2; y++) {
			for(int x = 0; x < 2; x++) {
				crosshair.SetPixel(x, y, Color.white);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) / 2, crosshair.width, crosshair.height), crosshair);
	}
}