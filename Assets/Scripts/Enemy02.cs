using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    //[Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    public bool isPulse = false; //パルスフラグ
    public GameObject bulletPrefab; // 弾のプレハブ
    public bool isShotStop = false;
    
    
    
    

    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    private Animator anim = null;
    private float bullettime; // 経過時間(秒)
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

     void Update()
    {
       if(isShotStop == false)
       
            BulletShot();

       


    }

    void BulletShot()
    {
        
       
        bullettime += Time.deltaTime;  //経過時間をカウント

        //1秒ごとに弾を発射
        if (bullettime > 1.5f) //経過時間が一秒より大きければ
        {
            bullettime -= 1.5f; //経過時間をリセット

            GameObject obj;
            obj = Instantiate(bulletPrefab); //弾プレハブのインスタンスを生成し、変数objに格納
            
            obj.transform.position = transform.position; //弾インスタンスの座標に敵の座標をセット

            
        }
        
    }

    void FixedUpdate()
    {
        if (sr.isVisible || nonVisibleAct )
        {
            if (checkCollision.isOn)
            {
                rightTleftF = !rightTleftF;
            }

            int xVector = -1;
            if (rightTleftF)
            {
                xVector = 1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            if (isPulse == false)
            {
                rb.velocity = new Vector2(xVector * speed, 0);
                anim.SetBool("walk", true);
            }

            else
            {
                anim.SetBool("walk", false);
            }

           

            
        }
       
    }
}