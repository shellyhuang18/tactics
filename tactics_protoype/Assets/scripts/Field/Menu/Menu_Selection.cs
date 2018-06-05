using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu_Selection : MonoBehaviour {
	private GameObject menu;
	public bool activate_menu;

	int i;
	// Use this for initialization
	void Start () {
		//menu iterator
		i = 0;

		//? menu active 
		activate_menu = false;

		//disable menu (while still having access to its reference)
		gameObject.GetComponent<Image> ().enabled = false;
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("i")) {
			OpenMenu ();
		}
		if (activate_menu) {
			MenuSelection ();
		}
	}

	void MenuSelection(){
		GameObject[] actions = GameObject.FindGameObjectsWithTag ("action");
		GameObject cursor = gameObject.transform.GetChild (0).gameObject;

		if (Input.GetKeyDown ("up")) {
			i = i - 1;
			if (i < 0) {
				i = actions.Length - 1;
			} 
		}		
		if (Input.GetKeyDown ("down")) {
			i = (i+1) % 3;
		}

		cursor.transform.position = new Vector3 (cursor.transform.position.x, actions [i].transform.position.y+10, 0);
	}


	public void OpenMenu(){
		activate_menu = !activate_menu;

		gameObject.GetComponent<Image> ().enabled = activate_menu;
		foreach (Transform child in transform) {
			child.gameObject.SetActive (activate_menu);
		}
	}



}
