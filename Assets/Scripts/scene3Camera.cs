using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.SceneManagement;

public class scene3Camera : MonoBehaviour {
	public GameObject enemy;
	public static int count = 0;
	KeywordRecognizer keyRecg;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	Vector3 pos;
	Quaternion rot;

	// Use this for initialization
	void Start () {
		keywords.Add ("left", () => {
			shootLeft();
		});
		keywords.Add ("right", () => {
			shootRight();
		});
		keywords.Add ("center", () => {
			shootCenter();
		});

		keyRecg = new KeywordRecognizer (keywords.Keys.ToArray());
		keyRecg.OnPhraseRecognized += keywordRecognozerOnPhraseRecognized;
		keyRecg.Start ();

		pos = new Vector3(-5F, 0.65F, 16.7F);
		rot = Quaternion.Euler (0, 0, 0);
		Invoke ("spawn",4F);
		Invoke ("spawn",30F);

	}

	void keywordRecognozerOnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;

		if (keywords.TryGetValue (args.text, out keywordAction)) {
			keywordAction.Invoke ();
		}
	}

	// Update is called once per frame
	void Update () {
		if(newVoice.count==20 && transform.position.z <= 20){
			transform.Translate (0, 0, 0.045F);
		}
		if (transform.position.z >= 20) {
			SceneManager.LoadScene("scene3", LoadSceneMode.Single);
			Debug.Log ("new Scene");
		}

	}

	void shootLeft()
	{
		print ("Shoot left!");
		laserBeam.left = true;
		Invoke ("off", 0.2F);

	}

	void shootRight()
	{
		print ("Shoot Right!");
		laser2Beam.right = true;
		Invoke ("off", 0.2F);
	}

	void shootCenter()
	{
		print ("Shoot Center!");
		laser1Beam.center = true;
		Invoke ("off", 0.2F);	
	}
	void off(){
		laserBeam.left = false;
		laser1Beam.center = false;
		laser2Beam.right = false;
	}

	void spawn(){
		
		for (int i = 0; i < 10; i++,i++,i++) {
			pos.z += i;
			Instantiate (enemy, pos, rot);
			pos.x = -0.18F;
			pos.z += ++i;;
			Instantiate (enemy, pos, rot);
			pos.x = 5.26F;
			pos.z += i;
			Instantiate (enemy, pos, rot);
		}
	}
}
