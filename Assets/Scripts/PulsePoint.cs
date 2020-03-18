using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsePoint : MonoBehaviour
{
    
    GameObject enemy01;
    GameObject enemy02;
    GameObject enemy03;
    Rigidbody2D enemy01rb;
    Rigidbody2D enemy02rb;
    Rigidbody2D enemy03rb;
    Enemy01 enemy01s;
    Enemy02 enemy02s;
    Enemy03 enemy03s;
    Animator enemy01anim;
    Animator enemy02anim;
    Animator enemy03anim;
    

   

    
    

    // Start is called before the first frame update
    void Start()
    {
        
        enemy01 = GameObject.FindWithTag("Enemy01");
        enemy02 = GameObject.FindWithTag("Enemy02");
        enemy03 = GameObject.FindWithTag("Enemy03");
        enemy01rb = enemy01.GetComponent<Rigidbody2D>();
        enemy02rb = enemy02.GetComponent<Rigidbody2D>();
        enemy03rb = enemy03.GetComponent<Rigidbody2D>();
        enemy01s = enemy01.GetComponent<Enemy01>();
        enemy02s = enemy02.GetComponent<Enemy02>();
        enemy03s = enemy03.GetComponent<Enemy03>();
        enemy01anim = enemy01.GetComponent<Animator>();
        enemy02anim = enemy02.GetComponent<Animator>();
        enemy03anim = enemy03.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy01" )
        {
            enemy01rb.velocity = Vector2.zero;
            Debug.Log("敵がパルスに当たる");
            enemy01anim.SetBool("enemypulse",true);
            enemy01s.isPulse = true;
        }

        if (collider.gameObject.tag == "Enemy02")
        {
            enemy02rb.velocity = Vector2.zero;
            enemy02rb.isKinematic = false;
            Debug.Log("敵02がパルスに当たる");
            enemy02anim.SetBool("enemypulse", true);
            enemy02s.isPulse = true;
            enemy02s.isShotStop = true;
        }
            if (collider.gameObject.tag == "Enemy03")
            {
                enemy03rb.velocity = Vector2.zero;
                Debug.Log("敵がパルスに当たる");
                enemy03anim.SetBool("enemypulse", true);
                enemy03s.isPulse = true;
            }


        

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy01")
        {
            Invoke("Pulse01", 3f); //3秒後に敵が動き出す
        }

        if (collider.gameObject.tag == "Enemy02")
        {
            Invoke("Pulse02", 3f); //3秒後に敵が動き出す
        }

        if(collider.gameObject.tag == "Enemy03")
        {
            Invoke("Pulse03", 3f); //3秒後に敵が動き出す
        }
    }

   
        void Pulse01()　//パルスメソッド
    {
        enemy01s.isPulse = false;
        enemy01anim.SetBool("enemypulse", false);

        

    }

        void Pulse02() //パルスメソッド
        {
            enemy02s.isPulse = false;
            enemy02anim.SetBool("enemypulse", false);

        }

       void Pulse03()
    {
        enemy03s.isPulse = false;
        enemy03anim.SetBool("enemypulse", false);
    }


    }
