
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionCheck : MonoBehaviour
{
    /// <summary>
    /// 判定内に敵か壁がある
    /// </summary>
    [HideInInspector] public bool isOn = false;

    private string wallTag = "Wall";
    private string enemyTag = "Enemy";


    #region//接触判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == wallTag || collision.tag == enemyTag)
        {
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == wallTag || collision.tag == enemyTag)
        {
            isOn = false;
        }
    }
    #endregion
}