using UnityEngine;
using System.Collections;

public class dummyplayer : MonoBehaviour {

	public GameObject uiprompt;
	private Quaternion targetRotation;
	private bool looking = false;

	void Update() {
		if (Input.GetKeyDown(KeyCode.F)) {
			
		}
	}

	void LateUpdate() {
		if (looking) {
			//transform.root.LookAt(target);
			
			transform.root.rotation = Quaternion.Slerp(transform.root.rotation, targetRotation, Time.deltaTime * 2f);
			if (Quaternion.Angle(transform.root.rotation, targetRotation) < 2) {
				GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().reset_camera();
				looking = false;
			}

		}
		
	}

	void OnTriggerStay(Collider col) {
		if (col.transform.root.GetComponentInChildren<DialogueControl>()) {
			if (Input.GetKeyDown(KeyCode.E)) {
				col.BroadcastMessage("Interact");
				uiprompt.SetActive(false);

				targetRotation = Quaternion.LookRotation(col.transform.position - transform.root.position);
				looking = true;

			}
			if (Input.GetKeyDown(KeyCode.F)) {
				col.BroadcastMessage("Interrupt");
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.transform.root.GetComponentInChildren<DialogueControl>()) {
			uiprompt.SetActive(true);
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.transform.root.GetComponentInChildren<DialogueControl>()) {
			col.BroadcastMessage("Interrupt");
			uiprompt.SetActive(false);
		}
	}
}
