using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

	public float stoppingRadius = 5f;

	public bool stay_put = false;

	NavMeshAgent agent;
	GameObject player;
	public Animator anim;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update() {
		anim.SetFloat("speed", agent.velocity.magnitude);
		if (!stay_put) {
			agent.SetDestination(player.transform.position);
			if ((transform.position - player.transform.position).magnitude < stoppingRadius) {
				agent.Stop();
			}
			else {
				agent.Resume();
			}
		}
		
	}
}
