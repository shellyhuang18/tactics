using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu_Selection : MonoBehaviour {
	private GameObject menu;
	public bool activate_menu;
	private GameObject selector;

	int i;
	// Use this for initialization
	void Start () {
		selector = GameObject.Find ("Selector");

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
		if (selector.GetComponent<Selector_Behavior>().curr_char != null && activate_menu) {
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
			i = (i + 1) % 3;
		}
			
		cursor.transform.position = new Vector3 (cursor.transform.position.x, actions [i].transform.position.y + 10, 0);


		//move
		if (i == 0 && Input.GetKeyDown ("d")) {
					
			selector.GetComponent<Selector_Behavior> ().curr_char.GetComponent<Move> ().DisplayMoveRange ();
			CloseMenu ();
					
		}
		/*//act
			else if (i == 1 && Input.GetKeyDown("d")) {

			} 
			//wait
			else if (i == 2 && Input.GetKeyDown("d")) {

			}*/
		
	}
	public void CloseMenu(){
		activate_menu = false;

		gameObject.GetComponent<Image> ().enabled = false;
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}
	}

	public void OpenMenu(){
		activate_menu = true;
		gameObject.GetComponent<Image> ().enabled = true;
		foreach (Transform child in transform) {
			child.gameObject.SetActive (true);
		}




	}



}
