using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class TestManager : MonoBehaviour {

	[SerializeField]
	Slider hpBar;

	[SerializeField]
	BattleCharacter myCharacter;

	// Use this for initialization
	void Start () {
		myCharacter.OnDamaged += () => {
			hpBar.value = (float)myCharacter.hp / (float)myCharacter.maxhp;
		};

		int[] array = new int[]{ 312, 124455, 3123, -3123, 31, 986, -300 };

		//int[] upperZeroArray = array.Where ((i) => { return 0 < i; }).ToArray ();
		//int[] upperZeroArray = array.Where (i => 0 < i).ToArray ();

		StartCoroutine (GameLoop ());
	}

	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator GameLoop()
	{
		yield return null;


	}
}
