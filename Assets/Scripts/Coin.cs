using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// 衝突時イベント
	/// </summary>
	/// <param name="collision">衝突対象</param>
	void OnCollisionEnter(Collision collision)
	{
		// 衝突時に消滅
		Destroy(gameObject);

		// 撃墜数をカウントアップする
		ScoreMng.GetInstance().CountUpNumShot();
	}
}
