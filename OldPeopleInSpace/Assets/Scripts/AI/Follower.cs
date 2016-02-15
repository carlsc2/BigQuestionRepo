using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

    public float stoppingRadius = 5f;

    NavMeshAgent agent;
    GameObject player;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update() {
        agent.SetDestination(player.transform.position);
        if ((transform.position - player.transform.position).magnitude < stoppingRadius) {
            agent.Stop();
        }
        else
        {
            agent.Resume();
        }
    }
}
