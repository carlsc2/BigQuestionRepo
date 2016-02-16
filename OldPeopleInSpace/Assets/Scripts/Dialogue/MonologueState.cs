using UnityEngine;
using System.Collections;

public class MonologueState : StateMachineBehaviour {

	private MonologueControl self;
	public string monologueText;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//called on the first frame of the state being played
		self = animator.GetComponent<MonologueControl>();
		if (!monologueText.Equals("")) {
			self.monologuebox.SetActive(true);
			self.get_textbox().text = monologueText;
		}

	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//called after MonoBehaviour Updates on every frame whilst the animator is playing the state this behaviour belongs to
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//called on the last frame of a transition to another state.

		//trigger other to speak
		self.monologuebox.SetActive(false);


		if (animator.GetBool("speak")) {
			self.Interrupt();
		}
		else {
			if (self.other) self.other.Speak();
			else self.Speak();
		}
		
		

		
	}

	//override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
		//self.Interrupt();	
	//}

	
}
