using UnityEngine;
using System.Collections;

public class GlobalDialogueStateChange : StateMachineBehaviour {

	public int new_state_index;

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//called on the last frame of a transition to another state.

		//set global state index
		animator.SetInteger("globalstate", new_state_index);
		DialogueControl.globalstate = new_state_index;
	}

}
