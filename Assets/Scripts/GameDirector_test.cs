using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class GameDirector_test : MonoBehaviour {

	public GameObject text_name;
	public GameObject text_point;

	public void Registration()
	{
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");

		//Scoreフィールドの降順でデータを取得
		query.OrderByDescending("Score");

		//検索件数を5けんに設定
		query.Limit = 5;

		//データストアでのけん
	}

}
