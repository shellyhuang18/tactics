using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class Selector_Behavior : MonoBehaviour {

	GameObject raycast_hit;
	Color raycast_hit_color;
	bool has_moved;

	int ray_count;
	// Use this for initialization
	void Start () {
		has_moved = false;
		ray_count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		HighlightBlock ();
	}



	void HighlightBlock(){
		RaycastHit hit;

		//if there is a block under selector, highlight the block
		// ~(1 >> 7) everything except layer 7


		int layer_mask = LayerMask.GetMask ("field");
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.down), out hit, Mathf.Infinity, layer_mask)) {
			
			if (has_moved && (raycast_hit_color != null)) {
				Debug.Log ("moved");
				raycast_hit.GetComponent<Renderer> ().material.color = raycast_hit_color;
				ray_count = 0;
			}

			//on first raycast hit an object so color stored is original color (not color it was just chhanged to)
			if (ray_count == 0) {
				raycast_hit = hit.collider.gameObject;
				raycast_hit_color = raycast_hit.GetComponent<Renderer> ().material.color;
			}

			ray_count++;
			hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;

		}

	}

	void Move(){
		bool moveLeft = Input.GetKeyUp ("left");
		bool moveRight = Input.GetKeyUp ("right");
		bool moveUp = Input.GetKeyUp ("up");
		bool moveDown = Input.GetKeyUp ("down");

		Vector3 pos = GetComponent<Rigidbody> ().position;
		if (moveLeft) {
			GetComponent<Rigidbody> ().transform.position = new Vector3 (pos.x - 1, pos.y, pos.z);
			has_moved = true;
		} else if (moveRight) {
			GetComponent<Rigidbody> ().transform.position = new Vector3 (pos.x + 1, pos.y, pos.z);
			has_moved = true;
		} else if (moveUp) {
			GetComponent<Rigidbody> ().transform.position = new Vector3 (pos.x, pos.y, pos.z + 1);
			has_moved = true;
		} else if (moveDown) {
			GetComponent<Rigidbody> ().transform.position = new Vector3 (pos.x, pos.y, pos.z - 1);
			has_moved = true;
		} else { 
			has_moved = false;
		}
	}
}
