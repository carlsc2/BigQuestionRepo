using UnityEngine;
using System.Collections;

public class PlotEventTrigger : MonoBehaviour {

	public Transform waypoint;

	private bool started = false;
	private bool bowstarted = false;
	private Follower follower;
	private NavMeshAgent agent;
	private float bowstart;
	public float bowtime = 5f;
	public int numbows = 3;
	private int bownum = 0;
	private bool in_position = false;

	void OnTriggerEnter(Collider col) {
		if (!started) {
			if (col.transform.root.tag == "oldman") {
				print("PLOT EVENT TRIGGER");
				follower = col.transform.root.GetComponent<Follower>();
				follower.stay_put = true;
				agent = col.transform.root.GetComponent<NavMeshAgent>();
				agent.SetDestination(waypoint.position);
				started = true;
			}
		}
	}

	void Update() {
		if (started) {
			//get in position
			if (!in_position) {
				print("navigating");
				
				agent.ResetPath();
				agent.SetDestination(waypoint.position);
				if ((agent.transform.position - waypoint.position).magnitude < 1) {
					//reached target, begin bowing
					agent.Stop();
					in_position = true;
				}
			}
			else {
				//start bowing
				if (bownum < numbows) {
					if (bowstarted) {
						if (Time.time - bowstart > bowtime) {
							//end bowing
							follower.anim.SetBool("bowing", false);
							bownum++;
							bowstarted = false;

							if(bownum == numbows) {
								agent.Resume();
								follower.stay_put = false;
								//set global state
								follower.transform.Find("dialogue").GetComponent<Animator>().SetInteger("globalstate", 2);
								DialogueControl.globalstate = 2;
							}

						}
					}
					else {
						bowstart = Time.time;
						follower.anim.SetBool("bowing", true);
						bowstarted = true;
					}
				}
			}
		}	
	}
}
