using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCube : MonoBehaviour {


	public Transform redCube;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		iTween.MoveTo (gameObject, iTween.Hash ("position",redCube, "speed", 5, "easetype", iTween.EaseType.easeInCubic,  "oncomplete", "Die"));
		iTween.ColorTo (gameObject, iTween.Hash ("time", 10, "g"));
	}
	void onYellowCubeClicked(){
		
	}

	void Die(){
		Destroy(gameObject);
	}
}
