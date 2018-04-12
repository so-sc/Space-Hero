using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBeam : MonoBehaviour {
	LineRenderer laser;
	public static bool left;
	GameObject alien;
	// Use this for initialization
	void Start () {
		laser = gameObject.GetComponent<LineRenderer> ();
		laser.enabled = false;
		left = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (left) {
			StopCoroutine ("fire");
			StartCoroutine ("fire");
		}
	}
	IEnumerator fire () {
		laser.enabled = true;
		while (left) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			laser.SetPosition (0, ray.origin);
			if (Physics.Raycast (ray, out hit, 100)) {
				laser.SetPosition (1, hit.point);
				if (hit.rigidbody) {
					//hit.rigidbody.AddForceAtPosition (transform.forward * 50, hit.point);
					alien = hit.rigidbody.gameObject;
					score.playerScore += 10;
					Invoke ("del", 0.5F);
				}
			}
			else
				laser.SetPosition (1, ray.GetPoint (100));
			yield return null;
		}
		laser.enabled = false;
	}
	void del(){
		if (alien != null) {
			Destroy (alien);
			newVoice.count += 1;
			alien = null;
		}
	}

}
