using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinMng : MonoBehaviour {
	/// <summary>生成数</summary>
	public int generateNum = 3;

	/// <summary>コイン</summary>
	public GameObject coin;

	/// <summary>コインを格納するリスト</summary>
	private List<Object> coinList = new List<Object>();

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update()
	{
		// 撃墜されたものは取り除く
		coinList.RemoveAll(coin => coin == null);

		// 生成数分コインを生成する
		while (coinList.Count < generateNum)
		{
			coinList.Add(GenerateCoin());
		}
	}

	/// <summary>
	/// コインを生成する
	/// </summary>
	private Object GenerateCoin()
	{
		// x軸：-12～12、y軸：1、z軸：-12～12の範囲の位置にコインを生成する
		// ※ Quaternion.identityは、回転なしの状態(すべての角度が0)
		return Instantiate(coin
			, new Vector3(Random.Range(-12f, 12f), 1, Random.Range(-12f, 12f))
			, Quaternion.identity);
	}
}
