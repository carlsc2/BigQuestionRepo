using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Animator))]
public class DialogueControl : MonoBehaviour {

	//manage the dialogue of an NPC

	public static int globalstate = 0;

	public string npc_name = "Default";

	private Animator anim;

	void Awake () {
		anim = GetComponent<Animator>();
		anim.SetInteger("globalstate", globalstate);
	}
	
	void Interact() {
		DialogueManager.Instance.set_name(npc_name);
		anim.SetTrigger("stop");
		anim.SetBool("speak",true);

	}

	//void Interrupt() {
		//anim.SetTrigger("stop");
	//}

}
