using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocialConnector;

public class SnsShare : MonoBehaviour {
	public void Share() {
		StartCoroutine(ShareScreenShot());
	}

	IEnumerator ShareScreenShot() {
		//スクリーンショット画像の保存先を設定。ファイル名が重複しないように実行時間を付与
		string fileName = String.Format("sns.png");
		string imagePath = Application.persistentDataPath + "/" + fileName;

		//スクリーンショットを撮影
		ScreenCapture.CaptureScreenshot(fileName);
		yield return new WaitForEndOfFrame();

		// Shareするメッセージを設定
		string text ="ツイート内容\n#hashtag ";
		string URL = "url";
		yield return new WaitForSeconds(1);

		//Shareする
		//SocialConnector.SocialConnector.Share(text, URL, imagePath);
	}
}
