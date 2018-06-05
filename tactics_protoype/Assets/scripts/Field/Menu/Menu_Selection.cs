using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu_Selection : MonoBehaviour {
	private GameObject menu;
	public bool activate_menu;

	// Use this for initialization
	void Start () {
		//for pop up menu
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
			Debug.Log ("ffff");
		}
	}

	void MenuSelection(){
		
	}

	public void OpenMenu(){
		activate_menu = !activate_menu;

		gameObject.GetComponent<Image> ().enabled = activate_menu;
		foreach (Transform child in transform) {
			child.gameObject.SetActive (activate_menu);
		}
	}



}
