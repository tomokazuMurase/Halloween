using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public Text[] text_name;
	public Text[] text_score;

	void Start()
	{
		ScoreGet ();
	}

	public void ScoreGet()
	{
		Debug.Log ("scoreGet");
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("Helloween");

		query.OrderByDescending ("Score");

		//Scoreフィールドの降順でデータを取得
		query.Limit = 5;


		//データストアでの検索を行う
		query.FindAsync ((List<NCMBObject> objList, NCMBException e) => {
			if(e != null)
			{
				//検索失敗時の処理
				Debug.Log("失敗");
			}
			else
			{
				//検索成功時の処理
				Debug.Log("成功");

				//名前のリスト
				List<string> nameList = new List<string>();

				//スコアのリスト
				List<int> scoreList = new List<int>();

				for(int i = 0; i < objList.Count; i++)
				{
					string s = System.Convert.ToString(objList[i]["Name"]);
					int n = System.Convert.ToInt32(objList[i]["Score"]);
					nameList.Add(s);
					text_name[i].text = s.ToString(); 
					scoreList.Add(n);
					text_score[i].text = n.ToString();

				}

			}

		});
	}

}
