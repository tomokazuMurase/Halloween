using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour {

	public GameObject enemyPrefab;

	float span = 1.0f;
	float delta = 0;

	public void EnemyInstance(float spanTime){

		span = spanTime;

		if(this.delta > this.span)
		{
			GameObject go = Instantiate (enemyPrefab) as GameObject;
			this.delta = 0;
			int pxX = Random.Range (-7, 7);
			int pxY = Random.Range (-5, 5);
			go.transform.position = new Vector3 (pxX, pxY, -2);
		}
	}

}
