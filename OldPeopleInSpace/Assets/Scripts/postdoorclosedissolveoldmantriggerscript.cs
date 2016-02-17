using UnityEngine;
using System.Collections;

public class postdoorclosedissolveoldmantriggerscript : StateMachineBehaviour {

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//called on the last frame of a transition to another state.
		GameObject oldman = GameObject.FindGameObjectWithTag("oldman");
		oldman.GetComponentInChildren<Follower>().anim.gameObject.SetActive(false);
		DissolveOldMan tmpm = oldman.GetComponentInChildren<DissolveOldMan>(true);
		tmpm.gameObject.SetActive(true);
		tmpm.riperoni();
	}
}
