using UnityEngine;
using System.Collections;

public class DialogueFollow : StateMachineBehaviour {

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//called on the last frame of a transition to another state.

		animator.transform.root.GetComponentInChildren<Follower>().enabled = true;
	}

}
