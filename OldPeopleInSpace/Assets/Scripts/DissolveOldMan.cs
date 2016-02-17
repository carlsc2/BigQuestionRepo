using UnityEngine;
using System.Collections;

public class DissolveOldMan : MonoBehaviour {

	public SkinnedMeshRenderer head, body;
	private Material headmat, bodymat;
	public float dissolvetime = 2f;


	// Use this for initialization
	void Start () {
		headmat = head.material;
		bodymat = body.material;
		StartCoroutine(dissolve());
	}
	
	// Update is called once per frame
	IEnumerator dissolve () {
		for(float i=0; i < 100; i++) {
			headmat.SetFloat("_DissolveIntensity", i / 50);
			bodymat.SetFloat("_DissolveIntensity", i / 50);
			yield return new WaitForSeconds(dissolvetime/100);
		}
		
	}
}
