using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chara = Character;

public class Move : MonoBehaviour {
	private int move_range;
	private int x_center;
	private int y_center;

	Chara selected_char;
	// Use this for initialization
	void Start () {
		move_range = 1;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DisplayRange(){
		//(x−h)^2+(y−k)^2=r^2
		selected_char = GameObject.Find("selector").GetComponent<Selector_Behavior> ().selected_char;

		//reference selected character's center on map (for (h,k) )
		x_center = (int)selected_char.char_gameobj.transform.position.x;
		y_center = (int)selected_char.char_gameobj.transform.position.y;

		move_range = selected_char.getMove ();

	}

}
	