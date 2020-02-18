using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {
	private AudioSource audiosource;

	public ColorCode code;

	public GameObject player;

	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource> ();

		GetComponent<Renderer> ().material.color = Random.ColorHSV ();
	}
	
	// Update is called once per frame
	void Update (){
	//	transform.Rotate (transform.position.x, Time.deltaTime, transform.position.z, Space.World);

	}

	public void Clicked(){
		GameObject box = null;
		RaycastHit hit;
		if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 100)){
			box = hit.transform.gameObject;
			Debug.Log (box.name);
		}
		if (GameController.clicks == 0) {
			GameController.clicks = 1;
			GameController.firstBox = box;
			box.transform.localScale += new Vector3 (1f, 1f, 1f);
			audiosource.Play ();
		} else if (GameController.clicks == 1) {
			GameController.clicks = 2;
			GameController.secondBox = box;
			audiosource.Play ();
		}
			
	}

	public enum ColorCode{ blue, red, yellow, green, purple, orange

	};
}
