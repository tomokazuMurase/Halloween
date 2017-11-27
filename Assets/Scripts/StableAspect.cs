using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableAspect : MonoBehaviour {

	private Camera cam;
	private float height = 1280f;
	private float width = 720f;

	private float prixelPerUnit = 100f;

	void Awake(){
		float aspect = (float)Screen.height / (float)Screen.width;
		float bgAcpect = height / width;

		cam = GetComponent<Camera> ();
		cam.orthographicSize = (height / 2f / prixelPerUnit);

		if (bgAcpect > aspect) {
			float bgScale = height / Screen.height;
			float camWidth = width / (Screen.width * bgScale);
		} else {
			float bgScale = width / Screen.width;
			float camHeight = height / (Screen.height * bgScale);
			cam.rect = new Rect (0f,(1f - camHeight) / 2f,1f,camHeight);
		}
	}
		
}
