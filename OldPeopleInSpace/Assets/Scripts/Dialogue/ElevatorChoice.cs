using UnityEngine;
using System.Collections;

public class ElevatorChoice : StateMachineBehaviour {

	public string choice;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		DialogueManager.Instance.endDialogue(animator);
		Elevator.LoadRoom(choice);
	}

}
