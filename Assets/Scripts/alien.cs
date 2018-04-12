using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class alien : MonoBehaviour {
	public static int level = 1;

	int step=0;
	bool move;
	int r;
	float s=0;
	// Use this for initialization
	void Start () {
		//level = 1;
		move = true;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.z < -6) {
			move = false;
			print ("Game Over");
			SceneManager.LoadScene("mainScene", LoadSceneMode.Single);
		}
		if(level != 1){
			if (step> 100) {
			r = Random.Range (0, 3);
			//r=0;
			//Debug.Log ("R is "+r);
			if (r == 0) {
				if (transform.position.x<5.25) {
					r = 2;

				}
				s = 0.15f;
			}
			else if (r == 2) {
				if (transform.position.x>-5.01) {
					r = 1;

				}
				s = -0.1f;
			}
			else if (r == 1)
				s = 0;
		//	Debug.Log ("R is "+r);
			//Debug.Log ("S is "+s);
			step=0;
		}
		step++;
		float xpos = transform.position.x + s;
		//Debug.Log (step);
		if(xpos<5.25&&xpos>-5.02 && move)
			transform.position = new Vector3(transform.position.x+s, transform.position.y, transform.position.z-0.01F);
		else
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-0.01F);
		//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-0.01F);
		//Debug.Log(transform.position);
	}
	}
}
