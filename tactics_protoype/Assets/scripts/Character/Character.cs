using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character {
	public GameObject character;

	private int hp;
	private int mp;

	private float strength;
	private float magic;

	private float mdef;
	private float def;

	private int move;
	private int jump;

	private int speed;

	public Character(){
		this.hp = 10;
		this.mp = 0;
		this.strength = 1;
		this.magic = 1;
		this.mdef = 1;
		this.def = 1;
		this.move = 1;
		this.jump = 1;
		this.speed = 1;
	}


}
