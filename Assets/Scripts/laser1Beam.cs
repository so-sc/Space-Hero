using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser1Beam : MonoBehaviour {
	LineRenderer laser;
	public static bool center;
	GameObject aliens;
	// Use this for initialization
	void Start () {
		laser = gameObject.GetComponent<LineRenderer> ();
		laser.enabled = false;
		center = false;
	}

	// Update is called once per frame
	void Update () {
		if (center) {
			StopCoroutine ("fire");
			StartCoroutine ("fire");
		}
	}
	IEnumerator fire () {
		laser.enabled = true;
		while (center) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			laser.SetPosition (0, ray.origin);
			if (Physics.Raycast (ray, out hit, 100)) {
				laser.SetPosition (1, hit.point);
				if (hit.rigidbody) {
					//hit.rigidbody.AddForceAtPosition (transform.forward * 50, hit.point);
					aliens = hit.rigidbody.gameObject;
					score.playerScore += 10;
					//Debug.Log (aliens);
					Invoke ("del", 0.5f);
				}
			}
			else
				laser.SetPosition (1, ray.GetPoint (100));
			yield return null;
		}
		laser.enabled = false;
	}
	void del(){
		if (aliens != null) {
			if(alien.level !=3)
				newVoice.count += 1;
			Destroy (aliens);
			aliens = null;
		}
	}
}
