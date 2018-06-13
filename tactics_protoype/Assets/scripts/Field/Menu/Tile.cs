using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
	public bool walkable = true;
	public bool current = false;
	public bool target = false;
	public bool selectable = false;

	//BFS
	public bool visited = false;
	public Tile parent = null;
	public int distance = 0;

	public List<Tile> adj_list = new List<Tile> ();

	Color orig_color;
	// Update is called once per frame
	void Update () {
		if (current) {
			GetComponent<Renderer> ().material.color = Color.yellow;
		} else if (target) {
			GetComponent<Renderer> ().material.color = Color.magenta;
		} else if (selectable) {
			GetComponent<Renderer> ().material.color = Color.blue;
		} 
	}

	void Reset(){
		adj_list.Clear ();

		current = false;
		target = false;
		selectable = false;

		visited = false;
		parent = null;
		distance = 0;
	}

	public void FindNeighbors(float jump){
		Reset ();

		CheckTile (Vector3.right, jump);
		CheckTile (Vector3.left, jump);
		CheckTile (Vector3.forward, jump);
		CheckTile (Vector3.back, jump);

	}

	//check tile to add to adjacency list
	void CheckTile(Vector3 direction, float jump){

		Vector3 half_extents = new Vector3 (.25f, (1 + jump)/2.0f, .25f);
		Collider[] cols = Physics.OverlapBox (transform.position + direction, half_extents);

		foreach (Collider c in cols) {
			Tile tile = c.GetComponent<Tile> ();
			if (tile != null/* && tile.walkable*/) {
				RaycastHit hit;

				//if there is something on the tile
				if(!Physics.Raycast (tile.transform.position, Vector3.up, out hit, 1)){
					adj_list.Add (tile);
				}

			}
		}
	}
}
