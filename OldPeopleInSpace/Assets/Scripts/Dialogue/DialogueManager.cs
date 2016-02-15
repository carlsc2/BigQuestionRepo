using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

//The master dialogue control script

public class DialogueManager : Singleton<DialogueManager> {
	protected DialogueManager() { } // guarantee this will be always a singleton only - can't use the constructor!

	public Text dialogueTextBox;
	public GameObject dialogueUIObject;
	public RectTransform responseBox;
	public GameObject responseButtonPrefab;
	public Text namebox;

	private List<GameObject> buttons;

	// Use this for initialization
	void Start() {
		buttons = new List<GameObject>();
	}

	public void set_name(string name) {
		namebox.text = name;
	}


	public void setDialogue(DialogueState state, Animator animator) {
		dialogueUIObject.SetActive(true);
		//destroy all previously created buttons
		foreach (GameObject g in buttons) {
			Destroy(g);
		}
		buttons.RemoveAll((o) => o == null);

		//set the new text
		dialogueTextBox.text = state.dialogueText;

		//generate responses

		float yoffset = 0;
		for (int i=0; i<state.responses.Length; i++) {
			//set dialogue text
			string response = state.responses[i];
			GameObject responsebutton = Instantiate(responseButtonPrefab) as GameObject;
			buttons.Add(responsebutton);
			Text rtext = responsebutton.GetComponentInChildren<Text>();
			rtext.text = response;
			//resize buttons to fit response
			RectTransform rt = responsebutton.GetComponent<RectTransform>();
			rt.SetParent(responseBox, false);
			Vector2 tmp = rt.sizeDelta;
			tmp.y = rtext.preferredHeight + 10;//add 10 for padding
			rt.sizeDelta = tmp;
			rt.localPosition = new Vector3(0, -(tmp.y / 2) - yoffset, 0);
			yoffset += tmp.y;
			//rescale the content box for the scrollbars
			tmp = responseBox.sizeDelta;
			tmp.y = yoffset;
			responseBox.sizeDelta = tmp;
			int tmp2 = i + 1; // need to capture value of variable before passing to delegate
			responsebutton.GetComponent<Button>().onClick.AddListener(() => { animator.SetInteger("optionselect", tmp2); });
		}

		GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void endDialogue() {
		//destroy all previously created buttons
		foreach (GameObject g in buttons) {
			Destroy(g);
		}
		buttons.RemoveAll((o) => o == null);
		dialogueTextBox.text = "";
		dialogueUIObject.SetActive(false);

		GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;

	}

}
