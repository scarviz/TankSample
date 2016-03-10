public class ScoreMng {
	private static ScoreMng instance = null;

	/// <summary>撃墜数</summary>
	public int NumShot
	{
		get; private set;
	}

	private ScoreMng() { }

	/// <summary>
	/// インスタンスを取得する
	/// </summary>
	/// <returns>インスタンス</returns>
	public static ScoreMng GetInstance()
	{
		if (instance == null) instance = new ScoreMng();
		return instance;
	}

	/// <summary>
	/// 撃墜数をカウントアップする
	/// </summary>
	/// <param name="countUpNum">カウントアップ値(デフォルトは1)</param>
	public void CountUpNumShot(int countUpNum = 1)
	{
		NumShot += countUpNum;
	}

	/// <summary>
	/// 撃墜数をリセットする
	/// </summary>
	public void ResetNumShot()
	{
		NumShot = 0;
	}
}
