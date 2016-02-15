using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Elevator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter(Collider c)
    {

    }

    public void LoadRoom(string sceneName)
    {
        SceneManager.LoadSceneAsync("Scenes/" + sceneName);
    }
}
