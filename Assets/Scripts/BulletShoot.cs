using UnityEngine;
using System.Collections;

public class BulletShoot : MonoBehaviour {
	/// <summary>発射速度</summary>
	public float speed = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// 前方に進める
		// ※ x軸が前方なのでrightを使用している。z軸方向はforward、y軸方向はupになる。
		transform.position += transform.right * Time.deltaTime * speed;
	}
}
