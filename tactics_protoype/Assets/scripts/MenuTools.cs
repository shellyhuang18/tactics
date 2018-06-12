using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuTools{
	[MenuItem("Tools/Assign Tile Material")]
	public static void AssignTileMaterial(){
		GameObject[] tiles = GameObject.FindGameObjectsWithTag ("tile");
		Material mat = Resources.Load<Material> ("Tile");

		foreach (GameObject tile in tiles) {
			tile.GetComponent<Renderer> ().material = mat;
		}
	}

	[MenuItem("Tools/Assign Tile Script")]
	public static void AssignTileScript(){
		GameObject[] tiles = GameObject.FindGameObjectsWithTag ("tile");

		foreach (GameObject tile in tiles) {
			tile.AddComponent<Tile> ();
		}
	}
}
