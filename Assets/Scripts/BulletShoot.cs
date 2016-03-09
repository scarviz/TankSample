using UnityEngine;
using System.Collections;

public class BulletShoot : MonoBehaviour {
	/// <summary>発射速度</summary>
	public float speed = 100f;

	// Use this for initialization
	void Start ()
	{
		// 1.5秒後に自動消滅
		Destroy(gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		// 前方に進める
		// ※ x軸が前方なのでrightを使用している。z軸方向はforward、y軸方向はupになる。
		transform.position += transform.right * Time.deltaTime * speed;
	}

	/// <summary>
	/// 衝突時イベント
	/// </summary>
	/// <param name="collision">衝突対象</param>
	void OnCollisionEnter(Collision collision)
	{
		// 衝突時に消滅
		Destroy(gameObject);
	}
}
