using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class Player_Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		bool moveLeft = Input.GetKeyUp ("left");
		bool moveRight = Input.GetKeyUp ("right");
		bool moveUp = Input.GetKeyUp ("up");
		bool moveDown = Input.GetKeyUp ("down");
		Vector3 pos = GetComponent<Rigidbody> ().position;
		if (moveLeft) 
			GetComponent<Rigidbody> ().transform.position = new Vector3 (pos.x + 1, pos.y, pos.z);
		else if(moveRight)
			GetComponent<Rigidbody> ().transform.position = new Vector3 (pos.x -1, pos.y, pos.z);
		else if(moveUp)
			GetComponent<Rigidbody> ().transform.position = new Vector3 (pos.x, pos.y, pos.z+1);
		else if(moveDown)
			GetComponent<Rigidbody> ().transform.position = new Vector3 (pos.x, pos.y, pos.z-1);
	}
}
