using UnityEngine;
using System.Collections;

public class TankShot : MonoBehaviour
{
	/// <summary>砲弾</summary>
	public GameObject bullet;

	/// <summary>砲塔</summary>
	private GameObject cylinder;

	// Use this for initialization
	void Start()
	{
		cylinder = gameObject.transform.FindChild("GunTurret/Cylinder").gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButton("Fire1"))
		{
			// 砲弾を生成する(このスクリプトが設定されているGameObjectの位置と向きを合わせる)
			Instantiate(bullet, cylinder.transform.position, transform.rotation);
		}
	}
}
