using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {
	InputField inputField;

	void Start () {
		inputField = GetComponent<InputField> ();
		InitInputField ();
	}

	public void InputLogger()
	{
		string inputValue = inputField.text;
	}

	void InitInputField()
	{
		//値をリセット
		inputField.text = "";

		//フォーカス
		inputField.ActivateInputField();
	}

}
