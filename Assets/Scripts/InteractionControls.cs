using UnityEngine;
using System.Collections;

public class InteractionControls : MonoBehaviour {
	private bool carrying = false;
	private GameObject carriedObject;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate() {
		if(carrying) {
			// Make the item float at the front of the camera
			carriedObject.rigidbody.velocity = Vector3.zero;
			Vector3 carrySpot = Camera.main.transform.position + Camera.main.transform.forward * 2;
			carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, carrySpot, Time.deltaTime * 2);

			// Make the item not rotate
			carriedObject.rigidbody.angularVelocity = Vector3.zero;
		}
	}

	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			HandleInteraction();
		}
		else if(Input.GetMouseButtonDown(1)) {
			if(carrying) {
				HandleDrop();
			}
			else {
				HandlePickup();
			}
		}
	}

	private void HandleInteraction() {
		RaycastHit hit;
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		
		// Player is layer 8, don't hit player. :)
		int mask = 127;
		
		if(Physics.Raycast(ray, out hit, 5f, mask)) {
			Interaction i = hit.collider.gameObject.GetComponent<Interaction>();
			if(i != null) {
				// Whee, can interact!
				i.Activate(gameObject, null);
			}
		}
	}

	private void HandleDrop() {
		carrying = false;
		carriedObject.transform.parent = null;
		carriedObject.rigidbody.useGravity = true;
		carriedObject = null;
		return;
	}
	
	private void HandlePickup() {
		RaycastHit hit;
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		
		// Player is layer 8, don't hit player. :)
		int mask = 127;
		
		if(Physics.Raycast(ray, out hit, 5f, mask)) {
			if(hit.collider.gameObject.rigidbody == null) {
				// No rigidbody, no carrying.
				return;
			}
			
			float mass = hit.collider.gameObject.rigidbody.mass;
			// TODO: Add some cool calculations of player's strength and energy or something here
			float maxCarryWeight = 40f;

			if(mass <= maxCarryWeight) {
				carrying = true;
				carriedObject = hit.collider.gameObject;
				carriedObject.transform.parent = Camera.main.transform;
				carriedObject.rigidbody.useGravity = false;
			}
		}
	}
}
