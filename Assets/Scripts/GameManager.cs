using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Text;

public class GameManager : MonoBehaviour {
	/// <summary>制限時間(秒)</summary>
	public int limitTimeSec = 60;

	/// <summary>情報表示用テキスト</summary>
	public Text infoText;

	/// <summary>カウントダウンタイマー</summary>
	private CountDownTimer cntDown = null;

	/// <summary>スコア管理</summary>
	private ScoreMng scoreMng = null;

	/// <summary>時間表示用フォーマット</summary>
	private const string FMT_TIME = "{0:D2}:{1:D2}";

	/// <summary>撃墜数用フォーマット</summary>
	private const string FMT_NUM_SHOT = "撃墜数:{0:D2}";

	// Use this for initialization
	void Start () {
		cntDown = CountDownTimer.GetInstance();
		cntDown.StartCountDown(limitTimeSec);

		scoreMng = ScoreMng.GetInstance();
		scoreMng.ResetNumShot();
	}
	
	// Update is called once per frame
	void Update () {
		var remainTimeSec = cntDown.GetRemainingTimeSec();
		var min = remainTimeSec / 60;
		var sec = remainTimeSec % 60;

		var sb = new StringBuilder();
		sb.AppendLine(String.Format(FMT_TIME, min, sec));
		sb.Append(String.Format(FMT_NUM_SHOT, scoreMng.NumShot));
		infoText.text = sb.ToString();
	}
}
