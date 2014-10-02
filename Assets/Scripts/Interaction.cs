using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Activate(GameObject player, GameObject itemInHand) {
		Debug.Log("Hello I'm the Activate-method of the Interaction class. You should override me.");
	}
}
