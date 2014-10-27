using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	private static float hunger;
	private static ThirstManager thirst;
	private static float sanity;
	private static float energy;
	private static float drunkness;

	public static float Hunger {
		get { return hunger; }
	}

	public static ThirstManager Thirst {
		get { return thirst; }
	}

	public static float Sanity {
		get { return sanity; }
	}

	public static float Energy {
		get { return energy; }
	}

	public static float Drunkness {
		get { return drunkness; }
		set { drunkness = value; }
	}

	// Use this for initialization
	void Start () {
		hunger = 1f;
		thirst = GetComponent<ThirstManager>();
		sanity = 1f;
		energy = 1f;
		drunkness = 0f;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
