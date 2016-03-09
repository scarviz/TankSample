using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour {
	/// <summary>移動する速さ</summary>
	public float speed = 10f;
	
	private CharacterController mCharCtrl;

	// Use this for initialization
	void Start () {
		// Tank(このスクリプトが設定されているGameObject)に追加したCharacterControllerをここで取得する
		mCharCtrl = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		// 移動する方向(x軸方向へ前進後進)
		// ※ Verticalはキー入力の上下
		var moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, 0);

		// Tankの現在の座標に移動する方向を追加する
		// ※ transformはこのスクリプトが設定されているGameObjectの方向や座標情報などを持っている
		moveDirection = transform.TransformDirection(moveDirection);

		// 移動する速さ(移動量)を加味する
		moveDirection *= speed;

		// このUpdate処理(1フレーム当たり)の移動量からTankを移動させる
		// ※ Time.deltaTimeは前回Updateが呼ばれた時からの経過時間が格納される
		//    フレーム落ちなどでスキップされた分を考慮して移動量を算出する必要があるため
		mCharCtrl.Move(moveDirection * Time.deltaTime);

		// 回転(y軸中心に回転)
		// ※ Horizontalはキー入力の左右
		transform.Rotate(0, Input.GetAxis("Horizontal") * speed, 0);
	}
}
