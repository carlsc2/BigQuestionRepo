using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Animator))]
public class DialogueControl : MonoBehaviour {

	//manage the dialogue of an NPC

	public string npc_name = "Default";

	private Animator anim;

	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	void Interact() {
		DialogueManager.Instance.set_name(npc_name);
		anim.SetTrigger("speak");
	}

	void Interrupt() {
		anim.SetTrigger("stop");
	}

}
