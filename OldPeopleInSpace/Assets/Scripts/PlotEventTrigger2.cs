using UnityEngine;
using System.Collections;

public class PlotEventTrigger2 : MonoBehaviour {

	public Transform waypoint;

	private bool started = false;
	private Follower follower;
	private NavMeshAgent agent;
	private bool in_position = false;

	private Animator anim;

	private bool speaking = false;

	public MonologueControl oldmanmc;

	public MonologueControl kidmc;

	private bool done = false;

	//void Awake() {
	//	DialogueControl.globalstate = 2;
	//}


	void OnTriggerEnter(Collider col) {
		if (DialogueControl.globalstate == 2 && !started) {
			if (col.transform.root.tag == "oldman") {
				print("PLOT EVENT TRIGGER");
				follower = col.transform.root.GetComponent<Follower>();
				follower.stay_put = true;
				agent = col.transform.root.GetComponent<NavMeshAgent>();
				agent.SetDestination(waypoint.position);
				started = true;
				anim = follower.transform.Find("dialogue").GetComponent<Animator>();
			}
		}
	}

	void Update() {
		if (started && !done) {
			//get in position
			if (!in_position) {
				agent.SetDestination(waypoint.position);
				if ((agent.transform.position - waypoint.position).magnitude < 1) {
					//reached target, begin talking to family


					agent.Stop();
					in_position = true;

					oldmanmc.other = kidmc;
					kidmc.other = oldmanmc;

					oldmanmc.Speak();
				}
			}
			else {
				if(anim.GetInteger("globalstate") == 3) {
					agent.Resume();
					follower.stay_put = false;
					done = true;
				}
			}
		}	
	}
}
