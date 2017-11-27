using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private GameObject gameDirector;
	bool lifeCheck = true;

	void Start()
	{
		gameDirector = GameObject.Find ("GameDirector");
	}

	void Update ()
	{
		if(lifeCheck == true)
		{
			transform.localScale += new Vector3 (0.1f, 0.1f, 0);

			if (transform.localScale.x > 5.0f) {
				Destroy (gameObject);
				gameDirector.GetComponent<GameDirector> ().Hp_decrease ();
			}
		}
	}

	public void EnemyDeadBefore(GameObject obj)
	{
		lifeCheck = false;
		obj.GetComponent<BoxCollider2D> ().enabled = false;
		obj.GetComponent<Animation> ().Play ("EnemyDeadAnimation");
	}

	public void EnemyDead()
	{
		Destroy (gameObject);
	}

}
