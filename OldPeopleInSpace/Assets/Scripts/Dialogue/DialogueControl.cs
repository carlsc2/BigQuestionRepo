using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

//The master dialogue control script

public class DialogueControl : Singleton<DialogueControl> {
	protected DialogueControl() { } // guarantee this will be always a singleton only - can't use the constructor!

	public Text dialogueTextBox;
	public RectTransform responseBox;
	public GameObject responseButtonPrefab;

	private float buttonheight;
	private List<GameObject> buttons;

	// Use this for initialization
	void Start() {
		buttons = new List<GameObject>();
		buttonheight = responseButtonPrefab.GetComponent<RectTransform>().rect.height;
	}


	public void setDialogue(DialogueState state, Animator animator) {

		//destroy all previously created buttons
		foreach(GameObject g in buttons) {
			Destroy(g);
		}
		buttons.RemoveAll((o) => o == null);

		//set the new text
		dialogueTextBox.text = state.dialogueText;

		//generate responses
		for (int i=0; i<state.responses.Length; i++) {
			string response = state.responses[i];
			GameObject responsebutton = Instantiate(responseButtonPrefab) as GameObject;
			buttons.Add(responsebutton);
			responsebutton.GetComponentInChildren<Text>().text = response;
			RectTransform rt = responsebutton.GetComponent<RectTransform>();
			rt.SetParent(responseBox, false);
			rt.localPosition = new Vector3(0, -(buttonheight * i) - buttonheight/2, 0);
			int tmp = i + 1; // need to capture value of variable before passing to delegate
			responsebutton.GetComponent<Button>().onClick.AddListener(() => { animator.SetInteger("optionselect", tmp); });
		}
	}



	
	
	// Update is called once per frame
	void Update () {
	
	}
}
