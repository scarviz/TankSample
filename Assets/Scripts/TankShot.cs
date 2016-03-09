using UnityEngine;
using System.Collections;

public class TankShot : MonoBehaviour {
	/// <summary>砲弾</summary>
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
		{
			// 砲弾を生成する(このスクリプトが設定されているGameObjectの位置と向きを合わせる)
			Instantiate(bullet, transform.position, transform.rotation);
		}
	}
}
