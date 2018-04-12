using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.SceneManagement;

public class newVoice : MonoBehaviour {
	public static int level = 1;
	public static int count = 0;
	KeywordRecognizer keyRecg;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

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
		if(newVoice.count==3 && transform.position.z <= 20){
			transform.Translate (0, 0, 0.045F);
			SceneManager.LoadScene("scene2", LoadSceneMode.Single);
		
			//Debug.Log ("new Scene");
		}
		if (transform.position.z >= 20 && alien.level == 2) {
			count = 0;
			SceneManager.LoadScene("scene3", LoadSceneMode.Single);

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

}
