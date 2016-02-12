using UnityEngine;
using System.Collections;

public class dummyplayer : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown(KeyCode.F)) {
			
		}
	}

	void OnTriggerStay(Collider col) {
		if (col.transform.root.GetComponentInChildren<DialogueControl>()) {
			if (Input.GetKeyDown(KeyCode.E)) {
				col.BroadcastMessage("Interact");
			}
			if (Input.GetKeyDown(KeyCode.F)) {
				col.BroadcastMessage("Interrupt");
			}
		}
	}
	void OnTriggerExit(Collider col) {
		if (col.transform.root.GetComponentInChildren<DialogueControl>()) {
			col.BroadcastMessage("Interrupt");
		}
	}
}
