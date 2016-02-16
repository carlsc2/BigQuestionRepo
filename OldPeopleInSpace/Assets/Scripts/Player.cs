using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

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
			
			Quaternion newrot = Quaternion.Slerp(transform.root.rotation, targetRotation, Time.deltaTime * 2f);
			transform.root.rotation = Quaternion.Euler(new Vector3(0,newrot.eulerAngles.y,0));
			transform.parent.localRotation = Quaternion.Slerp(transform.parent.localRotation, Quaternion.identity, Time.deltaTime * 2f);
			if (Quaternion.Angle(transform.root.rotation, targetRotation) < 2 && Quaternion.Angle(transform.parent.localRotation, Quaternion.identity) < 2) {
				GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().reset_camera();
				looking = false;
			}

		}
		
	}

	void OnTriggerStay(Collider col) {
		if (col.transform.root.GetComponentInChildren<DialogueControl>()) {
			if (Input.GetKeyDown(KeyCode.E)) {
				col.transform.root.BroadcastMessage("Interact");
				uiprompt.SetActive(false);

				targetRotation = Quaternion.LookRotation(col.transform.position - transform.root.position);
				looking = true;

			}
			if (Input.GetKeyDown(KeyCode.Escape)) {
				col.transform.root.BroadcastMessage("Interrupt");
				looking = false;
				GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().reset_camera();
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
			//col.BroadcastMessage("Interrupt");
			uiprompt.SetActive(false);
		}
	}
}
