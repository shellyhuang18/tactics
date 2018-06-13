using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chara = Character;

public class Move : MonoBehaviour {
	private int move_range;
	private float jump;
	private List<Tile> selectable_tiles = new List<Tile> ();
	private GameObject[] tiles;

	private Tile curr_tile = null;
	Stack<Tile> path = new Stack<Tile> ();

	// Use this for initialization
	void Start () {
		tiles = GameObject.FindGameObjectsWithTag ("tile");
		move_range = GetComponent<Character> ().getMove ();
		jump = GetComponent<Character> ().getJump ();
		//move_range = 2;
		//jump = 2;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void GetCurrentTile(){
		curr_tile = GetTargetTile (gameObject);
		curr_tile.current = true;
	}

	Tile GetTargetTile(GameObject target){
		Tile tile = null;
		RaycastHit hit;

		if(Physics.Raycast (target.transform.position, Vector3.down, out hit, 1)){
			tile = hit.collider.GetComponent<Tile> ();
		}

		return tile;

	}

	void CalculateAdjLists(){
		Debug.Log ("is tiles empty?: " + tiles.Length);

		foreach (GameObject t in tiles) {
			Tile tile = t.GetComponent<Tile> ();
			tile.FindNeighbors (jump);
		}
	}

	public void DisplayMoveRange(){
		Debug.Log ("func called");
		CalculateAdjLists ();
		GetCurrentTile ();

		Queue<Tile> process = new Queue<Tile> ();

		process.Enqueue (curr_tile);
		curr_tile.visited = true;

		while (process.Count > 0) {
			Tile t = process.Dequeue ();

			selectable_tiles.Add (t);
			t.selectable = true;

			if (t.distance < move_range) {

				foreach (Tile ti in t.adj_list) {
					Debug.Log ("is adj list empty?: " + t.adj_list.Count);
					if (!ti.visited) {
						ti.parent = t;
						ti.visited = true;
						ti.distance = 1 + t.distance;
						process.Enqueue (ti);
					}
				}
			}
		}

	}

}
	