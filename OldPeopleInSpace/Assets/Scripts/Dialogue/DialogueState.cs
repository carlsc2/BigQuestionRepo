using UnityEngine;
using System.Collections;

public class DialogueState : StateMachineBehaviour {

	public bool idle_state = false;

	public string dialogueText;
	public string[] responses;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//called on the first frame of the state being played

		if (idle_state) {
			//hide UI in idle state
			if (DialogueManager.Instance) {
				DialogueManager.Instance.endDialogue(animator);
			}
			
		}
		else {
			animator.SetBool("speak", false);
			//display options on UI
			DialogueManager.Instance.setDialogue(this, animator);
		}
		
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//called after MonoBehaviour Updates on every frame whilst the animator is playing the state this behaviour belongs to
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//called on the last frame of a transition to another state.

		//reset the options
		animator.SetInteger("optionselect", 0);
	}

	//override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash) {
		//animator.SetBool("speak", false);
	//}
}
