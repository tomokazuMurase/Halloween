using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleCharacter : MonoBehaviour {

	public event Action OnDamaged;

	public int maxhp;

	public int hp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ApplyDamage(int damage)
	{
		this.hp -= damage;
		if (OnDamaged != null) {
			OnDamaged ();
		}
	}
}
