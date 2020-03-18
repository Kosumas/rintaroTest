using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorA : MonoBehaviour
{
   //当該オブジェクト発のイベント
    public string[] scenarios;
     //プレイヤーが一定範囲内に入ったらサインを表すオブジェクト
    public GameObject keysymbol;
     //プレイヤーが範囲内にいるかどうかの判定
    bool playerflag = false;

    public EventScript EventScript;



    void Start () {
        keysymbol.SetActive (false);
    }


    void Update () {
    }

    void OnTriggerEnter2D(Collider2D other){
//もしplayerタグをつけたゲームオブジェクトがCollider判定範囲に入ったら
        if (other.gameObject.tag == "Player") {
            playerflag = true;
            Debug.Log("接触");
//EventScriptのStartEventメソッドにイベント実行可能な状態であることを示すフラグと、内容を送る。
            EventScript.StartEvent (playerflag, scenarios);

//頭上にオブジェクトを表示(座標は自由に変えてください)
            keysymbol.transform.position = gameObject.transform.position + new Vector3 (-0.5f, 1f, 0);
            keysymbol.SetActive (true);
        }
    }


    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag==　"Player"　){
//プレイヤーが範囲外に出たらイベント通知しない。 
            playerflag = false;
            keysymbol.SetActive (false);
            }
    }

}
