using UnityEngine;
using System.Collections;

public class TankShot : MonoBehaviour
{
	/// <summary>砲弾</summary>
	public GameObject bullet;

	/// <summary>砲塔</summary>
	public GameObject cylinder;

	/// <summary>発射間隔</summary>
	public float shotInterval = 1.5f;

	/// <summary>発射間隔の積み上げ値</summary>
	private float stackShotInterval = 1.5f;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		stackShotInterval += Time.deltaTime;

		if (Input.GetButton("Fire1") && EnableShot())
		{
			// 砲弾を生成する(このスクリプトが設定されているGameObjectの位置と向きを合わせる)
			Instantiate(bullet, cylinder.transform.position, transform.rotation);

			stackShotInterval = 0f;
		}
	}

	/// <summary>
	/// 発射可能かどうか
	/// </summary>
	/// <returns>可否</returns>
	private bool EnableShot()
	{
		return shotInterval <= stackShotInterval;
	}
}
