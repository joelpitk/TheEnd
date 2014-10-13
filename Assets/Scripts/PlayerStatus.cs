using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	private float hunger;
	private float thirst;
	private float sanity;
	private float energy;

	public float Hunger {
		get { return hunger; }
	}
	public float Thirst {
		get { return thirst; }
	}
	public float Sanity {
		get { return sanity; }
	}
	public float Energy {
		get { return energy; }
	}

	// Use this for initialization
	void Start () {
		hunger = 1f;
		thirst = 1f;
		sanity = 1f;
		energy = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
