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

	/// <summary>時間切れ用テキスト</summary>
	public Text timeOverText;

	/// <summary>カウントダウンタイマー</summary>
	private CountDownTimer cntDown = null;

	/// <summary>スコア管理</summary>
	private ScoreMng scoreMng = null;

	/// <summary>時間表示用フォーマット</summary>
	private const string FMT_TIME = "{0:D2}:{1:D2}";

	/// <summary>撃墜数用フォーマット</summary>
	private const string FMT_NUM_SHOT = "撃墜数:{0:D2}";

	/// <summary>Time Over</summary>
	private const string TIME_OVER = "Time Over";

	/// <summary>プレイ中かどうか</summary>
	private bool playing = false;

	// Use this for initialization
	void Start () {
		cntDown = CountDownTimer.GetInstance();
		scoreMng = ScoreMng.GetInstance();

		// 初期化処理
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		// プレイ中でない場合
		if (!playing)
		{
			// TimeOverが表示されていなければ、表示する
			if (!timeOverText.enabled)
			{
				SetTimeOverText();
				timeOverText.enabled = true;
			}

			// リターンキー入力で再スタート
			if (Input.GetButton("Submit")) Init();

			return;
		}

		var remainTimeSec = cntDown.GetRemainingTimeSec();
		if (remainTimeSec <= 0)
		{
			playing = false;
		}

		var min = remainTimeSec / 60;
		var sec = remainTimeSec % 60;

		var sb = new StringBuilder();
		sb.AppendLine(String.Format(FMT_TIME, min, sec));
		sb.Append(String.Format(FMT_NUM_SHOT, scoreMng.NumShot));
		infoText.text = sb.ToString();
	}

	/// <summary>
	/// 初期化処理
	/// </summary>
	private void Init()
	{
		// タイマー開始
		cntDown.StartCountDown(limitTimeSec);

		// スコアクリア
		scoreMng.ResetNumShot();

		// プレイ中にする
		playing = true;

		// TimeOverテキストを非表示にする
		timeOverText.enabled = false;
	}

	/// <summary>
	/// TimeOverテキストを設定する
	/// </summary>
	private void SetTimeOverText()
	{
		var sb = new StringBuilder();
		sb.AppendLine(TIME_OVER);
		sb.Append(String.Format(FMT_NUM_SHOT, scoreMng.NumShot));
		timeOverText.text = sb.ToString();
	}
}
