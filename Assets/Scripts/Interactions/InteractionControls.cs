using UnityEngine;
using System.Collections;

public class InteractionControls : MonoBehaviour {
	private bool carrying = false;
	private GameObject carriedObject;
	public GameObject CarriedObject {
		get {
			return carriedObject;
		}
	}

	public float interactionDistance = 4f;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate() {
		if(carrying) {
			// Make the item float at the front of the camera
			carriedObject.rigidbody.velocity = Vector3.zero;
			Vector3 carrySpot = Camera.main.transform.position + Camera.main.transform.forward * 1.5f + Camera.main.transform.right;
			carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, carrySpot, Time.deltaTime * 2);

			// Make the item not rotate
			carriedObject.rigidbody.angularVelocity = Vector3.zero;
		}
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.E)) {
			HandleInteraction();
		}
		if(Input.GetMouseButtonDown(0)) {
			HandleCarriedInteraction();
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
		
		if(Physics.Raycast(ray, out hit, interactionDistance, mask)) {
			Interaction i = hit.collider.gameObject.GetComponent<Interaction>();
			if(i != null) {
				// Whee, can interact!
				i.Activate(gameObject, carriedObject);
			}
		}
	}

	private void HandleCarriedInteraction() {
		if(carriedObject != null) {
			Interaction i = carriedObject.GetComponent<Interaction>();
			if(i != null) {
				i.Activate(gameObject, null);
			}
		}
	}

	public void HandleDrop() {
		carrying = false;
		carriedObject.transform.parent = null;
		carriedObject.rigidbody.useGravity = true;
		carriedObject = null;
		return;
	}
	
	public void HandlePickup() {
		RaycastHit hit;
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		
		// Player is layer 8, don't hit player. :)
		int mask = 127;
		
		if(Physics.Raycast(ray, out hit, 5f, mask)) {
			SetItemInHand(hit.collider.gameObject);
		}
	}

	public void SetItemInHand(GameObject item) {
		if(item.rigidbody == null) {
			// No rigidbody, no carrying.
			return;
		}
		
		float mass = item.rigidbody.mass;
		// TODO: Add some cool calculations of player's strength and energy or something here
		float maxCarryWeight = 40f;
		
		if(mass <= maxCarryWeight) {
			carrying = true;
			carriedObject = item;
			carriedObject.transform.parent = Camera.main.transform;
			carriedObject.rigidbody.useGravity = false;
		}
	}
}
