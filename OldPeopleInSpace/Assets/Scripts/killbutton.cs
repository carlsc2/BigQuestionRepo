using UnityEngine;
using System.Collections;

public class killbutton : MonoBehaviour {

	public Animator anim;

	public PlotEventTrigger3 pevt;

	void Interact() {
		if (pevt.ready) {
			anim.SetTrigger("closedoor");
		}
	}
}
