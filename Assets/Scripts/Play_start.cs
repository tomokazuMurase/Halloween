using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_start : MonoBehaviour {

	public void Play_start_before()
	{
		gameObject.GetComponent<Animation> ().Play ("Play_start");
	}

	public void Play_start_SetActive()
	{
		gameObject.SetActive (false);
	}

	public void Play_end_before()
	{
		gameObject.SetActive (true);
		gameObject.GetComponent<Animation> ().Play ("Play_end");
	}

	public void Play_end_SetActive()
	{
		Debug.Log ("hoge");
	}

}
