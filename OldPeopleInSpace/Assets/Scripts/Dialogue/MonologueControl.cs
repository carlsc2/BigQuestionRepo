using UnityEngine;
using UnityEngine.UI;

public class MonologueControl : MonoBehaviour {

	private Text textbox;
	public GameObject monologuebox;
	private Animator anim;
	public MonologueControl other;

	void Awake() {
		anim = GetComponent<Animator>();
		textbox = monologuebox.GetComponentInChildren<Text>();
	}

	public Text get_textbox() {
		return textbox;
	}

	public void Speak() {
		anim.SetTrigger("next");
	}

	public void BeginMonologue() {
		anim.SetTrigger("begin");
	}

	public void Stop() {
		anim.SetTrigger("stop");
	}

	public void Interrupt() {
		if (other) other.Stop();
	}

}
