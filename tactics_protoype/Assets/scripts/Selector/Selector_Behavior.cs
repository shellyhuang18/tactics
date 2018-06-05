using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class Selector_Behavior : MonoBehaviour {

	private GameObject raycast_hit;
	private Color raycast_hit_color;

	private bool has_moved;
	private int ray_count;

	GameObject menu;
	// Use this for initialization
	void Awake () {
		has_moved = false;
		ray_count = 0;

		menu = GameObject.Find ("Panel");
	}
	
	// Update is called once per frame
	void Update () {
		if (!menu.GetComponent<Menu_Selection> ().activate_menu) {
			Move ();
		}

		HighlightBlock ();
	}
		

	void DetectObject(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.down), out hit, Mathf.Infinity)) {
			if (hit.collider.gameObject.tag == "character") {

			}
		}
	}


	void HighlightBlock(){
		RaycastHit hit;

		//if there is a block under selector, highlight the block
		// ~(1 >> 7) everything except layer 7


		int layer_mask = LayerMask.GetMask ("field");
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.down), out hit, Mathf.Infinity, layer_mask)) {
			
			if (has_moved && (raycast_hit_color != null)) {
				raycast_hit.GetComponent<Renderer> ().material.color = raycast_hit_color;
				ray_count = 0;
			}

			//on first instance raycast hits an object 
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
