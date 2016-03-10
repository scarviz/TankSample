using System.Diagnostics;

public class CountDownTimer
{
	private static CountDownTimer instance = null;

	private Stopwatch sw = new Stopwatch();

	/// <summary>制限時間(秒)</summary>
	private int limitTimeSec = 0;

	private CountDownTimer() { }

	/// <summary>
	/// インスタンスを取得する
	/// </summary>
	/// <returns>インスタンス</returns>
	public static CountDownTimer GetInstance()
	{
		if (instance == null) instance = new CountDownTimer();
		return instance;
	}

	/// <summary>
	/// カウントダウンを開始する
	/// </summary>
	/// <param name="limitTimeSec">制限時間(秒)</param>
	public void StartCountDown(int limitTimeSec)
	{
		this.limitTimeSec = limitTimeSec;

		sw.Reset();
		sw.Start();
	}

	/// <summary>
	/// 残り時間(秒)を取得する
	/// </summary>
	/// <returns>残り時間(秒)</returns>
	public int GetRemainingTimeSec()
	{
		var remainingTime = 0;

		// 経過時間の取得(秒)
		var totalSec = (int)sw.Elapsed.TotalSeconds;
		// 残り時間
		remainingTime = limitTimeSec - totalSec;

		if (limitTimeSec <= totalSec)
		{
			sw.Stop();
			remainingTime = 0;
		}

		return remainingTime;
	}
}
