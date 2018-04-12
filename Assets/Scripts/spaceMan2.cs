using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMan2 : MonoBehaviour {
	public bool next;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
		if(newVoice.count==3)
		anim.SetTrigger ("run");
		if(newVoice.count==3 && transform.position.z <= 27.8){
			transform.Translate (0, 0, 0.05F);
		} else {
			anim.ResetTrigger ("run");
			//newVoice.count = 0;
			anim.SetTrigger ("stop");
		}
	}
}
