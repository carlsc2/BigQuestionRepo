using UnityEngine;

public class faceplayer : MonoBehaviour {

	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
			                                              Quaternion.LookRotation(transform.position - player.position).eulerAngles.y,
			                                              transform.rotation.z));
	}
}
