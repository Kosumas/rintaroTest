using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    //[Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    public bool isPulse = false; //パルスフラグ
  
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    private Animator anim = null;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
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