using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class GameDirector : MonoBehaviour {

	float playTime = 0;
	float span = 1.0f;
	float delta = 0;
	int point = 0;
	int hp = 5;
	int stargeCheck = 0;
	bool gameStartCheck = false;

	public GameObject enemyPrefab_pumpkin;
	public GameObject enemyPrefab_mummy;
	public GameObject enenyPrefab_ghost;
	public GameObject enenyPrefab_wolf;
	public GameObject enenyPrefab_reaper;
	public GameObject enenyPrefab_vampire;
	public GameObject text_play_time;
	public GameObject text_point;
	public GameObject text_point_start;
	public GameObject ranking_object;
	public GameObject text_hp;
	public GameObject[] enemyTags;
	public GameObject startObject;
	public GameObject damage;
	public GameObject infoStart;
	public GameObject text_starge;
	public Text[] text_rank_name;
	public Text[] text_rank_score;
	public GameObject button_score;
	public GameObject inputFiled;
	public Text text_caution;
	public GameObject fx_point;
	public GameObject[] hpObj;

	void Start()
	{
		startObject.SetActive (true);
		infoStart.SetActive (false);
		ranking_object.SetActive (false);
	}

	void Update ()
	{
		//オブジェクトクリック判定
		GameObject obj = getClickObject ();
		if (obj != null)
		{
			obj.GetComponent<EnemyController_animatior>().EnemyDeadBefore(obj);
			point++;
			text_point.GetComponent<Text>().text = point.ToString();
			fx_point.GetComponent<Animation> ().Play ("FX_point");
			text_point.GetComponent<Animation> ().Play ("Text_point_up");

		}

		//プレイ時間
		this.playTime += Time.deltaTime;

		//Enemy発生間隔
		this.delta += Time.deltaTime;

		if(playTime < 10)
		{
			EnemyInstance (2.0f, enemyPrefab_pumpkin);
			if(stargeCheck == 0)
			{
				text_starge.GetComponent<Text> ().text = "Starge 1 パンプキンの嵐";
				infoStart.GetComponent<Animation> ().Play ("Info_starge");
				stargeCheck = 1;
			}
		}
		else if(playTime > 10 && playTime <= 20)
		{
			EnemyInstance (1.5f, enenyPrefab_ghost);
			if(stargeCheck == 1)
			{
				text_starge.GetComponent<Text> ().text = "Starge 2 ゴーストの嵐";
				infoStart.GetComponent<Animation> ().Play ("Info_starge");
				stargeCheck = 2;
			}
		}
		else if(playTime > 20 && playTime <= 30)
		{
			EnemyInstance (1.0f, enemyPrefab_mummy);
			if(stargeCheck == 2)
			{
				text_starge.GetComponent<Text> ().text = "Starge 3 ミイラの嵐";
				infoStart.GetComponent<Animation> ().Play ("Info_starge");
				stargeCheck = 3;
			}
		}
		else if(playTime > 30 && playTime <= 40)
		{
			EnemyInstance (0.75f, enenyPrefab_wolf);
			if(stargeCheck == 3)
			{
				text_starge.GetComponent<Text> ().text = "Starge 4 狼の嵐";
				infoStart.GetComponent<Animation> ().Play ("Info_starge");
				stargeCheck = 4;
			}
		}
		else if(playTime > 40 && playTime <= 50)
		{
			EnemyInstance (0.5f, enenyPrefab_reaper);
			if(stargeCheck == 4)
			{
				text_starge.GetComponent<Text> ().text = "Starge 5 死神の嵐";
				infoStart.GetComponent<Animation> ().Play ("Info_starge");
				stargeCheck = 5;
			}
		}
		else if(playTime > 50)
		{
			EnemyInstance (0.25f, enenyPrefab_vampire);
			if(stargeCheck == 5)
			{
				text_starge.GetComponent<Text> ().text = "Starge 6 ドラキュラの嵐";
				infoStart.GetComponent<Animation> ().Play ("Info_starge");
				stargeCheck = 6;
			}
		}

		//時間制御
		text_play_time.GetComponent<Text> ().text = playTime.ToString();

	}

	//ゲームスタート処理
	public void OnClick()
	{
		//プレイ時間リセット
		enemyTags = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach(GameObject enemyTag in enemyTags)
		{
			Destroy (enemyTag);
		}
		playTime = 0;
		hp = 5;
		point = 0;
		text_hp.GetComponent<Text> ().text = hp.ToString ();
		text_point.GetComponent<Text> ().text = point.ToString ();
		startObject.GetComponent<Play_start>().Play_start_before();
		infoStart.SetActive (true);
		gameStartCheck = true;

		for(int i = 0; i <= 4; i++)
		{
			hpObj [i].SetActive (true);
		}
	}
		
	//オブジェクトクリック処理
	private GameObject getClickObject()
	{
		GameObject result = null;

		if(Input.GetMouseButtonDown(0)){
			Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
		
			if(collition2d)
			{
				result = collition2d.transform.gameObject;
			}
		}
		return result;
	}

	//Enemy作成
	public void EnemyInstance(float spanTime, GameObject enemyPrefab)
	{
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

	//HP制御
	public void Hp_decrease()
	{
		if(hp > 0)
		{
			hp--;
			text_hp.GetComponent<Text> ().text = hp.ToString ();
			damage.GetComponent<Animation> ().Play ("Damage");
			text_point.GetComponent<Animation>().Play("Text_point_damage");
			text_hp.GetComponent<Animation>().Play("Text_hp_damage");

			if (hp == 1) { hpObj [1].SetActive (false); }
			else if (hp == 2) { hpObj [2].SetActive (false); }
			else if (hp == 3) { hpObj [3].SetActive (false); }
			else if (hp == 4) { hpObj [4].SetActive (false); }
			else if (hp == 0) { hpObj [0].SetActive (false); }
		}
		else if(hp == 0)
		{
			hp--;
			if(gameStartCheck == true)
			{
				ranking_object.SetActive (true);
				ScoreGet ();
				text_point_start.GetComponent<Text>().text = point.ToString();
				startObject.GetComponent<Play_start>().Play_end_before();
				gameStartCheck = false;
				infoStart.SetActive (false);
				button_score.SetActive (true);
				inputFiled.SetActive (true);
				text_caution.text = " ";
				stargeCheck = 0;
				hpObj [0].SetActive (false); 
			}
		}
	}

	public void ScoreGet()
	{
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("Helloween");

		query.OrderByDescending ("Score");

		//Scoreフィールドの降順でデータを取得
		query.Limit = 5;


		//データストアでの検索を行う
		query.FindAsync ((List<NCMBObject> objList, NCMBException e) => {
			if(e != null)
			{
				//検索失敗時の処理
			}
			else
			{
				//検索成功時の処理

				//名前のリスト
				List<string> nameList = new List<string>();

				//スコアのリスト
				List<int> scoreList = new List<int>();

				for(int i = 0; i < objList.Count; i++)
				{
					string s = System.Convert.ToString(objList[i]["Name"]);
					int n = System.Convert.ToInt32(objList[i]["Score"]);
					nameList.Add(s);
					text_rank_name[i].text = s.ToString(); 
					scoreList.Add(n);
					text_rank_score[i].text = n.ToString();

				}

			}

		});
	}
}
