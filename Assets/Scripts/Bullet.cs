using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	// 変数宣言
	public float bulletspeed = 3.0f; // スピード
	public float time = 0.0f;  // 経過時間
	public float angle;     // 角度
	public float limitTime; // 生存時間(秒)



	void Start()
	{
	}

	
	void Update()
	{


		// -----移動処理-----

		float rad;      // 角度(Radian)←計算に使用する
		Vector2 vec;    // 移動量ベクトル(x方向, y方向)
		float move_x, move_y;   // x方向、y方向それぞれの移動量格納用

		rad = angle * Mathf.Deg2Rad;

		move_x = Mathf.Cos(rad) * bulletspeed * Time.deltaTime; // x方向の移動量
		move_y = Mathf.Sin(rad) * bulletspeed * Time.deltaTime; // y方向の移動量
		vec = new Vector2(move_x, move_y); // 変数vecを初期化しつつ、xとyの移動量をセット


		transform.Translate(vec); // 変数vec分だけ自オブジェクトを移動


		// -----寿命処理-----
		// 前回のUpdate実行から経過した時間をtimeに加算
		time += Time.deltaTime;
		// 消滅処理
		if (time > 5.0f)
		{ // 弾の経過時間が５秒より大きければ
			Destroy(gameObject);
		}

	}

	 
}
