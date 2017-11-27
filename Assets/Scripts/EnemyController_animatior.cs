using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_animatior : MonoBehaviour {

	Animator anim;
	private GameObject gameDirector;
	bool lifeCheck = true;

	void Start()
	{
		gameDirector = GameObject.Find ("GameDirector");
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		if(lifeCheck == true)
		{
			transform.localScale += new Vector3 (0.075f, 0.075f, 0);

			if (transform.localScale.x > 3.0f) {
				Destroy (gameObject);
				gameDirector.GetComponent<GameDirector> ().Hp_decrease ();
			}
		}
	}

	public void EnemyDeadBefore(GameObject obj)
	{
		lifeCheck = false;
		obj.GetComponent<BoxCollider2D> ().enabled = false;
		anim.SetTrigger ("Dead");
	}

	public void EnemyDead()
	{
		Destroy (gameObject);
	}



}
