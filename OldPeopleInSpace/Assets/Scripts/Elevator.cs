using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour {
	public static void LoadRoom(string sceneName){
		SceneManager.LoadSceneAsync("Scenes/" + sceneName);
	}

	public static void reset_game() {
		SceneManager.LoadScene(0);
	}
}
