using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class ButtonScore : MonoBehaviour {

	public Text text_Score;
	public Text text_inputField;
	public GameObject gameDirector;
	public GameObject inputFiled;
	public Text text_caution;

	//データ保存　
	public void SaveScore()
	{
		string score = text_Score.text;
		string name = text_inputField.text;

		int scoreInt = int.Parse (score);

		if (name.Length == 0) {
			text_caution.text = "1文字以上は入力してください";
		} else if (name.Length >= 21) {
			text_caution.text = "21文字以下で入力してください";
		} else {

			NCMBObject obj = new NCMBObject ("Helloween");

			obj["Name"] = name;
			obj ["Score"] = scoreInt;
			obj.SaveAsync ();
			gameObject.SetActive (false);
			inputFiled.SetActive (false);
			Invoke ("DelayMethod", 2.0f);

		}
	}

	void DelayMethod()
	{
		gameDirector.GetComponent<GameDirector>().ScoreGet ();

	}
}
