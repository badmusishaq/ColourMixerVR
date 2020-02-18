using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColourMix;

public class GameController : MonoBehaviour {

	public GameObject finalCube;
	public static int clicks = 0;

	public static GameObject firstBox;
	public static GameObject secondBox;

	public static cube.ColorCode firstColour;
	public static cube.ColorCode secondColour;

	private AudioSource audiosource;


	void Start(){
		audiosource = GetComponent<AudioSource>();
	}


	// Use this for initialization
	void Update(){
		if (clicks == 2) {
			iTween.MoveTo (firstBox, iTween.Hash ("position", secondBox.transform, "time", 2, "easetype", iTween.EaseType.easeOutCubic, "oncompletetarget", gameObject, "oncomplete", "DetermineColour2"));
			clicks = 0;
		}
	}

	void Die(){
		Debug.Log ("I was called");
	}

	void DetermineColour2(){
		Material firstMaterial, secondMaterial;
		firstMaterial = firstBox.GetComponent<Renderer> ().material;
		secondMaterial = secondBox.GetComponent<Renderer> ().material;
		ColourMixer.RGBColour firstColor, secondColor, finalColor;
		firstColor = new ColourMixer.RGBColour (firstMaterial.color.r, firstMaterial.color.g, firstMaterial.color.b);
		secondColor = new ColourMixer.RGBColour (secondMaterial.color.r, secondMaterial.color.g, secondMaterial.color.b);
		finalColor = ColourMixer.Mixer (firstColor, secondColor);

		GameObject[] remainingBox = GameObject.FindGameObjectsWithTag ("defaultBox");
		foreach (GameObject g in remainingBox) {
			g.SetActive (false);
		}

		Instantiate (finalCube, new Vector3 (-90, 10, -5), Quaternion.identity);
		audiosource.Play ();

		Color colourF = new Color();
		colourF.r = finalColor.r;
		colourF.g = finalColor.g;
		colourF.b = finalColor.b;
		colourF.a = 1;
		finalCube.GetComponent<Renderer>().sharedMaterial.color = colourF;
	}

	/*void DetermineColour(){
		cube.ColorCode initialColour = firstColour;
		cube.ColorCode finalColour = secondColour;
		firstBox.SetActive (false);
		secondBox.SetActive (false);
		if (initialColour == cube.ColorCode.blue) {
			switch (finalColour) {
			case cube.ColorCode.red:
				Instantiate (purple, new Vector3 (1, 5, 1), Quaternion.identity);
				audiosource.Play ();
				break;
			case cube.ColorCode.yellow:
				Instantiate (green, new Vector3 (1, 5, 1), Quaternion.identity);
				audiosource.Play ();
				break;
				}
		}
		else if (initialColour == cube.ColorCode.red){
			switch (finalColour) {
			case cube.ColorCode.blue:
				Instantiate (purple, new Vector3 (1, 5, 1), Quaternion.identity);
				audiosource.Play ();
				break;
			case cube.ColorCode.yellow:
				Instantiate (orange, new Vector3 (1, 5, 1), Quaternion.identity);
				audiosource.Play ();
				break;
		}
			}
		else if (initialColour == cube.ColorCode.yellow){
			switch (finalColour) {
			case cube.ColorCode.blue:
				Instantiate (green, new Vector3 (1, 5, 1), Quaternion.identity);
				audiosource.Play ();
				break;
			case cube.ColorCode.red:
				Instantiate (orange, new Vector3 (1, 5, 1), Quaternion.identity);
				audiosource.Play ();
				break;
			}
					
		}
	}*/


}