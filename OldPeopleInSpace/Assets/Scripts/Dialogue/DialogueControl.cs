using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Animator))]
public class DialogueControl : MonoBehaviour {

	//manage the dialogue of an NPC

	private Animator anim;

	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	void Interact() {
		anim.SetTrigger("speak");
	}

	void Interrupt() {
		anim.SetTrigger("stop");
	}

}
