using UnityEngine;
using System.Collections;

public class PlotEventTrigger3 : MonoBehaviour {

	public Transform waypoint;

	private bool started = false;
	private Follower follower;
	private NavMeshAgent agent;
	private bool in_position = false;

	public bool ready = false;


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
		if (started && !ready) {
			//get in position
			if (!in_position) {
				agent.SetDestination(waypoint.position);
				if ((agent.transform.position - waypoint.position).magnitude < 1) {
					//reached target, begin talking to family
					agent.Stop();
					follower.enabled = false;
					in_position = true;
				}
			}
			else {
				agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.identity, .2f);
				if(Quaternion.Angle(agent.transform.rotation, Quaternion.identity) < 2) {
					ready = true;
				}
			}
		}	
	}
}
