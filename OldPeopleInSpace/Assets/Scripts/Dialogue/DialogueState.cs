using UnityEngine;
using System.Collections;

public class DialogueState : StateMachineBehaviour {

	public string dialogueText;
	public string[] responses;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//called on the first frame of the state being played

		//display options on UI
		DialogueControl.Instance.setDialogue(this, animator);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//called after MonoBehaviour Updates on every frame whilst the animator is playing the state this behaviour belongs to
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//called on the last frame of a transition to another state.

		//reset options
		animator.SetInteger("optionselect", 0);
	}
}
